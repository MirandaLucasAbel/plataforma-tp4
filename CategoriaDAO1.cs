using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;
using Clase7;
using Microsoft.EntityFrameworkCore;

namespace dao
{
    class CategoriaDAO1 : DataBaseConfig
    {
        private string tabla = "categorias";
        private MyContext contexto;

        public CategoriaDAO1()
        {

        }

        public List<Categoria> getAll()
        {
            List<Categoria> productos = new List<Categoria>();


            try
            {
                contexto = new MyContext();
                contexto.categorias.Load();

                foreach (Categoria C in contexto.categorias)
                    productos.Add(C);

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
                productos = null;
            }
            finally
            {
                conexion.Close();
            }

            return productos;
        }

        public bool insert(string categoria)
        {
            
            bool flag = true;

            try
            {

                string sql = $"use [ecommerce-plataforma]; insert into categorias(nombre) values('{categoria}');";
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

        public bool update(int id,string nombre)
        {
            bool flag = true;

            try
            {

                string sql = $"use [ecommerce-plataforma]; update categorias set nombre = '{nombre}' where id = {id}";
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

        public bool delete(int id)
        {
    
            bool flag = true;

            try
            {

                string sql = $"use[ecommerce-plataforma]; delete from categorias where id = {id}";
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

        public bool saveAll (List<Categoria> categorias)
        {

            bool flag = true;
            foreach(Categoria c in categorias)
            {
                flag = flag && insert(c.nombre);
            }

            return true;
        }

        internal Categoria get(int id)
        {

            Categoria categoria = null;
            try
            {
                string sql = $"use[ecommerce - plataforma]; select id, nombre from { tabla}; ";
                SqlDataReader data = ejecutarQuery(sql);

             
                string nombre;

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());
                    nombre = (data.GetValue(1).ToString());

                    categoria = new Categoria(id, nombre);
 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Archivo no encontrado");
            }

            finally
            {
                conexion.Close();
            }

            return categoria;
        }
    }
}
