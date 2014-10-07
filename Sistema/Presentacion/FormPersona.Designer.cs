namespace Presentacion
{
    partial class FormPersona
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
            this.txtApellido = new Negocios.Componente.DevStringTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new Negocios.Componente.DevStringWTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new Negocios.Componente.DevNumericTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCelular = new Negocios.Componente.DevNumericTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new Negocios.Componente.DevNumericTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCiudad = new Negocios.Componente.DevStringWTextBox(this.components);
            this.ribbonBar1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // txtCodigo
            // 
            // 
            // 
            // 
            this.txtCodigo.Border.Class = "TextBoxBorder";
            this.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // ribbonBar1
            // 
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 339);
            this.ribbonBar1.Size = new System.Drawing.Size(310, 42);
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(102, 3);
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(210, 3);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.txtCiudad);
            this.panelEx1.Controls.Add(this.label8);
            this.panelEx1.Controls.Add(this.label7);
            this.panelEx1.Controls.Add(this.txtIdentificacion);
            this.panelEx1.Controls.Add(this.label6);
            this.panelEx1.Controls.Add(this.txtCelular);
            this.panelEx1.Controls.Add(this.label5);
            this.panelEx1.Controls.Add(this.txtTelefono);
            this.panelEx1.Controls.Add(this.label4);
            this.panelEx1.Controls.Add(this.txtDireccion);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txtApellido);
            this.panelEx1.Size = new System.Drawing.Size(310, 381);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Controls.SetChildIndex(this.label2, 0);
            this.panelEx1.Controls.SetChildIndex(this.label1, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtApellido, 0);
            this.panelEx1.Controls.SetChildIndex(this.label3, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtDireccion, 0);
            this.panelEx1.Controls.SetChildIndex(this.label4, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtTelefono, 0);
            this.panelEx1.Controls.SetChildIndex(this.label5, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtCelular, 0);
            this.panelEx1.Controls.SetChildIndex(this.label6, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtIdentificacion, 0);
            this.panelEx1.Controls.SetChildIndex(this.label7, 0);
            this.panelEx1.Controls.SetChildIndex(this.label8, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtCodigo, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtNombre, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtCiudad, 0);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Size = new System.Drawing.Size(58, 15);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Size = new System.Drawing.Size(52, 15);
            // 
            // txtApellido
            // 
            // 
            // 
            // 
            this.txtApellido.Border.Class = "TextBoxBorder";
            this.txtApellido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtApellido.Location = new System.Drawing.Point(88, 90);
            this.txtApellido.MaxLength = 300;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(191, 22);
            this.txtApellido.TabIndex = 9;
            this.txtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtApellido.WatermarkText = "Ingrese Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(24, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(18, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Direccion";
            // 
            // txtDireccion
            // 
            // 
            // 
            // 
            this.txtDireccion.Border.Class = "TextBoxBorder";
            this.txtDireccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDireccion.Location = new System.Drawing.Point(89, 133);
            this.txtDireccion.MaxLength = 300;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(191, 22);
            this.txtDireccion.TabIndex = 11;
            this.txtDireccion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDireccion.WatermarkText = "Ingrese Direccion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(16, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Telefono";
            // 
            // txtTelefono
            // 
            // 
            // 
            // 
            this.txtTelefono.Border.Class = "TextBoxBorder";
            this.txtTelefono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTelefono.CantidadDecimal = 4;
            this.txtTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTelefono.Location = new System.Drawing.Point(90, 220);
            this.txtTelefono.MaxLength = 10;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.NumeroDecimal = false;
            this.txtTelefono.Size = new System.Drawing.Size(139, 22);
            this.txtTelefono.TabIndex = 13;
            this.txtTelefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTelefono.WatermarkText = "Ingrese Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(24, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Celular";
            // 
            // txtCelular
            // 
            // 
            // 
            // 
            this.txtCelular.Border.Class = "TextBoxBorder";
            this.txtCelular.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCelular.CantidadDecimal = 4;
            this.txtCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCelular.Location = new System.Drawing.Point(90, 248);
            this.txtCelular.MaxLength = 10;
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.NumeroDecimal = false;
            this.txtCelular.Size = new System.Drawing.Size(139, 22);
            this.txtCelular.TabIndex = 15;
            this.txtCelular.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCelular.WatermarkText = "Ingrese Celular";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(12, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Identificacion";
            // 
            // txtIdentificacion
            // 
            // 
            // 
            // 
            this.txtIdentificacion.Border.Class = "TextBoxBorder";
            this.txtIdentificacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdentificacion.CantidadDecimal = 4;
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtIdentificacion.Location = new System.Drawing.Point(119, 298);
            this.txtIdentificacion.MaxLength = 15;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.NumeroDecimal = false;
            this.txtIdentificacion.Size = new System.Drawing.Size(162, 22);
            this.txtIdentificacion.TabIndex = 17;
            this.txtIdentificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdentificacion.WatermarkText = "Ingrese  # de Identif.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(29, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            // 
            // 
            // 
            this.txtCiudad.Border.Class = "TextBoxBorder";
            this.txtCiudad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCiudad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCiudad.Location = new System.Drawing.Point(90, 177);
            this.txtCiudad.MaxLength = 300;
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(156, 22);
            this.txtCiudad.TabIndex = 20;
            this.txtCiudad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCiudad.WatermarkText = "Ingrese Ciudad";
            // 
            // FormPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 381);
            this.Name = "FormPersona";
            this.Text = "Persona";
            this.ribbonBar1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public Negocios.Componente.DevStringTextBox txtApellido;
        public Negocios.Componente.DevNumericTextBox txtIdentificacion;
        public Negocios.Componente.DevNumericTextBox txtCelular;
        public Negocios.Componente.DevNumericTextBox txtTelefono;
        public Negocios.Componente.DevStringWTextBox txtDireccion;
        public Negocios.Componente.DevStringWTextBox txtCiudad;
      
       
    }
}