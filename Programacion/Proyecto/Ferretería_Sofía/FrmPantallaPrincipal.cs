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
    public partial class FrmPantallaPrincipal : Form
    {
        private int childFormNumber = 0;

        public string Idtrabajador = "";
        public string Nombre = "";
        public string Apellido = "";
        public string Acceso = "";


        public FrmPantallaPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategorias frm = new FrmCategorias();
            frm.MdiParent = this;
            frm.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresentacion frm = new FrmPresentacion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulos form = FrmArticulos.GetInstancia();
            form.MdiParent = this;
            form.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores frm = new FrmProveedores();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngresos frm = FrmIngresos.GetInstancia_();
            frm.IdUSUARIO = Convert.ToInt32(this.Idtrabajador);
            frm.MdiParent = this;
            frm.Show();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVentas frm = FrmVentas.GetInstancia();
            frm.IdUSUARIO = Convert.ToInt32(this.Idtrabajador);
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmcli = new FrmClientes();
            frmcli.MdiParent = this;
            frmcli.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajadores frmtrab = new FrmTrabajadores();
            frmtrab.MdiParent = this;
            frmtrab.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario form = FrmUsuario.GetInstancia();
            form.MdiParent = this;
            form.Show();
        }

        private void backUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackupBD frmbackup = new FrmBackupBD();
            frmbackup.MdiParent = this;
            frmbackup.Show();
        }

        private void FrmPantallaPrincipal_Load(object sender, EventArgs e)
        {
            //formularios que todos los usuarios tendran acceso
            this.MnuAlmacén.Enabled = true;
            this.MnuCompras.Enabled = true;
            this.MnuVentas.Enabled = true;
            this.sistemaToolStripMenuItem.Enabled = true;
            //procedimiento para los formularios con permiso
            GestionarAcceso();
        }


        private void GestionarAcceso()
        {
            //administramos los formularios que va a poder tener acceso el gerente
            if (Acceso == "GERENTE")
            {

                this.MnuMantenimiento.Enabled = true;
                this.MnuHerramientas.Enabled = true;

            }
            //administramos los formularios que va a poder tener acceso el vendedor
            else
            {

                this.proveedoresToolStripMenuItem.Enabled = false;

                this.MnuMantenimiento.Enabled = false;

                this.MnuHerramientas.Enabled = false;
            }
        }

        private void FrmPantallaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin FrmLogin = new FrmLogin();
            FrmLogin.Show();
        }
    }
}
