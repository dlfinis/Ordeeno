namespace Presentacion.Venta
{
    partial class FormVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntInsertar = new System.Windows.Forms.ToolStripMenuItem();
            this.cntEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.cntBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.cntLimpiar = new System.Windows.Forms.ToolStripMenuItem();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dtLista = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VentaIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.panelEx4.SuspendLayout();
            this.contextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).BeginInit();
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
            this.btnPSeleccion.Click += new System.EventHandler(this.btnPSeleccion_Click);
            // 
            // txtCodigo
            // 
            // 
            // 
            // 
            this.txtCodigo.Border.Class = "TextBoxBorder";
            this.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.label10);
            this.panelEx1.Size = new System.Drawing.Size(634, 244);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.Controls.SetChildIndex(this.txtCliente, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtIdentificacion, 0);
            this.panelEx1.Controls.SetChildIndex(this.txtCodigo, 0);
            this.panelEx1.Controls.SetChildIndex(this.label1, 0);
            this.panelEx1.Controls.SetChildIndex(this.btnPSeleccion, 0);
            this.panelEx1.Controls.SetChildIndex(this.label2, 0);
            this.panelEx1.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.panelEx1.Controls.SetChildIndex(this.label3, 0);
            this.panelEx1.Controls.SetChildIndex(this.groupPanel1, 0);
            this.panelEx1.Controls.SetChildIndex(this.label9, 0);
            this.panelEx1.Controls.SetChildIndex(this.label10, 0);
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
            this.rdbCotizacion.TabIndex = 4;
            this.rdbCotizacion.CheckedChanged += new System.EventHandler(this.rdbCotizacion_CheckedChanged);
            // 
            // rdbFactura
            // 
            this.rdbFactura.TabIndex = 3;
            this.rdbFactura.CheckedChanged += new System.EventHandler(this.rdbFactura_CheckedChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = true;
            this.dateTimePicker1.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2000, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.TabIndex = 2;
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
            // 
            // txtDescuento
            // 
            // 
            // 
            // 
            this.txtDescuento.Border.Class = "TextBoxBorder";
            this.txtDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDescuento.Enabled = false;
            this.txtDescuento.ReadOnly = false;
            this.txtDescuento.TextChanged += new System.EventHandler(this.txtDescuento_TextChanged);
            // 
            // txtIVA
            // 
            // 
            // 
            // 
            this.txtIVA.Border.Class = "TextBoxBorder";
            this.txtIVA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // txtSub0
            // 
            // 
            // 
            // 
            this.txtSub0.Border.Class = "TextBoxBorder";
            this.txtSub0.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // txtSub12
            // 
            // 
            // 
            // 
            this.txtSub12.Border.Class = "TextBoxBorder";
            this.txtSub12.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // chkDescuento
            // 
            // 
            // 
            // 
            this.chkDescuento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.chkDescuento.Checked = false;
            this.chkDescuento.CheckState = System.Windows.Forms.CheckState.Unchecked;
            this.chkDescuento.CheckValue = "N";
            this.chkDescuento.CheckedChanged += new System.EventHandler(this.chkDescuento_CheckedChanged);
            // 
            // txtCliente
            // 
            // 
            // 
            // 
            this.txtCliente.Border.Class = "TextBoxBorder";
            this.txtCliente.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtCliente.Enabled = false;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // txtVDescuento
            // 
            // 
            // 
            // 
            this.txtVDescuento.Border.Class = "TextBoxBorder";
            this.txtVDescuento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label10.Location = new System.Drawing.Point(98, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 16);
            this.label10.TabIndex = 68;
            this.label10.Text = "Comprador";
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
            this.Venta,
            this.VentaIVA,
            this.Cantidad,
            this.Aumento,
            this.Descuento,
            this.Total,
            this.IVA});
            this.dtLista.ContextMenuStrip = this.contextMenu;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtLista.DefaultCellStyle = dataGridViewCellStyle12;
            this.dtLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtLista.Location = new System.Drawing.Point(0, 0);
            this.dtLista.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtLista.MultiSelect = false;
            this.dtLista.Name = "dtLista";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dtLista.RowHeadersWidth = 10;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Orange;
            this.dtLista.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.dtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtLista.Size = new System.Drawing.Size(628, 202);
            this.dtLista.TabIndex = 1;
            this.dtLista.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellEndEdit);
            this.dtLista.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellValueChanged);
            this.dtLista.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtLista_EditingControlShowing);
            this.dtLista.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtLista_KeyDown);
            // 
            // Codigo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Codigo.DefaultCellStyle = dataGridViewCellStyle3;
            this.Codigo.FillWeight = 5F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MaxInputLength = 15;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Codigo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Codigo.Visible = false;
            // 
            // CodProd
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.CodProd.DefaultCellStyle = dataGridViewCellStyle4;
            this.CodProd.FillWeight = 110F;
            this.CodProd.HeaderText = "CodProd";
            this.CodProd.MaxInputLength = 15;
            this.CodProd.Name = "CodProd";
            this.CodProd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nombre
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle5;
            this.Nombre.FillWeight = 250F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Venta
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = "0.0";
            this.Venta.DefaultCellStyle = dataGridViewCellStyle6;
            this.Venta.FillWeight = 85F;
            this.Venta.HeaderText = "Precio Venta";
            this.Venta.Name = "Venta";
            this.Venta.ReadOnly = true;
            this.Venta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // VentaIVA
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = "0.0";
            this.VentaIVA.DefaultCellStyle = dataGridViewCellStyle7;
            this.VentaIVA.HeaderText = "Precio Venta+IVA";
            this.VentaIVA.Name = "VentaIVA";
            this.VentaIVA.ReadOnly = true;
            this.VentaIVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cantidad
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 20;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Aumento
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = "0.0";
            this.Aumento.DefaultCellStyle = dataGridViewCellStyle9;
            this.Aumento.FillWeight = 60F;
            this.Aumento.HeaderText = "Aum.";
            this.Aumento.Name = "Aumento";
            // 
            // Descuento
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = "0.0";
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle10;
            this.Descuento.FillWeight = 60F;
            this.Descuento.HeaderText = "Desc.";
            this.Descuento.Name = "Descuento";
            // 
            // Total
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "C2";
            dataGridViewCellStyle11.NullValue = "0";
            this.Total.DefaultCellStyle = dataGridViewCellStyle11;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // IVA
            // 
            this.IVA.FillWeight = 5F;
            this.IVA.HeaderText = "IVA";
            this.IVA.Name = "IVA";
            this.IVA.ReadOnly = true;
            this.IVA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IVA.Visible = false;
            // 
            // FormVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 715);
            this.Name = "FormVenta";
            this.Text = "Venta";
            this.Load += new System.EventHandler(this.FormVenta_Load);
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
            this.contextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem cntInsertar;
        private System.Windows.Forms.ToolStripMenuItem cntEliminar;
        private System.Windows.Forms.ToolStripMenuItem cntLimpiar;
        private System.Windows.Forms.ToolStripMenuItem cntBuscar;
        public System.Windows.Forms.DataGridView dtLista;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn VentaIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;

    }
}