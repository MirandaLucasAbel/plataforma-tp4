using System;

using Slc_Mercado;
using System.IO;

using System.Collections.Generic;
using tp1;
using config;

using System.Data.SqlClient;
using Clase7;

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

	public  List<List<string>> getAll()
    {

		List<List<string>> compras = new List<List<string>>(); 
		
		
		
		return compras;
	}



	public bool insert(int id_usuario,Carro carro)
    {

        bool flag = true;

        //int id_producto;
       // int cantidad;
		//double total;
        try
        {
            
           

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
