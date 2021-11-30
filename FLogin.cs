using System;
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
    public partial class FLogin : Form
    {
        private bool logued;
        private string[] argumentos;
        private Usuario usuario;
        public delegate void TransfDelegado(Mercado mercado);
        public TransfDelegado TrasfEvento;
        private Mercado mercado = new Mercado();
        private FPrincipal fprincipal;
        public FLogin(string[] args,FPrincipal fPrincipal)
        {
            logued = false;
            InitializeComponent();
            argumentos = args;
            this.fprincipal = fPrincipal;
        }
        private void login_Click(object sender, EventArgs e)
        {



           


        
                int dni_;
            bool loginOK = false;
                bool dniOK = Int32.TryParse(dni.Text, out dni_);
            
                if (dniOK &&  pass.Text!="")
                {
                loginOK =  mercado.iniciarSesion(dni_, pass.Text);
                //encontron al usuario

                }
            

            if (loginOK && mercado.getUsuario().nombre!= null && mercado.getUsuario()!=null)
            {
                this.TrasfEvento(mercado);
                this.Close();
            }
            else
                MessageBox.Show("Ocurrio un error al intentar realizar el login");

        }

        private void FLogin_Load(object sender, EventArgs e)
        {

        }

        private void registro_Click(object sender, EventArgs e)
        {
            this.Close();
            FRegistro registro = new FRegistro(mercado);
            registro.Show();
        }

        private void configurar_Click(object sender, EventArgs e)
        {
            FConfigurar configurar = new FConfigurar();
            configurar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.fprincipal.Close();
            this.Close();
            fprincipal.Close();
        }
    }
}