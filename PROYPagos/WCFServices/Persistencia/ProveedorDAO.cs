using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServices.Dominio;

namespace WCFServices.Persistencia
{
    public class ProveedorDAO
    {
        private string CadenaConexion = "Data Source=HN060851\\SQLEXPRESS;Initial Catalog=TRABAJO_DSD;Integrated Security=SSPI;";

        public Proveedor Crear(Proveedor proveedorACrear)
        {
            Proveedor proveedorCreado = null;
            string sql = "INSERT INTO tbl_Proveedor VALUES (@Ruc,@Tipo,@Razon,@Telefono,@EMail)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Ruc", proveedorACrear.Ruc));
                    comando.Parameters.Add(new SqlParameter("@Tipo", proveedorACrear.Tipo));
                    comando.Parameters.Add(new SqlParameter("@Razon", proveedorACrear.RazonSocial));
                    comando.Parameters.Add(new SqlParameter("@Telefono", proveedorACrear.Telefono));
                    comando.Parameters.Add(new SqlParameter("@EMail", proveedorACrear.Email));
                    comando.ExecuteNonQuery();
                }
            }
            proveedorCreado = Obtener(proveedorACrear.Ruc);
            return proveedorCreado;
        }

        public Proveedor Obtener(string ruc)
        {
            Proveedor proveedorEncontrado = null;
            string sql = "SELECT * FROM tbl_Proveedor WHERE RUC = @Ruc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Ruc", ruc));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            proveedorEncontrado = new Proveedor()
                            {
                                Ruc = (string)resultado["RUC"],
                                Tipo = (string)resultado["TIPO"],
                                RazonSocial = (string)resultado["RAZON_SOCIAL"],
                                Telefono = (string)resultado["TELEFONO"],
                                Email = (string)resultado["EMAIL"]
                            };
                        }
                    }
                }
            }
            return proveedorEncontrado;
        }

        public Proveedor Modificar(Proveedor proveedorAModificar)
        {
            Proveedor proveedorModificado = null;
            string sql = "UPDATE tbl_Proveedor SET TIPO=@Tipo,RAZON_SOCIAL=@Razon,TELEFONO=@Telefono,EMAIL=@EMail WHERE RUC=@Ruc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Tipo", proveedorAModificar.Tipo));
                    comando.Parameters.Add(new SqlParameter("@Razon", proveedorAModificar.RazonSocial));
                    comando.Parameters.Add(new SqlParameter("@Telefono", proveedorAModificar.Telefono));
                    comando.Parameters.Add(new SqlParameter("@EMail", proveedorAModificar.Email));
                    comando.Parameters.Add(new SqlParameter("@Ruc", proveedorAModificar.Ruc));
                    comando.ExecuteNonQuery();
                }
            }
            proveedorModificado = Obtener(proveedorAModificar.Ruc);
            return proveedorModificado;
        }

        public int Eliminar(string ruc)
        {
            int r = 1;
            string sql = "DELETE FROM tbl_Proveedor WHERE RUC = @Ruc";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Ruc", ruc));
                    comando.ExecuteNonQuery();
                }
                r = 0;
            }
            return r;
        }

        public List<Proveedor> Listar()
        {
            List<Proveedor> proveedoresEncontrados = new List<Proveedor>();
            Proveedor proveedorEncontrado = null;
            string sql = "SELECT Pr.*, Tp.dscTipoPersona   FROM tbl_Proveedor Pr left join TIPO_PERSONA Tp on Pr.tipo = Tp.codTipoPersona";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            proveedorEncontrado = new Proveedor()
                            {
                                Ruc = (string)resultado["RUC"],
                                Tipo = (string)resultado["TIPO"],
                                RazonSocial = (string)resultado["RAZON_SOCIAL"],
                                Telefono = (string)resultado["TELEFONO"],
                                Email = (string)resultado["EMAIL"]
                            };
                            proveedoresEncontrados.Add(proveedorEncontrado);
                        }
                    }
                }
            }
            return proveedoresEncontrados;
        }
    }
}