namespace Presentacion.Pedido
{
    partial class FormDataPedidos
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
            this.btnVer = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.lblFecha = new DevComponents.DotNetBar.LabelItem();
            this.controlContainerItem3 = new DevComponents.DotNetBar.ControlContainerItem();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.panelPreview = new System.Windows.Forms.FlowLayoutPanel();
            this.rbbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbbMain
            // 
            // 
            // 
            // 
            this.rbbMain.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbbMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbbMain.Controls.Add(this.dateFecha);
            this.rbbMain.Size = new System.Drawing.Size(922, 60);
            // 
            // 
            // 
            this.rbbMain.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbbMain.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.rbbMain.Controls.SetChildIndex(this.cmbBusqSec, 0);
            this.rbbMain.Controls.SetChildIndex(this.cmbBusqueda, 0);
            this.rbbMain.Controls.SetChildIndex(this.txtBuscar, 0);
            this.rbbMain.Controls.SetChildIndex(this.labelX2, 0);
            this.rbbMain.Controls.SetChildIndex(this.dateFecha, 0);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(333, 8);
            this.labelX2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // cmbBusqueda
            // 
            this.cmbBusqueda.Location = new System.Drawing.Point(620, 8);
            this.cmbBusqueda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbBusqueda_SelectedIndexChanged);
            // 
            // cmbBusqSec
            // 
            this.cmbBusqSec.Location = new System.Drawing.Point(727, 8);
            this.cmbBusqSec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBusqSec.Size = new System.Drawing.Size(82, 21);
            this.cmbBusqSec.SelectedIndexChanged += new System.EventHandler(this.cmbBusqSec_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscar.Location = new System.Drawing.Point(421, 8);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnVer});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // itemContainer2
            // 
            // 
            // 
            // 
            this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer2.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblFecha,
            this.controlContainerItem2});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(797, 67);
            // 
            // btnVer
            // 
            this.btnVer.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnVer.Image = global::Presentacion.Properties.Resources.Tutorial;
            this.btnVer.Name = "btnVer";
            this.btnVer.Text = "Ver";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.PaddingLeft = 5;
            this.lblFecha.PaddingRight = 5;
            this.lblFecha.Text = "Fecha";
            // 
            // controlContainerItem3
            // 
            this.controlContainerItem3.AllowItemResize = false;
            this.controlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem3.Name = "controlContainerItem3";
            // 
            // dateFecha
            // 
            this.dateFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.dateFecha.Enabled = false;
            this.dateFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.dateFecha.Location = new System.Drawing.Point(573, 23);
            this.dateFecha.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateFecha.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(21, 19);
            this.dateFecha.TabIndex = 10005;
            this.dateFecha.ValueChanged += new System.EventHandler(this.dateFecha_ValueChanged);
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.Control = this.dateFecha;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // panelPreview
            // 
            this.panelPreview.Location = new System.Drawing.Point(-34, 0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(956, 470);
            this.panelPreview.TabIndex = 12;
            // 
            // FormDataPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 421);
            this.Controls.Add(this.panelPreview);
            this.Name = "FormDataPedidos";
            this.Text = "Pedidos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDataPedidos_FormClosing);
            this.Load += new System.EventHandler(this.FormDataPedidos_Load);
            this.Resize += new System.EventHandler(this.FormDataPedidos_Resize);
            this.Controls.SetChildIndex(this.rbbMain, 0);
            this.Controls.SetChildIndex(this.lblCantidad, 0);
            this.Controls.SetChildIndex(this.panelPreview, 0);
            this.rbbMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem btnVer;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private System.Windows.Forms.DateTimePicker dateFecha;
        private DevComponents.DotNetBar.LabelItem lblFecha;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem3;
        public System.Windows.Forms.FlowLayoutPanel panelPreview;
    }
}