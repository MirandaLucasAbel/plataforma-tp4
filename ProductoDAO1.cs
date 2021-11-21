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

        public ProductoDAO1(MyContext contexto)
        {
            this.contexto = contexto;
        }

        public Producto get(int id)
        {
            Producto producto = new Producto();
            try
            {
                this.contexto = new MyContext();
                this.contexto.categorias.Load();

                producto = this.contexto.producto.Where(P => (P.id == id)).FirstOrDefault();
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
            this.contexto = new MyContext();
            this.contexto.producto.Load();

            foreach (Producto P in this.contexto.producto)
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

        public bool insert(string nombre, double precio, int cantidad, int id_categoria)
        {
            try
            {
                //conseguir la categoria para insertar
                this.contexto.categorias.Load();
                this.contexto.producto.Load();
                List<Categoria> categorias;
                CategoriaDAO1 daoCateg = new CategoriaDAO1(this.contexto);
                categorias = daoCateg.getAll();

                int id = this.contexto.producto.OrderByDescending(u => u.id).FirstOrDefault().id;
                Categoria categoria = this.contexto.categorias.Where(C => (C.categoria_id == id_categoria)).FirstOrDefault();

                Producto producto = new Producto(++id,nombre,precio,cantidad,categoria);
                this.contexto.producto.Add(producto);
                this.contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool update(int id, string nombreProd, double precioProd, int cantProd,int idCateg )
        {
            bool salida = false;
            foreach (Producto p in this.contexto.producto)
                if (p.id == id)
                {
                    p.nombre = nombreProd;
                    p.precio = precioProd;
                    p.cantidad = cantProd;
                    p.categoria.categoria_id = idCateg; //revisar
                    salida = true;
                }
            if (salida)
                this.contexto.SaveChanges();
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
                foreach (Producto p in this.contexto.producto)
                    if (p.id == id)
                    {
                        this.contexto.producto.Remove(p);
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
