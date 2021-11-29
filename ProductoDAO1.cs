using System;

using System.IO;

using System.Collections.Generic;
using tp1;


using Clase7;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dao
{
    class ProductoDAO1
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
             
            }
            return producto;
        }
    

        public List<Producto> getAll()
        {
            List<Producto> productos = new List<Producto>();

        
            try
            {
            
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
              
                CategoriaDAO1 daoCateg = new CategoriaDAO1(this.contexto);
                
                Categoria categoria = this.contexto.categorias.Where(C => (C.categoria_id == id_categoria)).FirstOrDefault();

                Producto producto = new Producto(nombre,precio,cantidad,categoria);
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

        //pasar a EF
        public bool update(int id, string nombreProd, double precioProd, int cantProd,int idCateg )
        {
            try
            {
                Producto producto = this.contexto.producto.Where(P => (P.id == id)).FirstOrDefault();
                producto.precio = precioProd;
                producto.cantidad = cantProd;
                producto.id_categoria = idCateg;
                producto.nombre = nombreProd;
                this.contexto.producto.Update(producto);
                this.contexto.SaveChanges();
                return true;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
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
