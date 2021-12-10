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
    public partial class FrmVentas : Form
    {
        private bool IsNuevo = false;
        public int IdUSUARIO;
        private DataTable dtDetalle;

        private decimal totalPagado = 0;

        private static FrmVentas _instancia;

        public static FrmVentas GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmVentas();
            }
            return _instancia;
        }

        public void setCliente(string idcliente, string nombre)
        {
            this.txtIdcliente.Text = idcliente;
            this.txtCliente.Text = nombre;
        }

        public void setArticulo(string iddetalle_ingreso, string nombre, decimal precio_compra, int stock,
            DateTime fecha_vencimiento)
        {
            this.txtIDArticulo.Text = iddetalle_ingreso;
            this.txtArticulo.Text = nombre;
            this.txtPrecioCompra.Text = Convert.ToString(precio_compra);
            this.txtStockActual.Text = Convert.ToString(stock);
            this.dtFechaVencimiento.Value = fecha_vencimiento;
        }

        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdVenta.Text = string.Empty;
            this.txtIdcliente.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtSerie.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";
            this.txtISV.Text = "18";
            this.crearTabla();
        }

        //Limpieza
        private void limpiarDetalle()
        {
            this.txtIDArticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStockActual.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtDescuento.Text = string.Empty;


            errorIcono.SetError(txtIDArticulo, "");
            errorIcono.SetError(txtCantidad, "");
            errorIcono.SetError(txtDescuento, "");
            errorIcono.SetError(txtPrecioVenta, "");
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtSerie.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtCantidad.Enabled = valor;
            this.txtPrecioVenta.Enabled = valor;
            this.txtDescuento.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;
            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.dtFechaIngresoAlmacen.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }

        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = Nventa.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = Nventa.BuscarFechas(this.dtFechaInicio.Value.ToString("yyyy/MM/dd"),
                this.dtFechaFin.Value.ToString("yyyy/MM/dd"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = Nventa.MostrarDetalle(this.txtIdVenta.Text);

        }

        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        public FrmVentas()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtCliente, "Seleccione un Cliente");
            this.ttMensaje.SetToolTip(this.txtSerie, "Ingrese una serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtCantidad, "Ingrese la Cantidad del Artículo a Vender");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione un Artículo");
            this.dtFechaVencimiento.Enabled = false;
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaCliente_Ventas vista = new FrmVistaCliente_Ventas();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ventas vista = new FrmVistaArticulo_Ventas();
            vista.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = Nventa.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente la venta");
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

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtSerie.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(false);
            errorIcono.SetError(txtIdcliente, "");
            errorIcono.SetError(txtIdcliente, "");
            errorIcono.SetError(txtSerie, "");
            errorIcono.SetError(dataListadoDetalle, "");
            errorIcono.SetError(txtArticulo, "");
            errorIcono.SetError(cbTipoComprobante, "");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdVenta.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Venta"].Value);
            this.txtCliente.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Cliente"].Value);
            this.dtFechaIngresoAlmacen.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_Venta"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Comprobante"].Value);
            this.txtSerie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool bError = false;
            bool bError2 = false;
            try
            {

                if (this.txtPrecioVenta.Text == string.Empty)
                {
                    errorIcono.SetError(txtPrecioVenta, "Ingrese el precio de venta");
                    bError = true;
                }
                if (this.txtCantidad.Text == string.Empty)
                {
                    errorIcono.SetError(txtCantidad, "Ingrese la cantidad");
                    bError = true;
                }
                if (this.txtArticulo.Text == string.Empty)
                {
                    errorIcono.SetError(txtArticulo, "Elija un articulo");
                    bError = true;
                }
                if (this.txtDescuento.Text == string.Empty)
                {
                    errorIcono.SetError(txtDescuento, "Ingrese a un descuento");
                    bError = true;
                }
                if (bError == true)
                {
                    MessageBox.Show("Se ha olvidado de algunos campos", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Convert.ToDecimal(this.txtCantidad.Text) <= 0)
                {
                    errorIcono.SetError(txtCantidad, "Debe ser mayor a 0");
                    bError2 = true;
                }
                if (Convert.ToDecimal(this.txtPrecioVenta.Text) <= 0)
                {
                    errorIcono.SetError(txtPrecioVenta, "Debe ser mayor a 0");
                    bError2 = true;
                }
                if (Convert.ToDecimal(this.txtPrecioVenta.Text) <= Convert.ToDecimal(this.txtPrecioCompra.Text))
                {
                    errorIcono.SetError(txtPrecioVenta, "No es viable para la empresa");
                    bError2 = true;
                }
                if (bError2 == true)
                {
                    MessageBox.Show("Hay algunas condiciones que deben respetarse", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["iddetalle_ingreso"]) == Convert.ToInt32(this.txtIDArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar && Convert.ToInt32(txtCantidad.Text) <= Convert.ToInt32(txtStockActual.Text))
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecioVenta.Text) - Convert.ToDecimal(this.txtDescuento.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["iddetalle_ingreso"] = Convert.ToInt32(this.txtIDArticulo.Text);
                        row["articulo"] = this.txtArticulo.Text;
                        row["cantidad"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["descuento"] = Convert.ToDecimal(this.txtDescuento.Text);
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }
                    else
                    {
                        MensajeError("No hay Stock Suficiente");
                        errorIcono.SetError(txtCantidad, "No puede ser mayor al ingreso");
                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataListadoDetalle.Rows.Count == 0)
                {
                    this.MensajeError("No hay fila para remover");
                }
                else
                {
                    int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                    DataRow row = this.dtDetalle.Rows[indiceFila];
                    //Disminuir el totalPAgado
                    this.totalPagado = this.totalPagado - Convert.ToDecimal(row["Subtotal"].ToString());
                    this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                    //Removemos la fila
                    this.dtDetalle.Rows.Remove(row);

                }
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bError = false;
            try
            {
                string rpta = "";
                if (string.IsNullOrWhiteSpace(this.txtCliente.Text))
                {
                    errorIcono.SetError(txtSerie, "Ingrese un cliente");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtIdcliente.Text))
                {
                    errorIcono.SetError(txtIdcliente, "Ingrese un cliente");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtSerie.Text))
                {
                    errorIcono.SetError(txtSerie, "Ingrese un el numero de serie");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cbTipoComprobante.Text))
                {
                    errorIcono.SetError(cbTipoComprobante, "Elija un comprobante");
                    bError = true;
                }
                if (this.dataListadoDetalle.Rows.Count == 0)
                {
                    errorIcono.SetError(dataListadoDetalle, "No ha ingresado ningún detalle de ingreso");
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
                        rpta = Nventa.Insertar(Convert.ToInt32(this.txtIdcliente.Text), this.IdUSUARIO, this.dtFechaIngresoAlmacen.Value, cbTipoComprobante.Text, txtSerie.Text, 
                            Convert.ToDecimal(txtISV.Text), dtDetalle);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                            errorIcono.SetError(txtIdcliente, "");
                            errorIcono.SetError(txtIdcliente, "");
                            errorIcono.SetError(txtSerie, "");
                        }


                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnComprobante_Click(object sender, EventArgs e)
        {

        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteVentas Reporte = new Reportes.FrmReporteVentas();
            Reporte.ShowDialog();
        }

        private void BtnReturn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtStockActual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void dataListadoDetalle_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            errorIcono.SetError(dataListadoDetalle, "");

        }

        private void txtPrecioVenta_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtPrecioVenta, "");
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtCantidad, "");
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtDescuento, "");
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtArticulo, "");
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtSerie, "");
        }

        private void cbTipoComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cbTipoComprobante, "");
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtCliente, "");
        }

        private void txtIdcliente_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtIdcliente, "");
        }
    }
    
}
