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
            this.txtRazon_Social.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.cmbSectorsocial.Enabled = Valor;
            this.cmbTipodoc.Enabled = Valor;
            this.txtNum_Documento.ReadOnly = !Valor;
            this.TxtTelefono.ReadOnly = !Valor;
            this.Txtemail.ReadOnly = !Valor;
            this.TxtURL.ReadOnly = !Valor;
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
            this.txtRazon_Social.Focus();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //La variable que almacena si se inserto
                //o se modifico la tabla
                string Rpta = "";
                if (this.txtRazon_Social.Text == string.Empty || this.txtNum_Documento.Text == string.Empty
                    || this.txtDireccion.Text == string.Empty)
                {

                    MensajeError("Falta Ingresar algunos valores");
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRazon_Social, "Ingrese un Valor");
                    errorIcono.SetError(txtNum_Documento, "Ingrese un Valor");
                    errorIcono.SetError(txtDireccion, "Ingrese un Valor");
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

        private void Txtidproveedor_TextChanged(object sender, EventArgs e)
        {

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
    }
}
