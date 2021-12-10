
namespace Ferretería_Sofía.Reportes
{
    partial class FrmReporteUsuarios
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
            this.SP_MOSTRAR_USUARIOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SP_MOSTRAR_USUARIOTableAdapter = new Ferretería_Sofía.Reportes.DsSistemaTableAdapters.SP_MOSTRAR_USUARIOTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOSTRAR_USUARIOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtsUsuarios";
            reportDataSource1.Value = this.SP_MOSTRAR_USUARIOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Ferretería_Sofía.Reportes.RptUsuarios.rdlc";
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
            // SP_MOSTRAR_USUARIOBindingSource
            // 
            this.SP_MOSTRAR_USUARIOBindingSource.DataMember = "SP_MOSTRAR_USUARIO";
            this.SP_MOSTRAR_USUARIOBindingSource.DataSource = this.DsSistema;
            // 
            // SP_MOSTRAR_USUARIOTableAdapter
            // 
            this.SP_MOSTRAR_USUARIOTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteUsuarios";
            this.Text = "FrmReporteUsuarios";
            this.Load += new System.EventHandler(this.FrmReporteUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsSistema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SP_MOSTRAR_USUARIOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SP_MOSTRAR_USUARIOBindingSource;
        private DsSistema DsSistema;
        private DsSistemaTableAdapters.SP_MOSTRAR_USUARIOTableAdapter SP_MOSTRAR_USUARIOTableAdapter;
    }
}