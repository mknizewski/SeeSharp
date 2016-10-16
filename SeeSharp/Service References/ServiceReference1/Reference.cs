﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 5.0.61118.0
// 
namespace SeeSharp.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IServerService")]
    public interface IServerService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerService/CreateMainDirectoryIfDosentExists", ReplyAction="http://tempuri.org/IServerService/CreateMainDirectoryIfDosentExistsResponse")]
        System.IAsyncResult BeginCreateMainDirectoryIfDosentExists(System.AsyncCallback callback, object asyncState);
        
        void EndCreateMainDirectoryIfDosentExists(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerService/CreateDirectoryForUser", ReplyAction="http://tempuri.org/IServerService/CreateDirectoryForUserResponse")]
        System.IAsyncResult BeginCreateDirectoryForUser(string loginName, int code, System.AsyncCallback callback, object asyncState);
        
        void EndCreateDirectoryForUser(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IServerService/GetUserProfile", ReplyAction="http://tempuri.org/IServerService/GetUserProfileResponse")]
        System.IAsyncResult BeginGetUserProfile(string loginName, System.AsyncCallback callback, object asyncState);
        
        System.Collections.Generic.Dictionary<string, string> EndGetUserProfile(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerServiceChannel : SeeSharp.ServiceReference1.IServerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetUserProfileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetUserProfileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.Generic.Dictionary<string, string> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.Generic.Dictionary<string, string>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerServiceClient : System.ServiceModel.ClientBase<SeeSharp.ServiceReference1.IServerService>, SeeSharp.ServiceReference1.IServerService {
        
        private BeginOperationDelegate onBeginCreateMainDirectoryIfDosentExistsDelegate;
        
        private EndOperationDelegate onEndCreateMainDirectoryIfDosentExistsDelegate;
        
        private System.Threading.SendOrPostCallback onCreateMainDirectoryIfDosentExistsCompletedDelegate;
        
        private BeginOperationDelegate onBeginCreateDirectoryForUserDelegate;
        
        private EndOperationDelegate onEndCreateDirectoryForUserDelegate;
        
        private System.Threading.SendOrPostCallback onCreateDirectoryForUserCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetUserProfileDelegate;
        
        private EndOperationDelegate onEndGetUserProfileDelegate;
        
        private System.Threading.SendOrPostCallback onGetUserProfileCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public ServerServiceClient() {
        }
        
        public ServerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CreateMainDirectoryIfDosentExistsCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CreateDirectoryForUserCompleted;
        
        public event System.EventHandler<GetUserProfileCompletedEventArgs> GetUserProfileCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SeeSharp.ServiceReference1.IServerService.BeginCreateMainDirectoryIfDosentExists(System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateMainDirectoryIfDosentExists(callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void SeeSharp.ServiceReference1.IServerService.EndCreateMainDirectoryIfDosentExists(System.IAsyncResult result) {
            base.Channel.EndCreateMainDirectoryIfDosentExists(result);
        }
        
        private System.IAsyncResult OnBeginCreateMainDirectoryIfDosentExists(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((SeeSharp.ServiceReference1.IServerService)(this)).BeginCreateMainDirectoryIfDosentExists(callback, asyncState);
        }
        
        private object[] OnEndCreateMainDirectoryIfDosentExists(System.IAsyncResult result) {
            ((SeeSharp.ServiceReference1.IServerService)(this)).EndCreateMainDirectoryIfDosentExists(result);
            return null;
        }
        
        private void OnCreateMainDirectoryIfDosentExistsCompleted(object state) {
            if ((this.CreateMainDirectoryIfDosentExistsCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateMainDirectoryIfDosentExistsCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateMainDirectoryIfDosentExistsAsync() {
            this.CreateMainDirectoryIfDosentExistsAsync(null);
        }
        
        public void CreateMainDirectoryIfDosentExistsAsync(object userState) {
            if ((this.onBeginCreateMainDirectoryIfDosentExistsDelegate == null)) {
                this.onBeginCreateMainDirectoryIfDosentExistsDelegate = new BeginOperationDelegate(this.OnBeginCreateMainDirectoryIfDosentExists);
            }
            if ((this.onEndCreateMainDirectoryIfDosentExistsDelegate == null)) {
                this.onEndCreateMainDirectoryIfDosentExistsDelegate = new EndOperationDelegate(this.OnEndCreateMainDirectoryIfDosentExists);
            }
            if ((this.onCreateMainDirectoryIfDosentExistsCompletedDelegate == null)) {
                this.onCreateMainDirectoryIfDosentExistsCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateMainDirectoryIfDosentExistsCompleted);
            }
            base.InvokeAsync(this.onBeginCreateMainDirectoryIfDosentExistsDelegate, null, this.onEndCreateMainDirectoryIfDosentExistsDelegate, this.onCreateMainDirectoryIfDosentExistsCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SeeSharp.ServiceReference1.IServerService.BeginCreateDirectoryForUser(string loginName, int code, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginCreateDirectoryForUser(loginName, code, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void SeeSharp.ServiceReference1.IServerService.EndCreateDirectoryForUser(System.IAsyncResult result) {
            base.Channel.EndCreateDirectoryForUser(result);
        }
        
        private System.IAsyncResult OnBeginCreateDirectoryForUser(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string loginName = ((string)(inValues[0]));
            int code = ((int)(inValues[1]));
            return ((SeeSharp.ServiceReference1.IServerService)(this)).BeginCreateDirectoryForUser(loginName, code, callback, asyncState);
        }
        
        private object[] OnEndCreateDirectoryForUser(System.IAsyncResult result) {
            ((SeeSharp.ServiceReference1.IServerService)(this)).EndCreateDirectoryForUser(result);
            return null;
        }
        
        private void OnCreateDirectoryForUserCompleted(object state) {
            if ((this.CreateDirectoryForUserCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CreateDirectoryForUserCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CreateDirectoryForUserAsync(string loginName, int code) {
            this.CreateDirectoryForUserAsync(loginName, code, null);
        }
        
        public void CreateDirectoryForUserAsync(string loginName, int code, object userState) {
            if ((this.onBeginCreateDirectoryForUserDelegate == null)) {
                this.onBeginCreateDirectoryForUserDelegate = new BeginOperationDelegate(this.OnBeginCreateDirectoryForUser);
            }
            if ((this.onEndCreateDirectoryForUserDelegate == null)) {
                this.onEndCreateDirectoryForUserDelegate = new EndOperationDelegate(this.OnEndCreateDirectoryForUser);
            }
            if ((this.onCreateDirectoryForUserCompletedDelegate == null)) {
                this.onCreateDirectoryForUserCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCreateDirectoryForUserCompleted);
            }
            base.InvokeAsync(this.onBeginCreateDirectoryForUserDelegate, new object[] {
                        loginName,
                        code}, this.onEndCreateDirectoryForUserDelegate, this.onCreateDirectoryForUserCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult SeeSharp.ServiceReference1.IServerService.BeginGetUserProfile(string loginName, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetUserProfile(loginName, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.Generic.Dictionary<string, string> SeeSharp.ServiceReference1.IServerService.EndGetUserProfile(System.IAsyncResult result) {
            return base.Channel.EndGetUserProfile(result);
        }
        
        private System.IAsyncResult OnBeginGetUserProfile(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string loginName = ((string)(inValues[0]));
            return ((SeeSharp.ServiceReference1.IServerService)(this)).BeginGetUserProfile(loginName, callback, asyncState);
        }
        
        private object[] OnEndGetUserProfile(System.IAsyncResult result) {
            System.Collections.Generic.Dictionary<string, string> retVal = ((SeeSharp.ServiceReference1.IServerService)(this)).EndGetUserProfile(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetUserProfileCompleted(object state) {
            if ((this.GetUserProfileCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetUserProfileCompleted(this, new GetUserProfileCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetUserProfileAsync(string loginName) {
            this.GetUserProfileAsync(loginName, null);
        }
        
        public void GetUserProfileAsync(string loginName, object userState) {
            if ((this.onBeginGetUserProfileDelegate == null)) {
                this.onBeginGetUserProfileDelegate = new BeginOperationDelegate(this.OnBeginGetUserProfile);
            }
            if ((this.onEndGetUserProfileDelegate == null)) {
                this.onEndGetUserProfileDelegate = new EndOperationDelegate(this.OnEndGetUserProfile);
            }
            if ((this.onGetUserProfileCompletedDelegate == null)) {
                this.onGetUserProfileCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetUserProfileCompleted);
            }
            base.InvokeAsync(this.onBeginGetUserProfileDelegate, new object[] {
                        loginName}, this.onEndGetUserProfileDelegate, this.onGetUserProfileCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override SeeSharp.ServiceReference1.IServerService CreateChannel() {
            return new ServerServiceClientChannel(this);
        }
        
        private class ServerServiceClientChannel : ChannelBase<SeeSharp.ServiceReference1.IServerService>, SeeSharp.ServiceReference1.IServerService {
            
            public ServerServiceClientChannel(System.ServiceModel.ClientBase<SeeSharp.ServiceReference1.IServerService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginCreateMainDirectoryIfDosentExists(System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[0];
                System.IAsyncResult _result = base.BeginInvoke("CreateMainDirectoryIfDosentExists", _args, callback, asyncState);
                return _result;
            }
            
            public void EndCreateMainDirectoryIfDosentExists(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("CreateMainDirectoryIfDosentExists", _args, result);
            }
            
            public System.IAsyncResult BeginCreateDirectoryForUser(string loginName, int code, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = loginName;
                _args[1] = code;
                System.IAsyncResult _result = base.BeginInvoke("CreateDirectoryForUser", _args, callback, asyncState);
                return _result;
            }
            
            public void EndCreateDirectoryForUser(System.IAsyncResult result) {
                object[] _args = new object[0];
                base.EndInvoke("CreateDirectoryForUser", _args, result);
            }
            
            public System.IAsyncResult BeginGetUserProfile(string loginName, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = loginName;
                System.IAsyncResult _result = base.BeginInvoke("GetUserProfile", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.Generic.Dictionary<string, string> EndGetUserProfile(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.Generic.Dictionary<string, string> _result = ((System.Collections.Generic.Dictionary<string, string>)(base.EndInvoke("GetUserProfile", _args, result)));
                return _result;
            }
        }
    }
}
