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
    public partial class FrmVistaArticulo_Ingreso : Form
    {
        public FrmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        //metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[7].Visible = false;
        }

        //Método Mostrar()
        private void Mostrar()
        {
            this.dataListado.DataSource = Narticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);

            foreach (DataGridViewRow fila in this.dataListado.Rows)
            {
                fila.Height = 160;

            }

            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].Visible = false;

                }
            }
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = Narticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            foreach (DataGridViewRow fila in this.dataListado.Rows)
            {
                fila.Height = 160;

            }


            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngresos form = FrmIngresos.GetInstancia_();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Art"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Art"].Value);
            form.setArticulo(par1, par2);
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            foreach (DataGridViewRow fila in this.dataListado.Rows)
            {
                fila.Height = 160;

            }


            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }
        }
    }
}
