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
    public partial class FrmUsuario : Form
    {
        
        //Variable que nos indica si vamos a insertar un nuevo producto
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un producto
        private bool IsModificar = false;

        private static FrmUsuario _Instancia;

        public static FrmUsuario GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmUsuario();
            }
            return _Instancia;
        }
        public void setTrabajador(string idtrabajador, string nombre)
        {
            this.txtIdTrabajador.Text = idtrabajador;
            this.txtempleado.Text = nombre;
        }
        public FrmUsuario()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.cmbaccess, "Seleccione el rol del empleado");
            this.ttMensaje.SetToolTip(this.txtuser, "Ingrese el usuario");
            this.ttMensaje.SetToolTip(this.txtpassword, "Ingrese la contraseña");
            this.ttMensaje.SetToolTip(this.txtconfirm, "Ingrese la contraseña nuevamente");
        }

        //Para mostrar mensaje de confirmación
        private void MensajeOK(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Para mostrar mensaje de error
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpia los controles del formulario
        private void Limpiar()
        {
            this.txtIduser.Text = string.Empty;
            this.txtempleado.Text = string.Empty;
            this.txtuser.Text = string.Empty;
            this.txtpassword.Text = string.Empty;
            this.txtconfirm.Text = string.Empty;

        }

        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            btnBuscarCategoria.Enabled = Valor;
            this.cmbaccess.Enabled = Valor;
            this.txtuser.Enabled = Valor;
            this.txtpassword.Enabled = Valor;
            this.txtconfirm.Enabled = Valor;
            this.cmbEstado.Enabled = Valor;
        }

        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsModificar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }


        //Método Mostrar()

        private void Mostrar()
        {
            this.dataListado.DataSource = Nusuario.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[7].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void BuscarUsuario()
        {
            this.dataListado.DataSource = Nusuario.BuscarUsuario(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            //Para ubicar al formulario en la parte superior del contenedor
            //this.Top = 0;
            //this.Left = 0;
            //Le decimos al DataGridView que no auto genere las columnas
            //Llenamos el DataGridView con la información
            //de todos nuestros clientes
            this.Mostrar();
            //Deshabilita los controles
            this.Habilitar(false);
            //Establece los botones
            this.Botones();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = Nusuario.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOK("Se Anuló Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkAnular_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAnular.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIduser.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Usuario"].Value);
            this.txtIdTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Trabajador_ID"].Value);
            this.txtempleado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Trabajador"].Value);
            this.cmbaccess.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Acceso"].Value);
            this.txtuser.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Usuario"].Value);
            this.txtpassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Contrasena"].Value);
            this.cmbEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsModificar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtuser.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bError = false;
            try
            {
                //La variable que almacena si se inserto
                //o se modifico la tabla
                string Rpta = "";
                int C = dataListado.Rows.Count;

                for (int i = 0; i < C; i++)
                {
                    if ( this.IsNuevo && dataListado.Rows[i].Cells[3].Value.ToString() == this.txtuser.Text)
                    {
                        MensajeError("Ya existe ese usuario");
                        errorIcono.SetError(txtuser, "Ingrese un Usuario");
                        this.txtuser.Text = string.Empty;
                    }
                }
                if (string.IsNullOrWhiteSpace(this.cmbaccess.Text))
                {
                    errorIcono.SetError(cmbaccess, "Seleccione acceso");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtempleado.Text))
                {
                    errorIcono.SetError(txtempleado, "Ingrese un trabajador");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtuser.Text))
                {
                    errorIcono.SetError(txtuser, "Ingrese un usuario");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtpassword.Text))
                {
                    errorIcono.SetError(txtpassword, "Ingrese una contraseña");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtconfirm.Text))
                {
                    errorIcono.SetError(txtconfirm, "Confirme la contraseña");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cmbEstado.Text))
                {
                    errorIcono.SetError(cmbEstado, "Seleccione estado");
                    bError = true;
                }
                if (bError == true)
                {
                    MessageBox.Show("Se ha olvidado de algunos campos", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txtpassword.Text != txtconfirm.Text)
                {
                    MensajeError("Estos campos no coinciden");
                    errorIcono.SetError(txtpassword, "Las campos deben de ser iguales");
                    errorIcono.SetError(txtconfirm, "Las campos deben de ser iguales");    
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un usuario
                        Rpta = Nusuario.Insertar(Convert.ToInt32(txtIdTrabajador.Text), this.cmbaccess.Text, this.txtuser.Text.Trim(), this.txtpassword.Text, this.cmbEstado.Text);

                    }
                    else
                    {
                        //Vamos a modificar un usuario
                        Rpta = Nusuario.Editar(Convert.ToInt32(this.txtIduser.Text), Convert.ToInt32(txtIdTrabajador.Text), this.cmbaccess.Text, this.txtuser.Text.Trim().ToUpper(), Convert.ToString(this.txtpassword.Text), this.cmbEstado.Text);
                    }
                    //Si la respuesta fue OK, fue porque se modifico
                    //o inserto el usuario
                    //de forma correcta
                    if (Rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se actualizó de forma correcta el registro");
                        }
                        errorIcono.SetError(txtuser, "");
                        errorIcono.SetError(txtpassword, "");
                        errorIcono.SetError(txtempleado, "");
                        errorIcono.SetError(txtconfirm, "");
                        errorIcono.SetError(cmbaccess, "");
                        errorIcono.SetError(cmbEstado, "");

                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.IsModificar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdTrabajador.Text = "";

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un cliente no puede modificar
            if (!this.txtIduser.Text.Equals(""))
            {
                this.IsModificar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsModificar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtIduser.Text = string.Empty;
            this.txtIdTrabajador.Text = string.Empty;
            errorIcono.SetError(txtuser, "");
            errorIcono.SetError(txtpassword, "");
            errorIcono.SetError(txtempleado, "");
            errorIcono.SetError(txtconfirm, "");
            errorIcono.SetError(cmbaccess, "");
            errorIcono.SetError(cmbEstado, "");
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarUsuario();
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVistaTrabajador form = new FrmVistaTrabajador();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
            }
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteUsuarios Reporte = new Reportes.FrmReporteUsuarios();
            Reporte.ShowDialog();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[7].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void FrmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtempleado_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtempleado, "");
        }

        private void cmbaccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cmbaccess, "");
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtuser, "");
        }

        private void txtconfirm_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtpassword, "");
            errorIcono.SetError(txtconfirm, "");
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cmbEstado, "");
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtpassword, "");
            errorIcono.SetError(txtconfirm, "");
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar > 91 && e.KeyChar <= 94) || (e.KeyChar > 95 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo no admite espacios ni caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar > 91 && e.KeyChar <= 94) || (e.KeyChar >= 95 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo no admite espacios ni caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtconfirm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 64) || (e.KeyChar > 91 && e.KeyChar <= 94) || (e.KeyChar >= 95 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo no admite espacios ni caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
    }
}
