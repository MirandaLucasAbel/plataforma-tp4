using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace tp1
{
    

    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

        public int id_categoria { get; set; }

   
        public Categoria categoria { get; set; }
        //public List<Carro> carritos { get; set; }
        public ICollection<Producto_Carro> producto_carro { get; set; }
        public Producto() { }
        public Producto(int id, string nombre, double precio, int cantidad, Categoria categoria){

            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.id_categoria = categoria.categoria_id;
        
        }

        public Producto( string nombre, double precio, int cantidad, Categoria categoria)
        {

            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.categoria = categoria;
            this.id_categoria = categoria.categoria_id;

        }

        public  string toString()
        {
            return "Producto: id " + this.id + " - nombre " + this.nombre + " - precio " + this.precio + " - cantidad " + this.cantidad + " - " + this.categoria.toString();
        }
    }
}