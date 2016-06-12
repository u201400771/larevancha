using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSD = BE.DbDSDDataContext;

/// <summary>
/// Descripción breve de DAOBanco
/// </summary>
public class DAOBanco
{
    DSD db;
	public DAOBanco()
	{
        db = new DSD();
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public List<BE.MAESTRO_BANCOS>  listar_Bancos(string nombres)
    {
        using (db)
        {
            return db.MAESTRO_BANCOS.Where(x => x.DESCRIPCION.Contains(nombres)).ToList();
           
        }


    }


    public BE.MAESTRO_BANCOS traer_banco(string codigo)
    {
        using (db)
        {
            return db.MAESTRO_BANCOS.Where(x => x.CODIGO_BANCO.Equals(codigo)).Single();
        }

        
    }

    internal int eliminar_banco(string codigo)
    {
        BE.MAESTRO_BANCOS obj = new BE.MAESTRO_BANCOS();
        using (db)
        {
            obj =  db.MAESTRO_BANCOS.Where(x => x.CODIGO_BANCO.Equals(codigo)).Single();
            db.MAESTRO_BANCOS.DeleteOnSubmit(obj);
            //db.SubmitChanges();
            return 1;
        }
    }

    internal string grabar_Banco(BE.MAESTRO_BANCOS obj)
    {

        using (db)
        {
            db.MAESTRO_BANCOS.InsertOnSubmit(obj);
            db.SubmitChanges();
            return "OK";
        }

    }

    internal string actualizar_Banco(BE.MAESTRO_BANCOS obj)
    {
        BE.MAESTRO_BANCOS obj1;
        using (db)
        {
            obj1 = db.MAESTRO_BANCOS.Where(x => x.CODIGO_BANCO.Equals(obj.CODIGO_BANCO)).Single();
            obj1.DESCRIPCION = obj.DESCRIPCION;
            db.SubmitChanges();
            return "OK";
        }
    }
}