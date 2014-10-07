namespace Presentacion.Producto
{
    partial class FormRestaurarSeleccion
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtR2 = new System.Windows.Forms.RadioButton();
            this.rbtR3 = new System.Windows.Forms.RadioButton();
            this.rbtR1 = new System.Windows.Forms.RadioButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panelEx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "De Cual desea realizar la restauracion ? ";
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(382, 164);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtR2);
            this.groupBox1.Controls.Add(this.rbtR3);
            this.groupBox1.Controls.Add(this.rbtR1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(15, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 109);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Respaldos";
            // 
            // rbtR2
            // 
            this.rbtR2.AutoSize = true;
            this.rbtR2.Location = new System.Drawing.Point(20, 50);
            this.rbtR2.Name = "rbtR2";
            this.rbtR2.Size = new System.Drawing.Size(41, 17);
            this.rbtR2.TabIndex = 1;
            this.rbtR2.TabStop = true;
            this.rbtR2.Text = "R0";
            this.rbtR2.UseVisualStyleBackColor = true;
            this.rbtR2.CheckedChanged += new System.EventHandler(this.rbtR2_CheckedChanged);
            // 
            // rbtR3
            // 
            this.rbtR3.AutoSize = true;
            this.rbtR3.Location = new System.Drawing.Point(20, 76);
            this.rbtR3.Name = "rbtR3";
            this.rbtR3.Size = new System.Drawing.Size(41, 17);
            this.rbtR3.TabIndex = 2;
            this.rbtR3.TabStop = true;
            this.rbtR3.Text = "R0";
            this.rbtR3.UseVisualStyleBackColor = true;
            this.rbtR3.CheckedChanged += new System.EventHandler(this.rbtR3_CheckedChanged);
            // 
            // rbtR1
            // 
            this.rbtR1.AutoSize = true;
            this.rbtR1.Location = new System.Drawing.Point(20, 22);
            this.rbtR1.Name = "rbtR1";
            this.rbtR1.Size = new System.Drawing.Size(41, 17);
            this.rbtR1.TabIndex = 0;
            this.rbtR1.TabStop = true;
            this.rbtR1.Text = "R0";
            this.rbtR1.UseVisualStyleBackColor = true;
            this.rbtR1.CheckedChanged += new System.EventHandler(this.rbtR1_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(188, 170);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(295, 170);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormRestaurarSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 201);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panelEx1);
            this.Name = "FormRestaurarSeleccion";
            this.Text = "Seleccione un Respaldo";
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton rbtR2;
        public System.Windows.Forms.RadioButton rbtR3;
        public System.Windows.Forms.RadioButton rbtR1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}