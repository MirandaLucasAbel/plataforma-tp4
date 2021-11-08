using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;
using System;
using System.Data.SqlClient;

namespace dao
{
	public class UsuarioDAO1 : DataBaseConfig
	{
	
		private string tabla = "usuarios";

		public UsuarioDAO1()
		{
		}

		public  Usuario getUserById(int userId)
        {
			string sql = $"use [ecommerce-plataforma]; select id,nombre,apellido,dni,mail,password,tipo,cuil from {tabla} where id = {userId.ToString()};";
			SqlDataReader data = ejecutarQuery(sql);

			Usuario usuario = null;
			int id;
			string nombre;
			string apellido;
			int dni;
			string mail;
			string password;
			string tipo;
			string cuil;

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
				nombre = (data.GetValue(1).ToString());
				apellido = (data.GetValue(2).ToString());
				dni = Int32.Parse(data.GetValue(3).ToString());
				mail = (data.GetValue(4).ToString());
				password  = (data.GetValue(5).ToString());
				tipo = data.GetValue(6).ToString();
				cuil = data.GetValue(7).ToString();


				usuario = new Usuario(id, dni, nombre, apellido, mail, password, tipo, cuil);
			}
			conexion.Close();
			return usuario;

		}

		public Usuario getUsuarioByDni(int dni,string password)
        {
			Usuario usuario = new Usuario();
			try
            {
				string sql = $"use [ecommerce-plataforma]; select id,nombre,apellido,dni,mail,password,tipo,cuil from {tabla} where dni = {dni.ToString()} and password = '{password}';";
				SqlDataReader data = ejecutarQuery(sql);

				
				int id;
				string nombre;
				string apellido;
				//int dni;
				string mail;
				//string password;
				string tipo;
				string cuil;

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
					nombre = (data.GetValue(1).ToString());
					apellido = (data.GetValue(2).ToString());
					dni = Int32.Parse(data.GetValue(3).ToString());
					mail = (data.GetValue(4).ToString());
					password = (data.GetValue(5).ToString());
					tipo = data.GetValue(6).ToString();
					cuil = data.GetValue(7).ToString();


					usuario = new Usuario(id, dni, nombre, apellido, mail, password, tipo, cuil);
				}
			}
			catch(Exception ex)
            {
				Console.WriteLine(ex.Message);
				usuario = null;
            }
            finally
            {
				conexion.Close();
			}
			
			
			return usuario;
		}

		public  List<Usuario> getAll()
		{
			
			List<Usuario> usuarios = new List<Usuario>();
			try
			{
				string sql = $"use [ecommerce-plataforma]; select id,nombre,apellido,dni,mail,password,tipo,cuil from {tabla};";
				SqlDataReader data = ejecutarQuery(sql);

				Usuario usuario = null;
				int id;
				string nombre;
				string apellido;
				int dni;
				string mail;
				string password;
				string tipo;
				string cuil;

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
					nombre = (data.GetValue(1).ToString());
					apellido = (data.GetValue(2).ToString());
					dni = Int32.Parse(data.GetValue(3).ToString());
					mail = (data.GetValue(4).ToString());
					password = (data.GetValue(5).ToString());
					tipo = data.GetValue(6).ToString();
					cuil = data.GetValue(7).ToString();


					usuario = new Usuario(id, dni, nombre, apellido, mail, password, tipo, cuil);
					usuarios.Add(usuario);
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
				usuarios = null;
			}
            finally
            {
				conexion.Close();
			}
			
			return usuarios;
		}

		public bool insert(string nombre,string apellido, string password, int dni,string mail,string tipo,string cuilCuit)
        {
			bool flag = true;
			try
			{
				string sql = $"use [ecommerce-plataforma]; insert into {tabla}(nombre,apellido,dni,mail,password,tipo,cuil) values('{nombre}','{apellido}','{dni}','{mail}','{password}','{tipo}','{cuilCuit}');";
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

		public bool update(int id, int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
		{
			bool flag = true;
			try
			{
				string sql = $"use [ecommerce-plataforma]; update usuarios set nombre = '{nombre}', apellido = '{apellido}', dni = {dni},mail = '{mail}',password = '{password}', tipo='{tipo}',cuil = '{cuit_Cuil}' where id = {id};";
				SqlDataReader data = ejecutarQuery(sql);


				ejecutarQuery(sql);

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
				string sql = $"use [ecommerce-plataforma]; delete from {tabla} where id = {id};";
				SqlDataReader data = ejecutarQuery(sql);

				ejecutarQuery(sql);

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

		public  bool saveAll(List<Usuario> usuario)
		{

			//revisar
			return false;
		}

	}

}
