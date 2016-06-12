using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RESTCHEQUES.Dominio;
using RESTCHEQUES.Persistencia;
using System.ServiceModel.Web;
using System.Messaging;
using System.Net;

namespace RESTCHEQUES
{

    public class Cheques : ICheques   //Creado por Christopher Flores
    {
        private ChequeDAO ChequeDAO = new ChequeDAO();
        public Cheque CrearCheque(Cheque chequeACrear)
        {
            Cheque ChequeObtenido = ChequeDAO.Obtener(chequeACrear.NUMERO_CHEQUE);

            if (ChequeObtenido != null)
            {
                throw new WebFaultException<string>(
                    "El cliente con codigo " + chequeACrear.NUMERO_CHEQUE + " ya existe", HttpStatusCode.InternalServerError);
            }
            //return ChequeDAO.Crear(chequeACrear);

            Cheque chequeCreado = ChequeDAO.Crear(chequeACrear);


  /*          if (chequeCreado != null)

  
            {
                string postdata = "{\"NUMERO_CHEQUE\":\"" + chequeCreado.NUMERO_CHEQUE + "\" }";
                byte[] data = Encoding.UTF8.GetBytes(postdata);
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:62210/Mensajes.svc/Mensajes");
                //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:62210/Mensajes.svc/Mensajes");
                req.Method = "POST";
                req.ContentLength = data.Length;
                req.ContentType = "application/json";
                var reqStream = req.GetRequestStream();
                reqStream.Write(data, 0, data.Length);
                req.GetResponse();
            }

            catch (WebException e)
            {*/
                string rutaCola = @".\private$\ofabian";
                if (!MessageQueue.Exists(rutaCola))
                    MessageQueue.Create(rutaCola);
                MessageQueue cola = new MessageQueue(rutaCola);
                Message mensaje = new Message();
                mensaje.Label = "Nuevo Pedido";
                mensaje.Body = new Mensaje() { NUMERO_CHEQUE = chequeCreado.NUMERO_CHEQUE};
                cola.Send(mensaje);

            return chequeCreado;


        }

        public void EliminarCheque(string NUMERO_CHEQUE)
        {
            Cheque chequeEncontrado = null;
            chequeEncontrado = ObtenerCheque(NUMERO_CHEQUE);

            if (chequeEncontrado.ESTADO != "GIR")
            {
                throw new WebFaultException<string>("El cheque no existe", HttpStatusCode.NotImplemented);
            }

            ChequeDAO.Eliminar(NUMERO_CHEQUE);
        }

        public List<Cheque> ListarACheques()
        {
            return ChequeDAO.listar();
        }

        public Cheque ModificarCheque(Cheque chequeAModificar)
        {
            return ChequeDAO.Modificar(chequeAModificar);
        }

        public Cheque ObtenerCheque(string NUMERO_CHEQUE)
        {
            return ChequeDAO.Obtener(NUMERO_CHEQUE);
        }
    }
}
