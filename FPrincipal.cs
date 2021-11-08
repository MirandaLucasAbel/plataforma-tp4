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

namespace Slc_Mercado
{
    public partial class FPrincipal : Form
    {
        FLogin hijoLogin;
        FAdmin hijoMain;
        FUser hijoMain2;
        internal string texto;
        Mercado mercado;
        bool logued;
        public bool touched;
        public FPrincipal()
        {
            InitializeComponent();
            logued = false;
            // LOGIN
            hijoLogin = new FLogin(new string[1]);
            hijoLogin.MdiParent = this;
            hijoLogin.TrasfEvento += TransfDelegado;
            hijoLogin.Show();

            touched = false;

        }
        private void TransfDelegado(Mercado mercado)
        {
            this.mercado = mercado;
            if (mercado.getUsuario() != null && mercado.getUsuario().nombre != "")
            {
                MessageBox.Show("Log-in correcto, Usuario: " + mercado.getUsuario().nombre);
                hijoLogin.Close();

                if (mercado.getUsuario().nombre !=null && mercado.esAdmin())
                {
                    hijoMain = new FAdmin(mercado);
                    hijoMain.MdiParent = this;
                    hijoMain.Show();
                }
                else
                {
                    hijoMain2 = new FUser(mercado);
                    hijoMain2.MdiParent = this;
                    hijoMain2.Show();
                }
            }
        }

        private void FPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
