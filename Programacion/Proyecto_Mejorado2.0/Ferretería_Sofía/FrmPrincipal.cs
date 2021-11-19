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
        public string Idtrabajador = "";
        public string Nombre = "";
        public string Apellido = "";
        public string Acceso = "";

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulos form = FrmArticulos.GetInstancia();
            form.ShowDialog();
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
            FrmIngresos frm = FrmIngresos.GetInstancia_();
            frm.IdUSUARIO = Convert.ToInt32(this.Idtrabajador);
            frm.ShowDialog();
            
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores frmpove = new FrmProveedores();
            frmpove.ShowDialog();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVentas frm = FrmVentas.GetInstancia();
            frm.IdUSUARIO = Convert.ToInt32(this.Idtrabajador);
            frm.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes frmcli = new FrmClientes();
            frmcli.ShowDialog();
        }
        //BOTON PARA INGRESAR AL FORMULARIO DE STOCK DE ARTICULOS
        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajadores frmtrab = new FrmTrabajadores();
            frmtrab.ShowDialog();
        }
        

        private void realizarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBackupBD frmbackup = new FrmBackupBD();
            frmbackup.ShowDialog();
        }
        //BOTON PARA CERRAR SESION
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogin Login = new FrmLogin();
            Login.Show();
        }
        //CLASE PARA SALIR DE LA APLICACION
        private void SalirtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //EVENTO PARA INGRESAR AL FORMULARIO DE USUARIO
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario form = FrmUsuario.GetInstancia();
            form.ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //formularios que todos los usuarios tendran acceso
            this.MnuAlmacén.Enabled = true;
            this.MnuCompras.Enabled = true;
            this.MnuVentas.Enabled = true;
            this.cerrarSesiónToolStripMenuItem.Enabled = true;
            this.SalirtoolStripMenuItem.Enabled = true;
            //procedimiento para los formularios con permiso
            GestionarAcceso();
        }
            //Procedimiento para el control de usuario
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
    }
}
