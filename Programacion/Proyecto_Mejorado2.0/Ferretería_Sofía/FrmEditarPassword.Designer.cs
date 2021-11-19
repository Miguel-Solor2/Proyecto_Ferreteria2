
namespace Ferretería_Sofía
{
    partial class FrmEditarPassword
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
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.Lblconfirm = new System.Windows.Forms.Label();
            this.txtconfirm = new System.Windows.Forms.TextBox();
            this.Lblpassword = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.Lbluser = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Location = new System.Drawing.Point(357, 296);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(103, 48);
            this.BtnCancelar.TabIndex = 25;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnActualizar.Location = new System.Drawing.Point(480, 297);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(103, 47);
            this.BtnActualizar.TabIndex = 24;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // Lblconfirm
            // 
            this.Lblconfirm.AutoSize = true;
            this.Lblconfirm.BackColor = System.Drawing.Color.Transparent;
            this.Lblconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblconfirm.Location = new System.Drawing.Point(40, 233);
            this.Lblconfirm.Name = "Lblconfirm";
            this.Lblconfirm.Size = new System.Drawing.Size(311, 24);
            this.Lblconfirm.TabIndex = 23;
            this.Lblconfirm.Text = "Ingrese nuevamente su contraseña:";
            // 
            // txtconfirm
            // 
            this.txtconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconfirm.Location = new System.Drawing.Point(357, 234);
            this.txtconfirm.Name = "txtconfirm";
            this.txtconfirm.Size = new System.Drawing.Size(226, 24);
            this.txtconfirm.TabIndex = 22;
            // 
            // Lblpassword
            // 
            this.Lblpassword.AutoSize = true;
            this.Lblpassword.BackColor = System.Drawing.Color.Transparent;
            this.Lblpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblpassword.Location = new System.Drawing.Point(40, 179);
            this.Lblpassword.Name = "Lblpassword";
            this.Lblpassword.Size = new System.Drawing.Size(258, 24);
            this.Lblpassword.TabIndex = 21;
            this.Lblpassword.Text = "Ingrese su nueva contraseña:";
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(357, 180);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(226, 24);
            this.txtpassword.TabIndex = 20;
            // 
            // Lbluser
            // 
            this.Lbluser.AutoSize = true;
            this.Lbluser.BackColor = System.Drawing.Color.Transparent;
            this.Lbluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbluser.Location = new System.Drawing.Point(40, 124);
            this.Lbluser.Name = "Lbluser";
            this.Lbluser.Size = new System.Drawing.Size(170, 24);
            this.Lbluser.TabIndex = 19;
            this.Lbluser.Text = "Ingrese su usuario:";
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.Location = new System.Drawing.Point(357, 125);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(226, 24);
            this.txtuser.TabIndex = 18;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LblTitulo.Location = new System.Drawing.Point(12, 9);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(372, 42);
            this.LblTitulo.TabIndex = 17;
            this.LblTitulo.Text = "Cambiar contraseña";
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // FrmEditarPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ferretería_Sofía.Properties.Resources.pantallas;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 360);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.Lblconfirm);
            this.Controls.Add(this.txtconfirm);
            this.Controls.Add(this.Lblpassword);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.Lbluser);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.LblTitulo);
            this.Name = "FrmEditarPassword";
            this.Text = "FrmEditarPassword";
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Label Lblconfirm;
        private System.Windows.Forms.TextBox txtconfirm;
        private System.Windows.Forms.Label Lblpassword;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label Lbluser;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ErrorProvider errorIcono;
    }
}