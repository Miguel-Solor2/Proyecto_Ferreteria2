using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferretería_Sofía
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (TxtPassword.PasswordChar == '*')
            {
                BtnHide.BringToFront();
                TxtPassword.PasswordChar = '\0';
            }
        }

        private void BtnHide_Click(object sender, EventArgs e)
        {
            if (TxtPassword.PasswordChar == '\0')
            {
                BtnShow.BringToFront();
                TxtPassword.PasswordChar = '*';
            }
        }

        private void LinkLblPress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRecuperar frmrecup = new FrmRecuperar();
            this.Hide();
            frmrecup.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (TxtUser.Text == "JoseMa" && TxtPassword.Text == "2002")
            {
                FrmPrincipal frmmenu = new FrmPrincipal();
                this.Hide();
                frmmenu.Show();
            }
            else
            {
                MessageBox.Show("Intente nuevamente", "Usuario o contraseñas incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
