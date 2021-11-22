using System;


using tp1;
using config;

using Clase7;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Slc_Mercado
{
    class CarroDAO1 : DataBaseConfig
    {

        private MyContext contexto;

        public CarroDAO1(MyContext contexto)
        {
            this.contexto = contexto;
        }

        public Carro getByUserId(int userId)
        {
            
            this.contexto.carro.Load();
            this.contexto.producto_carro.Load();

            Carro carro = this.contexto.carro.Where(U => (U.usuario_id == userId)).FirstOrDefault();

            return carro;
        }

        //pasar producto_carro desde mercado
        public bool agregarAlCarrito(int id_carro, int id_producto, int cantidad)
        {
            bool flag = true;
            try
            {
                this.contexto.producto_carro.Load();
                Producto_Carro producto_Carro = this.contexto.producto_carro.Where(C => (C.id_Carro == id_carro && C.id_Producto == id_producto)).FirstOrDefault();
                if (producto_Carro == null)
                {
                    //el producto no existe, lo agrego 
                    producto_Carro = new Producto_Carro { id_Producto = id_producto, cantidad = cantidad, id_Carro = id_carro }; //conseguir id de carro de mercado
                    this.contexto.producto_carro.Add(producto_Carro);
                    this.contexto.SaveChanges();
                }
                else 
                {
                    //el producto existe le actualizo la cantidad
                    producto_Carro.cantidad = cantidad;
                    this.contexto.producto_carro.Update(producto_Carro); //preguntar si la cantidad es 0 y eliminar registro
                    this.contexto.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            return flag;
        }

        public bool update(int id_carro, int id_producto, int cantidad)
        {
  
            bool flag = true;
            try
            {
                Producto_Carro producto_Carro = this.contexto.producto_carro.Where(C => (C.id_Carro == id_carro && C.id_Producto == id_producto)).FirstOrDefault();
                producto_Carro.cantidad = cantidad;
                this.contexto.producto_carro.Update(producto_Carro);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            return flag;
        }

        public bool delete(int id)
        {
            bool flag = true;
            try
            {
                Producto_Carro pc = this.contexto.producto_carro.Where(pc => pc.id_Carro == id).FirstOrDefault();
                this.contexto.producto_carro.Remove(pc);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                
            }
            return flag;
        }

        public bool vaciarCarrito(int id_carro)
        {
            this.contexto.producto_carro.RemoveRange(contexto.producto_carro.Where(PC => PC.id_Carro == id_carro));
            this.contexto.SaveChanges();
            return false;
        }

        internal bool deleteProducto(object id_usuario, object id_producto)
        {
            //borrar producto no deseado
            return false;
        }

        public bool comprar(Carro carro)
        {
            double total = 0;
            try
            {
                
                this.contexto.producto.Load();
                foreach (var producto_carro in carro.producto_Carro)
                {
                    //hay existencias de ese producto en la tabla de producto?
                    Producto producto = this.contexto.producto.Where(P => (P.id == producto_carro.id_Producto)).FirstOrDefault();
                    if(producto.cantidad >= producto_carro.cantidad)
                    {
                        total += producto_carro.cantidad * producto_carro.producto.precio;
                        producto.cantidad = producto.cantidad - producto_carro.cantidad;
                        this.contexto.producto.Update(producto);
                    }
                    else
                    {
                        //rollback;
                        return false;
                    }
                   
                }
                this.contexto.SaveChanges();

                vaciarCarrito(carro.id);
                this.contexto.usuario_compra.Load();
                List<Usuario_Compra> usuario_compra = new List<Usuario_Compra>();
                foreach (Usuario_Compra UC in this.contexto.usuario_compra)
                {
                    usuario_compra.Add(UC);
                }
                 
                Compra compra = new Compra { total = total, usuario_compra = usuario_compra };
                this.contexto.compras.Add(compra);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

                return false;
        }
    }
}
