namespace Presentacion.Producto
{
    partial class FormUnidad
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrefijo = new Negocios.Componente.DevStringTextBox(this.components);
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
            this.txtNombre.WatermarkText = "Ingrese Nombre Unidad";
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
            this.ribbonBar1.Location = new System.Drawing.Point(0, 128);
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
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.txtPrefijo);
            this.panelEx1.Size = new System.Drawing.Size(329, 170);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Controls.SetChildIndex(this.label2, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtCodigo, 0);
            this.panelEx1.Controls.SetChildIndex(this.label1, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtNombre, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtPrefijo, 0);
            this.panelEx1.Controls.SetChildIndex(this.label3, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(32, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Prefijo";
            // 
            // txtPrefijo
            // 
            // 
            // 
            // 
            this.txtPrefijo.Border.Class = "TextBoxBorder";
            this.txtPrefijo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPrefijo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPrefijo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPrefijo.Location = new System.Drawing.Point(89, 93);
            this.txtPrefijo.MaxLength = 3;
            this.txtPrefijo.Name = "txtPrefijo";
            this.txtPrefijo.Size = new System.Drawing.Size(81, 22);
            this.txtPrefijo.TabIndex = 13;
            this.txtPrefijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrefijo.WatermarkText = "Ing.. Pref.";
            // 
            // FormUnidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 170);
            this.Name = "FormUnidad";
            this.Text = "Unidad";
            this.ribbonBar1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        public Negocios.Componente.DevStringTextBox txtPrefijo;
    }
}