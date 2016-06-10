using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BE;

/// <summary>
/// Descripción breve de BLBanco
/// </summary>
public class BLBanco
{
	public BLBanco()
	{
		
	}


    public List<BE.MAESTRO_BANCOS> listar_Bancos(string nombres)
    {
        return new DAOBanco().listar_Bancos(nombres);
    }

    public MAESTRO_BANCOS traer_banco(string codigo)
    {
        return new DAOBanco().traer_banco(codigo);
    }

    public int eliminar_banco(string codigo)
    {
        return new DAOBanco().eliminar_banco(codigo);
    }

    public string grabar_Banco(MAESTRO_BANCOS obj)
    {
        return new DAOBanco().grabar_Banco(obj);
    }

    public string actualizar_Banco(MAESTRO_BANCOS obj)
    {
        return new DAOBanco().actualizar_Banco(obj);
    }
}