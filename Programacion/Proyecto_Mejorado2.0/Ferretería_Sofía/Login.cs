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
            this.Close();
            frmrecup.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //se hace referencia al login de la capa de negocio de usuario
            DataTable Datos = Capa_Negocio.Nusuario.Login(this.TxtUser.Text, this.TxtPassword.Text);
            //Evaluar si existe el usuario que se escribe en textbox
            if (Datos.Rows.Count == 0)
            {

                MessageBox.Show("Usuario o contraseña incorrectas", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                FrmPrincipal frm = new FrmPrincipal();
                frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellido = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();

                frm.Show();
                this.Hide();
            }
        
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
