using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "MensageHora" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione MensageHora.svc o MensageHora.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class MensageHora : IMensageHora
    {
        public int ObtenerHora()
        {
            var hora = DateTime.Now.Hour;
            return (hora);
        }
    }
}
