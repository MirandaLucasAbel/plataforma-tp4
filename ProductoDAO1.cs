using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;

using Clase7;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dao
{
    class ProductoDAO1 : DataBaseConfig
    {

        
       
        private MyContext contexto;

        public ProductoDAO1()
        {
        }

        public Producto get(int id)
        {
            Producto producto = new Producto();
            try
            {
                contexto = new MyContext();
                contexto.categorias.Load();

                producto = contexto.producto.Where(P => (P.id == id)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public bool insert(string nombre, decimal precio, int cantidad, int id_categoria)
        {
            try
            {
                //conseguir la categoria para insertar
                Producto producto = new Producto(nombre,precio,cantidad,null);
                contexto.producto.Add(producto);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool update(int id, string nombreProd,decimal precioProd, int cantProd,int idCateg )
        {
            bool salida = false;
            foreach (Producto p in contexto.producto)
                if (p.id == id)
                {
                    p.nombre = nombreProd;
                    p.precio = precioProd;
                    p.cantidad = cantProd;
                    p.categoria.id = idCateg; //revisar
                    salida = true;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
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
            try
            {
                bool salida = false;
                foreach (Producto p in contexto.producto)
                    if (p.id == id)
                    {
                        contexto.producto.Remove(p);
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
