using System;

using Slc_Mercado;
using System.IO;

using System.Collections.Generic;
using tp1;



using Clase7;
using Microsoft.EntityFrameworkCore;

public class CompraDAO1
{
    private MyContext contexto;
    public CompraDAO1(MyContext contexto)
    {
        this.contexto = contexto;
    }
   

    public Compra get(int id_usuario)
    {
		return new Compra(id_usuario,null,null);

    }

	public  List<Compra> getAll()
    {
        List<Compra> compras = new List<Compra>();
        try
        {
            this.contexto.compras.Load();


            foreach(Compra compra in this.contexto.compras)
            {
                compras.Add(compra);
            }

           
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
		
		
		
		return compras;
	}



	

	public bool delete(int id)
    {
        try
        {
            bool salida = false;
            foreach (Compra c in this.contexto.compras)
                if (c.id == id)
                {
                    this.contexto.compras.Remove(c);
                    salida = true;
                }
            if (salida)
                this.contexto.SaveChanges();
            return salida;
        }
        catch (Exception)
        {
            return false;
        }
    }



	
}
