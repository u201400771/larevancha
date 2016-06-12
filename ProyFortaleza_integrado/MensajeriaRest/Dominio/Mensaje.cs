using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
// Dominio
namespace MensajeriaRest.Dominio
{
    public class Mensaje
    {
        [DataMember]
        public string NUMERO_CHEQUE { get; set; }
    }
}