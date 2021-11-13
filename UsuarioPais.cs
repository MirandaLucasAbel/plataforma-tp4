using System;
using System.Collections.Generic;
using System.Text;

namespace Clase7
{
    class UsuarioPais
    {
        //Acá podríamos agregar cualquier otra propiedad que necesitemos (por ejemplo el total de una compra no?) ;)
        public int id { get; set; }
        public Pais pais { get; set; }
        public int num_usr { get; set; }
     //   public Usuario_ejemplo user { get; set; }
        public UsuarioPais() { }
    }
}
