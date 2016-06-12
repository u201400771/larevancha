using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Prurbas de carga
namespace RESTTest
{
    class Cheque
    {
        public string CODIGO_BANCO { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_EMISION { get; set; }
        public decimal IMPORTE_TOTAL { get; set; }
        public string MONEDA { get; set; }
        public string NUMERO_CHEQUE { get; set; }
        public string NUMERO_DOCUMENTO { get; set; }
        public string RUC { get; set; }
        public string TIPO_DOCUMENTO { get; set; }
    }
}
