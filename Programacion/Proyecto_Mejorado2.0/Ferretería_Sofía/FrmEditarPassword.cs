using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Ferretería_Sofía
{
    public partial class FrmEditarPassword : Form
    {
        public FrmEditarPassword()
        {
            InitializeComponent();
        }
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmRecuperar frmrecup = new FrmRecuperar();
            frmrecup.Show();
            this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //La variable que almacena si se inserto
                //o se modifico la tabla
                string Rpta = "";
                if (txtuser.Text == string.Empty || txtpassword.Text == string.Empty || txtconfirm.Text == string.Empty)
                {
                    MensajeError("Falta Ingresar algunos valores");
                    errorIcono.SetError(txtuser, "Ingrese su usuario");
                    errorIcono.SetError(txtpassword, "Ingrese su contraseña");
                    errorIcono.SetError(txtconfirm, "Ingrese su nueva contraseña de nuevo");
                }
                else if (txtpassword.Text != txtconfirm.Text)
                {
                    MensajeError("Algunos campos no coinciden");
                    errorIcono.SetError(txtpassword, "Las campos deben de ser iguales");
                    errorIcono.SetError(txtconfirm, "Las campos deben de ser iguales");
                }
                else
                {
                    //Vamos a modificar un usuario
                    Rpta = Nusuario.EditarUser(this.txtuser.Text, this.txtpassword.Text);
                    //Si la respuesta fue OK, fue porque se modifico
                    //de forma correcta
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOK("Se actualizó de forma correcta su contraseña");
                        this.Close();
                        FrmLogin frmlogin = new FrmLogin();
                        frmlogin.Show();

                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(Rpta);
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
