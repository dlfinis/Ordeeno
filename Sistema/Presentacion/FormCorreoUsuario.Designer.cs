namespace Presentacion
{
    partial class FormCorreoUsuario
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMensaje = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEnviar = new DevComponents.DotNetBar.ButtonX();
            this.btnCancelar = new DevComponents.DotNetBar.ButtonX();
            this.txtEmail = new Negocios.Componente.DevStringWTextBox(this.components);
            this.txtClave = new Negocios.Componente.DevStringWTextBox(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "E-mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Clave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 45);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mensaje\r\nAdicional\r\n(Opcional)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "- Se enviara el Log de Errores\r\n- Atraves de su Correo Electronico";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(93, 96);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(267, 96);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btnEnviar);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 43);
            this.panel1.TabIndex = 13;
            // 
            // btnEnviar
            // 
            this.btnEnviar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEnviar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEnviar.Image = global::Presentacion.Properties.Resources.Mail_Read;
            this.btnEnviar.Location = new System.Drawing.Point(94, 4);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(94, 33);
            this.btnEnviar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelar.Image = global::Presentacion.Properties.Resources.Close;
            this.btnCancelar.ImageTextSpacing = 2;
            this.btnCancelar.Location = new System.Drawing.Point(202, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(94, 33);
            this.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.Border.Class = "TextBoxBorder";
            this.txtEmail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(93, 20);
            this.txtEmail.MaxLength = 300;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtEmail.Size = new System.Drawing.Size(236, 22);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.WatermarkText = "Ingrese su Correo Electronico";
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtClave
            // 
            // 
            // 
            // 
            this.txtClave.Border.Class = "TextBoxBorder";
            this.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtClave.Location = new System.Drawing.Point(93, 57);
            this.txtClave.MaxLength = 300;
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(191, 22);
            this.txtClave.TabIndex = 1;
            this.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtClave.WatermarkText = "Ingrese la Clave del Correo";
            // 
            // FormCorreoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 287);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormCorreoUsuario";
            this.Text = "Envio de Correo";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtMensaje;
        private System.Windows.Forms.Panel panel1;
        public DevComponents.DotNetBar.ButtonX btnEnviar;
        public DevComponents.DotNetBar.ButtonX btnCancelar;
        private Negocios.Componente.DevStringWTextBox txtEmail;
        private Negocios.Componente.DevStringWTextBox txtClave;
    }
}