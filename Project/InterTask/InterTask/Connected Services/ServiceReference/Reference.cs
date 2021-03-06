//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InterTask.ServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.InterTaskWebServiceSoap")]
    public interface InterTaskWebServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerifyLogin", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        string VerifyLogin(string usernmae, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/VerifyLogin", ReplyAction="*")]
        System.Threading.Tasks.Task<string> VerifyLoginAsync(string usernmae, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveSearchResult", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int SaveSearchResult(string h, string tmax, string tmin, string username, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SaveSearchResult", ReplyAction="*")]
        System.Threading.Tasks.Task<int> SaveSearchResultAsync(string h, string tmax, string tmin, string username, string city);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSearchResults", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataSet GetSearchResults(string usernmae);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetSearchResults", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetSearchResultsAsync(string usernmae);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteRecords", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        int DeleteRecords(string[] ids);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteRecords", ReplyAction="*")]
        System.Threading.Tasks.Task<int> DeleteRecordsAsync(string[] ids);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface InterTaskWebServiceSoapChannel : InterTask.ServiceReference.InterTaskWebServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class InterTaskWebServiceSoapClient : System.ServiceModel.ClientBase<InterTask.ServiceReference.InterTaskWebServiceSoap>, InterTask.ServiceReference.InterTaskWebServiceSoap {
        
        public InterTaskWebServiceSoapClient() {
        }
        
        public InterTaskWebServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public InterTaskWebServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InterTaskWebServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public InterTaskWebServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string VerifyLogin(string usernmae, string password) {
            return base.Channel.VerifyLogin(usernmae, password);
        }
        
        public System.Threading.Tasks.Task<string> VerifyLoginAsync(string usernmae, string password) {
            return base.Channel.VerifyLoginAsync(usernmae, password);
        }
        
        public int SaveSearchResult(string h, string tmax, string tmin, string username, string city) {
            return base.Channel.SaveSearchResult(h, tmax, tmin, username, city);
        }
        
        public System.Threading.Tasks.Task<int> SaveSearchResultAsync(string h, string tmax, string tmin, string username, string city) {
            return base.Channel.SaveSearchResultAsync(h, tmax, tmin, username, city);
        }
        
        public System.Data.DataSet GetSearchResults(string usernmae) {
            return base.Channel.GetSearchResults(usernmae);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetSearchResultsAsync(string usernmae) {
            return base.Channel.GetSearchResultsAsync(usernmae);
        }
        
        public int DeleteRecords(string[] ids) {
            return base.Channel.DeleteRecords(ids);
        }
        
        public System.Threading.Tasks.Task<int> DeleteRecordsAsync(string[] ids) {
            return base.Channel.DeleteRecordsAsync(ids);
        }
    }
}
