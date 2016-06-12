using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
namespace RESTCHEQUES.Dominio
{
    [DataContract]
    public class Cheque
    {
        [DataMember]
        public string NUMERO_CHEQUE { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string CODIGO_BANCO { get; set; }
        [DataMember]
        public string FECHA_EMISION { get; set; }
        [DataMember]
        public string MONEDA { get; set; }
        [DataMember]
        public decimal IMPORTE_TOTAL { get; set; }
        [DataMember]
        public string ESTADO { get; set; }
        [DataMember]
        public string TIPO_DOCUMENTO { get; set; }
        [DataMember]
        public string NUMERO_DOCUMENTO { get; set; }


    }
}