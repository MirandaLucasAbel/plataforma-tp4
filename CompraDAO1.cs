using System;

using Slc_Mercado;
using System.IO;

using System.Collections.Generic;
using tp1;
using config;

using System.Data.SqlClient;
using Clase7;
using Microsoft.EntityFrameworkCore;

public class CompraDAO1 : DataBaseConfig
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
        bool flag = true;

        try
        {

            string sql = $"use[ecommerce-plataforma]; delete from {1} where id = {id}";
            SqlDataReader data = ejecutarQuery(sql);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            flag = false;
        }
        finally
        {
            conexion.Close();
        }
        return flag;
    }



	
}
