using Slc_Mercado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using tp1;

namespace tp4EF
{
    public partial class FCarro : Form
    {
        private Mercado mercado;
        private FUser hijoMain2;
        public FCarro(Mercado mercado)
        {
            this.mercado = mercado;
            InitializeComponent();
            label3.Text = mercado.getUsuario().nombre;
            

            double total_compra = 0;

            dataGridView1.Rows.Clear();
            //agrego lo nuevo
            int row = 0;
            foreach (var producto_carro in mercado.getCarrito().producto_Carro)
            {
                List<string> data = new List<string>();
                Producto producto = producto_carro.producto;
                data.Add(producto_carro.id_Producto_Carro.ToString());
                data.Add(producto.nombre);
                data.Add(producto.precio.ToString());
                data.Add(producto_carro.cantidad.ToString());
                double total = producto_carro.cantidad * producto.precio;
                data.Add(total.ToString());

                dataGridView1.Rows.Add(data.ToArray());

                total_compra += total;
                
            }

            textBox1.Text = "$ "+ total_compra.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id_producto_carro;
            int cantidad;
            try
            {
                if (e.ColumnIndex == 5)
                {
                    bool idOK = int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out id_producto_carro);
                    bool cantOK = int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), out cantidad);
                    mercado.modificarProductoCarro(id_producto_carro, cantidad);
                    //MessageBox.Show("modificar");

                }
                if (e.ColumnIndex == 6)
                {
                    bool idOK = int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), out id_producto_carro);
                    mercado.eliminarProductoCarro(id_producto_carro);
                    MessageBox.Show("borrar");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
          
          
        }


        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FUser Fusuario = new FUser(this.mercado);
            Fusuario.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = this.mercado.comprar();
            string mensaje = (flag) ? "compra realizada!" : "ocurrio un error al intentar realizar la compra";
            MessageBox.Show(mensaje);
            this.Close();
            FUser Fusuario = new FUser(this.mercado);
            Fusuario.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            mercado.cerrarSesion();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mercado.vaciarCarro();
        }
    }
}
