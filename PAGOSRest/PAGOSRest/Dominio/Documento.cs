using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PAGOSRest.Dominio
{
    [DataContract]
    public class Documento
    {
        [DataMember]
        public string ruc { get; set; }

        [DataMember]
        public string numero_documento { get; set; }

        [DataMember]
        public string tipo_documento { get; set; }

        [DataMember]
        public DateTime fecha_emision { get; set; }

        [DataMember]
        public DateTime fecha_vencimiento { get; set; }

        [DataMember]
        public string moneda { get; set; }

        [DataMember]
        public string glosa { get; set; }

        [DataMember]
        public decimal importe { get; set; }

        [DataMember]
        public string estado { get; set; }
        //

    }
}