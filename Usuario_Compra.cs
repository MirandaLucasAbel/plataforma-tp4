using Slc_Mercado;
using System;
using System.Collections.Generic;
using System.Text;

namespace tp1
{
   public class Usuario_Compra
    {
        public int id { get; set; }
        public Usuario usuario {get;set;} 

        public int id_usuario { get; set; }

        public int id_compra { get; set; }


        public Compra compra { get; set; }

        

        public Usuario_Compra() { }
    }
}
