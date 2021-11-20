using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
   public class Usuario_Carro
    {
        public int id { get; set; }
        public Usuario usuario {get;set;} 
        public int id_usuario { get; set; }
        
        public Carro carro { get; set; }
       // public IEnumerable<Carro> carros { get; set; }

        public Usuario_Carro() { }
    }
}
