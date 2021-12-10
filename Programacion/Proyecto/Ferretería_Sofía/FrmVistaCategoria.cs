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
    public partial class FrmVistaCategoria : Form
    {
        public FrmVistaCategoria()
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
            this.dataListado.DataSource = Ncategoria.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre

        private void BuscarNombre()
        {
            this.dataListado.DataSource = Ncategoria.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmVistaCategoria_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[4].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].Visible = false;
     
                }
            }


           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            FrmArticulos form = FrmArticulos.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Categoria"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Categoria"].Value);
            form.setCategoria(par1, par2);
            this.Hide();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
