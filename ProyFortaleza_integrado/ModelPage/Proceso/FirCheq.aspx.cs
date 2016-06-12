using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using BE;

public partial class Proceso_FirCheq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnFirmar_Click(object sender, EventArgs e)
    {
        try
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://localhost:62210/Mensajes.svc/Mensajes");
            req.Method = "GET";
            var res = (HttpWebResponse)req.GetResponse();
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string proveedorJson = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Mensaje resultado = js.Deserialize<Mensaje>(proveedorJson);

            lblError.Text = "Nuevos cheques firmados";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}