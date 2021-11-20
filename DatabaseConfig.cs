using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace config
{
    public abstract class DataBaseConfig
    {
        protected SqlConnection conexion;
        SqlCommand command;
        SqlDataReader data;

        public DataBaseConfig()
        {
            try
            {
                //poner este config en un properties
                //string cnnString = @"data source=DESKTOP-GHUBDR4\SQLEXPRESS;initial catalog=master;trusted_connection=true";
                string cnnString = @"data source=localhost\SQLEXPRESS;initial catalog=master;trusted_connection=true";
                conexion = new SqlConnection(cnnString);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public SqlDataReader ejecutarQuery(string sql)
        {
            try
            {
    
                conexion.Open();

               // sql = "use [ecommerce-plataforma]; select * from usuarios ";
                Console.WriteLine("conexion establecida");



                command = new SqlCommand(sql, conexion);


                data = command.ExecuteReader();


           
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                data = null;
            }

           

            return data;
            
        }
    }
}
