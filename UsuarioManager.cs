using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Clase7
{
    class UsuarioManager
    {
        /*
        private MyContext contexto;
        public UsuarioManager()
        {
            inicializarAtributos();
        }

        private void inicializarAtributos()
        {
            try
            {
                //creo un contexto
                contexto = new MyContext();
                //cargo los usuarios
                contexto.usuarios.Load();
                contexto.paises.Load();
                contexto.domicilios.Load();
                contexto.identidades.Load();
                //seteo relación de paises:
                contexto.usuarios.Where(u => u.num_usr == 1).FirstOrDefault().Nacionalidad = new List<Pais>();
                contexto.usuarios.Where(u => u.num_usr == 2).FirstOrDefault().Nacionalidad = new List<Pais>();
                contexto.usuarios.Where(u => u.num_usr == 3).FirstOrDefault().Nacionalidad = new List<Pais>();
                contexto.usuarios.Where(u => u.num_usr == 4).FirstOrDefault().Nacionalidad = new List<Pais>();
                contexto.usuarios.Where(u => u.num_usr == 5).FirstOrDefault().Nacionalidad = new List<Pais>();
                contexto.usuarios.Where(u => u.num_usr == 1).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 1).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 1).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 2).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 1).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 3).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 2).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 4).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 2).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 5).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 3).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 1).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 4).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 2).FirstOrDefault());
                contexto.usuarios.Where(u => u.num_usr == 5).FirstOrDefault().Nacionalidad.Add(contexto.paises.Where(p => p.id == 3).FirstOrDefault());

                contexto.SaveChanges();

            }
            catch (Exception)
            {

            }
        }
        public Usuario_ejemplo obtenerUsuario(int dni)
        {
            return contexto.usuarios.Where(U => U.dni.numero == dni).FirstOrDefault();
        }
        public List<Usuario_ejemplo> obtenerUsuarios()
        {
            List<Usuario_ejemplo> salida = new List<Usuario_ejemplo>();
            foreach (Usuario_ejemplo u in contexto.usuarios)
                salida.Add(u);
            return salida;
        }
        public List<Pais> obtenerPaises()
        {
            List<Pais> salida = new List<Pais>();
            foreach (Pais P in contexto.paises)
                salida.Add(P);
            return salida;
        }
        public List<Domicilio> obtenerDomicilios()
        {
            List<Domicilio> salida = new List<Domicilio>();
            foreach (Domicilio D in contexto.domicilios)
                salida.Add(D);
            return salida;
        }
        public List<Usuario_ejemplo> usuariosAdministradores()
        {
            List<Usuario_ejemplo> salida = new List<Usuario_ejemplo>();
            var query = from Usuario in contexto.usuarios
                        where Usuario.esADM == true
                        select Usuario;
            foreach (Usuario_ejemplo u in query)
                salida.Add(u);
            return salida;
        }

        public bool agregarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            try
            {
                DNI identidad = new DNI { numero = Dni, tramite = Dni };
                Usuario_ejemplo nuevo = new Usuario_ejemplo { dni = identidad, nombre = Nombre, mail = Mail, password = Password, esADM = EsADM, bloqueado = Bloqueado };
                identidad.user = nuevo;
                //Si tenemos el domicilio, agregarlo a esta lista luego de inicializarla, al hacer save changes EF guarda la relación en la tabla por nosotros!!!
                nuevo.domicilios = new List<Domicilio>();
                //Idem para Nacionalidad y eso que es many to many!
                //nuevo.Nacionalidad = new List<Pais>();
                //contexto.usuarios.Add(nuevo);
                //contexto.usuarios.Add(nuevo);
                contexto.identidades.Add(identidad);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool agregarPais(int Dni, string NombrePais)
        {
            try
            {
                Usuario_ejemplo usr = contexto.usuarios.Where(u => u.dni.numero == Dni).FirstOrDefault();
                Pais pais = contexto.paises.Where(p => p.nombre.Equals(NombrePais)).FirstOrDefault();
                if (usr != null && pais != null)
                {
                    if (usr.Nacionalidad == null)
                        usr.Nacionalidad = new List<Pais>();
                    usr.Nacionalidad.Add(pais);
                    contexto.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool agregarDomicilio(int Dni, string Calle, int Altura)
        {
            try
            {
                Usuario_ejemplo usr = contexto.usuarios.Where(u => u.dni.numero == Dni).FirstOrDefault();
                
                if (usr != null)
                {
                    if (usr.domicilios == null)
                        usr.domicilios = new List<Domicilio>();
                    Domicilio dom = new Domicilio { calle = Calle, altura = Altura, user=usr};
                    usr.domicilios.Add(dom);
                    contexto.domicilios.Add(dom);
                    contexto.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            try
            {
                bool salida = false;
                foreach (Usuario_ejemplo u in contexto.usuarios)
                    if (u.dni.numero == Dni)
                    {
                        contexto.usuarios.Remove(u);
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool modificarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsADM, bool Bloqueado)
        {
            bool salida = false;
            foreach (Usuario_ejemplo u in contexto.usuarios)
                if (u.dni.numero==Dni)
                {
                    u.nombre = Nombre;
                    u.mail = Mail;
                    u.password = Password;
                    u.esADM = EsADM;
                    u.bloqueado = Bloqueado;
                    contexto.usuarios.Update(u);
                    salida = true;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        public void cerrar()
        {
            contexto.Dispose();
        }
          */
    }

}
