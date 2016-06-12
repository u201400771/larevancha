using RESTCHEQUES.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RESTCHEQUES.Persistencia
{
    public class ChequeDAO
    {

        public Cheque Crear(Cheque chequeACrear)
        {
            Cheque ChequeCreado = null;
            string sql = "INSERT INTO CHEQUE_CABECERA VALUES (@NUMERO_CHEQUE, @RUC, @CODIGO_BANCO, @FECHA_EMISION, @MONEDA, @IMPORTE_TOTAL, @ESTADO)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@NUMERO_CHEQUE", chequeACrear.NUMERO_CHEQUE));
                    com.Parameters.Add(new SqlParameter("@RUC", chequeACrear.RUC));
                    com.Parameters.Add(new SqlParameter("@CODIGO_BANCO", chequeACrear.CODIGO_BANCO));
                    com.Parameters.Add(new SqlParameter("@FECHA_EMISION", chequeACrear.FECHA_EMISION));
                    com.Parameters.Add(new SqlParameter("@MONEDA", chequeACrear.MONEDA));
                    com.Parameters.Add(new SqlParameter("@IMPORTE_TOTAL", chequeACrear.IMPORTE_TOTAL));
                    com.Parameters.Add(new SqlParameter("@ESTADO", chequeACrear.ESTADO));
                    com.ExecuteNonQuery();
                }
            }
            ChequeCreado = Obtener(chequeACrear.NUMERO_CHEQUE);

            string sql2 = "INSERT INTO CHEQUE_DETALLE VALUES (@NUMERO_CHEQUE, @TIPO_DOCUMENTO, @NUMERO_DOCUMENTO)";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql2, con))
                {
                    com.Parameters.Add(new SqlParameter("@NUMERO_CHEQUE", chequeACrear.NUMERO_CHEQUE));
                    com.Parameters.Add(new SqlParameter("@TIPO_DOCUMENTO", chequeACrear.TIPO_DOCUMENTO));
                    com.Parameters.Add(new SqlParameter("@NUMERO_DOCUMENTO", chequeACrear.NUMERO_DOCUMENTO));
                    com.ExecuteNonQuery();
                }
            }
            return ChequeCreado;
        }

        public Cheque Obtener(string NUMERO_CHEQUE)
        {
            Cheque ChequeEncontrado = null;
            string sql = "SELECT * FROM CHEQUE_CABECERA WHERE NUMERO_CHEQUE = @NUMERO_CHEQUE";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("NUMERO_CHEQUE", NUMERO_CHEQUE));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            ChequeEncontrado = new Cheque()
                            {
                                NUMERO_CHEQUE = (string)resultado["NUMERO_CHEQUE"],
                                RUC = (string)resultado["RUC"],
                                CODIGO_BANCO = (string)resultado["CODIGO_BANCO"],
                                FECHA_EMISION = (string)resultado["FECHA_EMISION"],
                                MONEDA = (string)resultado["MONEDA"],
                                IMPORTE_TOTAL = (decimal)resultado["IMPORTE_TOTAL"],
                                ESTADO = (string)resultado["ESTADO"],


                            };
                        }
                    }
                }
            }
            return ChequeEncontrado;
        }



        public Cheque Modificar(Cheque chequeAModificar)
        {
            Cheque ChequeModificado = null;
            string sql = "UPDATE CHEQUE_CABECERA SET NUMERO_CHEQUE=@NUMERO_CHEQUE,RUC=@RUC,CODIGO_BANCO=@CODIGO_BANCO,FECHA_EMISION=@FECHA_EMISION,MONEDA=@MONEDA,IMPORTE_TOTAL=@IMPORTE_TOTAL,ESTADO=@ESTADO WHERE NUMERO_CHEQUE=@NUMERO_CHEQUE";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@NUMERO_CHEQUE", chequeAModificar.NUMERO_CHEQUE));
                    com.Parameters.Add(new SqlParameter("@RUC", chequeAModificar.RUC));
                    com.Parameters.Add(new SqlParameter("@CODIGO_BANCO", chequeAModificar.CODIGO_BANCO));
                    com.Parameters.Add(new SqlParameter("@FECHA_EMISION", chequeAModificar.FECHA_EMISION));
                    com.Parameters.Add(new SqlParameter("@MONEDA", chequeAModificar.MONEDA));
                    com.Parameters.Add(new SqlParameter("@IMPORTE_TOTAL", chequeAModificar.IMPORTE_TOTAL));
                    com.Parameters.Add(new SqlParameter("@ESTADO", chequeAModificar.ESTADO));
                    com.ExecuteNonQuery();
                }
            }
            ChequeModificado = Obtener(chequeAModificar.NUMERO_CHEQUE);
            return ChequeModificado;
        }

        public void Eliminar(string NUMERO_CHEQUE)
        {

            string sql = "DELETE FROM CHEQUE_DETALLE WHERE NUMERO_CHEQUE = @NUMERO_CHEQUE";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@NUMERO_CHEQUE", NUMERO_CHEQUE));
                    com.ExecuteNonQuery();
                }
            }


            sql = "DELETE FROM CHEQUE_CABECERA WHERE NUMERO_CHEQUE = @NUMERO_CHEQUE";
            using (SqlConnection con = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@NUMERO_CHEQUE", NUMERO_CHEQUE));
                    com.ExecuteNonQuery();
                }
            }

        }

        public List<Cheque> listar()
        {
            List<Cheque> chequesEncontrados = new List<Cheque>();
            Cheque chequeEncontrado = default(Cheque);
            string sql = "SELECT * FROM CHEQUE_CABECERA";
            using (SqlConnection conexion = new SqlConnection(ConexionUtil.CadenaClientes))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            chequeEncontrado = new Cheque()
                            {
                                NUMERO_CHEQUE = (string)resultado["NUMERO_CHEQUE"],
                                RUC = (string)resultado["RUC"],
                                CODIGO_BANCO = (string)resultado["CODIGO_BANCO"],
                                FECHA_EMISION = (string)resultado["FECHA_EMISION"],
                                MONEDA = (string)resultado["MONEDA"],
                                IMPORTE_TOTAL = (decimal)resultado["IMPORTE_TOTAL"],
                                ESTADO = (string)resultado["ESTADO"],

                            };
                            chequesEncontrados.Add(chequeEncontrado);
                        }
                    }
                }
            }
            return chequesEncontrados;
        }
    }
}