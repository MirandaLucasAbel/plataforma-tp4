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
                data.Add(producto.nombre);
                data.Add(producto.precio.ToString());
                data.Add(producto.cantidad.ToString());
                double total = producto.cantidad * producto.precio;
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
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //volver a pantalla anterior //revisar
            hijoMain2 = new FUser(mercado);
            hijoMain2.MdiParent = this;
            hijoMain2.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = this.mercado.comprar();
            string mensaje = (flag) ? "compra realizada!" : "ocurrio un error al intentar realizar la compra";
            MessageBox.Show(mensaje);
            
        }
    }
}
