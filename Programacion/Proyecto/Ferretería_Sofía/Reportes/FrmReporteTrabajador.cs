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
    public partial class FrmReporteTrabajador : Form
    {
        public FrmReporteTrabajador()
        {
            InitializeComponent();
        }

        private void FrmReporteTrabajador_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.SP_MOSTRAR_TRABAJADOR' Puede moverla o quitarla según sea necesario.
            this.SP_MOSTRAR_TRABAJADORTableAdapter.Fill(this.DsSistema.SP_MOSTRAR_TRABAJADOR);

            this.reportViewer1.RefreshReport();
        }
    }
}
