﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HLP.Controls.wcfDbFunctions {
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EnumControls.stFilterQuickSearch", Namespace="http://schemas.datacontract.org/2004/07/HLP.Controls.Enum")]
    public enum EnumControlsstFilterQuickSearch : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        equal = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        startWith = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        contains = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcfDbFunctions.IdbFunctionsToComponents")]
    public interface IdbFunctionsToComponents {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekRetResponse")]
        System.Data.DataTable qrySeekRet(string sExpressao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekRetResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> qrySeekRetAsync(string sExpressao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet2", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet2Response")]
        System.Data.DataTable qrySeekRet2(string sTabela, string sCampos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet2", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet2Response")]
        System.Threading.Tasks.Task<System.Data.DataTable> qrySeekRet2Async(string sTabela, string sCampos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet3", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet3Response")]
        System.Data.DataTable qrySeekRet3(string sTabela, string sCampos, string sWhere);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet3", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekRet3Response")]
        System.Threading.Tasks.Task<System.Data.DataTable> qrySeekRet3Async(string sTabela, string sCampos, string sWhere);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekValue", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekValueResponse")]
        string qrySeekValue(string sTabela, string sCampo, string sWhere);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/qrySeekValue", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/qrySeekValueResponse")]
        System.Threading.Tasks.Task<string> qrySeekValueAsync(string sTabela, string sCampo, string sWhere);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/fExisteCampo", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/fExisteCampoResponse")]
        bool fExisteCampo(string sNomeCampo, string sTabela);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/fExisteCampo", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/fExisteCampoResponse")]
        System.Threading.Tasks.Task<bool> fExisteCampoAsync(string sNomeCampo, string sTabela);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/GetRecord", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/GetRecordResponse")]
        int GetRecord(string xNameTable, string xCampo, string xValue, HLP.Controls.wcfDbFunctions.EnumControlsstFilterQuickSearch stFilterQS, int idEmpresa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/GetRecord", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/GetRecordResponse")]
        System.Threading.Tasks.Task<int> GetRecordAsync(string xNameTable, string xCampo, string xValue, HLP.Controls.wcfDbFunctions.EnumControlsstFilterQuickSearch stFilterQS, int idEmpresa);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IdbFunctionsToComponentsChannel : HLP.Controls.wcfDbFunctions.IdbFunctionsToComponents, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IdbFunctionsToComponentsClient : System.ServiceModel.ClientBase<HLP.Controls.wcfDbFunctions.IdbFunctionsToComponents>, HLP.Controls.wcfDbFunctions.IdbFunctionsToComponents {
        
        public IdbFunctionsToComponentsClient() {
        }
        
        public IdbFunctionsToComponentsClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IdbFunctionsToComponentsClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IdbFunctionsToComponentsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IdbFunctionsToComponentsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable qrySeekRet(string sExpressao) {
            return base.Channel.qrySeekRet(sExpressao);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> qrySeekRetAsync(string sExpressao) {
            return base.Channel.qrySeekRetAsync(sExpressao);
        }
        
        public System.Data.DataTable qrySeekRet2(string sTabela, string sCampos) {
            return base.Channel.qrySeekRet2(sTabela, sCampos);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> qrySeekRet2Async(string sTabela, string sCampos) {
            return base.Channel.qrySeekRet2Async(sTabela, sCampos);
        }
        
        public System.Data.DataTable qrySeekRet3(string sTabela, string sCampos, string sWhere) {
            return base.Channel.qrySeekRet3(sTabela, sCampos, sWhere);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> qrySeekRet3Async(string sTabela, string sCampos, string sWhere) {
            return base.Channel.qrySeekRet3Async(sTabela, sCampos, sWhere);
        }
        
        public string qrySeekValue(string sTabela, string sCampo, string sWhere) {
            return base.Channel.qrySeekValue(sTabela, sCampo, sWhere);
        }
        
        public System.Threading.Tasks.Task<string> qrySeekValueAsync(string sTabela, string sCampo, string sWhere) {
            return base.Channel.qrySeekValueAsync(sTabela, sCampo, sWhere);
        }
        
        public bool fExisteCampo(string sNomeCampo, string sTabela) {
            return base.Channel.fExisteCampo(sNomeCampo, sTabela);
        }
        
        public System.Threading.Tasks.Task<bool> fExisteCampoAsync(string sNomeCampo, string sTabela) {
            return base.Channel.fExisteCampoAsync(sNomeCampo, sTabela);
        }
        
        public int GetRecord(string xNameTable, string xCampo, string xValue, HLP.Controls.wcfDbFunctions.EnumControlsstFilterQuickSearch stFilterQS, int idEmpresa) {
            return base.Channel.GetRecord(xNameTable, xCampo, xValue, stFilterQS, idEmpresa);
        }
        
        public System.Threading.Tasks.Task<int> GetRecordAsync(string xNameTable, string xCampo, string xValue, HLP.Controls.wcfDbFunctions.EnumControlsstFilterQuickSearch stFilterQS, int idEmpresa) {
            return base.Channel.GetRecordAsync(xNameTable, xCampo, xValue, stFilterQS, idEmpresa);
        }
    }
}
