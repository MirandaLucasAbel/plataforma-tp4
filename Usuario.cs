﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace tp1
{

    public class Usuario
    {
        public int id { get; set; }
        public int dni { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string tipo { get; set; }
        public string cuil { get; set; }
        [NotMapped]
        public Carro MiCarro { get; set; }


        public Usuario(int id, int dni, string nombre, string apellido, string mail, string password, string tipo, string cuilCuit)
        {
            this.id = id;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.mail = mail;
            this.password = password;
            this.tipo = tipo;
            this.cuil = cuilCuit;
            this.MiCarro = new Carro();
        }

        public Usuario()
        {
        }

        public string toString()
        {
            return "Usuario: " + this.id + " - Dni " + this.dni + " - Nombre " + this.nombre + " - Apellido " + this.apellido + " - Mail " + this.mail + " - Cuil/Cuit:" + this.cuil + " - Tipo de Usuario:" + this.tipo; // " - Carro :" + MiCarro.toString();
        }
    }
}