﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="https://ws.geonorge.no/SKWS2/services/EiendomBygg", ConfigurationName="EiendomBygg")]
public interface EiendomBygg
{
    
    // CODEGEN: Generating message contract since the wrapper namespace (http://ws.ngisedmws.sk.hosledata.no) of message edmBydSokRequest does not match the default value (https://ws.geonorge.no/SKWS2/services/EiendomBygg)
    [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
    [System.ServiceModel.XmlSerializerFormatAttribute(Style=System.ServiceModel.OperationFormatStyle.Rpc, Use=System.ServiceModel.OperationFormatUse.Encoded)]
    [System.ServiceModel.ServiceKnownTypeAttribute(typeof(BydRecord))]
    edmBydSokResponse edmBydSok(edmBydSokRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="", ReplyAction="*")]
    System.Threading.Tasks.Task<edmBydSokResponse> edmBydSokAsync(edmBydSokRequest request);
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:edm2.ws.statkart.no")]
public partial class EdmBydSokRes
{
    
    private BydRecord[] bydRecordsField;
    
    private EdmBydSokStatus sokStatusField;
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public BydRecord[] bydRecords
    {
        get
        {
            return this.bydRecordsField;
        }
        set
        {
            this.bydRecordsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public EdmBydSokStatus sokStatus
    {
        get
        {
            return this.sokStatusField;
        }
        set
        {
            this.sokStatusField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:edm2.ws.statkart.no")]
public partial class BydRecord
{
    
    private int alternativtArealField;
    
    private double austField;
    
    private int bruksNummerField;
    
    private string byggNaringsGruppeField;
    
    private int bygningsNummerField;
    
    private string bygningsStatusField;
    
    private string bygningsTypeField;
    
    private int festeNummerField;
    
    private int gaardsNummerField;
    
    private string godkjentDatoField;
    
    private double hoydeField;
    
    private string igangsattDatoField;
    
    private int kommuneNummerField;
    
    private int koordSystField;
    
    private int lopeNummerField;
    
    private double nordField;
    
    private string oppdateringsDatoField;
    
    private string regIgangsattDatoField;
    
    private string regTattIbrukDatoField;
    
    private int seksjonsNummerField;
    
    private string tattIbrukDatoField;
    
    /// <remarks/>
    public int alternativtAreal
    {
        get
        {
            return this.alternativtArealField;
        }
        set
        {
            this.alternativtArealField = value;
        }
    }
    
    /// <remarks/>
    public double aust
    {
        get
        {
            return this.austField;
        }
        set
        {
            this.austField = value;
        }
    }
    
    /// <remarks/>
    public int bruksNummer
    {
        get
        {
            return this.bruksNummerField;
        }
        set
        {
            this.bruksNummerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string byggNaringsGruppe
    {
        get
        {
            return this.byggNaringsGruppeField;
        }
        set
        {
            this.byggNaringsGruppeField = value;
        }
    }
    
    /// <remarks/>
    public int bygningsNummer
    {
        get
        {
            return this.bygningsNummerField;
        }
        set
        {
            this.bygningsNummerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string bygningsStatus
    {
        get
        {
            return this.bygningsStatusField;
        }
        set
        {
            this.bygningsStatusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string bygningsType
    {
        get
        {
            return this.bygningsTypeField;
        }
        set
        {
            this.bygningsTypeField = value;
        }
    }
    
    /// <remarks/>
    public int festeNummer
    {
        get
        {
            return this.festeNummerField;
        }
        set
        {
            this.festeNummerField = value;
        }
    }
    
    /// <remarks/>
    public int gaardsNummer
    {
        get
        {
            return this.gaardsNummerField;
        }
        set
        {
            this.gaardsNummerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string godkjentDato
    {
        get
        {
            return this.godkjentDatoField;
        }
        set
        {
            this.godkjentDatoField = value;
        }
    }
    
    /// <remarks/>
    public double hoyde
    {
        get
        {
            return this.hoydeField;
        }
        set
        {
            this.hoydeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string igangsattDato
    {
        get
        {
            return this.igangsattDatoField;
        }
        set
        {
            this.igangsattDatoField = value;
        }
    }
    
    /// <remarks/>
    public int kommuneNummer
    {
        get
        {
            return this.kommuneNummerField;
        }
        set
        {
            this.kommuneNummerField = value;
        }
    }
    
    /// <remarks/>
    public int koordSyst
    {
        get
        {
            return this.koordSystField;
        }
        set
        {
            this.koordSystField = value;
        }
    }
    
    /// <remarks/>
    public int lopeNummer
    {
        get
        {
            return this.lopeNummerField;
        }
        set
        {
            this.lopeNummerField = value;
        }
    }
    
    /// <remarks/>
    public double nord
    {
        get
        {
            return this.nordField;
        }
        set
        {
            this.nordField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string oppdateringsDato
    {
        get
        {
            return this.oppdateringsDatoField;
        }
        set
        {
            this.oppdateringsDatoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string regIgangsattDato
    {
        get
        {
            return this.regIgangsattDatoField;
        }
        set
        {
            this.regIgangsattDatoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string regTattIbrukDato
    {
        get
        {
            return this.regTattIbrukDatoField;
        }
        set
        {
            this.regTattIbrukDatoField = value;
        }
    }
    
    /// <remarks/>
    public int seksjonsNummer
    {
        get
        {
            return this.seksjonsNummerField;
        }
        set
        {
            this.seksjonsNummerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string tattIbrukDato
    {
        get
        {
            return this.tattIbrukDatoField;
        }
        set
        {
            this.tattIbrukDatoField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:edm2.ws.statkart.no")]
public partial class EdmBydSokStatus
{
    
    private string meldingField;
    
    private bool mereDataField;
    
    private bool okField;
    
    /// <remarks/>
    [System.Xml.Serialization.SoapElementAttribute(IsNullable=true)]
    public string melding
    {
        get
        {
            return this.meldingField;
        }
        set
        {
            this.meldingField = value;
        }
    }
    
    /// <remarks/>
    public bool mereData
    {
        get
        {
            return this.mereDataField;
        }
        set
        {
            this.mereDataField = value;
        }
    }
    
    /// <remarks/>
    public bool ok
    {
        get
        {
            return this.okField;
        }
        set
        {
            this.okField = value;
        }
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(WrapperName="edmBydSok", WrapperNamespace="http://ws.ngisedmws.sk.hosledata.no", IsWrapped=true)]
public partial class edmBydSokRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
    public string brukerid;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=1)]
    public string passord;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=2)]
    public string aliasId;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=3)]
    public int kommuneNummer;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=4)]
    public int gaardsNummer;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=5)]
    public int bruksNummer;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=6)]
    public int festeNummer;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=7)]
    public int seksjonsNummer;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=8)]
    public int maxAnt;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=9)]
    public int tilSosiKoordSyst;
    
    public edmBydSokRequest()
    {
    }
    
    public edmBydSokRequest(string brukerid, string passord, string aliasId, int kommuneNummer, int gaardsNummer, int bruksNummer, int festeNummer, int seksjonsNummer, int maxAnt, int tilSosiKoordSyst)
    {
        this.brukerid = brukerid;
        this.passord = passord;
        this.aliasId = aliasId;
        this.kommuneNummer = kommuneNummer;
        this.gaardsNummer = gaardsNummer;
        this.bruksNummer = bruksNummer;
        this.festeNummer = festeNummer;
        this.seksjonsNummer = seksjonsNummer;
        this.maxAnt = maxAnt;
        this.tilSosiKoordSyst = tilSosiKoordSyst;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
[System.ServiceModel.MessageContractAttribute(WrapperName="edmBydSokResponse", WrapperNamespace="https://ws.geonorge.no/SKWS2/services/EiendomBygg", IsWrapped=true)]
public partial class edmBydSokResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="", Order=0)]
    public EdmBydSokRes edmBydSokReturn;
    
    public edmBydSokResponse()
    {
    }
    
    public edmBydSokResponse(EdmBydSokRes edmBydSokReturn)
    {
        this.edmBydSokReturn = edmBydSokReturn;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface EiendomByggChannel : EiendomBygg, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class EiendomByggClient : System.ServiceModel.ClientBase<EiendomBygg>, EiendomBygg
{
    
    public EiendomByggClient()
    {
    }
    
    public EiendomByggClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public EiendomByggClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public EiendomByggClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public EiendomByggClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    edmBydSokResponse EiendomBygg.edmBydSok(edmBydSokRequest request)
    {
        return base.Channel.edmBydSok(request);
    }
    
    public EdmBydSokRes edmBydSok(string brukerid, string passord, string aliasId, int kommuneNummer, int gaardsNummer, int bruksNummer, int festeNummer, int seksjonsNummer, int maxAnt, int tilSosiKoordSyst)
    {
        edmBydSokRequest inValue = new edmBydSokRequest();
        inValue.brukerid = brukerid;
        inValue.passord = passord;
        inValue.aliasId = aliasId;
        inValue.kommuneNummer = kommuneNummer;
        inValue.gaardsNummer = gaardsNummer;
        inValue.bruksNummer = bruksNummer;
        inValue.festeNummer = festeNummer;
        inValue.seksjonsNummer = seksjonsNummer;
        inValue.maxAnt = maxAnt;
        inValue.tilSosiKoordSyst = tilSosiKoordSyst;
        edmBydSokResponse retVal = ((EiendomBygg)(this)).edmBydSok(inValue);
        return retVal.edmBydSokReturn;
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    System.Threading.Tasks.Task<edmBydSokResponse> EiendomBygg.edmBydSokAsync(edmBydSokRequest request)
    {
        return base.Channel.edmBydSokAsync(request);
    }
    
    public System.Threading.Tasks.Task<edmBydSokResponse> edmBydSokAsync(string brukerid, string passord, string aliasId, int kommuneNummer, int gaardsNummer, int bruksNummer, int festeNummer, int seksjonsNummer, int maxAnt, int tilSosiKoordSyst)
    {
        edmBydSokRequest inValue = new edmBydSokRequest();
        inValue.brukerid = brukerid;
        inValue.passord = passord;
        inValue.aliasId = aliasId;
        inValue.kommuneNummer = kommuneNummer;
        inValue.gaardsNummer = gaardsNummer;
        inValue.bruksNummer = bruksNummer;
        inValue.festeNummer = festeNummer;
        inValue.seksjonsNummer = seksjonsNummer;
        inValue.maxAnt = maxAnt;
        inValue.tilSosiKoordSyst = tilSosiKoordSyst;
        return ((EiendomBygg)(this)).edmBydSokAsync(inValue);
    }
}
