using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
   public class Producto_Carro
    {
        public int id_Producto_Carro { get; set; }

        public int cantidad { get; set;}

        public int id_Carro;

        public int id_Producto;
        public Carro carro { get; set; }
        public Producto producto { get; set; }

       // public IEnumerable<Carro> carros { get; set; }

        public Producto_Carro() { }
    }
}
