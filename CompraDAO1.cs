using System;

using Slc_Mercado;
using System.IO;

using System.Collections.Generic;
using tp1;
using config;

using System.Data.SqlClient;

public class CompraDAO1 : DataBaseConfig
{

    private string tabla = "compra";

    public Compra get(int id_usuario)
    {
		return new Compra(id_usuario,null,null);

    }

	public  List<List<string>> getAll()
    {

		List<List<string>> compras = new List<List<string>>(); ;
		try
		{
			string sql = $"use [ecommerce-plataforma];select c.id,id_usuario, p.nombre, c.cantidad,total from compra c inner join producto p on p.id = c.id_producto;";
			SqlDataReader data = ejecutarQuery(sql);

		
			int id;
			int id_usuario;
			string nombreProducto;
			int cantidad;
			double total;

			while (data.Read())
			{
				/*Console.WriteLine(data.GetValue(0));
				Console.WriteLine(data.GetValue(1));
				Console.WriteLine(data.GetValue(2));
				Console.WriteLine(data.GetValue(3));
				Console.WriteLine(data.GetValue(4));
				Console.WriteLine(data.GetValue(5));
				Console.WriteLine(data.GetValue(6));
				Console.WriteLine(data.GetValue(7));

				Console.WriteLine("------------");
				*/

				id = Int32.Parse(data.GetValue(0).ToString());
				id_usuario = Int32.Parse (data.GetValue(1).ToString());
				nombreProducto = (data.GetValue(2).ToString());
				cantidad = Int32.Parse(data.GetValue(3).ToString());
				total = Double.Parse(data.GetValue(4).ToString());



				//usuario = new Usuario(id, dni, nombre, apellido, mail, password, tipo, cuil);
				List<string> aux = new List<string>() { id.ToString(),id_usuario.ToString(), nombreProducto.ToString(), cantidad.ToString(), total.ToString() };
				compras.Add(aux);
			}
		}
		catch (Exception ex)
		{
			/*
			//en caso de no haber datos se genera un admin y se guarda en el archivo
			Console.WriteLine("archivo no encontrado, se inicializa un objeto vacio para productos");
			usuarios = new List<Usuario>();
			usuarios.Add(new Usuario(0, 0000, "admin", "admin", "admin@gmail.com", "admin", "admin", "000"));
			usuarios.Add(new Usuario(1, 0001, "cliente", "cliente", "cliente@gmail.com", "cliente", "cliente", "001"));
			saveAll(usuarios);
			*/
			compras = null;
		}
		finally
		{
			conexion.Close();
		}

		return compras;
	}



	public bool insert(int id_usuario,Carro carro)
    {

        bool flag = true;

        int id_producto;
        int cantidad;
		double total;
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

            string sql = $"use[ecommerce-plataforma]; delete from {tabla} where id = {id}";
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
