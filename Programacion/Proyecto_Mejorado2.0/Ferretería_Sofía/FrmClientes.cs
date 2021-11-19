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
    public partial class FrmClientes : Form
    {
        //Variable que nos indica si vamos a insertar un nuevo producto
        private bool IsNuevo = false;
        //Variable que nos indica si vamos a modificar un producto
        private bool IsModificar = false;
        public FrmClientes()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del cliente");
            this.ttMensaje.SetToolTip(this.txtApellido, "Ingrese el apellido del cliente");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese la dirección del cliente");
            this.ttMensaje.SetToolTip(this.txtNumDocumento, "Ingrese el número de documento del cliente");

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
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.mtxtTelefono.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            this.txtIdCliente.Text = string.Empty;
        }

        //Habilita los controles de los formularios
        private void Habilitar(bool Valor)
        {
            this.txtNombre.ReadOnly = !Valor;
            this.txtIdCliente.ReadOnly = !Valor;
            this.txtNumDocumento.ReadOnly = !Valor;
            this.txtApellido.ReadOnly = !Valor;
            this.txtDireccion.ReadOnly = !Valor;
            this.mtxtTelefono.ReadOnly = !Valor;
            this.txtEmail.ReadOnly= !Valor;
            this.cbSexo.Enabled = Valor;
            this.cbTipoDocumento.Enabled = Valor;
            this.dtFechaNacimineto.Enabled = Valor;
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
            this.dataListado.DataSource = Nclientes.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellido

        private void BuscarApellido()
        {
            this.dataListado.DataSource = Nclientes.BuscarApellido(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmCategorias_Load(object sender, EventArgs e)
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

        private void BtnReturn_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
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
                            Rpta = Nclientes.Anular(Convert.ToInt32(Codigo));

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

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Cliente"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Cliente"].Value);
            this.txtApellido.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Apellido_Cliente"].Value);
            this.dtFechaNacimineto.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_Nacimiento"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Genero"].Value);
            this.cbTipoDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Direccion_C"].Value);
            this.mtxtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Telefono_C"].Value);
            this.txtEmail.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Email_C"].Value);
            this.txtNumDocumento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["N_Documento"].Value);
            this.cmbEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsModificar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //La variable que almacena si se inserto
                //o se modifico la tabla
                string Rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtApellido.Text == string.Empty ||
                    this.txtNumDocumento.Text == string.Empty)
                {

                    MensajeError("Falta Ingresar algunos valores");
                    errorIcono.SetError(txtNombre, "Ingrese Nombre");
                    errorIcono.SetError(txtApellido, "Ingrese Apellido");
                    errorIcono.SetError(txtNumDocumento, "Ingrese Número de documento");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        //Vamos a insertar un cliente
                        Rpta = Nclientes.Insertar(this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(),
                            this.dtFechaNacimineto.Value, this.cbSexo.Text, this.cbTipoDocumento.Text, this.txtDireccion.Text,
                            this.mtxtTelefono.Text, this.txtEmail.Text, this.txtNumDocumento.Text, this.cmbEstado.Text);

                    }
                    else
                    {
                        //Vamos a modificar un cliente
                        Rpta = Nclientes.Editar(Convert.ToInt32(this.txtIdCliente.Text),
                            this.txtNombre.Text.Trim().ToUpper(), this.txtApellido.Text.Trim().ToUpper(),this.dtFechaNacimineto.Value, 
                            this.cbSexo.Text, this.cbTipoDocumento.Text, this.txtDireccion.Text, this.mtxtTelefono.Text, this.txtEmail.Text, 
                            this.txtNumDocumento.Text, this.cmbEstado.Text);
                    }
                    //Si la respuesta fue OK, fue porque se modifico
                    //o inserto el cliente
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
                    this.IsModificar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                    this.txtIdCliente.Text = "";

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
            if (!this.txtIdCliente.Text.Equals(""))
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
            this.txtIdCliente.Text = string.Empty;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarApellido();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteCliente Reporte = new Reportes.FrmReporteCliente();
            Reporte.ShowDialog();
        }
    }
    }
