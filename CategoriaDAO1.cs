using System;

using System.IO;

using System.Collections.Generic;
using tp1;

using System.Data.SqlClient;
using Clase7;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace dao
{
    class CategoriaDAO1
    {
        private MyContext contexto;

        public CategoriaDAO1(MyContext contexto){
            this.contexto = contexto;
        }

        public List<Categoria> getAll()
        {
            List<Categoria> categorias = new List<Categoria>();

            try
            {
        
                this.contexto.categorias.Load();

                foreach (Categoria C in this.contexto.categorias)
                    categorias.Add(C);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                categorias = null;
            }
            finally
            {
               
            }

            return categorias;
        }

        public bool insert(string nombre)
        {

            try
            {
                Categoria categoria = new Categoria(nombre);
                contexto.categorias.Load();
                List<Categoria> categorias = this.contexto.categorias.ToList();
                categorias.Add(categoria);
                contexto.categorias.Add(categoria);
                this.contexto.SaveChanges();
               
               // this.contexto.SaveChanges();
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
            foreach (Categoria c in this.contexto.categorias)
                if (c.categoria_id == id)
                {
                    c.nombre = nombre;
                    this.contexto.categorias.Update(c);
                    salida = true;
                }
            if (salida)
                this.contexto.SaveChanges();
            return salida;
        }

        public bool delete(int id)
        {
            try
            {
                bool salida = false;
                foreach (Categoria c in this.contexto.categorias)
                    if (c.categoria_id == id)
                    {
                        this.contexto.categorias.Remove(c);
                        salida = true;
                    }
                if (salida)
                    this.contexto.SaveChanges();
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
          
                this.contexto.categorias.Load();

                categoria = this.contexto.categorias.Where(C => (C.categoria_id == id )).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                categoria = null;
            }
            finally
            {
               
            }
            return categoria;
        }
    }
}
