using System;

using System.Collections.Generic;
using tp1;

namespace Slc_Mercado
{

    public class Compra
    {
        public int id { get; set; }
        
        //public Dictionary<Producto, int> productos;
        public double total { get; set; }

        public List<Usuario_Compra> usuario_compra { get; set; }


        public Compra() { }
        public Compra(int id,Usuario comprador, Dictionary<Producto,int> productosCarrito) {
          //  this.comprador = comprador;
           // this.productos = productosCarrito;
            foreach (KeyValuePair<Producto, int> kvp in productosCarrito)
            {
                this.total += kvp.Key.precio * kvp.Value; 

            }


        }

        public string toString()
        {
            return "ID: "+ this.id + "- Usuario: " +  "- Productos: " + "PRODUCTOS" + "- Total: " + this.total;
        }

        internal double calcularCompra()
        {
            double suma = 1;

            return suma;

        }

        public string listaDeProductos()
        {
            string aux = "";

           /* foreach (KeyValuePair<Producto, int> kvp in productos)
            {
                aux  += "id: "+kvp.Key.producto_id + " nombre: "+kvp.Key.nombre + " precio: "+kvp.Key.precio + " cantidad:"+ kvp.Value; 

            }*/
            return aux;
        }

    }


}
