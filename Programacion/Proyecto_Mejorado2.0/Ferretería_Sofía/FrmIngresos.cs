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
    public partial class FrmIngresos : Form
    {
        public int IdUSUARIO;
        private bool Isnuevo;
        private decimal totalPagado = 0;
        private DataTable dtDetalle;
        private static FrmIngresos _instancia;

        //Creamos una instancia para poder utilizar los
        //Objetos del formulario
        public static FrmIngresos GetInstancia_()
        {
            if (_instancia == null)
            {
                _instancia = new FrmIngresos();
            }
            return _instancia;
        }
        //Creamos un método para enviar los valores recibidos
        //del proveedor
        public void setProveedor(string idproveedor, string nombre)
        {
            this.txtIdproveedor.Text = idproveedor;
            this.txtProveedor.Text = nombre;
        }

        //Creamos un método para enviar los valores recibidos
        //del artículo
        public void setArticulo(string idarticulo, string nombre)
        {
            this.txtidArticulo.Text = idarticulo;
            this.txtArticulo.Text = nombre;
        }
        public FrmIngresos()
        { 
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtProveedor, "Seleccione el proveedor");
            this.ttMensaje.SetToolTip(this.txtcomprobante, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtStock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtArticulo, "Seleccione el articulo de compra");
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
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
            this.txtIdIngreso.Text = string.Empty;
            this.txtIdproveedor.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            this.txtcomprobante.Text = string.Empty;
            this.txtIVA.Text = string.Empty;
            this.lblTotalPagado.Text = "0,0";
            this.txtIVA.Text = "18";
            this.crearTabla();

        }
        private void limpiarDetalle()
        {

            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
        }

        //Habilita los controles de los formularios
        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtcomprobante.ReadOnly = !valor;
            this.txtIVA.ReadOnly = !valor;
            this.dtFechaIngresoAlmacen.Enabled = valor;
            this.cbTipoComprobante.Enabled = valor;
            this.txtArticulo.ReadOnly = !valor;
            this.txtProveedor.ReadOnly = !valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.dtFechaProduccion.Enabled = valor;
            this.dtFechaVencimiento.Enabled = valor;
            this.cmbestado.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnBuscarArticulo.Enabled = valor;
        }

        //Habilita los botones
        private void Botones()
        {
            if (this.Isnuevo)
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
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[3].Visible = false;
        }

        //Método Mostrar()
        private void Mostrar()
        {
            this.dataListado.DataSource = Ningresos.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFecha
        private void BuscarFechas()
        {
            this.dataListado.DataSource = Ningresos.BuscarFechas(this.dtFechaInicio.Value.ToString("dd/MM/yyyy"),
                this.dtFechaFin.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);

        }
        //mostrar detalles
        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = Ningresos.MostrarDetalle(this.txtIdIngreso.Text);
        }

        private void BtnReturn_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmIngresos_Load(object sender, EventArgs e)
        {
            //Para ubicar al formulario en la parte superior del contenedor
            //this.Top = 0;
            //this.Left = 0;
            //Mostrar
            this.Mostrar();
            //Deshabilita los controles
            this.Habilitar(false);
            //Establece los botones
            this.Botones();
            this.crearTabla();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ingreso vista = new FrmVistaArticulo_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Ingresos", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = Ningresos.Anular(Convert.ToInt32(Codigo));

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
            if (e.ColumnIndex == dataListado.Columns["Anular"].Index)
            {
                DataGridViewCheckBoxCell ChkAnular =
                    (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Anular"];
                ChkAnular.Value = !Convert.ToBoolean(ChkAnular.Value);
            }
        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("Art_ID", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Nombre_Art", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("Precio_Compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Stock_Ingreso", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Stock_Actual", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("Fecha_Produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Fecha_Vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Estado", System.Type.GetType("System.String"));
            //relacionar nuestro Datagrid con la datatable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Isnuevo = true;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.Habilitar(true);
            this.txtcomprobante.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Isnuevo = false;
            this.Botones();
            this.Limpiar();
            this.limpiarDetalle();
            this.txtIdIngreso.Text = string.Empty;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                //La variable que almacena si se inserto 
                //o se modifico la tabla
                string Rpta = "";
                if (this.txtProveedor.Text == string.Empty || this.txtcomprobante.Text == string.Empty || txtIVA.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtProveedor, "Seleccione un Proveedor");
                    errorIcono.SetError(txtcomprobante, "Ingrese la serie del comprobante");
                    errorIcono.SetError(txtIVA, "Ingrese el porcentaje de IVA");
                }
                else
                {
                    if (this.Isnuevo)
                    {
                        //Vamos a insertar un Ingreso 
                        Rpta = Ningresos.Insertar(this.IdUSUARIO, Convert.ToInt32(txtIdproveedor.Text),
                        dtFechaIngresoAlmacen.Value, cbTipoComprobante.Text,
                        txtcomprobante.Text, Convert.ToDecimal(txtIVA.Text), cmbestado.Text, dtDetalle);

                    }

                    //Si la respuesta fue OK, fue porque se modifico 
                    //o inserto el Ingreso
                    //de forma correcta
                    if (Rpta.Equals("OK"))
                    {

                        this.MensajeOK("Se insertó de forma correcta el registro");


                    }
                    else
                    {
                        //Mostramos el mensaje de error
                        this.MensajeError(Rpta);
                    }
                    this.Isnuevo = false;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtArticulo.Text == string.Empty || this.txtStock.Text == string.Empty || txtPrecioCompra.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtArticulo, "Seleccione un Artículo");
                    errorIcono.SetError(txtStock, "Ingrese el stock inicial");
                    errorIcono.SetError(txtPrecioCompra, "Ingrese el precio de Compra");
                }
                else
                {
                    //Variable que va a indicar si podemos registrar el detalle
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["Art_ID"]) == Convert.ToInt32(this.txtidArticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("Ya se encuentra el artículo en el detalle");
                        }
                    }
                    //Si podemos registrar el producto en el detalle
                    if (registrar)
                    {
                        //Calculamos el sub total del detalle sin descuento
                        decimal subTotal = Convert.ToDecimal(this.txtPrecioCompra.Text) * Convert.ToDecimal(txtStock.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //Agregamos al fila a nuestro datatable
                        DataRow row = this.dtDetalle.NewRow();
                        row["Art_ID"] = Convert.ToInt32(this.txtidArticulo.Text);
                        row["Nombre_Art"] = this.txtArticulo.Text;
                        row["Precio_Compra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["Stock_Ingreso"] = Convert.ToInt32(this.txtStock.Text);
                        row["Stock_Actual"] = Convert.ToInt32(this.txtStock.Text);
                        row["Fecha_Produccion"] = this.dtFechaProduccion.Value;
                        row["Fecha_Vencimiento"] = this.dtFechaVencimiento.Value;
                        row["SubTotal"] = subTotal;
                        row["Estado"] = this.cmbestado.Text;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();
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
                //Indice dila actualmente seleccionado y que vamos a eliminar
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                //Fila que vamos a eliminar
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuimos el total a pagar
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subTotal"].ToString());
                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Ingreso"].Value);
            this.txtIdproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Proveedor"].Value);
            this.txtProveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Proveedor"].Value);
            this.dtFechaIngresoAlmacen.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["Fecha_Ingreso"].Value);
            this.cbTipoComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Tipo_Comprobante"].Value);
            this.txtcomprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Serie"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Total"].Value);
            this.cmbestado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            this.txtIVA.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["IVA"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteIngresos Reporte = new Reportes.FrmReporteIngresos();
            Reporte.ShowDialog();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
