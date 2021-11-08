using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;

namespace dao
{
    class CategoriaDAO1 : DataBaseConfig
    {
        private string tabla = "categorias";

        public CategoriaDAO1()
        {

        }

        public List<Categoria> getAll()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                string sql = $"use [ecommerce-plataforma]; select id, nombre from { tabla}; ";
                SqlDataReader data = ejecutarQuery(sql);

                Categoria categoria = null;
                int id;
                string nombre;

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());
                    nombre = (data.GetValue(1).ToString());

                    categoria = new Categoria(id, nombre);
                    categorias.Add(categoria);
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

            return categorias;
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
