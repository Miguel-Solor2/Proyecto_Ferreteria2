using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Capa_Negocio;
namespace Ferretería_Sofía
{
    public partial class FrmTrabajadores : Form
    {
        //Variable que nos indica si vamos a insertar un nuevo producto
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un producto
        private bool IsModificar = false;
        
        public FrmTrabajadores()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Trabajador");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese Los Apellidos del Trabajador");
            this.ttMensaje.SetToolTip(this.txtNumDocumento, "Ingrese el Documento del Trabajador");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la Dirección del Trabajador");
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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
                            Rpta = Ntrabajador.Anular(Convert.ToInt32(Codigo));

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

        private void FrmTrabajadores_Load(object sender, EventArgs e)
        {
            //Le decimos al DataGridView que no auto genere las columnas
            //this.datalistado.AutoGenerateColumns = false;
            //Llenamos el DataGridView con la informacion
            //de todos nuestros Trabajadores
            this.Mostrar();
            //Deshabilita los controles
            this.Habilitar(false);
            //Establece los botones
            this.Botones();
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
            this.txtIdTrabajador.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.mtxtTelefono.Text = string.Empty;
            this.txtEmail.Text = string.Empty;

        }
        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtNombre.Enabled = Valor;
            this.txtApellido.Enabled = Valor;
            this.txtDireccion.Enabled = Valor;
            this.cbSexo.Enabled = Valor;
            this.dtFechaNacimineto.Enabled = Valor;
            this.cmbTipodoc.Enabled = Valor;
            this.txtNumDocumento.Enabled = Valor;
            this.txtDireccion.Enabled = Valor;
            this.mtxtTelefono.Enabled = Valor;
            this.txtEmail.Enabled = Valor;
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

        private void Mostrar()
        {
            this.dataListado.DataSource = Ntrabajador.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[11].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void BuscarApellidos()
        {
            this.dataListado.DataSource = Ntrabajador.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsModificar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
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
                    if (this.IsNuevo && dataListado.Rows[i].Cells[9].Value.ToString() == this.txtEmail.Text)
                    {
                        MensajeError("Ya existe ese Correo");
                        errorIcono.SetError(txtEmail, "Ingrese un correo");
                        this.txtEmail.Text = string.Empty;
                    }
                    else if (this.IsNuevo && dataListado.Rows[i].Cells[8].Value.ToString() == this.mtxtTelefono.Text)
                    {
                        MensajeError("Ya existe ese Telfono");
                        errorIcono.SetError(mtxtTelefono, "Ingrese un telefono valido");
                        this.mtxtTelefono.Text = string.Empty;
                    }
                }
                if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
                {
                    errorIcono.SetError(txtNombre, "Ingrese Nombre");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtApellido.Text))
                {
                    errorIcono.SetError(txtApellido, "Ingrese Apellido");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cbSexo.Text))
                {
                    errorIcono.SetError(cbSexo, "Seleccione sexo");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cmbTipodoc.Text))
                {
                    errorIcono.SetError(cmbTipodoc, "Seleccione tipo de documento");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtNumDocumento.Text))
                {
                    errorIcono.SetError(txtNumDocumento, "Ingrese número de documento");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.mtxtTelefono.Text))
                {
                    errorIcono.SetError(mtxtTelefono, "Ingrese un número de teléfono válido");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtEmail.Text))
                {
                    errorIcono.SetError(txtEmail, "Ingrese un dirección de correo válida");
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
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un Trabajador 
                        Rpta = Ntrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellido.Text.Trim().ToUpper(), cbSexo.Text,
                        dtFechaNacimineto.Value,
                        txtNumDocumento.Text, txtDireccion.Text,
                        mtxtTelefono.Text, txtEmail.Text, cmbTipodoc.Text, cmbEstado.Text);

                    }
                    else
                    {
                        //Vamos a modificar un Trabajador
                        Rpta = Ntrabajador.Editar(Convert.ToInt32(this.txtIdTrabajador.Text), this.txtNombre.Text.Trim().ToUpper(),
                        this.txtApellido.Text.Trim().ToUpper(), cbSexo.Text,
                        dtFechaNacimineto.Value,
                        txtNumDocumento.Text, txtDireccion.Text,
                        mtxtTelefono.Text, txtEmail.Text, cmbTipodoc.Text, cmbEstado.Text);
                    }

                    //Si la respuesta fue OK, fue porque se modifico 
                    //o inserto el Trabajador
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
                        errorIcono.SetError(cmbEstado, "");
                        errorIcono.SetError(cbSexo, "");
                        errorIcono.SetError(cmbTipodoc, "");
                        errorIcono.SetError(txtNombre, "");
                        errorIcono.SetError(txtApellido, "");
                        errorIcono.SetError(txtNumDocumento, "");
                        errorIcono.SetError(mtxtTelefono, "");
                        errorIcono.SetError(txtEmail, "");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsModificar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            this.txtIdTrabajador.Text = string.Empty;
            errorIcono.SetError(cmbEstado, "");
            errorIcono.SetError(cbSexo, "");
            errorIcono.SetError(cmbTipodoc, "");
            errorIcono.SetError(txtNombre, "");
            errorIcono.SetError(txtApellido, "");
            errorIcono.SetError(txtNumDocumento, "");
            errorIcono.SetError(txtEmail, "");
            errorIcono.SetError(mtxtTelefono, "");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un cliente no puede modificar
            if (!this.txtIdTrabajador.Text.Equals(""))
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

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtIdTrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Trabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Trabajador"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido_Trabajador"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Genero"].Value);
            this.dtFechaNacimineto.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_Nacimiento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Documento"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["N_Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion_T"].Value);
            this.mtxtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono_T"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email_T"].Value);
            this.cmbEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarApellidos();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteTrabajador Reporte = new Reportes.FrmReporteTrabajador();
            Reporte.ShowDialog();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 129) ||
            (e.KeyChar >= 131 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 129) ||
            (e.KeyChar >= 131 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 129) ||
            (e.KeyChar >= 131 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void mtxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[11].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private void mtxtTelefono_Validating(object sender, CancelEventArgs e)
        {
            Regex rex = new Regex("(9|8|3|2)+[]{1}[0-9]{7,7}$");
            if (!rex.IsMatch(mtxtTelefono.Text))
            {
                MensajeError("Número no válido");
                errorIcono.SetError(mtxtTelefono, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar > 64 && e.KeyChar <= 94) || (e.KeyChar > 95 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo no admite espacios ni caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(txtEmail.Text))
            {
                MensajeError("Email no válido");
                errorIcono.SetError(txtEmail, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtNombre, "");  
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtApellido, "");
        }

        private void cbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cbSexo, "");
        }

        private void cmbTipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cmbTipodoc, "");
        }

        private void txtNumDocumento_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtNumDocumento, "");
        }

        private void mtxtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(mtxtTelefono, "");
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtEmail, "");
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cmbEstado, "");
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\s]*[A-Za-z]{3,30}");
            if (!regex.IsMatch(txtNombre.Text))
            {
                MensajeError("Nombre muy corto");
                errorIcono.SetError(txtNombre, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void txtApellido_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\s]*[A-Za-z]{3,30}");
            if (!regex.IsMatch(txtApellido.Text))
            {
                MensajeError("Apellido muy corto");
                errorIcono.SetError(txtApellido, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }
    }
    }
