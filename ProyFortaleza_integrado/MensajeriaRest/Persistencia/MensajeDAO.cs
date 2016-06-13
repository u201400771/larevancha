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
          
            return mensajeCreado;
        }

        public  List<Mensaje> ListarTodos()
        {

            return null;//pedidosEncontrados;
        }

    }
}