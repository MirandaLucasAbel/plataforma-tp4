using System;
using System.Collections.Generic;
using dao;
using Slc_Mercado;

namespace tp1

{

    
    public class Carro
    {
        public int id { get; set; }
        //public Dictionary<Producto, int> productos  { get; set; }

        //public List<Producto> productoss { get; set; }
        public int usuario_id { get; set; }
        public Usuario usuario { get; set; }
        //public List<Usuario_Carro> usuario_carro { get; set; }
        public ICollection<Producto_Carro> producto_Carro { get; set; }



        public Carro() {
            this.id = id;
           // this.productos = new Dictionary<Producto, int>();
        }
        public Carro(int id) {
            this.id = id;
           // this.productos = new Dictionary<Producto, int>();
        }

        public bool agregarProducto(int id_usuario, Producto id_producto, int cantidad) {
           // CarroDAO1 dao = new CarroDAO1();
           
            return true;
        }

        internal double calcularTotal()
        {
            double total = 0;
            

            return total;
        }

        public bool sacarProductos(Producto id_producto, int cantidad) {
           
                return false;


        }
        internal int cantidadArticulos()
        {
            

            return 0;
        }

        public string toString()
        {
          

            return "implementar";
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
    

