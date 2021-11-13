using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;
using System;
using System.Data.SqlClient;
using Clase7; //revisar!!! revisar revisar
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Forms;

namespace dao
{
	public class UsuarioDAO1 : DataBaseConfig
	{
	

		private MyContext contexto;

		public UsuarioDAO1()
		{
		}

		public  Usuario getUserById(int userId)
        {
			Usuario usuario = new Usuario();
			try
			{


				contexto = new MyContext();
				contexto.usuarios.Load();

				usuario = contexto.usuarios.Where(U => (U.id == userId)).FirstOrDefault();

			}
			catch (Exception ex)
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



		public Usuario getUsuarioByDni(int dni,string password)
        {
			
			
			Usuario usuario = new Usuario();
			try
            {
				
				contexto = new MyContext();
				contexto.usuarios.Load();

				usuario = contexto.usuarios.Where(U =>( U.dni==dni && U.password==password)).FirstOrDefault();
				
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
				contexto = new MyContext();
				contexto.usuarios.Load();

				foreach (Usuario U in contexto.usuarios)
					usuarios.Add(U);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
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
			
			try
			{

				Usuario nuevo = new Usuario { dni = dni, nombre = nombre, mail = mail, password = password, apellido=apellido, tipo = tipo,cuil = cuilCuit };
				contexto.usuarios.Add(nuevo);
				contexto.SaveChanges();
				return true;



			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}

				
        }

		public bool update(int id, int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
		{
			bool salida = false;
			foreach (Usuario u in contexto.usuarios)
				if (u.id == id)
				{
					u.nombre = nombre;
					u.apellido = apellido;
					u.dni = dni;
					u.mail = mail;
					u.password = password;
					u.cuil = cuit_Cuil;
					u.tipo = tipo;
					contexto.usuarios.Update(u);
					salida = true;
				}
			if (salida)
				contexto.SaveChanges();
			return salida;

		}

		public bool delete(int id)
		{
			try
			{
				bool salida = false;
				foreach (Usuario u in contexto.usuarios)
					if (u.id == id)
					{
						contexto.usuarios.Remove(u);
						salida = true;
					}
				if (salida)
					contexto.SaveChanges();
				return salida;
			}
			catch (Exception)
			{
				return false;
			}

		}



		public void getUserByTest()
		{
			//metodo para prueba
			contexto = new MyContext();
			contexto.usuarios.Load();
			MessageBox.Show(contexto.usuarios.Where(U => U.id == 29).FirstOrDefault().nombre);
		}

	}

}
