using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferretería_Sofía.Reportes
{
    public partial class FrmReporteCliente : Form
    {
        public FrmReporteCliente()
        {
            InitializeComponent();
        }

        private void FrmReporteCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.SP_MOSTRAR_CLIENTE' Puede moverla o quitarla según sea necesario.
            this.SP_MOSTRAR_CLIENTETableAdapter.Fill(this.DsSistema.SP_MOSTRAR_CLIENTE);

            this.reportViewer1.RefreshReport();
        }
    }
}
