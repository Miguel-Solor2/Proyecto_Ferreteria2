using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace Ferretería_Sofía
{
    public partial class FrmRecuperar : Form
    {
        public string randomCode;
        public static string To;

        public FrmRecuperar()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.TxtCorreo, "Ingrese el correo");
            this.ttMensaje.SetToolTip(this.TxtCode, "Ingrese el código");
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EnviarCodigo()
        {

            string messageBody;

            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();

            To = (TxtCorreo.Text).ToString();
            messageBody = "Tu codigo de recuperacion es " + randomCode;
            message.To.Add(To);
            message.From = new MailAddress("locosiloc@gmail.com");
            message.Body = messageBody;
            message.Subject = "codigo de recuperacion de contraseña";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25; //587;//465;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("locosiloc@gmail.com", "JMAF2018");
            try
            {
                smtp.Send(message);
                MessageBox.Show("Codigo enviado satifactoriamente");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                smtp.Dispose();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            FrmLogin frmlogin = new FrmLogin();
            frmlogin.Show();
            this.Close();
        }

        private void FrmRecuperar_Load(object sender, EventArgs e)
        {

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            DataTable Datos = Capa_Negocio.Ntrabajador.Verificar(this.TxtCorreo.Text);

            if(TxtCorreo.Text == string.Empty)
            {
                MessageBox.Show("Primero debe escribir un correo", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Datos.Rows.Count == 0)
            {

                MessageBox.Show("Correo no encontrado", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EnviarCodigo();
            }
        }

        private void BtnVerificar_Click(object sender, EventArgs e)
        {
            if(TxtCode.Text == string.Empty)
            {
                MessageBox.Show("Debe introducir un código de verificación", "Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (randomCode == (TxtCode.Text).ToString())
            {
                To = TxtCorreo.Text;

                FrmEditarPassword frmedit = new FrmEditarPassword();
                frmedit.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Codigo erroneo", "Intente nuevamente",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void TxtCorreo_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(TxtCorreo.Text))
            {
                MensajeError("Email no válido");
                errorIcono.SetError(TxtCorreo, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void TxtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar > 64 && e.KeyChar <= 94) || (e.KeyChar > 95 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo no admite espacios ni caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
