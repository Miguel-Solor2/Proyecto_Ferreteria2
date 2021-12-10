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
    public partial class FrmArticulos : Form
    {
        

        private bool IsNuevo = false;

        private bool IsEditar = false;

        private static FrmArticulos _Instancia;

        public static FrmArticulos GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmArticulos();
            }
            return _Instancia;
        }

        public void setCategoria (string idcategoria, string nombre)
        {
            this.txtIdCategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }

        public FrmArticulos()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre del Artículo");
            this.ttMensaje.SetToolTip(this.txtDescripcion, "Ingrese la descripción del Artículo");
            this.ttMensaje.SetToolTip(this.pxImagen, "Seleccione la imagen del artículo");
            this.txtIdCategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            this.LlenarPresentacion();

            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }

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
            this.txtDescripcion.Text = string.Empty;
            this.txtIdArticulo.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::Ferretería_Sofía.Properties.Resources.DEFAULT;
        }

        //Habilita los controles de los formularios
        private void Habilitar(bool valor)
        {
            this.txtIdCategoria.Enabled = valor;
            this.txtNombre.Enabled = valor;
            this.txtDescripcion.Enabled = valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.cmbPresentacion.Enabled = valor;
            this.cmbEstado.Enabled = valor;
            this.btnCargar.Enabled = valor;
            this.btnLimpiar.Enabled = valor;
        }
        //Habilita los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
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
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[7].Visible = false;
        }

        //Método Mostrar()
        private void Mostrar()
        {
            this.dataListado.DataSource = Narticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            foreach (DataGridViewRow fila in this.dataListado.Rows)
            {
                fila.Height = 160;
                
            }
            

            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }

        }

        //Método BuscarNombre

        private void BuscarNombre()
        {
            this.dataListado.DataSource = Narticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void LlenarPresentacion()
        {
            cmbPresentacion.DataSource = Npresentacion.MostrarCombo();
            cmbPresentacion.ValueMember = "ID_Presentacion";
            cmbPresentacion.DisplayMember = "Nombre_Presentacion";
        }


        private void BtnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            //Le decimos al DataGridView que no auto genere las columnas
            //this.datalistado.AutoGenerateColumns = false;
            //Llenamos el DataGridView con la información
            //de todos nuestros Artículos
            this.Mostrar();
            //Deshabilita los controles
            this.Habilitar(false);
            //Establece los botones
            this.Botones();
            int C = dataListado.Rows.Count;

            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pxImagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::Ferretería_Sofía.Properties.Resources.DEFAULT;
      
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
            foreach (DataGridViewRow fila in this.dataListado.Rows)
            {
                fila.Height = 160;

            }


            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdCategoria.Text = string.Empty;
            this.LlenarPresentacion();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bError = false;
            try
            {
                string rpta = "";
                if (string.IsNullOrWhiteSpace(this.txtNombre.Text))
                {
                    errorIcono.SetError(txtNombre, "Ingrese Nombre");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.txtCategoria.Text))
                {
                    errorIcono.SetError(txtCategoria, "Ingrese categoria");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cmbEstado.Text))
                {
                    errorIcono.SetError(cmbEstado, "Ingrese Estado");
                    bError = true;
                }
                if (string.IsNullOrWhiteSpace(this.cmbPresentacion.Text))
                {
                    errorIcono.SetError(cmbPresentacion, "Ingrese una presentacion");
                    bError = true;
                }
                if (bError == true)
                {
                    MessageBox.Show("Se ha olvidado de algunos campos", "Campos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Stream usado como buffer
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    // Se guarda la imagen en el buffer
                    pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {

                        rpta = Narticulo.Insertar( this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdCategoria.Text)
                            , Convert.ToInt32(cmbPresentacion.SelectedValue), this.cmbEstado.Text);
                    }
                    else
                    {
                        rpta = Narticulo.Editar(Convert.ToInt32(this.txtIdArticulo.Text), this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(txtIdCategoria.Text)
                            , Convert.ToInt32(cmbPresentacion.SelectedValue), this.cmbEstado.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOK("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOK("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
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
            this.txtIdArticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["ID_Art"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Art"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Descripcion_Art"].Value);
            //Mostramos la Imagen
            // El campo imagen primero se almacena en un buffer
            byte[] imagenBuffer = (byte[])this.dataListado.CurrentRow.Cells["Imagen"].Value;
            // Se crea un MemoryStream a partir de ese buffer
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            // Se utiliza el MemoryStream para extraer la imagen
            this.pxImagen.Image = Image.FromStream(ms);
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtIdCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria_ID"].Value);
            this.txtCategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Nombre_Categoria"].Value);
            this.cmbPresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["Presentacion_ID"].Value);
            this.cmbEstado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Estado"].Value);
            //this.cbIdpresentacion.DisplayMember = Convert.ToString(this.dataListado.CurrentRow.Cells["Presentacion"].Value);

            this.tabControl1.SelectedIndex = 1;
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
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
                            Rpta = Narticulo.Anular(Convert.ToInt32(Codigo));

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdArticulo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de buscar un registro para Modificar");
            }
            this.LlenarPresentacion();
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVistaCategoria form = new FrmVistaCategoria();
            form.ShowDialog();
        }

        private void btnBuscarCategoria_Click_1(object sender, EventArgs e)
        {
            FrmVistaCategoria form = new FrmVistaCategoria();
            form.ShowDialog();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            Reportes.FrmReporteArticulos Reporte = new Reportes.FrmReporteArticulos();
            Reporte.ShowDialog();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar >32 && e.KeyChar <= 64) || (e.KeyChar >=91 && e.KeyChar <=96) || (e.KeyChar >=123 && e.KeyChar <= 129) ||
            (e.KeyChar >= 131 && e.KeyChar <= 159) || (e.KeyChar >= 166 && e.KeyChar <= 255))
            {
                MessageBox.Show("Este campo solo admite letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtIdCategoria.Text = string.Empty;
            errorIcono.SetError(txtNombre, "");
            errorIcono.SetError(txtCategoria, "");
            errorIcono.SetError(cmbEstado, "");
            errorIcono.SetError(cmbPresentacion, "");
            this.LlenarPresentacion();
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

        private void dataListado_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lblTotal.Text = "Total Registros: " + Convert.ToString(dataListado.Rows.Count);
            foreach (DataGridViewRow fila in this.dataListado.Rows)
            {
                fila.Height = 160;

            }


            int C = dataListado.Rows.Count;
            for (int i = 0; i < C; i++)
            {
                if (dataListado.Rows[i].Cells[9].Value.ToString() == "INACTIVA")
                {
                    this.dataListado.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;

                }
            }
        }

        private void FrmArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtCategoria, "");
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(txtNombre, "");
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

        private void cmbPresentacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorIcono.SetError(cmbPresentacion, "");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
