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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="wcfDbFunctions.IdbFunctionsToComponents")]
    public interface IdbFunctionsToComponents {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/GetData", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/GetDataResponse")]
        System.Data.DataTable GetData(string sSelect);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IdbFunctionsToComponents/GetData", ReplyAction="http://tempuri.org/IdbFunctionsToComponents/GetDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataTable> GetDataAsync(string sSelect);
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
        
        public System.Data.DataTable GetData(string sSelect) {
            return base.Channel.GetData(sSelect);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> GetDataAsync(string sSelect) {
            return base.Channel.GetDataAsync(sSelect);
        }
    }
}
