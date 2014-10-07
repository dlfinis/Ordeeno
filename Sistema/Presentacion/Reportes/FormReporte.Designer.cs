namespace Presentacion.Reportes
{
    partial class FormReporte
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerar = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkVenta = new Negocios.Componente.BigCheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkFecha = new Negocios.Componente.BigCheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpPanel = new System.Windows.Forms.TabControl();
            this.tbcVenta = new System.Windows.Forms.TabPage();
            this.tbcCompra = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.chkPedido = new Negocios.Componente.BigCheckBox();
            this.tbcUtilidad = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtNombre = new Negocios.Componente.DevStringWTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.chkProducto = new Negocios.Componente.BigCheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chkVentaUtilidad = new Negocios.Componente.BigCheckBox();
            this.pnlFecha = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbpPanel.SuspendLayout();
            this.tbcVenta.SuspendLayout();
            this.tbcCompra.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tbcUtilidad.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnlFecha.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GrayText;
            this.flowLayoutPanel1.Controls.Add(this.btnGenerar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 343);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(478, 40);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // btnGenerar
            // 
            this.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnGenerar.Location = new System.Drawing.Point(3, 3);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(102, 30);
            this.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkVenta);
            this.panel2.Location = new System.Drawing.Point(11, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(226, 33);
            this.panel2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ventas No Confirmadas";
            // 
            // chkVenta
            // 
            // 
            // 
            // 
            this.chkVenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkVenta.Checked = true;
            this.chkVenta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVenta.CheckValue = "S";
            this.chkVenta.CheckValueChecked = "S";
            this.chkVenta.Location = new System.Drawing.Point(13, 2);
            this.chkVenta.Name = "chkVenta";
            this.chkVenta.Size = new System.Drawing.Size(25, 25);
            this.chkVenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkVenta.TabIndex = 0;
            this.chkVenta.Text = "bigCheckBox1";
            this.chkVenta.CheckedChanged += new System.EventHandler(this.chkConfirmar_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.chkFecha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(23, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 34);
            this.panel1.TabIndex = 6;
            // 
            // chkFecha
            // 
            // 
            // 
            // 
            this.chkFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkFecha.CheckValueChecked = "S";
            this.chkFecha.Checked = false;
            this.chkFecha.Location = new System.Drawing.Point(14, 2);
            this.chkFecha.Name = "chkFecha";
            this.chkFecha.Size = new System.Drawing.Size(25, 25);
            this.chkFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkFecha.TabIndex = 6;
            this.chkFecha.Text = "bigCheckBox1";
            this.chkFecha.CheckedChanged += new System.EventHandler(this.chkFecha_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Fechas de Analisis";
            // 
            // dateFechaFinal
            // 
            this.dateFechaFinal.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.dateFechaFinal.Enabled = false;
            this.dateFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.dateFechaFinal.Location = new System.Drawing.Point(143, 45);
            this.dateFechaFinal.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateFechaFinal.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateFechaFinal.Name = "dateFechaFinal";
            this.dateFechaFinal.Size = new System.Drawing.Size(196, 19);
            this.dateFechaFinal.TabIndex = 10007;
            this.dateFechaFinal.Value =  System.DateTime.Today;
            this.dateFechaFinal.ValueChanged += new System.EventHandler(this.dateFechaFinal_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Final :";
            // 
            // dateFechaInicial
            // 
            this.dateFechaInicial.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.dateFechaInicial.Enabled = false;
            this.dateFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.dateFechaInicial.Location = new System.Drawing.Point(143, 14);
            this.dateFechaInicial.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateFechaInicial.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dateFechaInicial.Name = "dateFechaInicial";
            this.dateFechaInicial.Size = new System.Drawing.Size(196, 19);
            this.dateFechaInicial.Value = System.DateTime.Today.AddDays(-1);
            this.dateFechaInicial.TabIndex = 10006;
            this.dateFechaInicial.ValueChanged += new System.EventHandler(this.dateFechaInicio_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Iniciall :";
            // 
            // tbpPanel
            // 
            this.tbpPanel.Controls.Add(this.tbcVenta);
            this.tbpPanel.Controls.Add(this.tbcCompra);
            this.tbpPanel.Controls.Add(this.tbcUtilidad);
            this.tbpPanel.HotTrack = true;
            this.tbpPanel.Location = new System.Drawing.Point(23, 145);
            this.tbpPanel.Multiline = true;
            this.tbpPanel.Name = "tbpPanel";
            this.tbpPanel.SelectedIndex = 0;
            this.tbpPanel.Size = new System.Drawing.Size(372, 183);
            this.tbpPanel.TabIndex = 10;
            // 
            // tbcVenta
            // 
            this.tbcVenta.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbcVenta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbcVenta.Controls.Add(this.panel2);
            this.tbcVenta.ForeColor = System.Drawing.Color.Black;
            this.tbcVenta.Location = new System.Drawing.Point(4, 24);
            this.tbcVenta.Name = "tbcVenta";
            this.tbcVenta.Padding = new System.Windows.Forms.Padding(3);
            this.tbcVenta.Size = new System.Drawing.Size(364, 155);
            this.tbcVenta.TabIndex = 0;
            this.tbcVenta.Text = "Ventas";
            // 
            // tbcCompra
            // 
            this.tbcCompra.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbcCompra.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbcCompra.Controls.Add(this.panel3);
            this.tbcCompra.Location = new System.Drawing.Point(4, 24);
            this.tbcCompra.Name = "tbcCompra";
            this.tbcCompra.Padding = new System.Windows.Forms.Padding(3);
            this.tbcCompra.Size = new System.Drawing.Size(364, 155);
            this.tbcCompra.TabIndex = 1;
            this.tbcCompra.Text = "Compras";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.chkPedido);
            this.panel3.Location = new System.Drawing.Point(11, 54);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(226, 33);
            this.panel3.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Pedidos No Confirmados";
            // 
            // chkPedido
            // 
            // 
            // 
            // 
            this.chkPedido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkPedido.Checked = true;
            this.chkPedido.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPedido.CheckValue = "S";
            this.chkPedido.CheckValueChecked = "S";
            this.chkPedido.Location = new System.Drawing.Point(13, 2);
            this.chkPedido.Name = "chkPedido";
            this.chkPedido.Size = new System.Drawing.Size(25, 25);
            this.chkPedido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkPedido.TabIndex = 0;
            this.chkPedido.Text = "bigCheckBox1";
            this.chkPedido.Click += new System.EventHandler(this.chkPedido_Click);
            // 
            // tbcUtilidad
            // 
            this.tbcUtilidad.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tbcUtilidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbcUtilidad.Controls.Add(this.panel5);
            this.tbcUtilidad.Controls.Add(this.panel4);
            this.tbcUtilidad.Location = new System.Drawing.Point(4, 24);
            this.tbcUtilidad.Name = "tbcUtilidad";
            this.tbcUtilidad.Padding = new System.Windows.Forms.Padding(3);
            this.tbcUtilidad.Size = new System.Drawing.Size(364, 155);
            this.tbcUtilidad.TabIndex = 2;
            this.tbcUtilidad.Text = "Utilidades";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightGray;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.txtNombre);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.chkProducto);
            this.panel5.Location = new System.Drawing.Point(12, 54);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(333, 83);
            this.panel5.TabIndex = 9;
            // 
            // txtNombre
            // 
            // 
            // 
            // 
            this.txtNombre.Border.Class = "TextBoxBorder";
            this.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtNombre.Location = new System.Drawing.Point(13, 45);
            this.txtNombre.MaxLength = 300;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtNombre.Size = new System.Drawing.Size(307, 22);
            this.txtNombre.TabIndex = 12;
            this.txtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNombre.WatermarkText = "Nombre";
            this.txtNombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombre_KeyDown);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Producto Definido ";
            // 
            // chkProducto
            // 
            // 
            // 
            // 
            this.chkProducto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkProducto.CheckValueChecked = "S";
            this.chkProducto.Location = new System.Drawing.Point(13, 15);
            this.chkProducto.Name = "chkProducto";
            this.chkProducto.Size = new System.Drawing.Size(25, 25);
            this.chkProducto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkProducto.TabIndex = 0;
            this.chkProducto.Text = "bigCheckBox1";
            this.chkProducto.CheckedChanged += new System.EventHandler(this.chkProducto_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.chkVentaUtilidad);
            this.panel4.Location = new System.Drawing.Point(12, 15);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(211, 33);
            this.panel4.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ventas No Confirmadas";
            // 
            // chkVentaUtilidad
            // 
            // 
            // 
            // 
            this.chkVentaUtilidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkVentaUtilidad.Checked = true;
            this.chkVentaUtilidad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVentaUtilidad.CheckValue = "S";
            this.chkVentaUtilidad.CheckValueChecked = "S";
            this.chkVentaUtilidad.Location = new System.Drawing.Point(13, 2);
            this.chkVentaUtilidad.Name = "chkVentaUtilidad";
            this.chkVentaUtilidad.Size = new System.Drawing.Size(25, 25);
            this.chkVentaUtilidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkVentaUtilidad.TabIndex = 0;
            this.chkVentaUtilidad.Text = "bigCheckBox1";
            // 
            // pnlFecha
            // 
            this.pnlFecha.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.pnlFecha.Controls.Add(this.dateFechaFinal);
            this.pnlFecha.Controls.Add(this.dateFechaInicial);
            this.pnlFecha.Controls.Add(this.label2);
            this.pnlFecha.Controls.Add(this.label1);
            this.pnlFecha.Location = new System.Drawing.Point(23, 50);
            this.pnlFecha.Name = "pnlFecha";
            this.pnlFecha.Size = new System.Drawing.Size(372, 82);
            this.pnlFecha.TabIndex = 11;
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(478, 383);
            this.Controls.Add(this.pnlFecha);
            this.Controls.Add(this.tbpPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "FormReporte";
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.FormReporte_Load);
            this.Resize += new System.EventHandler(this.FormReporte_Resize);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tbpPanel.ResumeLayout(false);
            this.tbcVenta.ResumeLayout(false);
            this.tbcCompra.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tbcUtilidad.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnlFecha.ResumeLayout(false);
            this.pnlFecha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateFechaFinal;
        private System.Windows.Forms.DateTimePicker dateFechaInicial;
        private DevComponents.DotNetBar.ButtonX btnGenerar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private Negocios.Componente.BigCheckBox chkVenta;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Negocios.Componente.BigCheckBox chkFecha;
        private System.Windows.Forms.TabControl tbpPanel;
        private System.Windows.Forms.TabPage tbcVenta;
        private System.Windows.Forms.TabPage tbcCompra;
        private System.Windows.Forms.TabPage tbcUtilidad;
        private System.Windows.Forms.Panel pnlFecha;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private Negocios.Componente.BigCheckBox chkPedido;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private Negocios.Componente.BigCheckBox chkProducto;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private Negocios.Componente.BigCheckBox chkVentaUtilidad;
        private Negocios.Componente.DevStringWTextBox txtNombre;
    }
}