﻿using Dapper;
using Microsoft.SqlServer.Types;
using Nin.Types.MsSql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using Types;

namespace Nin.IO.SqlServer
{
    public class SearchV2
    {
        private readonly string _connectionString;

        public SearchV2(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<INatureAreaGeoJson> GetNatureAreasBySearchFilter(SearchFilterRequest searchFilterRequest)
        {
            int natureAreaCount;
            var natureAreas = GetNatureAreasBySearchFilter(
                searchFilterRequest.AnalyzeSearchFilterRequest(),
                searchFilterRequest.NatureAreaTypeCodes,
                searchFilterRequest.DescriptionVariableCodes,
                searchFilterRequest.Municipalities,
                searchFilterRequest.Counties,
                searchFilterRequest.ConservationAreas,
                searchFilterRequest.Institutions,
                searchFilterRequest.Geometry,
                searchFilterRequest.BoundingBox,
                searchFilterRequest.EpsgCode,
                searchFilterRequest.CenterPoints,
                0,
                0,
                int.MaxValue,
                out natureAreaCount
                );
            return natureAreas;
        }

        public IEnumerable<INatureAreaGeoJson> GetNatureAreasBySearchFilter(
            Collection<NatureLevel> natureLevels,
            Collection<string> natureAreaTypeCodes,
            Collection<string> descriptionVariableCodes,
            Collection<int> municipalities,
            Collection<int> counties,
            Collection<int> conservationAreas,
            Collection<string> institutions,
            string geometry,
            string boundingBox,
            int espgCode,
            bool centerPoints,
            int infoLevel,
            int skip,
            int take,
            out int natureAreaCount)
        {
            IList<INatureAreaGeoJson> natureAreas = new List<INatureAreaGeoJson>();

            var builder = new SqlBuilder();

            string templateStr = "SELECT /**select**/ FROM Naturområde na /**join**/ /**where**/ /**groupby**/";

            if (skip != 0 || take != int.MaxValue)
            {
                templateStr += " OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
                builder.AddParameters(new { Skip = skip, Take = take });
            }

            var template = builder.AddTemplate(templateStr);

            bool groupByKommuner = centerPoints && string.IsNullOrWhiteSpace(boundingBox) && infoLevel == 0;

            if (groupByKommuner)
            {
                builder.Select("o.id AS Id, COUNT(*) AS Count");
                builder.Join("OmrådeLink ol ON na.id = ol.naturområde_id");
                builder.Join("Område o ON o.id = ol.geometri_id AND o.geometriType_id = 1");
                builder.GroupBy("o.id");
            }
            else
            {
                builder.Select("na.id AS Id, na.localId AS LocalId, " + (centerPoints ? "na.geometriSenterpunkt" : "na.geometri") + " AS Geometry");
            }

            FilterOnNatureLevels(natureLevels, builder);

            FilterOnInstitutions(institutions, builder);

            FilterOnNatureAreaTypeCodes(natureAreaTypeCodes, builder);

            FilterOnDescriptionVariables(descriptionVariableCodes, builder);

            FilterOnGeographicalAreas(municipalities, counties, conservationAreas, builder);

            var nonEmptyGeometry = FilterOnGeometry(builder, geometry, boundingBox, espgCode);

            if (!nonEmptyGeometry)
            {
                natureAreaCount = 0;
                return natureAreas;
            }

            string sql = template.RawSql;
            var parameters = template.Parameters;

            if (infoLevel == 0)
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();

                    if (groupByKommuner)
                    {
                        GroupByKommuner(natureAreas, sql, parameters, conn);
                    }
                    else
                    {
                        PopulateNatureAreas(natureAreas, sql, parameters, conn);
                    }
                }

                natureAreaCount = natureAreas.Count();
            }
            else
            {
                natureAreas = GetNatureAreaInfos(builder, template, infoLevel, out natureAreaCount)
                    .Select(n => (INatureAreaGeoJson)n)
                    .ToList();
            }

            return natureAreas;
        }

        private static void PopulateNatureAreas(IList<INatureAreaGeoJson> natureAreas, string sql, object parameters, SqlConnection conn)
        {
            var dtos = conn.Query<NatureAreaDto>(sql, parameters);

            foreach (var dto in dtos)
            {
                var natureArea = new NatureAreaGeoJson
                {
                    Id = dto.Id,
                    UniqueId = new Identification { LocalId = dto.LocalId },
                    Area = dto.Geometry
                };

                natureAreas.Add(natureArea);
            }
        }

        private static void GroupByKommuner(IList<INatureAreaGeoJson> natureAreas, string sql, object parameters, SqlConnection conn)
        {
            var counts = conn.Query<GroupByKommunerDto>(sql, parameters);
            var geometries = conn.Query<GroupByKommunerWithGeometryDto>("SELECT o.id as Id, o.geometri.STCentroid() AS Centerpoint FROM Område o WHERE o.id IN @Ids", new { Ids = counts.Select(c => c.Id).ToArray() });

            foreach (var geom in geometries)
            {
                var natureArea = new NatureAreaGeoJson
                {
                    Id = geom.Id,
                    UniqueId = new Identification { LocalId = Guid.Empty },
                    Area = geom.Centerpoint,
                    Count = counts.Single(c => c.Id == geom.Id).Count
                };

                natureAreas.Add(natureArea);
            }
        }

        private static void FilterOnGeographicalAreas(Collection<int> municipalities, Collection<int> counties, Collection<int> conservationAreas, SqlBuilder builder)
        {
            const string existsInGeoAreaTemplate = "EXISTS (SELECT 1 FROM OmrådeLink al JOIN Område a ON al.geometri_id = a.id WHERE al.naturområde_id = na.id AND a.geometriType_id = {0} AND a.nummer IN {1})";

            if (municipalities != null && municipalities.Count > 0)
            {
                builder.Where(string.Format(existsInGeoAreaTemplate, "@municipalityTypeId", "@municipalities"), new { municipalityTypeId = 1, municipalities = municipalities.ToArray() });
            }

            if (counties != null && counties.Count > 0)
            {
                builder.Where(string.Format(existsInGeoAreaTemplate, "@countyTypeId", "@counties"), new { countyTypeId = 2, counties = counties.ToArray() });
            }

            if (conservationAreas != null && conservationAreas.Count > 0)
            {
                builder.Where(string.Format(existsInGeoAreaTemplate, "@conservationAreaTypeId", "@conservationAreas"), new { conservationAreaTypeId = 3, conservationAreas = conservationAreas.ToArray() });
            }
        }

        private static void FilterOnDescriptionVariables(Collection<string> descriptionVariableCodes, SqlBuilder builder)
        {
            if (descriptionVariableCodes != null && descriptionVariableCodes.Count > 0)
            {
                builder.Join("Beskrivelsesvariabel dv ON na.id = dv.naturområde_id");
                builder.Where("dv.kode IN @dvcodes", new { dvcodes = descriptionVariableCodes.ToArray() });
            }
        }

        private static void FilterOnNatureAreaTypeCodes(Collection<string> natureAreaTypeCodes, SqlBuilder builder)
        {
            if (natureAreaTypeCodes != null && natureAreaTypeCodes.Count > 0)
            {
                builder.Join("NaturområdeType nat ON na.id = nat.naturområde_id");
                builder.Where("nat.kode IN @natcodes", new { natcodes = natureAreaTypeCodes.ToArray() });
            }
        }

        private static void FilterOnInstitutions(Collection<string> institutions, SqlBuilder builder)
        {
            if (institutions != null && institutions.Count > 0)
            {
                builder.Where("na.institusjon IN @institutions", new { institutions = institutions.ToArray() });
            }
        }

        private static void FilterOnNatureLevels(Collection<NatureLevel> natureLevels, SqlBuilder builder)
        {
            if (natureLevels != null && natureLevels.Count > 0)
            {
                var natureLevelIds = natureLevels.Select(nl => (int)nl).ToArray();

                builder.Where("na.naturnivå_id IN @natureLevelIds", new { natureLevelIds = natureLevelIds });
            }
        }

        private List<NatureArea> GetNatureAreaInfos(SqlBuilder builder, SqlBuilder.Template template, int infoLevel, out int natureAreaCount)
        {
            var natureAreas = new List<NatureArea>();

            builder.Select("na.id AS Id, na.localId AS LocalId, na.naturnivå_id AS NaturnivaId, na.kartlagt AS Kartlagt, na.institusjon AS Institusjon" + (infoLevel == 2 ? ", na.kartlegger_id AS KartleggerId" : string.Empty));

            builder.OrderBy("na.id");

            string sql = template.RawSql;

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                var infos = conn.Query<NatureAreaInfoDto>(sql, template.Parameters).ToList();

                foreach (var info in infos)
                {
                    var natureArea = new NatureAreaExport
                    {
                        Id = info.Id,
                        UniqueId = new Identification { LocalId = info.LocalId },
                        Nivå = (NatureLevel)info.NaturnivaId,
                        Surveyed = info.Kartlagt,
                        Institution = info.Institusjon
                    };

                    if (infoLevel == 2 && info.KartleggerId.HasValue)
                    {
                        natureArea.Surveyer = new Contact { Id = info.KartleggerId.Value };
                    }

                    natureAreas.Add(natureArea);
                }
            }

            if (infoLevel == 1)
            {
                natureAreas = SqlServer.SetParameters(sql.Contains("WHERE"), natureAreas).ToList();
            }
            else if (infoLevel == 2)
            {
                SqlServer.SetMetadata(natureAreas);
            }

            natureAreaCount = natureAreas.Count;
            return natureAreas;
        }

        private static bool FilterOnGeometry(SqlBuilder builder, string geometry, string boundingBox, int espgCode)
        {
            if (!string.IsNullOrEmpty(geometry) && !string.IsNullOrEmpty(boundingBox))
            {
                var area = SqlGeometry.STGeomFromText(new SqlChars(geometry), espgCode).MakeValid();
                var bbox = SqlGeometry.STGeomFromText(new SqlChars(boundingBox), espgCode).MakeValid();
                var areaIntersection = area.STIntersection(bbox);

                if (areaIntersection.STIsEmpty())
                {
                    return false;
                }

                FilterOnGeometry(builder, areaIntersection);
            }
            else if (!string.IsNullOrEmpty(boundingBox))
            {
                var bbox = SqlGeometry.STGeomFromText(new SqlChars(boundingBox), espgCode).MakeValid();

                FilterOnGeometry(builder, bbox);
            }
            else if (!string.IsNullOrEmpty(geometry))
            {
                var area = SqlGeometry.STGeomFromText(new SqlChars(geometry), espgCode).MakeValid();

                FilterOnGeometry(builder, area);
            }

            return true;
        }

        private static void FilterOnGeometry(SqlBuilder builder, SqlGeometry sqlGeometry)
        {
            builder.Where("na.geometri.STIntersects(@area) = 1", new { area = sqlGeometry.Serialize().Buffer }); // sqlGeometry.Serialize().Buffer
        }

        private class NatureAreaInfoDto
        {
            public int Id { get; set; }
            public Guid LocalId { get; set; }
            public int NaturnivaId { get; set; }
            public DateTime? Kartlagt { get; set; }
            public string Institusjon { get; set; }
            public int? KartleggerId { get; set; }
        }

        private class NatureAreaDto
        {
            public int Id { get; set; }
            public Guid LocalId { get; set; }
            public SqlGeometry Geometry { get; set; }
        }

        private class GroupByKommunerDto
        {
            public int Id { get; set; }
            public int Count { get; set; }
        }

        private class GroupByKommunerWithGeometryDto : GroupByKommunerDto
        {
            public SqlGeometry Centerpoint { get; set; }
        }
    }
}