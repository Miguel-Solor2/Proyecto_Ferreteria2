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
    public partial class FrmReporteIngresos : Form
    {
        public FrmReporteIngresos()
        {
            InitializeComponent();
        }

        private void FrmReporteIngresos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.SP_MOSTRAR_INGRESO' Puede moverla o quitarla según sea necesario.
            this.SP_MOSTRAR_INGRESO_NUEVOTableAdapter.Fill(this.DsSistema.SP_MOSTRAR_INGRESO_NUEVO);

            this.reportViewer1.RefreshReport();
        }
    }
}
