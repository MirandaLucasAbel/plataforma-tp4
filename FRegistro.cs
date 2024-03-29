﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp1;
using dao;


namespace Slc_Mercado
{
    public partial class FRegistro : Form
    {
        private Mercado mercado;
        public FRegistro(Mercado mercado)
        {
            this.mercado = mercado;
            InitializeComponent();
   
        }

        private void FRegistro_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Completar los campos con la informacion solicitada.");
        }
        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            FPrincipal menuPrincipal = new FPrincipal();
            menuPrincipal.Show();
        }
        private void registrarUsuario_Click(object sender, EventArgs e)
        {
            //leer archivo de usuarios //TODO encriptar en algun momento

            bool flag = false;

            //agregar usuario al array temporal
            int id = 0;
            int dniOut;
            int.TryParse(dni.Text, out dniOut);
            string nombre = nombre_.Text;
            string apellido = apellido_.Text;
            string mail = mail_.Text;
            string password = pass.Text;
            Carro MiCarro = null;

            if (validar())
            {

                
                flag = mercado.agregarUsuario(dniOut, nombre, apellido, password, mail, tipoUsuario.SelectedItem.ToString(), cuit.Text);
                
            }
           
            else return;

            //guardar


            if (flag)
            {
                MessageBox.Show("Usuario registrado con exito");
                this.Close();
                FPrincipal menuPrincipal = new FPrincipal();
                menuPrincipal.Show();
            }
            else
            {
                MessageBox.Show("ocurrio un error al intentar registrar el usuario");
            }
            
        }

        private bool validar()
        {
            if(dni.Text!="" && cuit.Text!="" && nombre_.Text!="" && apellido_.Text != "" && mail_.Text != "" && pass.Text != "" && tipoUsuario.SelectedItem!=null && !"".Equals(tipoUsuario.SelectedItem.ToString()) )

            return true;

            else
            {
                MessageBox.Show("Por favor completar todos los campos con la informacion solicitada.");
                return false;
            }
        }

        private void tipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
