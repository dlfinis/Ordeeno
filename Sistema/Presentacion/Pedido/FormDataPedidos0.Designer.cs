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
            this.lblFecha = new DevComponents.DotNetBar.LabelItem();
            this.dateFecha = new System.Windows.Forms.DateTimePicker();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.btnVer = new DevComponents.DotNetBar.ButtonItem();
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
            this.rbbMain.Size = new System.Drawing.Size(895, 60);
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
            this.labelX2.Location = new System.Drawing.Point(312, 7);
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
            this.cmbBusqueda.Location = new System.Drawing.Point(602, 19);
            this.cmbBusqueda.Size = new System.Drawing.Size(102, 23);
            this.cmbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbBusqueda_SelectedIndexChanged);
            // 
            // cmbBusqSec
            // 
            this.cmbBusqSec.Location = new System.Drawing.Point(710, 19);
            this.cmbBusqSec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBusqSec.Size = new System.Drawing.Size(94, 23);
            this.cmbBusqSec.SelectedIndexChanged += new System.EventHandler(this.cmbBusqSec_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscar.Location = new System.Drawing.Point(401, 20);
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
            this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblFecha,
            this.controlContainerItem1});
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(776, 66);
            // 
            // lblFecha
            // 
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.PaddingLeft = 5;
            this.lblFecha.PaddingRight = 5;
            this.lblFecha.Text = "Fecha";
            // 
            // dateFecha
            // 
            this.dateFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold);
            this.dateFecha.Enabled = false;
            this.dateFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.dateFecha.Location = new System.Drawing.Point(564, 22);
            this.dateFecha.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dateFecha.MinDate = new System.DateTime(2005, 1, 1, 0, 0, 0, 0);
            this.dateFecha.Name = "dateFecha";
            this.dateFecha.Size = new System.Drawing.Size(21, 19);
            this.dateFecha.TabIndex = 10006;
            this.dateFecha.ValueChanged += new System.EventHandler(this.dateFecha_ValueChanged);
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.dateFecha;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // btnVer
            // 
            this.btnVer.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnVer.Image = global::Presentacion.Properties.Resources.Tutorial;
            this.btnVer.Name = "btnVer";
            this.btnVer.Text = "Ver";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // panelPreview
            // 
            this.panelPreview.Location = new System.Drawing.Point(-38, 60);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(970, 362);
            this.panelPreview.TabIndex = 11;
            // 
            // FormDataPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 422);
            this.Controls.Add(this.panelPreview);
            this.Name = "FormDataPedidos";
            this.Text = "Pedidos";
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

        private System.Windows.Forms.DateTimePicker dateFecha;
        private DevComponents.DotNetBar.LabelItem lblFecha;
        private DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        private DevComponents.DotNetBar.ButtonItem btnVer;
        public System.Windows.Forms.FlowLayoutPanel panelPreview;
    }
}