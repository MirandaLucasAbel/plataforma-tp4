using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp1
{
    [Serializable]
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public int cantidad { get; set; }

   
        public Categoria categoria { get; set; }
        
        public Producto() { }
        public Producto(int id, string nombre,double precio, int cantidad, Categoria categoria){

            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            this.categoria = categoria;
        
        }

        public  string toString()
        {
            return "Producto: id " + this.id + " - nombre " + this.nombre + " - precio " + this.precio + " - cantidad " + this.cantidad + " - " + this.categoria.toString();
        }
    }
}