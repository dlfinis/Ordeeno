namespace Presentacion.Producto
{
    partial class FormDataProductosSeleccion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataProductosSeleccion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtBuscar = new Negocios.Componente.DevStringWTextBox(this.components);
            this.cmbBusqueda = new System.Windows.Forms.ComboBox();
            this.cmbBusqSec = new System.Windows.Forms.ComboBox();
            this.btnVer = new DevComponents.DotNetBar.ButtonItem();
            this.btnNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditar = new DevComponents.DotNetBar.ButtonItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem4 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem3 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.dtLista = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ribbonBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = false;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Controls.Add(this.labelX2);
            this.ribbonBar1.Controls.Add(this.txtBuscar);
            this.ribbonBar1.Controls.Add(this.cmbBusqueda);
            this.ribbonBar1.Controls.Add(this.cmbBusqSec);
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnVer,
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.controlContainerItem1,
            this.controlContainerItem4,
            this.controlContainerItem2,
            this.controlContainerItem3,
            this.labelItem1,
            this.btnSalir});
            this.ribbonBar1.ItemSpacing = 2;
            this.ribbonBar1.Location = new System.Drawing.Point(0, 0);
            this.ribbonBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(1059, 60);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 16;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.TitleVisible = false;
            this.ribbonBar1.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle;
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
            this.labelX2.Location = new System.Drawing.Point(428, 7);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(83, 47);
            this.labelX2.TabIndex = 14;
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
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(517, 19);
            this.txtBuscar.MaxLength = 300;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(133, 22);
            this.txtBuscar.TabIndex = 11;
            this.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscar.WatermarkText = "Ing. Busq";
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusqueda.FormattingEnabled = true;
            this.cmbBusqueda.Location = new System.Drawing.Point(656, 19);
            this.cmbBusqueda.Name = "cmbBusqueda";
            this.cmbBusqueda.Size = new System.Drawing.Size(102, 23);
            this.cmbBusqueda.TabIndex = 10002;
            this.cmbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbBusqueda_SelectedIndexChanged);
            // 
            // cmbBusqSec
            // 
            this.cmbBusqSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusqSec.Enabled = false;
            this.cmbBusqSec.FormattingEnabled = true;
            this.cmbBusqSec.Location = new System.Drawing.Point(764, 19);
            this.cmbBusqSec.Name = "cmbBusqSec";
            this.cmbBusqSec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBusqSec.Size = new System.Drawing.Size(75, 23);
            this.cmbBusqSec.TabIndex = 10003;
            this.cmbBusqSec.SelectedIndexChanged += new System.EventHandler(this.cmbBusqSec_SelectedIndexChanged);
            // 
            // btnVer
            // 
            this.btnVer.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnVer.Image = global::Presentacion.Properties.Resources.Tutorial;
            this.btnVer.Name = "btnVer";
            this.btnVer.Text = "Ver";
            this.btnVer.Tooltip = "Observar de mejor manera los datos";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.SubItemsExpandWidth = 14;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.SubItemsExpandWidth = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.SubItemsExpandWidth = 14;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.labelItem1.Text = "....";
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSalir.Image = global::Presentacion.Properties.Resources.Forward;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.SubItemsExpandWidth = 14;
            this.btnSalir.Text = "Pasar";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dtLista
            // 
            this.dtLista.AllowUserToAddRows = false;
            this.dtLista.AllowUserToDeleteRows = false;
            this.dtLista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DimGray;
            this.dtLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dtLista.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtLista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtLista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtLista.EnableHeadersVisualStyles = false;
            this.dtLista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.dtLista.HighlightSelectedColumnHeaders = false;
            this.dtLista.Location = new System.Drawing.Point(0, 62);
            this.dtLista.MultiSelect = false;
            this.dtLista.Name = "dtLista";
            this.dtLista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DimGray;
            this.dtLista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtLista.SelectAllSignVisible = false;
            this.dtLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtLista.Size = new System.Drawing.Size(1059, 362);
            this.dtLista.TabIndex = 17;
            // 
            // FormDataProductosSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 424);
            this.Controls.Add(this.dtLista);
            this.Controls.Add(this.ribbonBar1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormDataProductosSeleccion";
            this.Text = "Seleccion de Productos";
            this.Load += new System.EventHandler(this.FormDataProductosSeleccion_Load);
            this.Resize += new System.EventHandler(this.FormDataProductosSeleccion_Resize);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.RibbonBar ribbonBar1;
        public DevComponents.DotNetBar.LabelX labelX2;
        public Negocios.Componente.DevStringWTextBox txtBuscar;
        public System.Windows.Forms.ComboBox cmbBusqueda;
        public System.Windows.Forms.ComboBox cmbBusqSec;
        public DevComponents.DotNetBar.ButtonItem btnNuevo;
        public DevComponents.DotNetBar.ButtonItem btnEditar;
        public DevComponents.DotNetBar.ButtonItem btnEliminar;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem4;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem3;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        public DevComponents.DotNetBar.ButtonItem btnSalir;
        public DevComponents.DotNetBar.Controls.DataGridViewX dtLista;
        private DevComponents.DotNetBar.ButtonItem btnVer;
    }
}