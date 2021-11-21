using System;



using System.Collections.Generic;
using tp1;
using config;


using Clase7; //revisar!!! revisar revisar
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows.Forms;

namespace dao
{
	public class UsuarioDAO1 : DataBaseConfig
	{
	

		private MyContext contexto;

		public UsuarioDAO1(MyContext contexto)
		{
			this.contexto = contexto;
		}

		public  Usuario getUserById(int userId)
        {
			Usuario usuario = new Usuario();
			try
			{


			
				this.contexto.usuarios.Load();

				usuario = this.contexto.usuarios.Where(U => (U.id == userId)).FirstOrDefault();

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
				
				
				this.contexto.usuarios.Load();

				usuario = this.contexto.usuarios.Where(U =>( U.dni==dni && U.password==password)).FirstOrDefault();
				
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
				
				this.contexto.usuarios.Load();

				foreach (Usuario U in this.contexto.usuarios)
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

				Usuario nuevo =new Usuario { dni = dni, nombre = nombre, mail = mail, password = password, apellido = apellido, tipo = tipo, cuil = cuilCuit,  usuario_compra = new List<Usuario_Compra>() };
				this.contexto.usuarios.Add(nuevo);
				this.contexto.SaveChanges();
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
			foreach (Usuario u in this.contexto.usuarios)
				if (u.id == id)
				{
					u.nombre = nombre;
					u.apellido = apellido;
					u.dni = dni;
					u.mail = mail;
					u.password = password;
					u.cuil = cuit_Cuil;
					u.tipo = tipo;
					this.contexto.usuarios.Update(u);
					salida = true;
				}
			if (salida)
				this.contexto.SaveChanges();
			return salida;

		}

		public bool delete(int id)
		{
			try
			{
				bool salida = false;
				foreach (Usuario u in this.contexto.usuarios)
					if (u.id == id)
					{
						this.contexto.usuarios.Remove(u);
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



		public void getUserByTest()
		{
			//metodo para prueba
			
			contexto.usuarios.Load();
			//MessageBox.Show(contexto.usuarios.Where(U => U.id == 29).FirstOrDefault().nombre);
		}

	}

}
