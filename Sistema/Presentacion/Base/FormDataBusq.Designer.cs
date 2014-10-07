namespace Presentacion.Base
{
    partial class FormDataBusq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataBusq));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbbMain = new DevComponents.DotNetBar.RibbonBar();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtBuscar = new Negocios.Componente.DevStringWTextBox(this.components);
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.cmbBusqSec = new System.Windows.Forms.ComboBox();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditar = new DevComponents.DotNetBar.ButtonItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem4 = new DevComponents.DotNetBar.ControlContainerItem();
            this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem3 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.dtLista = new System.Windows.Forms.DataGridView();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.bndNavegador = new System.Windows.Forms.ToolStrip();
            this.bndPrimero = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bndAtras = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bndPagActual = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bndPagTotal = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bndSiguiente = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bndUltimo = new System.Windows.Forms.ToolStripButton();
            this.rbbMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).BeginInit();
            this.bndNavegador.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbbMain
            // 
            this.rbbMain.AutoOverflowEnabled = false;
            // 
            // 
            // 
            this.rbbMain.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbbMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbbMain.ContainerControlProcessDialogKey = true;
            this.rbbMain.Controls.Add(this.labelX2);
            this.rbbMain.Controls.Add(this.txtBuscar);
            this.rbbMain.Controls.Add(this.cmbBusqueda);
            this.rbbMain.Controls.Add(this.cmbBusqSec);
            this.rbbMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.rbbMain.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.rbbMain.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1,
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.controlContainerItem1,
            this.controlContainerItem4,
            this.itemContainer2,
            this.controlContainerItem2,
            this.controlContainerItem3,
            this.labelItem1,
            this.btnSalir});
            this.rbbMain.Location = new System.Drawing.Point(0, 0);
            this.rbbMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rbbMain.Name = "rbbMain";
            this.rbbMain.Size = new System.Drawing.Size(755, 60);
            this.rbbMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.rbbMain.TabIndex = 0;
            // 
            // 
            // 
            this.rbbMain.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbbMain.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbbMain.TitleVisible = false;
            this.rbbMain.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.EnableMarkup = false;
            this.labelX2.Image = ((System.Drawing.Image)(resources.GetObject("labelX2.Image")));
            this.labelX2.Location = new System.Drawing.Point(281, 7);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(83, 47);
            this.labelX2.TabIndex = 0;
            this.labelX2.Text = "Buscar";
            // 
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(369, 20);
            this.txtBuscar.MaxLength = 300;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtBuscar.Size = new System.Drawing.Size(147, 20);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscar.WatermarkText = " Ingrese  Busqueda";
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(546, 20);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(102, 21);
            this.cmbBusqueda.TabIndex = 2;
            // 
            // cmbBusqSec
            // 
            this.cmbBusqSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusqSec.Enabled = false;
            this.cmbBusqSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusqSec.FormattingEnabled = true;
            this.cmbBusqSec.Location = new System.Drawing.Point(653, 20);
            this.cmbBusqSec.Name = "cmbBusqSec";
            this.cmbBusqSec.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmbBusqSec.Size = new System.Drawing.Size(5, 21);
            this.cmbBusqSec.TabIndex = 0;
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer1.Name = "itemContainer1";
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.SubItemsExpandWidth = 14;
            this.btnNuevo.Text = "Nuevo";
            // 
            // btnEditar
            // 
            this.btnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.SubItemsExpandWidth = 14;
            this.btnEditar.Text = "Editar";
            // 
            // btnEliminar
            // 
            this.btnEliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.SubItemsExpandWidth = 14;
            this.btnEliminar.Text = "Eliminar";
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.labelX2;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // controlContainerItem4
            // 
            this.controlContainerItem4.AllowItemResize = false;
            this.controlContainerItem4.Control = this.txtBuscar;
            this.controlContainerItem4.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem4.Name = "controlContainerItem4";
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
            this.itemContainer2.Name = "itemContainer2";
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.Control = this.cmbBusqueda;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // controlContainerItem3
            // 
            this.controlContainerItem3.AllowItemResize = false;
            this.controlContainerItem3.Control = this.cmbBusqSec;
            this.controlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem3.Name = "controlContainerItem3";
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Transparent;
            this.labelItem1.Name = "labelItem1";
            this.labelItem1.Text = "..";
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.SubItemsExpandWidth = 14;
            this.btnSalir.Text = "Salir";
            // 
            // dtLista
            // 
            this.dtLista.AllowUserToAddRows = false;
            this.dtLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtLista.Location = new System.Drawing.Point(0, 86);
            this.dtLista.MultiSelect = false;
            this.dtLista.Name = "dtLista";
            this.dtLista.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtLista.RowHeadersWidth = 10;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Orange;
            this.dtLista.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtLista.Size = new System.Drawing.Size(755, 336);
            this.dtLista.TabIndex = 1;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(646, 65);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(50, 15);
            this.lblCantidad.TabIndex = 8;
            this.lblCantidad.Text = "Texto :";
            // 
            // bndNavegador
            // 
            this.bndNavegador.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bndNavegador.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bndPrimero,
            this.toolStripSeparator2,
            this.bndAtras,
            this.toolStripSeparator3,
            this.bndPagActual,
            this.toolStripSeparator1,
            this.bndPagTotal,
            this.toolStripSeparator5,
            this.bndSiguiente,
            this.toolStripSeparator4,
            this.bndUltimo});
            this.bndNavegador.Location = new System.Drawing.Point(0, 61);
            this.bndNavegador.Name = "bndNavegador";
            this.bndNavegador.Size = new System.Drawing.Size(755, 25);
            this.bndNavegador.TabIndex = 7;
            this.bndNavegador.Text = "toolStrip1";
            // 
            // bndPrimero
            // 
            this.bndPrimero.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bndPrimero.Image = global::Presentacion.Properties.Resources.BBack;
            this.bndPrimero.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bndPrimero.Name = "bndPrimero";
            this.bndPrimero.Size = new System.Drawing.Size(23, 22);
            this.bndPrimero.Text = "Primera";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bndAtras
            // 
            this.bndAtras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bndAtras.Image = global::Presentacion.Properties.Resources.Back;
            this.bndAtras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bndAtras.Name = "bndAtras";
            this.bndAtras.Size = new System.Drawing.Size(23, 22);
            this.bndAtras.Text = "toolStripButton1";
            this.bndAtras.ToolTipText = "Primero";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bndPagActual
            // 
            this.bndPagActual.MaxLength = 4;
            this.bndPagActual.Name = "bndPagActual";
            this.bndPagActual.Size = new System.Drawing.Size(40, 25);
            this.bndPagActual.Text = "1";
            this.bndPagActual.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bndPagActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.bndPagActual_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bndPagTotal
            // 
            this.bndPagTotal.Name = "bndPagTotal";
            this.bndPagTotal.Size = new System.Drawing.Size(22, 22);
            this.bndPagTotal.Text = "de ";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bndSiguiente
            // 
            this.bndSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bndSiguiente.Image = global::Presentacion.Properties.Resources.Forward1;
            this.bndSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bndSiguiente.Name = "bndSiguiente";
            this.bndSiguiente.Size = new System.Drawing.Size(23, 22);
            this.bndSiguiente.Text = "Siguiente";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bndUltimo
            // 
            this.bndUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bndUltimo.Image = global::Presentacion.Properties.Resources.FForward;
            this.bndUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bndUltimo.Name = "bndUltimo";
            this.bndUltimo.Size = new System.Drawing.Size(23, 22);
            this.bndUltimo.Text = "Ultimo";
            this.bndUltimo.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // FormDataBusq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 422);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.bndNavegador);
            this.Controls.Add(this.dtLista);
            this.Controls.Add(this.rbbMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormDataBusq";
            this.Text = "FormDataBusq";
            this.rbbMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).EndInit();
            this.bndNavegador.ResumeLayout(false);
            this.bndNavegador.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevComponents.DotNetBar.RibbonBar rbbMain;
        public DevComponents.DotNetBar.LabelX labelX2;
        public DevComponents.DotNetBar.ButtonItem btnNuevo;
        public DevComponents.DotNetBar.ButtonItem btnEditar;
        public DevComponents.DotNetBar.ButtonItem btnEliminar;
        public DevComponents.DotNetBar.ButtonItem btnSalir;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        public System.Windows.Forms.ComboBox cmbBusqueda;
        public System.Windows.Forms.ComboBox cmbBusqSec;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem3;
        public Negocios.Componente.DevStringWTextBox txtBuscar;
        public DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        public DevComponents.DotNetBar.ItemContainer itemContainer2;
        public System.Windows.Forms.DataGridView dtLista;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.Label lblCantidad;
        public System.Windows.Forms.ToolStrip bndNavegador;
        public System.Windows.Forms.ToolStripButton bndPrimero;
        public System.Windows.Forms.ToolStripTextBox bndPagActual;
        public System.Windows.Forms.ToolStripButton bndSiguiente;
        public System.Windows.Forms.ToolStripButton bndUltimo;
        public System.Windows.Forms.ToolStripLabel bndPagTotal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        public System.Windows.Forms.ToolStripButton bndAtras;
       

    }
}