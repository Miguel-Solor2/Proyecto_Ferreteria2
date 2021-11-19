using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            if (Datos.Rows.Count == 0)
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
            if (randomCode == (TxtCode.Text).ToString())
            {
                To = TxtCorreo.Text;

                FrmEditarPassword frmedit = new FrmEditarPassword();
                frmedit.Show();
                this.Hide();
            }
            else
            {

                MessageBox.Show("Codigo erroneo");
            }
        }
    }
}
