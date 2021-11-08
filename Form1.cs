using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase7
{
    public partial class Form1 : Form
    {
        private UsuarioManager usuarios;
        public Form1()
        {
            InitializeComponent();
            usuarios = new UsuarioManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //borro los datos que había
            refreshVista();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario_ejemplo selected = usuarios.obtenerUsuario(int.Parse(dataGridView1[0, e.RowIndex].Value.ToString()));
            textBox1.Text = selected.dni.numero.ToString();
            textBox2.Text = selected.nombre;
            textBox3.Text = selected.mail;
            textBox4.Text = selected.password;
            checkBox1.Checked = selected.esADM;
            checkBox2.Checked = selected.bloqueado;
            dataGridView2.Rows.Clear();
            if (selected.Nacionalidad != null)
            {
                foreach (Pais p in selected.Nacionalidad)
                    dataGridView2.Rows.Add(p.nombre);
            }
            if (selected.domicilios != null)
            {
                dataGridView3.Rows.Clear();
                foreach (Domicilio d in selected.domicilios)
                    dataGridView3.Rows.Add(d.calle, d.altura);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (usuarios.agregarUsuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Agregado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo agregar el usuario");
        }

        private void refreshVista()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            dataGridView1.Rows.Clear();
            foreach (Usuario_ejemplo usuario in usuarios.obtenerUsuarios())
                dataGridView1.Rows.Add(usuario.toArray());
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            listBox1.Items.Clear();
            foreach (Pais p in usuarios.obtenerPaises())
                listBox1.Items.Add(p);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (usuarios.eliminarUsuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Eliminado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo eliminar el usuario");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (usuarios.modificarUsuario(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, checkBox1.Checked, checkBox2.Checked))
            {
                MessageBox.Show("Modificado con éxito");
                refreshVista();
            }
            else
                MessageBox.Show("No se pudo modificar el usuario");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (Usuario_ejemplo usuario in usuarios.usuariosAdministradores())
                dataGridView1.Rows.Add(usuario.toArray());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Pais p = (Pais)listBox1.Items[listBox1.SelectedIndex];
                if (usuarios.agregarPais(int.Parse(textBox1.Text), p.nombre))
                {
                    MessageBox.Show("Modificado con éxito");
                    refreshVista();
                }
                else
                    MessageBox.Show("No se pudo modificar el usuario");
            }
            else
                MessageBox.Show("Debe seleccionar un pais para agregar");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox5.Text!="" && textBox6.Text!="" && textBox1.Text!=null)
            {
                if (usuarios.agregarDomicilio(int.Parse(textBox1.Text), textBox5.Text, int.Parse(textBox6.Text)))
                {
                    MessageBox.Show("Modificado con éxito");
                    refreshVista();
                }
                else
                    MessageBox.Show("No se pudo modificar el usuario");
            }
            else
                MessageBox.Show("Debe seleccionar un usuario y completar los campos");
        }
    }
}
