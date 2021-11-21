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
        public FCarro()
        {
            InitializeComponent();
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

        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            int idUsuario = mercado.getUsuario().id;

            string message = mercado.mostrarCarro();
            string caption = "Desea confirmar la compra?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    //mercado.comprar(usuario.id);

                    if (mercado.comprar(0))
                    {
                        MessageBox.Show("Compra realizada con exito!");
                        mercado.vaciarCarro(idUsuario);
                        textBox1.Text = mercado.calcularCompra(idUsuario).ToString();
                        button1.Text = "Ver carrito";
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al realizar la compra");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al intentar realizar la compra");
                }
            }*/
        }
    }
}
