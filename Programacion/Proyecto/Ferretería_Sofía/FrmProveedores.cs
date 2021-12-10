using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace Ferretería_Sofía
{
    public partial class FrmProveedores : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        public FrmProveedores()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese Razon Social del proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese el numero de documento del proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la diireccion del proveedor");
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
            this.txtRazon_Social.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.TxtTelefono.Text = string.Empty;
            this.TxtURL.Text = string.Empty;
            this.Txtemail.Text = string.Empty;
            this.Txtidproveedor.Text = string.Empty;
        }

        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtRazon_Social.Enabled = Valor;
            this.txtDireccion.Enabled = Valor;
            this.cmbSectorsocial.Enabled = Valor;
            this.cmbTipodoc.Enabled = Valor;
            this.txtNum_Documento.Enabled = Valor;
            this.TxtTelefono.Enabled = Valor;
            this.Txtemail.Enabled = Valor;
            this.TxtURL.Enabled = Valor;
            this.cmbEstado.Enabled = Valor;
        }

        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.BtnNuevo.Enabled = false;
                this.BtnGuardar.Enabled = true;
                this.BtnEditar.Enabled = false;
                this.BtnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.BtnNuevo.Enabled = true;
                this.BtnGuardar.Enabled = false;
                this.BtnEditar.Enabled = true;
                this.BtnCancelar.Enabled = false;
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
            this.dataListado.DataSource = Nproveedor.Mostrar();
            this.OcultarColumnas();
            LblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
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

        private void button2_Click(object sender, EventArgs e)
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
                            Rpta = Nproveedor.Anular(Convert.ToInt32(Codigo));

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

        private void BtnReturn_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
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

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
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
                    if (this.IsNuevo && dataListado.Rows[i].Cells[7].Value.ToString() == this.Txtemail.Text)
                    {
                        MensajeError("Ya existe ese Correo");
                        errorIcono.SetError(Txtemail, "Ingrese un correo");
                        this.Txtemail.Text = string.Empty;
                    }
                    else if (this.IsNuevo && dataListado.Rows[i].Cells[6].Value.ToString() == this.TxtTelefono.Text)
                    {
                        MensajeError("Ya existe ese Telfono");
                        errorIcono.SetError(TxtTelefono, "Ingrese un telefono valido");
                        this.TxtTelefono.Text = string.Empty;
                    }

                }
                if (string.IsNullOrWhiteSpace(this.txtRazon_Social.Text))
                {
                    errorIcono.SetError(txtRazon_Social, "Ingrese razón social");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cmbSectorsocial.Text))
                {
                    errorIcono.SetError(cmbSectorsocial, "Selecione el sector social");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cmbTipodoc.Text))
                {
                    errorIcono.SetError(cmbTipodoc, "Seleccione el tipo de documento");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtNum_Documento.Text))
                {
                    errorIcono.SetError(txtNum_Documento, "Ingrese numero de documento");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.TxtTelefono.Text))
                {
                    errorIcono.SetError(TxtTelefono, "Ingrese un número de teléfono válido");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.Txtemail.Text))
                {
                    errorIcono.SetError(Txtemail, "Ingrese un dirección de correo válida");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.TxtURL.Text))
                {
                    errorIcono.SetError(TxtURL, "Ingrese un dirección de URL válida");
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
                        //Vamos a insertar un proveedor
                        Rpta = Nproveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(),
                        cmbSectorsocial.Text, cmbTipodoc.Text,
                        txtNum_Documento.Text, txtDireccion.Text,
                        TxtTelefono.Text, Txtemail.Text, TxtURL.Text, cmbEstado.Text);

                    }
                    else
                    {
                        //Vamos a modificar un proveedor
                        Rpta = Nproveedor.Editar(Convert.ToInt32(this.Txtidproveedor.Text),
                        this.txtRazon_Social.Text.Trim().ToUpper(),
                        cmbSectorsocial.Text, cmbTipodoc.Text,
                        txtNum_Documento.Text, txtDireccion.Text,
                        TxtTelefono.Text, Txtemail.Text, TxtURL.Text, cmbEstado.Text);
                    }
                    //Si la respuesta fue OK, fue porque se modifico
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
                        errorIcono.SetError(txtRazon_Social, "");
                        errorIcono.SetError(cmbTipodoc, "");
                        errorIcono.SetError(txtNum_Documento, "");
                        errorIcono.SetError(cmbSectorsocial, "");
                        errorIcono.SetError(TxtTelefono, "");
                        errorIcono.SetError(TxtURL, "");
                        errorIcono.SetError(Txtemail, "");
                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(Rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.Txtidproveedor.Text = "";

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            //Si no ha seleccionado un proveedor no puede modificar
            if (!this.Txtidproveedor.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Txtidproveedor.Text = "";
            errorIcono.SetError(cmbEstado, "");
            errorIcono.SetError(txtRazon_Social, "");
            errorIcono.SetError(cmbTipodoc, "");
            errorIcono.SetError(txtNum_Documento, "");
            errorIcono.SetError(cmbSectorsocial, "");
            errorIcono.SetError(TxtTelefono, "");
            errorIcono.SetError(TxtURL, "");
            errorIcono.SetError(Txtemail, "");
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

        private void dataListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Txtidproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Proveedor"].Value);
            this.txtRazon_Social.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Razon_Social"].Value);
            this.cmbSectorsocial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Sector_Comercial"].Value);
            this.cmbTipodoc.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["N_Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion_P"].Value);
            this.TxtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono_P"].Value);
            this.Txtemail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email_P"].Value);
            this.TxtURL.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);
            this.cmbEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
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

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteProveedores Reporte = new Reportes.FrmReporteProveedores();
            Reporte.ShowDialog();
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void cmbTipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
           txtNum_Documento.Clear();
           errorIcono.SetError(cmbTipodoc, "");
        }

        private void txtNum_Documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void TxtTelefono_Validating(object sender, CancelEventArgs e)
        {
            Regex rex = new Regex("(9|8|3|2)+[]{1}[0-9]{7,7}$");
            if (!rex.IsMatch(TxtTelefono.Text))
            {
                MensajeError("Número no válido");
                errorIcono.SetError(TxtTelefono, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void Txtemail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!regex.IsMatch(Txtemail.Text))
            {
                MensajeError("Email no válido");
                errorIcono.SetError(Txtemail, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void Txtemail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45) || (e.KeyChar > 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 63) || (e.KeyChar > 64 && e.KeyChar <= 94) || (e.KeyChar > 95 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo no admite espacios ni caracteres especiales", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void TxtURL_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^(http|ftp|https|www)://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(TxtURL.Text))
            {
                MensajeError("URL no válida");
                errorIcono.SetError(TxtURL, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void txtNum_Documento_Validating(object sender, CancelEventArgs e)
        {
            if ((txtNum_Documento.Text.Length < 13 || txtNum_Documento.Text.Length > 13) && cmbTipodoc.Text.Equals("DNI"))
            {
                
                MensajeError("DNI no válido");
                errorIcono.SetError(txtNum_Documento, "Ingrese un valor válido");
                e.Cancel = true;
            }
            else if ((txtNum_Documento.Text.Length < 11 || txtNum_Documento.Text.Length > 11) && cmbTipodoc.Text.Equals("RUC"))
            {
                MensajeError("RUC no válido");
                errorIcono.SetError(txtNum_Documento, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }

        private void txtRazon_Social_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtRazon_Social, ""); 
        }

        private void cmbSectorsocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cmbSectorsocial, "");
        }

        private void txtNum_Documento_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtNum_Documento, "");
        }

        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(TxtTelefono, "");
        }

        private void Txtemail_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(Txtemail, "");
        }

        private void TxtURL_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(TxtURL, "");
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            errorIcono.SetError(cmbEstado, "");
        }

        private void txtRazon_Social_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\s]*[A-Za-z]{3,30}");
            if (!regex.IsMatch(txtRazon_Social.Text))
            {
                MensajeError("Razón social muy corta");
                errorIcono.SetError(txtRazon_Social, "Ingrese un valor válido");
                e.Cancel = true;
            }
        }
    }
}
