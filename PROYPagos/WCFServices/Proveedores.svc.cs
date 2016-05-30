using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServices.Dominio;
using WCFServices.Errores;
using WCFServices.Persistencia;

namespace WCFServices
{
    public class Proveedores : IProveedores
    {
        private ProveedorDAO proveedorDAO = new ProveedorDAO();
        public Proveedor CrearProveedor(Proveedor proveedorACrear)
        {
            if (proveedorDAO.Obtener(proveedorACrear.Ruc) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "101",
                        Descripcion = "El proveedor ya existe"
                    }, new FaultReason("Error al intentar creación"));
            }
            return proveedorDAO.Crear(proveedorACrear);
        }

        public Proveedor ObtenerProveedor(string ruc)
        {
            return proveedorDAO.Obtener(ruc);
        }

        public Proveedor ModificarProveedor(Proveedor proveedorAModificar)
        {
            return proveedorDAO.Modificar(proveedorAModificar);
        }

        public int EliminarProveedor(string ruc)
        {
            return proveedorDAO.Eliminar(ruc);
        }        
        public List<Proveedor> ListarProveedores()
        {
            return proveedorDAO.Listar();
        }
    }
}
