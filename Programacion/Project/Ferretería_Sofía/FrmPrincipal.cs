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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulos frmart = new FrmArticulos();
            frmart.ShowDialog();
        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias frmcat = new FrmCategorias();
            frmcat.ShowDialog();
        }

        private void presentaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresentacion frmpres = new FrmPresentacion();
            frmpres.ShowDialog();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresos frming = new FrmIngresos();
            frming.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores frmpove = new FrmProveedores();
            frmpove.ShowDialog();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVentas frventas = new FrmVentas();
            frventas.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmcli = new FrmClientes();
            frmcli.ShowDialog();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajadores frmtrab = new FrmTrabajadores();
            frmtrab.ShowDialog();
        }

        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStockdeArticulos frmstock = new FrmStockdeArticulos();
            frmstock.ShowDialog();
        }

        private void realizarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackupBD frmbackup = new FrmBackupBD();
            frmbackup.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            FrmLogin Login = new FrmLogin();
            Login.Show();
        }

        private void SalirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
