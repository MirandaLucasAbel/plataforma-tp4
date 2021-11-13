using System;
using System.Collections.Generic;
using dao;
using Slc_Mercado;

namespace tp1

{

    
    public class Carro
    {
        public int carro_id { get; set; }
        public int usuario_id { get; set; }
        public Dictionary<int, int> productos { get; set; }

        public Carro() {
            this.carro_id = carro_id;
            this.productos = new Dictionary<int, int>();
        }
        public Carro(int id) {
            this.carro_id = id;
            this.productos = new Dictionary<int, int>();
        }

        public bool agregarProducto(int id_usuario,int id_producto, int cantidad) {
            CarroDAO1 dao = new CarroDAO1();
            if ( this.productos.ContainsKey(id_producto))
            {
                this.productos[id_producto] = this.productos[id_producto] + cantidad;
              
                dao.update(id_usuario, id_producto, cantidad);
            }
            else
            {
                productos.Add(id_producto, cantidad);
                dao.insert(id_usuario, id_producto, cantidad);
            }
            return true;
        }

        internal decimal calcularTotal()
        {
            decimal total = 0;
            foreach (KeyValuePair<int, int> prod in productos)
            {
                ProductoDAO1 dao = new ProductoDAO1();
                Producto prodAux = dao.get(prod.Key);
                total += (prodAux.precio * prod.Value);
            }

            return total;
        }

        public bool sacarProductos(int id_producto, int cantidad) {
            if (productos.ContainsKey(id_producto))
            {
                if (productos[id_producto] <= cantidad)
                {
                    productos.Remove(id_producto);
                    //llamar al dao
                }
                else
                {
                    productos[id_producto] -= cantidad;
                }
                return true;
            }
            else
                return false;

            /*foreach (KeyValuePair<Producto, int> prod in productos)
            {
                if (prod.Key == producto) {
                    if (prod.Value <= cantidad)
                    {
                        productos.Remove(producto);
                    }
                    else
                    {
                        this.productos[prod.Key] = prod.Value - cantidad;
                    }
                    return true;
                }
            }
            return false;*/
        }
        internal int cantidadArticulos()
        {
            int cant = 0;
            foreach (KeyValuePair<int, int> prod in productos)
            {
                cant += prod.Value;
            }

            return cant;
        }

        public string toString()
        {
            //return "Carro: " + this.id + " - " + this.productos.ToString();
            string aux = "";
            foreach (KeyValuePair<int, int> prod in productos)
            {
                ProductoDAO1 dao = new ProductoDAO1();
                Producto prodAux = dao.get(prod.Key);
                aux += prodAux.nombre + " " + prod.Value.ToString() + "u * $" + prodAux.precio + "\n";
            }
            aux += "Total a pagar: ";
            aux += calcularTotal().ToString();

            return aux;
        }

        /*
        private Producto buscarProducto(int id_producto)
        {
            if (productos.ContainsKey(id_producto))
            {
                return id_producto;
            }
            return null;

        */

        /*foreach (KeyValuePair<Producto, int> prod in productos)
        {
            if (prod.Key == producto)
            {
                return prod.Key;
            }
        }
        return null;*/

    }

    /*
        public void mostrarTodosLosProductos()
        {
            foreach (KeyValuePair<int, int> prod in productos)
            {
                prod.Key.ToString();
            }
        }
    */


   
 
    
    
       
    
    }
    

