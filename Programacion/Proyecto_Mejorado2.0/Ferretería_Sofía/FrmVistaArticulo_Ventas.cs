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
    public partial class FrmVistaArticulo_Ventas : Form
    {
        public FrmVistaArticulo_Ventas()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

        }

        //Método BuscarNombre

        private void BuscarArticulo_Venta_Nombre()
        {
            this.dataListado.DataSource = Nventa.MostrarArticulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaArticulo_Ventas_Load(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarArticulo_Venta_Nombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVentas form = FrmVentas.GetInstancia();
            string par1, par2;
            decimal par3;
            int par4;
            DateTime par5;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["IDDetalle_Ingreso"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Art"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["Precio_Compra"].Value);
            par4 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Stock_Actual"].Value);
            par5 = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_Vencimiento"].Value);
            form.setArticulo(par1, par2, par3, par4, par5);
            this.Hide();
        }
    }
}
