using MensajeriaRest.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MensajeriaRest.Persistencia
{
    public class MensajeDAO
    {
        public Mensaje Crear(Mensaje mensajeACrear)
        {
            Mensaje mensajeCreado = null;
            //            string sql = "INSERT INTO tbl_pedido VALUES (@dni, @nombre)";
            string sql = "UPDATE CHEQUE_CABECERA SET ESTADO = 'FIR' WHERE NUMERO_CHEQUE = @NUMERO_CHEQUE";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@NUMERO_CHEQUE", mensajeACrear.NUMERO_CHEQUE));
                    com.ExecuteNonQuery();
                }
            }
            //            pedidoCreado = Obtener(pedidoACrear.dni);
            return mensajeCreado;
        }

        public  List<Mensaje> ListarTodos()
        {
            /* List<Mensaje> mensajeEncontrados = new List<Mensaje>();
             Mensaje pedidoEncontrado = null;
             string sql = "SELECT numero_cheque FROM cabecera_cheque";
             using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
             {
                 con.Open();
                 using (SqlCommand com = new SqlCommand(sql, con))
                 {
                     using (SqlDataReader resultado = com.ExecuteReader())
                     {
                         if (resultado.Read())
                         {
                             pedidoEncontrado = new Mensaje()
                             {
                                 dni = (string)resultado["numero_cheque"]

                             };
                             pedidosEncontrados.Add(pedidoEncontrado);
                         }
                     }
                 }
             }*/
            return null;//pedidosEncontrados;
        }

    }
}