namespace Presentacion.Base
{
    partial class FormFactura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFactura));
            this.panelEx3 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.labelD = new System.Windows.Forms.Label();
            this.txtVDescuento = new Negocios.Componente.DevNumericTextBox();
            this.chkDescuento = new Negocios.Componente.BigCheckBox();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new Negocios.Componente.DevNumericTextBox();
            this.txtDescuento = new Negocios.Componente.DevNumericTextBox();
            this.txtIVA = new Negocios.Componente.DevNumericTextBox();
            this.txtSub0 = new Negocios.Componente.DevNumericTextBox();
            this.txtSub12 = new Negocios.Componente.DevNumericTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEx4 = new DevComponents.DotNetBar.PanelEx();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonX();
            this.btnVer = new DevComponents.DotNetBar.ButtonX();
            this.btnSalir = new DevComponents.DotNetBar.ButtonX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.pnlDetalle = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.txtIdentificacion = new Negocios.Componente.DevNumericTextBox();
            this.txtCliente = new Negocios.Componente.DevStringTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdbCotizacion = new System.Windows.Forms.RadioButton();
            this.rdbFactura = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPSeleccion = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new Negocios.Componente.DevNumericTextBox();
            this.panelEx3.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx3
            // 
            this.panelEx3.AntiAlias = false;
            this.panelEx3.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx3.Controls.Add(this.groupPanel4);
            this.panelEx3.Controls.Add(this.panelEx4);
            this.panelEx3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx3.Location = new System.Drawing.Point(0, 492);
            this.panelEx3.Name = "panelEx3";
            this.panelEx3.Size = new System.Drawing.Size(636, 247);
            this.panelEx3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx3.Style.GradientAngle = 90;
            this.panelEx3.TabIndex = 2;
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.labelD);
            this.groupPanel4.Controls.Add(this.txtVDescuento);
            this.groupPanel4.Controls.Add(this.chkDescuento);
            this.groupPanel4.Controls.Add(this.line1);
            this.groupPanel4.Controls.Add(this.label8);
            this.groupPanel4.Controls.Add(this.label7);
            this.groupPanel4.Controls.Add(this.label6);
            this.groupPanel4.Controls.Add(this.txtTotal);
            this.groupPanel4.Controls.Add(this.txtDescuento);
            this.groupPanel4.Controls.Add(this.txtIVA);
            this.groupPanel4.Controls.Add(this.txtSub0);
            this.groupPanel4.Controls.Add(this.txtSub12);
            this.groupPanel4.Controls.Add(this.label5);
            this.groupPanel4.Controls.Add(this.label4);
            this.groupPanel4.Location = new System.Drawing.Point(12, 16);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(610, 181);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 0;
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelD.Location = new System.Drawing.Point(328, 100);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(108, 16);
            this.labelD.TabIndex = 26;
            this.labelD.Text = "Descuento Valor";
            // 
            // txtVDescuento
            // 
            // 
            // 
            // 
            this.txtVDescuento.Border.Class = "TextBoxBorder";
            this.txtVDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVDescuento.CantidadDecimal = 4;
            this.txtVDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtVDescuento.Location = new System.Drawing.Point(452, 94);
            this.txtVDescuento.MaxLength = 15;
            this.txtVDescuento.Name = "txtVDescuento";
            this.txtVDescuento.NumeroDecimal = true;
            this.txtVDescuento.ReadOnly = true;
            this.txtVDescuento.Size = new System.Drawing.Size(132, 22);
            this.txtVDescuento.TabIndex = 25;
            this.txtVDescuento.Text = "0.00";
            this.txtVDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVDescuento.WatermarkText = "Ingrese";
            // 
            // chkDescuento
            // 
            // 
            // 
            // 
            this.chkDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDescuento.Checked = true;
            this.chkDescuento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDescuento.CheckValue = "S";
            this.chkDescuento.CheckValueChecked = "S";
            this.chkDescuento.Location = new System.Drawing.Point(105, 10);
            this.chkDescuento.Name = "chkDescuento";
            this.chkDescuento.Size = new System.Drawing.Size(25, 25);
            this.chkDescuento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.chkDescuento.TabIndex = 0;
            this.chkDescuento.Text = "bigCheckBox1";
            // 
            // line1
            // 
            this.line1.Location = new System.Drawing.Point(452, 111);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(132, 23);
            this.line1.TabIndex = 22;
            this.line1.Text = "line1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(380, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Total";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Descuento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(349, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "SubTotal IVA";
            // 
            // txtTotal
            // 
            // 
            // 
            // 
            this.txtTotal.Border.Class = "TextBoxBorder";
            this.txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.CantidadDecimal = 4;
            this.txtTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtTotal.Location = new System.Drawing.Point(452, 137);
            this.txtTotal.MaxLength = 15;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.NumeroDecimal = true;
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(132, 22);
            this.txtTotal.TabIndex = 18;
            this.txtTotal.Text = "0.00";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTotal.WatermarkText = "Ingrese";
            // 
            // txtDescuento
            // 
            // 
            // 
            // 
            this.txtDescuento.Border.Class = "TextBoxBorder";
            this.txtDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescuento.CantidadDecimal = 4;
            this.txtDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescuento.Location = new System.Drawing.Point(136, 12);
            this.txtDescuento.MaxLength = 15;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.NumeroDecimal = true;
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(132, 22);
            this.txtDescuento.TabIndex = 17;
            this.txtDescuento.Text = "0.00";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDescuento.WatermarkText = "Ingrese";
            // 
            // txtIVA
            // 
            // 
            // 
            // 
            this.txtIVA.Border.Class = "TextBoxBorder";
            this.txtIVA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIVA.CantidadDecimal = 4;
            this.txtIVA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtIVA.Location = new System.Drawing.Point(452, 66);
            this.txtIVA.MaxLength = 15;
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.NumeroDecimal = true;
            this.txtIVA.ReadOnly = true;
            this.txtIVA.Size = new System.Drawing.Size(132, 22);
            this.txtIVA.TabIndex = 16;
            this.txtIVA.Text = "0.00";
            this.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIVA.WatermarkText = "Ingrese";
            // 
            // txtSub0
            // 
            // 
            // 
            // 
            this.txtSub0.Border.Class = "TextBoxBorder";
            this.txtSub0.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSub0.CantidadDecimal = 4;
            this.txtSub0.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSub0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSub0.Location = new System.Drawing.Point(452, 38);
            this.txtSub0.MaxLength = 15;
            this.txtSub0.Name = "txtSub0";
            this.txtSub0.NumeroDecimal = true;
            this.txtSub0.ReadOnly = true;
            this.txtSub0.Size = new System.Drawing.Size(132, 22);
            this.txtSub0.TabIndex = 15;
            this.txtSub0.Text = "0.00";
            this.txtSub0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSub0.WatermarkText = "Ingrese";
            // 
            // txtSub12
            // 
            // 
            // 
            // 
            this.txtSub12.Border.Class = "TextBoxBorder";
            this.txtSub12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSub12.CantidadDecimal = 4;
            this.txtSub12.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSub12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSub12.Location = new System.Drawing.Point(452, 10);
            this.txtSub12.MaxLength = 15;
            this.txtSub12.Name = "txtSub12";
            this.txtSub12.NumeroDecimal = true;
            this.txtSub12.ReadOnly = true;
            this.txtSub12.Size = new System.Drawing.Size(132, 22);
            this.txtSub12.TabIndex = 13;
            this.txtSub12.Text = "0.00";
            this.txtSub12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSub12.WatermarkText = "Ingrese";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(369, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "SubTotal0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(362, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "SubTotal12";
            // 
            // panelEx4
            // 
            this.panelEx4.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx4.Controls.Add(this.btnNuevo);
            this.panelEx4.Controls.Add(this.btnVer);
            this.panelEx4.Controls.Add(this.btnSalir);
            this.panelEx4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEx4.Location = new System.Drawing.Point(0, 203);
            this.panelEx4.Name = "panelEx4";
            this.panelEx4.Size = new System.Drawing.Size(636, 44);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            this.panelEx4.TabIndex = 15;
            // 
            // btnNuevo
            // 
            this.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(263, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(103, 33);
            this.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNuevo.TabIndex = 12;
            this.btnNuevo.Text = "Grabar";
            // 
            // btnVer
            // 
            this.btnVer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnVer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnVer.Enabled = false;
            this.btnVer.Image = global::Presentacion.Properties.Resources.Tutorial;
            this.btnVer.Location = new System.Drawing.Point(136, 5);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(103, 33);
            this.btnVer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnVer.TabIndex = 14;
            this.btnVer.Text = "Ver";
            // 
            // btnSalir
            // 
            this.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(387, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 33);
            this.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            // 
            // panelEx2
            // 
            this.panelEx2.AntiAlias = false;
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.pnlDetalle);
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 244);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(636, 495);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.AntiAlias = false;
            this.pnlDetalle.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnlDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.pnlDetalle.DrawTitleBox = false;
            this.pnlDetalle.Location = new System.Drawing.Point(8, 6);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(616, 236);
            // 
            // 
            // 
            this.pnlDetalle.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pnlDetalle.Style.BackColorGradientAngle = 90;
            this.pnlDetalle.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnlDetalle.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlDetalle.Style.BorderBottomWidth = 1;
            this.pnlDetalle.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnlDetalle.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlDetalle.Style.BorderLeftWidth = 1;
            this.pnlDetalle.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlDetalle.Style.BorderRightWidth = 1;
            this.pnlDetalle.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.pnlDetalle.Style.BorderTopWidth = 1;
            this.pnlDetalle.Style.CornerDiameter = 4;
            this.pnlDetalle.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.pnlDetalle.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.pnlDetalle.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnlDetalle.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.pnlDetalle.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.pnlDetalle.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.pnlDetalle.TabIndex = 0;
            this.pnlDetalle.Text = "Detalle";
            // 
            // panelEx1
            // 
            this.panelEx1.AntiAlias = false;
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.txtIdentificacion);
            this.panelEx1.Controls.Add(this.txtCliente);
            this.panelEx1.Controls.Add(this.label9);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Controls.Add(this.label3);
            this.panelEx1.Controls.Add(this.dateTimePicker1);
            this.panelEx1.Controls.Add(this.label2);
            this.panelEx1.Controls.Add(this.btnPSeleccion);
            this.panelEx1.Controls.Add(this.label1);
            this.panelEx1.Controls.Add(this.txtCodigo);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(636, 244);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // txtIdentificacion
            // 
            // 
            // 
            // 
            this.txtIdentificacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdentificacion.CantidadDecimal = 4;
            this.txtIdentificacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificacion.Location = new System.Drawing.Point(192, 53);
            this.txtIdentificacion.MaxLength = 15;
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.NumeroDecimal = false;
            this.txtIdentificacion.Size = new System.Drawing.Size(140, 16);
            this.txtIdentificacion.TabIndex = 24;
            this.txtIdentificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIdentificacion.WatermarkText = "Ingrese la Idf.";
            // 
            // txtCliente
            // 
            // 
            // 
            // 
            this.txtCliente.Border.Class = "TextBoxBorder";
            this.txtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCliente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCliente.Location = new System.Drawing.Point(192, 89);
            this.txtCliente.MaxLength = 300;
            this.txtCliente.Multiline = true;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(174, 33);
            this.txtCliente.TabIndex = 2;
            this.txtCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCliente.WatermarkText = "Seleccione Cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Identificacion";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.rdbCotizacion);
            this.groupPanel1.Controls.Add(this.rdbFactura);
            this.groupPanel1.Location = new System.Drawing.Point(192, 184);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(200, 42);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 21;
            // 
            // rdbCotizacion
            // 
            this.rdbCotizacion.AutoSize = true;
            this.rdbCotizacion.Checked = true;
            this.rdbCotizacion.Location = new System.Drawing.Point(99, 8);
            this.rdbCotizacion.Name = "rdbCotizacion";
            this.rdbCotizacion.Size = new System.Drawing.Size(92, 19);
            this.rdbCotizacion.TabIndex = 1;
            this.rdbCotizacion.TabStop = true;
            this.rdbCotizacion.Text = "Cotizacion";
            this.rdbCotizacion.UseVisualStyleBackColor = true;
            // 
            // rdbFactura
            // 
            this.rdbFactura.AutoSize = true;
            this.rdbFactura.Location = new System.Drawing.Point(20, 8);
            this.rdbFactura.Name = "rdbFactura";
            this.rdbFactura.Size = new System.Drawing.Size(73, 19);
            this.rdbFactura.TabIndex = 0;
            this.rdbFactura.Text = "Factura";
            this.rdbFactura.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Estado";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(191, 144);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(260, 21);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(128, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha";
            // 
            // btnPSeleccion
            // 
            this.btnPSeleccion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPSeleccion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPSeleccion.Enabled = false;
            this.btnPSeleccion.Image = global::Presentacion.Properties.Resources.User;
            this.btnPSeleccion.Location = new System.Drawing.Point(387, 89);
            this.btnPSeleccion.Name = "btnPSeleccion";
            this.btnPSeleccion.Size = new System.Drawing.Size(119, 33);
            this.btnPSeleccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPSeleccion.TabIndex = 1;
            this.btnPSeleccion.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Codigo";
            // 
            // txtCodigo
            // 
            // 
            // 
            // 
            this.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCodigo.CantidadDecimal = 4;
            this.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(191, 19);
            this.txtCodigo.MaxLength = 15;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.NumeroDecimal = false;
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(140, 22);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigo.WatermarkText = "Ingrese";
            // 
            // FormFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 739);
            this.Controls.Add(this.panelEx3);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormFactura";
            this.Text = "Factura";
            this.panelEx3.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.panelEx4.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx3;
        public DevComponents.DotNetBar.ButtonX btnVer;
        public DevComponents.DotNetBar.ButtonX btnNuevo;
        public DevComponents.DotNetBar.ButtonX btnSalir;
        public DevComponents.DotNetBar.ButtonX btnPSeleccion;
        public System.Windows.Forms.Label label1;
        public Negocios.Componente.DevNumericTextBox txtCodigo;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label9;
        public DevComponents.DotNetBar.PanelEx panelEx1;
        public DevComponents.DotNetBar.PanelEx panelEx2;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        public System.Windows.Forms.RadioButton rdbCotizacion;
        public System.Windows.Forms.RadioButton rdbFactura;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        public DevComponents.DotNetBar.Controls.GroupPanel pnlDetalle;
        public DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        public DevComponents.DotNetBar.PanelEx panelEx4;
        public DevComponents.DotNetBar.Controls.Line line1;
        public Negocios.Componente.DevNumericTextBox txtTotal;
        public Negocios.Componente.DevNumericTextBox txtDescuento;
        public Negocios.Componente.DevNumericTextBox txtIVA;
        public Negocios.Componente.DevNumericTextBox txtSub0;
        public Negocios.Componente.DevNumericTextBox txtSub12;
        public Negocios.Componente.BigCheckBox chkDescuento;
        public Negocios.Componente.DevStringTextBox txtCliente;
        public System.Windows.Forms.Label labelD;
        public Negocios.Componente.DevNumericTextBox txtVDescuento;
        public Negocios.Componente.DevNumericTextBox txtIdentificacion;
    }
}