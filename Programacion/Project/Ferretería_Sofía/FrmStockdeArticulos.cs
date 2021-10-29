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
    public partial class FrmStockdeArticulos : Form
    {
        public FrmStockdeArticulos()
        {
            InitializeComponent();
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
         
            this.Close();
        }
    }
}
