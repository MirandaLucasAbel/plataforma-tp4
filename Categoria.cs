using System;
using System.Collections.Generic;

namespace tp1
{
    [Serializable]

 
    public class Categoria
    {
         public int categoria_id { get; set; }
        public string nombre { get; set; }

        public ICollection<Producto> productos { get; set; }


        public Categoria() { }
public Categoria(int id, string nombre)
        {
            this.categoria_id = id;
            this.nombre = nombre;
        }

      public  Categoria(string nombre)
        {
            this.nombre = nombre;
        }

       public string  toString()
        {
            return "Categoria: " + this.categoria_id + " - Nombre: " + this.nombre;
        }
    }
}
