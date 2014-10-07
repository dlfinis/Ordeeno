namespace Presentacion.Pedido
{
    partial class FormPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtLista = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntInsertar = new System.Windows.Forms.ToolStripMenuItem();
            this.cntEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.cntBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.cntLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.panelEx4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).BeginInit();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVer
            // 
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnPSeleccion
            // 
            this.btnPSeleccion.Enabled = true;
            this.btnPSeleccion.Image = global::Presentacion.Properties.Resources.Wizard;
            this.btnPSeleccion.Text = "Proveedor";
            this.btnPSeleccion.Click += new System.EventHandler(this.btnPSeleccion_Click);
            // 
            // txtCodigo
            // 
            // 
            // 
            // 
            this.txtCodigo.Border.Class = "TextBoxBorder";
            this.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(26, 6);
            this.label7.Size = new System.Drawing.Size(73, 32);
            this.label7.Text = "Valor\r\nDescuento";
            // 
            // panelEx1
            // 
            this.panelEx1.Size = new System.Drawing.Size(634, 244);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            // 
            // panelEx2
            // 
            this.panelEx2.Size = new System.Drawing.Size(634, 224);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            // 
            // groupPanel1
            // 
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
            // 
            // rdbCotizacion
            // 
            this.rdbCotizacion.CheckedChanged += new System.EventHandler(this.rdbCotizacion_CheckedChanged);
            // 
            // rdbFactura
            // 
            this.rdbFactura.CheckedChanged += new System.EventHandler(this.rdbFactura_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = true;
            this.dateTimePicker1.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.dtLista);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Enabled = false;
            this.pnlDetalle.Location = new System.Drawing.Point(0, 0);
            this.pnlDetalle.Size = new System.Drawing.Size(634, 224);
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
            // 
            // groupPanel4
            // 
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
            // 
            // panelEx4
            // 
            this.panelEx4.Size = new System.Drawing.Size(634, 44);
            this.panelEx4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx4.Style.GradientAngle = 90;
            // 
            // txtTotal
            // 
            // 
            // 
            // 
            this.txtTotal.Border.Class = "TextBoxBorder";
            this.txtTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // txtDescuento
            // 
            // 
            // 
            // 
            this.txtDescuento.Border.Class = "TextBoxBorder";
            this.txtDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // txtIVA
            // 
            // 
            // 
            // 
            this.txtIVA.Border.Class = "TextBoxBorder";
            this.txtIVA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIVA.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // txtSub0
            // 
            // 
            // 
            // 
            this.txtSub0.Border.Class = "TextBoxBorder";
            this.txtSub0.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSub0.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // txtSub12
            // 
            // 
            // 
            // 
            this.txtSub12.Border.Class = "TextBoxBorder";
            this.txtSub12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtSub12.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            // 
            // chkDescuento
            // 
            // 
            // 
            // 
            this.chkDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDescuento.Visible = false;
            // 
            // txtCliente
            // 
            // 
            // 
            // 
            this.txtCliente.Border.Class = "TextBoxBorder";
            this.txtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCliente.Size = new System.Drawing.Size(174, 38);
            this.txtCliente.WatermarkText = "Seleccione Proveedor";
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // labelD
            // 
            this.labelD.Visible = false;
            // 
            // txtVDescuento
            // 
            // 
            // 
            // 
            this.txtVDescuento.Border.Class = "TextBoxBorder";
            this.txtVDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtVDescuento.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtVDescuento.Visible = false;
            // 
            // txtIdentificacion
            // 
            // 
            // 
            // 
            this.txtIdentificacion.Border.Class = "TextBoxBorder";
            this.txtIdentificacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdentificacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIdentificacion_KeyDown);
            // 
            // dtLista
            // 
            this.dtLista.AllowUserToAddRows = false;
            this.dtLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.LightGray;
            this.dtLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dtLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtLista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.CodProd,
            this.Nombre,
            this.Precio,
            this.Cantidad,
            this.Total,
            this.IVA});
            this.dtLista.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtLista.DefaultCellStyle = dataGridViewCellStyle9;
            this.dtLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtLista.Location = new System.Drawing.Point(0, 0);
            this.dtLista.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtLista.MultiSelect = false;
            this.dtLista.Name = "dtLista";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dtLista.RowHeadersWidth = 10;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Orange;
            this.dtLista.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtLista.Size = new System.Drawing.Size(628, 202);
            this.dtLista.TabIndex = 25;
            this.dtLista.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellEndEdit);
            this.dtLista.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellValueChanged);
            this.dtLista.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtLista_EditingControlShowing);
            this.dtLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtLista_KeyDown);
            // 
            // Codigo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle3.NullValue = "0";
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.FillWeight = 5F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MaxInputLength = 15;
            this.Codigo.Name = "Codigo";
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codigo.Visible = false;
            // 
            // CodProd
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.CodProd.DefaultCellStyle = dataGridViewCellStyle4;
            this.CodProd.HeaderText = "CodProd";
            this.CodProd.MaxInputLength = 15;
            this.CodProd.Name = "CodProd";
            this.CodProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nombre
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle5;
            this.Nombre.FillWeight = 300F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Precio
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "0.0";
            this.Precio.DefaultCellStyle = dataGridViewCellStyle6;
            this.Precio.FillWeight = 85F;
            this.Precio.HeaderText = "Precio Compra";
            this.Precio.MaxInputLength = 15;
            this.Precio.Name = "Precio";
            this.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle7;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 20;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Total
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = "0.0";
            this.Total.DefaultCellStyle = dataGridViewCellStyle8;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // IVA
            // 
            this.IVA.FillWeight = 5F;
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IVA.Visible = false;
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntInsertar,
            this.cntEliminar,
            this.cntBuscar,
            this.cntLimpiar});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.ShowImageMargin = false;
            this.contextMenu.Size = new System.Drawing.Size(89, 92);
            // 
            // cntInsertar
            // 
            this.cntInsertar.Name = "cntInsertar";
            this.cntInsertar.Size = new System.Drawing.Size(88, 22);
            this.cntInsertar.Text = "Insertar";
            this.cntInsertar.Click += new System.EventHandler(this.cntInsertar_Click);
            // 
            // cntEliminar
            // 
            this.cntEliminar.Name = "cntEliminar";
            this.cntEliminar.Size = new System.Drawing.Size(88, 22);
            this.cntEliminar.Text = "Eliminar";
            this.cntEliminar.Click += new System.EventHandler(this.cntEliminar_Click);
            // 
            // cntBuscar
            // 
            this.cntBuscar.Name = "cntBuscar";
            this.cntBuscar.Size = new System.Drawing.Size(88, 22);
            this.cntBuscar.Text = "Buscar";
            this.cntBuscar.Click += new System.EventHandler(this.cntBuscar_Click);
            // 
            // cntLimpiar
            // 
            this.cntLimpiar.Name = "cntLimpiar";
            this.cntLimpiar.Size = new System.Drawing.Size(88, 22);
            this.cntLimpiar.Text = "Limpiar";
            this.cntLimpiar.Click += new System.EventHandler(this.cntLimpiar_Click);
            // 
            // FormPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 715);
            this.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.Name = "FormPedido";
            this.Text = "Pedido";
            this.Load += new System.EventHandler(this.FormPedido_Load);
            this.Controls.SetChildIndex(this.panelEx1, 0);
            this.Controls.SetChildIndex(this.panelEx2, 0);
            this.panelEx1.ResumeLayout(false);
            this.panelEx1.PerformLayout();
            this.panelEx2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.panelEx4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).EndInit();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dtLista;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cntInsertar;
        private System.Windows.Forms.ToolStripMenuItem cntEliminar;
        private System.Windows.Forms.ToolStripMenuItem cntBuscar;
        private System.Windows.Forms.ToolStripMenuItem cntLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;

    }
}