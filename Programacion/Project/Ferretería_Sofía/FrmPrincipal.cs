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
        //BOTON PARA INGRESAR AL FORMULARIO DE STOCK DE ARTICULOS
        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajadores frmtrab = new FrmTrabajadores();
            frmtrab.ShowDialog();
        }
        //BOTON PARA INGRESAR AL FORMULARIO DE STOCK DE ARTICULOS
        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmStockdeArticulos frmstock = new FrmStockdeArticulos();
            frmstock.ShowDialog();
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
            GestionarAcceso();
        }
            //Procedimiento para el control de usuario
            private void GestionarAcceso()
            {
            //administramos los formularios que va a poder tener acceso el gerente
            if (Acceso == "GERENTE")
            {
                this.MnuAlmacén.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = true;
                this.MnuConsultas.Enabled = true;
               


                this.cerrarSesiónToolStripMenuItem.Enabled = true;
                this.SalirtoolStripMenuItem.Enabled = true;
            }
            //administramos los formularios que va a poder tener acceso el vendedor
            else
            {
                this.MnuAlmacén.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.proveedoresToolStripMenuItem.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
              



                this.cerrarSesiónToolStripMenuItem.Enabled = true;
                this.SalirtoolStripMenuItem.Enabled = true;
            }
            }
    }
}
