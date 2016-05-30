using PAGOSRest.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PAGOSRest.Persistencia
{
    public class DocumentoDAO
    {
        public Documento Crear(Documento documentoACrear)
        {
            Documento DocumentoCreado = null;
            string sql = "INSERT INTO documento VALUES (@ruc, @numero_documento, @tipo_documento, @fecha_emision, @fecha_vencimiento, @moneda, @glosa, @estado)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@ruc", documentoACrear.ruc));
                    com.Parameters.Add(new SqlParameter("@numero_documento", documentoACrear.numero_documento));
                    com.Parameters.Add(new SqlParameter("@tipo_documento", documentoACrear.tipo_documento));
                    com.Parameters.Add(new SqlParameter("@fecha_emision", documentoACrear.fecha_emision));
                    com.Parameters.Add(new SqlParameter("@fecha_vencimiento", documentoACrear.fecha_vencimiento));
                    com.Parameters.Add(new SqlParameter("@moneda", documentoACrear.moneda));
                    com.Parameters.Add(new SqlParameter("@glosa", documentoACrear.glosa));
                    com.Parameters.Add(new SqlParameter("@importe", documentoACrear.importe));
                    com.Parameters.Add(new SqlParameter("@estado", documentoACrear.estado));
                    com.ExecuteNonQuery();
                }
            }
            DocumentoCreado = Obtener(documentoACrear.numero_documento);
            return DocumentoCreado;
        }

        public Documento Obtener(string codigo)
        {
            Documento DocumentoEncontrado = null;
            string sql = "SELECT * FROM documento WHERE ruc = @ruc";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            DocumentoEncontrado = new Documento()
                            {
                                ruc = (string)resultado["ruc"],
                                numero_documento = (string)resultado["numero_documento"],
                                tipo_documento = (string)resultado["tipo_documento"],
                                fecha_emision = resultado["fecha_emision"].ToString(),
                                fecha_vencimiento = resultado["fecha_vencimiento"].ToString(),
                                moneda = (string)resultado["moneda"],
                                glosa = (string)resultado["glosa"],
                                importe = resultado["importe"].ToString(),
                                estado = (string)resultado["estado"],
                            };
                        }
                    }
                }
            }
            return DocumentoEncontrado;
        }



        public Documento Modificar(Documento documentoAModificar)
        {
            Documento DocumentoModificado = null;
            string sql = "UPDATE documento SET nombre=@nombre, direccion=@direccion WHERE codigo=@codigo";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    //com.Parameters.Add(new SqlParameter("@idCliente", clienteAModificar.idCliente));
                    com.Parameters.Add(new SqlParameter("@ruc", documentoAModificar.ruc));
                    com.Parameters.Add(new SqlParameter("@numero_documento", documentoAModificar.numero_documento));
                    com.Parameters.Add(new SqlParameter("@tipo_documento", documentoAModificar.tipo_documento));
                    com.ExecuteNonQuery();
                }
            }
            DocumentoModificado = Obtener(documentoAModificar.numero_documento);
            return DocumentoModificado;
        }

        //        public void Eliminar(Cliente clienteAEliminar)
        public void Eliminar(string codigo)
        {
            string sql = "DELETE FROM t_cliente WHERE codigo=@codigo";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", codigo));
                    com.ExecuteNonQuery();
                }
            }
        }

        public List<Documento> listar()
        {
            List<Documento> documentosEncontrados = new List<Documento>();
            Documento documentoEncontrado = default(Documento);
            string sql = "SELECT * FROM documento";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            documentoEncontrado = new Documento()
                            {
                                ruc = (string)resultado["ruc"],
                                numero_documento = (string)resultado["numero_documento"],
                                tipo_documento = (string)resultado["tipo_documento"],
                                fecha_emision = (string)resultado["fecha_emision"],
                                fecha_vencimiento = (string)resultado["fecha_vencimiento"],
                                moneda = (string)resultado["moneda"],
                                glosa = (string)resultado["glosa"],
                                importe = (string)resultado["importe"],
                                estado = (string)resultado["estado"],

                            };
                            documentosEncontrados.Add(documentoEncontrado);
                        }
                    }
                }
            }
            return documentosEncontrados;
        }

    }
}
