﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sistemaAGP.OrdenPedidoWebServices {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap")]
    public interface ServicioOrdenTrabajoAgSoap {
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento GetServiciosResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetServicios", ReplyAction="*")]
        sistemaAGP.OrdenPedidoWebServices.GetServiciosResponse GetServicios(sistemaAGP.OrdenPedidoWebServices.GetServiciosRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento GetDocumentosResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetDocumentos", ReplyAction="*")]
        sistemaAGP.OrdenPedidoWebServices.GetDocumentosResponse GetDocumentos(sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento GetQuienPagaResult del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/GetQuienPaga", ReplyAction="*")]
        sistemaAGP.OrdenPedidoWebServices.GetQuienPagaResponse GetQuienPaga(sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequest request);
        
        // CODEGEN: Se está generando un contrato de mensaje, ya que el nombre de elemento texto del espacio de nombres http://tempuri.org/ no está marcado para aceptar valores nil.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddOrdenPedido", ReplyAction="*")]
        sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoResponse AddOrdenPedido(sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetServiciosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetServicios", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.GetServiciosRequestBody Body;
        
        public GetServiciosRequest() {
        }
        
        public GetServiciosRequest(sistemaAGP.OrdenPedidoWebServices.GetServiciosRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetServiciosRequestBody {
        
        public GetServiciosRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetServiciosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetServiciosResponse", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.GetServiciosResponseBody Body;
        
        public GetServiciosResponse() {
        }
        
        public GetServiciosResponse(sistemaAGP.OrdenPedidoWebServices.GetServiciosResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetServiciosResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetServiciosResult;
        
        public GetServiciosResponseBody() {
        }
        
        public GetServiciosResponseBody(string GetServiciosResult) {
            this.GetServiciosResult = GetServiciosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDocumentosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetDocumentos", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequestBody Body;
        
        public GetDocumentosRequest() {
        }
        
        public GetDocumentosRequest(sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetDocumentosRequestBody {
        
        public GetDocumentosRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetDocumentosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetDocumentosResponse", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.GetDocumentosResponseBody Body;
        
        public GetDocumentosResponse() {
        }
        
        public GetDocumentosResponse(sistemaAGP.OrdenPedidoWebServices.GetDocumentosResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetDocumentosResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetDocumentosResult;
        
        public GetDocumentosResponseBody() {
        }
        
        public GetDocumentosResponseBody(string GetDocumentosResult) {
            this.GetDocumentosResult = GetDocumentosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetQuienPagaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetQuienPaga", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequestBody Body;
        
        public GetQuienPagaRequest() {
        }
        
        public GetQuienPagaRequest(sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetQuienPagaRequestBody {
        
        public GetQuienPagaRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetQuienPagaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetQuienPagaResponse", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.GetQuienPagaResponseBody Body;
        
        public GetQuienPagaResponse() {
        }
        
        public GetQuienPagaResponse(sistemaAGP.OrdenPedidoWebServices.GetQuienPagaResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetQuienPagaResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetQuienPagaResult;
        
        public GetQuienPagaResponseBody() {
        }
        
        public GetQuienPagaResponseBody(string GetQuienPagaResult) {
            this.GetQuienPagaResult = GetQuienPagaResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddOrdenPedidoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddOrdenPedido", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequestBody Body;
        
        public AddOrdenPedidoRequest() {
        }
        
        public AddOrdenPedidoRequest(sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddOrdenPedidoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string texto;
        
        public AddOrdenPedidoRequestBody() {
        }
        
        public AddOrdenPedidoRequestBody(string texto) {
            this.texto = texto;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddOrdenPedidoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddOrdenPedidoResponse", Namespace="http://tempuri.org/", Order=0)]
        public sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoResponseBody Body;
        
        public AddOrdenPedidoResponse() {
        }
        
        public AddOrdenPedidoResponse(sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddOrdenPedidoResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string AddOrdenPedidoResult;
        
        public AddOrdenPedidoResponseBody() {
        }
        
        public AddOrdenPedidoResponseBody(string AddOrdenPedidoResult) {
            this.AddOrdenPedidoResult = AddOrdenPedidoResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServicioOrdenTrabajoAgSoapChannel : sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioOrdenTrabajoAgSoapClient : System.ServiceModel.ClientBase<sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap>, sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap {
        
        public ServicioOrdenTrabajoAgSoapClient() {
        }
        
        public ServicioOrdenTrabajoAgSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioOrdenTrabajoAgSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioOrdenTrabajoAgSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioOrdenTrabajoAgSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        sistemaAGP.OrdenPedidoWebServices.GetServiciosResponse sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap.GetServicios(sistemaAGP.OrdenPedidoWebServices.GetServiciosRequest request) {
            return base.Channel.GetServicios(request);
        }
        
        public string GetServicios() {
            sistemaAGP.OrdenPedidoWebServices.GetServiciosRequest inValue = new sistemaAGP.OrdenPedidoWebServices.GetServiciosRequest();
            inValue.Body = new sistemaAGP.OrdenPedidoWebServices.GetServiciosRequestBody();
            sistemaAGP.OrdenPedidoWebServices.GetServiciosResponse retVal = ((sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap)(this)).GetServicios(inValue);
            return retVal.Body.GetServiciosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        sistemaAGP.OrdenPedidoWebServices.GetDocumentosResponse sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap.GetDocumentos(sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequest request) {
            return base.Channel.GetDocumentos(request);
        }
        
        public string GetDocumentos() {
            sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequest inValue = new sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequest();
            inValue.Body = new sistemaAGP.OrdenPedidoWebServices.GetDocumentosRequestBody();
            sistemaAGP.OrdenPedidoWebServices.GetDocumentosResponse retVal = ((sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap)(this)).GetDocumentos(inValue);
            return retVal.Body.GetDocumentosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        sistemaAGP.OrdenPedidoWebServices.GetQuienPagaResponse sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap.GetQuienPaga(sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequest request) {
            return base.Channel.GetQuienPaga(request);
        }
        
        public string GetQuienPaga() {
            sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequest inValue = new sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequest();
            inValue.Body = new sistemaAGP.OrdenPedidoWebServices.GetQuienPagaRequestBody();
            sistemaAGP.OrdenPedidoWebServices.GetQuienPagaResponse retVal = ((sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap)(this)).GetQuienPaga(inValue);
            return retVal.Body.GetQuienPagaResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoResponse sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap.AddOrdenPedido(sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequest request) {
            return base.Channel.AddOrdenPedido(request);
        }
        
        public string AddOrdenPedido(string texto) {
            sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequest inValue = new sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequest();
            inValue.Body = new sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoRequestBody();
            inValue.Body.texto = texto;
            sistemaAGP.OrdenPedidoWebServices.AddOrdenPedidoResponse retVal = ((sistemaAGP.OrdenPedidoWebServices.ServicioOrdenTrabajoAgSoap)(this)).AddOrdenPedido(inValue);
            return retVal.Body.AddOrdenPedidoResult;
        }
    }
}
