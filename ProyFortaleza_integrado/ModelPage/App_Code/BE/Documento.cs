using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Class1
/// </summary>
public class Documento
{
	public Documento()
	{}
	public string ruc { get; set; }
    public string numero_documento { get; set; }
    public string tipo_documento { get; set; }
    public string fecha_emision { get; set; }
    public string fecha_vencimiento { get; set; }
    public string moneda { get; set; }
    public string glosa { get; set; }
    public decimal importe { get; set; }
    public string estado { get; set; }
}