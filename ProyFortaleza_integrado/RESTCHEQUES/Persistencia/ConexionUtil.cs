using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTCHEQUES.Persistencia
{
    public class ConexionUtil
    {

        public static string CadenaClientes
        {
            get
            {
                return "Data Source=CHRISTOPHER\\CHRIS;Initial Catalog=TRABAJO_DSD;Integrated Security=SSPI;";
            }
        }
    }
}