using System;
using System.Collections.Generic;
using System.Text;

namespace Clase7
{
    class Pais
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public ICollection<Usuario_ejemplo> users { get; set; }
        public List<UsuarioPais> UserPais { get; set; }
        public Pais() { }

        public override string ToString()
        {
            return nombre;
        }
    }
}
