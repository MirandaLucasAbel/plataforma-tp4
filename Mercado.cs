using Slc_Mercado;
using System;
using System.Collections.Generic;
using System.Linq;
using dao;
using Clase7;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace tp1
{
    public class Mercado
    {


       private List<Categoria> categorias;

        private List<Producto> productos;

        private List<Usuario> usuarios;

        private Usuario usuario;

        private Carro carro;

        private List<Compra> compras ;

       private CategoriaDAO1 categoriaDao;
        private ProductoDAO1 productoDao;
        private UsuarioDAO1 usuarioDao;
        private CompraDAO1 compradao;
        private CarroDAO1 carroDao;

        private MyContext contexto;

        public Mercado()
            {

            this.contexto = new MyContext();

            /*daos*/
             this.categoriaDao = new CategoriaDAO1(this.contexto);
            this.compradao = new CompraDAO1(this.contexto);
            this.usuarioDao = new UsuarioDAO1(this.contexto);
            this.productoDao = new ProductoDAO1(this.contexto);
            this.carroDao = new CarroDAO1(this.contexto);
            

            //foreach (Usuario us in usuarios) us.MiCarro = new Carro();

        }

        internal void TEST()
        {
            this.usuarioDao.getUserByTest();
        }

        public List<Producto> getProductos()
        {
            return this.productoDao.getAll();
        }

        internal List<Producto> getProductosActivos()
        {
            return this.productoDao.getActivos();
        }

        public List<Compra> getCompras()
        {
            return this.compradao.getAll();
        }

        internal List<Usuario> getUsuarios()
        {
            return this.usuarioDao.getAll();
        }

        internal List<Categoria> getCategorias()
        {
            return this.categoriaDao.getAll();
        }

        internal bool modificarProductoCarro(int id_producto_carro, int cantidad)
        {

            return this.carroDao.update(id_producto_carro, cantidad);
        }

        public bool eliminarProductoCarro(int id_producto_carro)
        {
            return carroDao.delete(id_producto_carro);
        }

        internal string mostrarCarro()
        {
            //return  this.usuario.MiCarro.toString(); 
            return "";
        }

        internal int cantidadArticulos()
        {
            try
            {
                if (usuario.Micarro.producto_Carro != null)
                {
                    int cantidad = 0;
                    foreach (Producto_Carro pc in usuario.Micarro.producto_Carro)
                    {
                        cantidad += pc.cantidad;
                    }
                    return cantidad;
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }

            return 0;

        }

        public bool agregarProducto (string nombre, double precio, int cantidad, int id_Categoria)
            {

           bool flag = this.productoDao.insert(nombre, precio, cantidad, id_Categoria);
            
            return flag;
            }


        public bool modificarProducto(int id, string nombre, double precio, int cantidad, int id_Categoria)
        {

            bool flag = this.productoDao.update(id, nombre, precio, cantidad, id_Categoria);
            return flag;
        }

        public Categoria buscarCategoria(int id)
        {
            return categoriaDao.get(id);
        }
                public bool eliminarProducto (int id) {
            return this.productoDao.delete(id);
                }

        internal double calcularCompra(int idUsuario)
        {
            double total = 0; // this.usuario.MiCarro.calcularTotal();
        
            return total;
         }

        public List<Producto> buscarProductos(string query) 
            {
            List<Producto> productoPorNombre = productoDao.getByName(query);

            return productoPorNombre;
            }


            public List<Producto> buscarProductosPorPrecio (string query) //ORDENADO POR PRECIO DE MENOR A MAYOR LOS PRODUCTOS QUE CONTIENEN EN SU NOMBRE LA CADENA INGRESADA
            {

            List<Producto> listProductos = productoDao.getByPrice(query);
                return listProductos;
            }


            public List<Producto> buscarProductosPorCategoria (int id_Categoria) //ORDENADO POR NOMBRE LOS PRODUCTOS QUE PERTENCEN A LA CATEGORIA CON EL ID INGRESADO
            {
            List<Producto> listProd = productoDao.getbyCateg(id_Categoria);
                
                
            return listProd;
            }

        public Producto buscarProductoPorNombre(string nombre) //ORDENADO POR NOMBRE LOS PRODUCTOS QUE PERTENCEN A LA CATEGORIA CON EL ID INGRESADO
        {
            return productoDao.getAllByName(nombre);
        }


        public bool agregarUsuario (int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
            {
                
            int erroresDeIngreso = verificarIngresoUsuario( dni, nombre, apellido, mail, password, cuit_Cuil, tipo); //descomentar
            //int erroresDeIngreso = 0;
               
                if (erroresDeIngreso > 0)
                {
                Console.WriteLine("usted tiene " + erroresDeIngreso + " errores que solucionar antes de poder crear su usuario");
                return false;
                }

         

            bool flag = this.usuarioDao.insert(nombre, apellido, password, dni, mail, tipo, cuit_Cuil);

            return flag;
            }


        public bool modificarUsuario(int id, int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
        {
            //int contieneErrores = verificarIngresoUsuario(id, dni, nombre, apellido, mail, password, cuit_Cuil, tipo);
            int contieneErrores = 0;
            if (contieneErrores > 0)
            {
                //UPDATE
                Console.WriteLine("usted tiene "+ contieneErrores + " errores que solucionar antes de poder modificar el usuario");
                return false;
            }
            else
            {
                bool flag = this.usuarioDao.update(id,  dni,  nombre,  apellido,  mail,  password,  cuit_Cuil,  tipo);
            }
            return true;
        }

        private int verificarIngresoUsuario( int dni, string nombre, string apellido, string mail, string password, string cuit_Cuil, string tipo)
        {
            //revisar
            int contadorErrores = 0;
           // foreach (Usuario us in usuarios)
            {
                //if (us.id == id)
                {
                    if (tipo.Trim().Length == 11)
                    {
                        //usuario.cuil = cuit_Cuil;
                    }
                    else
                    {
                        Console.WriteLine("El Cuit/Cuil ingresado no es correcto, recuerde que debe tener 11 digitos");
                        MessageBox.Show("El Cuit/Cuil ingresado no es correcto, recuerde que debe tener 11 digitos");
                        contadorErrores += 1;
                    }

                    if (dni.ToString().Trim().Length == 8)
                    {
                        //usuario.dni = dni;
                    }
                    else
                    {
                        Console.WriteLine("El Dni ingresado no es correcto, recuerde que debe tener 8 digitos");
                        MessageBox.Show("El Dni ingresado no es correcto, recuerde que debe tener 8 digitos");
                        contadorErrores += 1;
                    }

                    if (!(string.IsNullOrEmpty(nombre)))
                    {
                        //usuario.nombre = nombre;
                    }
                    else
                    {
                        Console.WriteLine("El Nombre ingresado no puede estar vacio");
                        MessageBox.Show("El Nombre ingresado no puede estar vacio");
                        contadorErrores += 1;
                    }

                    if (!(string.IsNullOrEmpty(apellido)))
                    {
                        //usuario.apellido = apellido;
                    }
                    else
                    {
                        Console.WriteLine("El Apellido ingresado no puede estar vacio");
                        MessageBox.Show("El Apellido ingresado no puede estar vacio"); 
                        contadorErrores += 1;
                        
                    }

                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(password);

                    if (!(string.IsNullOrEmpty(password)) && match.Success)
                    {
                  //      usuario.mail = mail;
                    }
                    else
                    {
                        Console.WriteLine("El Mail ingresado no es correcto");
                        MessageBox.Show("El Mail ingresado no es correcto");
                        contadorErrores += 1;
                    }

                    if (!(string.IsNullOrEmpty(mail)) && mail.Length > 3)
                    {
                        //usuario.password = password;
                    }
                    else
                    {
                        Console.WriteLine("El Password ingresado no es correcto, recuerde que debe tener 4 digitos minimo");
                        MessageBox.Show("El Password ingresado no es correcto,  recuerde que debe tener 4 digitos minimo");
                        contadorErrores += 1;
                    }
                }
            }
            return contadorErrores;
        }

            public bool eliminarUsuario (int id)
            {
            bool flag = this.usuarioDao.delete(id);
            return flag;
            }

            public List<Usuario> mostrarUsuarios () 
            {
                usuarios = usuarios.OrderBy(o  =>  o.dni).ToList();
                return usuarios;     
            
            }
 
            public bool agregarCategoria (string nombre)
            {
            return this.categoriaDao.insert(nombre);
            }
            //private int verificarEspacio

            public bool modificarCategoria (int id, string nombre)
            {
            return this.categoriaDao.update(id, nombre);
            }


            public bool eliminarCategoria (int id)
            {
            return categoriaDao.delete(id);
      
        }


            public List<Categoria> mostrarCategorias()
            {
            categorias = categorias.OrderBy(o => o.categoria_id).ToList();
            return categorias;
            /*foreach (Categoria cat in categorias)
            {
                    Console.WriteLine(cat.toString());

            }*/
        }

        public List<Categoria> buscarProductosPorCategoria(string nombreCateg) 
        {
            categorias = categorias.OrderBy(o => o.categoria_id).ToList();
            List<Producto> aux = new List<Producto>();
            foreach (Producto prod in productos)
            {
                if(prod.categoria.nombre == nombreCateg)
                {
                    aux.Add(prod);
                }
            }
            return categorias;
        }


           

            public bool agregarAlCarro (int id_Producto, int cantidad){
             bool flag = true;
            try
            {
                int id_carro = this.usuario.id_carro;
                carroDao.agregarAlCarrito(id_carro, id_Producto, cantidad);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                flag = false;
            }

            return flag;
        }
        
            
            public bool quitarDelCarro (int id_Producto, int cantidad, int id_Usuario){
            bool flag = false;

            carroDao.deleteProducto(id_Usuario, id_Producto);

            return flag;
        }



        public List<Producto> buscarProductosPorNombre(string nombre)
        {
            List<Producto> aux = new List<Producto>();
            foreach (Producto prod in productos)
            {
                if (prod.nombre == nombre)
                {
                    aux.Add(prod);
                }
            }

            return aux;
        }
        public bool vaciarCarro (){
            bool flag = false;
            try
            {
                int id_carro = usuario.id_carro;
                flag = carroDao.vaciarCarrito(id_carro);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
         
            return flag;
            }
          
            public bool comprar(){

            bool flag = false;
            try
            {
                flag =  carroDao.comprar(usuario.Micarro);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

                return flag;
            }

        public bool checkCarrito(Dictionary<Producto,int> lista)
        {
            bool flag = true;
            foreach (KeyValuePair<Producto, int> prod in lista)
            {

                int pedido = prod.Value;
                int stock = getProductoById(prod.Key.id).cantidad;

                if ((stock < pedido))
                {
                    flag = false;
                    break;
                }
               
            }
            return flag;
        }

        //pasar al dao
        public Producto getProductoById(int id)
        {
            return productoDao.get(id);
        }


      

       

        public int cantidadStockPorProducto(int idProd)
        {
            foreach(Producto prod in productos)
            {
                if(prod.id == idProd)
                {
                    return prod.cantidad;
                }
            }

            return -1;
        }
        
        public bool modificarCompra ( int id, double total){
            bool flag = false;

            carroDao.updateCompra(id, total);
            return flag;
            }

        
        public bool eliminarCompra (int id){
            bool flag = compradao.delete(id);
            return flag;

            }

  
        public List<Producto> mostrarTodosProductos()
        {
            productos.Sort((a, b) => a.id.CompareTo(b.id));
            return productos;
            /*foreach (Producto pr in producto)
            {
                Console.WriteLine(pr.toString());

            }*/

        }

            public List<Producto> mostrarTodosProductosPorPrecio() //MUESTRA TODOS LOS PRODUCTOS DEL MERCADO, ORDENADO POR PRECIO
            {
                  return productos.OrderBy(pr => pr.precio).ToList();
            }


            public List<Producto> mostrarTodosProductosPorCategoria() //MUESTRA TODAS LAS CATEGORIAS DEL MERCADO Y PARA CADA UNA DE ELLAS, LOS PRODUCTOS DENTRO DE LA MISMA.
            {
            return productos.OrderBy(pr => pr.categoria.categoria_id).ToList();
            }




        public bool iniciarSesion(int dni,string pass)
        {
            UsuarioDAO1 usuarioDao = new UsuarioDAO1(this.contexto);
            this.usuario = usuarioDao.getUsuarioByDni(dni, pass);
            if (this.usuario != null && this.usuario.nombre!=null)
            {
                this.carro = carroDao.getByUserId(usuario.id);
               if (esAdmin()) this.carro = new Carro(); //si no es admin no necesito iniciar un carrito
                return true;
            }
            return false;


        }



        public bool esAdmin()
        {
            return this.usuario.tipo.Trim() == "admin";
        }

        public  Usuario getUsuario()
        {
            return this.usuario;
        }

        public Usuario getUsuario(int id)
        {
            return this.usuarioDao.getUserById(id);
        }

        public Carro getCarrito()
        {
            return this.usuario.Micarro;
        }

        public void cerrarSesion()
        {
            this.contexto.Dispose();
        }
    }
}
