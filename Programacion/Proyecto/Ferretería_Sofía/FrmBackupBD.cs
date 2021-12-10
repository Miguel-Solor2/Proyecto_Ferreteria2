using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ferretería_Sofía
{
    public partial class FrmBackupBD : Form {
        SqlConnection con = new SqlConnection("server= localhost; database= FERRETERIA; integrated security = true");
        public FrmBackupBD()
        {
            InitializeComponent();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnSeleccionarRuta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dig = new FolderBrowserDialog();
            if (dig.ShowDialog() == DialogResult.OK)
            {
                txtRutaBackup.Text = dig.SelectedPath;
                btnBackup.Enabled = true;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            if (txtRutaBackup.Text == string.Empty)
            {
                MessageBox.Show("Por favor Ingrese una ruta");

            }
            else
            {
                string cmd = "BACKUP DATABASE [" + database + "]TO DISK= '" + txtRutaBackup.Text + "//" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--MM-mm-ss") + ".bak'";
                con.Open();
                SqlCommand command = new SqlCommand(cmd, con);
                command.ExecuteNonQuery();
                MessageBox.Show("BackUp de la base de datos satisfactoriamente");
                con.Close();
                btnBackup.Enabled = false;
            }
        }
    }
}
