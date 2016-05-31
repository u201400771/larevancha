using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTTest
{
    public class Documento
    {
        public string ruc { get; set; }
        public string numero_documento { get; set; }
        public string tipo_documento { get; set; }
        public DateTime fecha_emision { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string moneda { get; set; }
        public string glosa { get; set; }
        public decimal importe { get; set; }
        public string estado { get; set; }
    }
}
