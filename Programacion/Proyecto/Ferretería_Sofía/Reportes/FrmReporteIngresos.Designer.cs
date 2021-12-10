
namespace Ferretería_Sofía.Reportes
{
    partial class FrmReporteIngresos
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsSistema = new Ferretería_Sofía.Reportes.DsSistema();
            this.SP_MOSTRAR_INGRESO_NUEVOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_MOSTRAR_INGRESO_NUEVOTableAdapter = new Ferretería_Sofía.Reportes.DsSistemaTableAdapters.SP_MOSTRAR_INGRESO_NUEVOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOSTRAR_INGRESO_NUEVOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Dtsingreso";
            reportDataSource1.Value = this.SP_MOSTRAR_INGRESO_NUEVOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Ferretería_Sofía.Reportes.RptIngresos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // DsSistema
            // 
            this.DsSistema.DataSetName = "DsSistema";
            this.DsSistema.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SP_MOSTRAR_INGRESO_NUEVOBindingSource
            // 
            this.SP_MOSTRAR_INGRESO_NUEVOBindingSource.DataMember = "SP_MOSTRAR_INGRESO_NUEVO";
            this.SP_MOSTRAR_INGRESO_NUEVOBindingSource.DataSource = this.DsSistema;
            // 
            // SP_MOSTRAR_INGRESO_NUEVOTableAdapter
            // 
            this.SP_MOSTRAR_INGRESO_NUEVOTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteIngresos";
            this.Text = "FrmReporteIngresos";
            this.Load += new System.EventHandler(this.FrmReporteIngresos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOSTRAR_INGRESO_NUEVOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_MOSTRAR_INGRESO_NUEVOBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.SP_MOSTRAR_INGRESO_NUEVOTableAdapter SP_MOSTRAR_INGRESO_NUEVOTableAdapter;
    }
}