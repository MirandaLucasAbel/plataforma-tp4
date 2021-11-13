using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;
using Clase7;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dao
{
    class CategoriaDAO1 : DataBaseConfig
    {
        private MyContext contexto;

        public CategoriaDAO1(){}

        public List<Categoria> getAll()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
                contexto = new MyContext();
                contexto.categorias.Load();

                foreach (Categoria C in contexto.categorias)
                    categorias.Add(C);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                categorias = null;
            }
            finally
            {
                conexion.Close();
            }

            return categorias;
        }

        public bool insert(string nombre)
        {

            try
            {
                Categoria categoria = new Categoria(nombre);
                contexto.categorias.Add(categoria);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool update(int id,string nombre)
        {
            bool salida = false;
            foreach (Categoria c in contexto.categorias)
                if (c.id == id)
                {
                    c.nombre = nombre;
                    contexto.categorias.Update(c);
                    salida = true;
                }
            if (salida)
                contexto.SaveChanges();
            return salida;
        }

        public bool delete(int id)
        {
            try
            {
                bool salida = false;
                foreach (Categoria c in contexto.categorias)
                    if (c.id == id)
                    {
                        contexto.categorias.Remove(c);
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }

        internal Categoria get(int id)
        {

            Categoria categoria = new Categoria();
            try
            {
                contexto = new MyContext();
                contexto.categorias.Load();

                categoria = contexto.categorias.Where(C => (C.id == id )).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                categoria = null;
            }
            finally
            {
                conexion.Close();
            }
            return categoria;
        }
    }
}
