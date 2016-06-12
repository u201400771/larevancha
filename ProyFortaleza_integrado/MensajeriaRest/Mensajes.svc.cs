using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MensajeriaRest.Dominio;
using System.Messaging;
using MensajeriaRest.Persistencia;

namespace MensajeriaRest
{
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Mensajes.svc o Mensajes.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Mensajes : IMensajes
    {

        private MensajeDAO mensajeDAO = new MensajeDAO();

        public Mensaje RegistrarMensaje(Mensaje mensajeACrear)
        {
            Mensaje mensajeCreado = null;

            mensajeCreado = mensajeDAO.Crear(mensajeACrear);

            return mensajeCreado;
        }


        public List<Mensaje> ListarMensaje()
        {
            Mensaje mensajeACrear = null;

            string rutaCola = @".\private$\ofabian";
            if (!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Mensaje) });
            int totmsjs = cola.GetAllMessages().Count();

            for (int i = 0; i < totmsjs; i++)
            {
                Message mensaje = cola.Receive();
                mensajeACrear = new Mensaje();
                mensajeACrear = (Mensaje)mensaje.Body;
                RegistrarMensaje(mensajeACrear);
            }

            return mensajeDAO.ListarTodos();
        }
    }
}
