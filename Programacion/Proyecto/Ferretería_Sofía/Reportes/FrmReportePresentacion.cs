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
    public partial class FrmReportePresentacion : Form
    {
        public FrmReportePresentacion()
        {
            InitializeComponent();
        }

        private void FrmReportePresentacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.SP_MOSTRAR_PRESENTACION' Puede moverla o quitarla según sea necesario.
            this.SP_MOSTRAR_PRESENTACIONTableAdapter.Fill(this.DsSistema.SP_MOSTRAR_PRESENTACION);

            this.reportViewer1.RefreshReport();
        }
    }
}
