//Desarrollado por Oscar Fabian
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Errores;

namespace WCFServices
{
    [ServiceContract]
    public interface IProveedores
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Proveedor CrearProveedor(Proveedor proveedorACrear);
        [OperationContract]
        Proveedor ObtenerProveedor(string ruc);
        [OperationContract]
        Proveedor ModificarProveedor(Proveedor proveedorAModificar);
        [OperationContract]
        int EliminarProveedor(string ruc);
        [OperationContract]
        List<Proveedor> ListarProveedores();
    }
}
