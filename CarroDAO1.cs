using System;

using System.IO;

using System.Collections.Generic;
using tp1;
using config;
using System.Data.SqlClient;

namespace Slc_Mercado
{
    class CarroDAO1 : DataBaseConfig
    {
        
        private string tabla = "carro";

        public CarroDAO1()
        {
        }

        public List<Carro> getAll()
        {
            List<Carro> carro = new List<Carro>();

            try
            {
                string sql = $"use[ecommerce - plataforma]; select id from { tabla}; ";
                SqlDataReader data = ejecutarQuery(sql);

                //Carro carro = null;
                int id;
                //VER QUE OTROS CAMPOS TIENE

                while (data.Read())
                {
                    id = Int32.Parse(data.GetValue(0).ToString());

                    //carro = new Carro(id);
                   //carro.Add(carro);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Archivo no encontrado");
            }

            finally
            {
                conexion.Close();
            }

            return carro;

        }

        public Carro getByUserId(int userId)
        {
            Carro carro = new Carro();
            return carro;
        }

        public bool insert(int id_usuario, int id_producto, int cantidad)
        {
            bool flag = true;

            try
            {

                string sql = $"use [ecommerce-plataforma]; insert into carro(id_usuario,id_producto,cantidad) values({id_usuario},{id_producto},{cantidad});";
                SqlDataReader data = ejecutarQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }

        public bool update(int id_usuario, int id_producto, int cantidad)
        {
  
            bool flag = true;

            try
            {

                string sql = $"use [ecommerce-plataforma];update carro set cantidad = {cantidad} where id_usuario = {id_usuario} and id_producto = {id_producto}";
                SqlDataReader data = ejecutarQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }

        public bool delete(int id)
        {
            bool flag = true;

            try
            {
                string sql = $"use [ecommerce-plataforma];delete from carro where id_usuario = {id}";
                SqlDataReader data = ejecutarQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }

        internal bool deleteProducto(object id_usuario, object id_producto)
        {
            bool flag = true;

            try
            {

                string sql = $"use [ecommerce-plataforma];delete from carro where id_usuario = {id_usuario} and id_producto = {id_producto}";
                SqlDataReader data = ejecutarQuery(sql);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }
            finally
            {
                conexion.Close();
            }
            return flag;
        }
    }
}
