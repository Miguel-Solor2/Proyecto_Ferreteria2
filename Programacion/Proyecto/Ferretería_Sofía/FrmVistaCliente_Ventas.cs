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
    public partial class FrmVistaCliente_Ventas : Form
    {
        public FrmVistaCliente_Ventas()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar()

        private void Mostrar()
        {
            this.dataListado.DataSource = Nclientes.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellido

        private void BuscarApellido()
        {
            this.dataListado.DataSource = Nclientes.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaCliente_Ventas_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[11].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].Visible = false;
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarApellido();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmVentas form = FrmVentas.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Cliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido_Cliente"].Value) + " " +
                Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Cliente"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }
    }
}
