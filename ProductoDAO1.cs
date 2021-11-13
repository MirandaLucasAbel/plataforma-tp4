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
    class ProductoDAO1 : DataBaseConfig
    {

        
        private string tabla = "producto";
        private MyContext contexto;

        public ProductoDAO1()
        {
        }

        public Producto get(int id)
        {
            Producto producto = null;

            try
            {
                string sql = $"use [ecommerce-plataforma]; select p.id, p.nombre, precio, cantidad, c.id, c.nombre from { tabla}  p inner join categorias c on p.id_categoria = c.id where p.id = {id}; ";
                SqlDataReader data = ejecutarQuery(sql);

               
                string nombre;
                double precio;
                int cantidad;
                int categoria;
                string nombreCateg;
                Categoria categ;

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());
                    nombre = (data.GetValue(1).ToString());
                    precio = Double.Parse(data.GetValue(2).ToString());
                    cantidad = Int32.Parse(data.GetValue(3).ToString());
                    categoria = Int32.Parse(data.GetValue(4).ToString());
                    nombreCateg = (data.GetValue(5).ToString());


                    categ = new Categoria(id, nombreCateg); //revisar

                    producto = new Producto(id, nombre, precio, cantidad, categ);// categoria); //revisar
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("archivo no encontrado");
                producto = null;
            }

            finally
            {
                conexion.Close();
            }

            return producto;
        }

        public List<Producto> getAll()
        {
            List<Producto> productos = new List<Producto>();

        
            try
            {
                contexto = new MyContext();
                contexto.producto.Load();

                foreach (Producto P in contexto.producto)
                    productos.Add(P);

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

        internal List<Producto> getActivos()
        {
            throw new NotImplementedException();
        }

        public bool insert(string nombre, double precio, int cantidad, int id_categoria)
        {
            bool flag = true;

            try
            {

                string sql = $"use [ecommerce-plataforma]; insert into {tabla} (nombre, precio, cantidad, id_categoria) values ('{nombre}','{precio}','{cantidad}','{id_categoria}');";
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

        public bool update(int id, string nombreProd,double precioProd, int cantProd,int idCateg )
        {
            bool flag = true;
            try
            {
                string sql = $"use[ecommerce - plataforma]; update productos set nombre = '{nombreProd}', precio = '{precioProd}', cantidad = '{cantProd}', categoria = '{idCateg}' where id = '{id};";
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

        internal List<Producto> getByPrice(string query)
        {
            throw new NotImplementedException();
        }

        internal List<Producto> getByName(string query)
        {
            throw new NotImplementedException();
        }

        internal List<Producto> getbyCateg(int id_Categoria)
        {
            throw new NotImplementedException();
        }

        public bool delete (int id)
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

        internal Producto getAllByName(string nombre)
        {
            throw new NotImplementedException();
        }

        internal int getCantidad(int id)
        {
            throw new NotImplementedException();
        }
    }
}
