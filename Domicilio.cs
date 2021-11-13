using System;
using System.Collections.Generic;
using System.Text;

namespace Clase7
{
    class Domicilio
    {
        public int id { get; set; }
        public string calle { get; set; }
        public int altura { get; set; }
       // public Usuario_ejemplo user { get; set; }
        public int num_usr { get; set; }
        public Domicilio() { }

        public override string ToString()
        {
            return calle+", "+altura;
        }
    }
}
