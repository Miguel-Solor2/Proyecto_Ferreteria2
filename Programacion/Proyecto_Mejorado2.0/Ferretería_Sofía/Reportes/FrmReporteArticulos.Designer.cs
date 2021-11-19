
namespace Ferretería_Sofía.Reportes
{
    partial class FrmReporteArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.SP_MOSTRAR_ARTICULOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsSistema = new Ferretería_Sofía.Reportes.DsSistema();
            this.SP_MOSTRAR_ARTICULOTableAdapter = new Ferretería_Sofía.Reportes.DsSistemaTableAdapters.SP_MOSTRAR_ARTICULOTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOSTRAR_ARTICULOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            this.SuspendLayout();
            // 
            // SP_MOSTRAR_ARTICULOBindingSource
            // 
            this.SP_MOSTRAR_ARTICULOBindingSource.DataMember = "SP_MOSTRAR_ARTICULO";
            this.SP_MOSTRAR_ARTICULOBindingSource.DataSource = this.DsSistema;
            // 
            // DsSistema
            // 
            this.DsSistema.DataSetName = "DsSistema";
            this.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_MOSTRAR_ARTICULOTableAdapter
            // 
            this.SP_MOSTRAR_ARTICULOTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtsArticulos";
            reportDataSource1.Value = this.SP_MOSTRAR_ARTICULOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Ferretería_Sofía.Reportes.RptArticulos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmReporteArticuos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteArticuos";
            this.Text = "FrmReporteArticuos";
            this.Load += new System.EventHandler(this.FrmReporteArticuos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOSTRAR_ARTICULOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource SP_MOSTRAR_ARTICULOBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.SP_MOSTRAR_ARTICULOTableAdapter SP_MOSTRAR_ARTICULOTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}