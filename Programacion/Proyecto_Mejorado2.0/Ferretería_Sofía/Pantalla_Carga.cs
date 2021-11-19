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
    public partial class Pantalla_Carga : Form
    {
        public Pantalla_Carga()
        {
            InitializeComponent();
        }
        public void Progress_Bar()
        {
            barra_progreso.Increment(1);
            LblPorcentaje.Text = barra_progreso.Value.ToString() + "%";
            if (barra_progreso.Value == barra_progreso.Maximum)
            {
                timer1.Stop();
                this.Hide();
                FrmLogin FrmLogin = new FrmLogin();
                FrmLogin.Show();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Progress_Bar();
        }
    }
}
