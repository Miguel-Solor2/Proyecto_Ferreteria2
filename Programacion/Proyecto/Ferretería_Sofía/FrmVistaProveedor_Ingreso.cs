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
    public partial class FrmVistaProveedor_Ingreso : Form
    {
        public FrmVistaProveedor_Ingreso()
        {
            InitializeComponent();
        }

        private void FrmVistaProveedor_Ingreso_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar()

        private void Mostrar()
        {
            this.dataListado.DataSource = Nproveedor.Mostrar();
            this.OcultarColumnas();
            LblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);

            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[10].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].Visible = false;

                }
            }


        }

        //Método BuscarRazon_Social

        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = Nproveedor.BuscarRazon_Social(this.TxtBuscar.Text);
            this.OcultarColumnas();
            LblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = Nproveedor.BuscarNum_Documento(this.TxtBuscar.Text);
            this.OcultarColumnas();
            LblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbbuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cmbbuscar.Text.Equals("Documento"))
            {
                BuscarNum_Documento();
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmIngresos form = FrmIngresos.GetInstancia_();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Proveedor"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Razon_Social"].Value);
            form.setProveedor(par1, par2);
            this.Hide();
        }
    }
}
