namespace Presentacion.Producto
{
    partial class FormDataProductos
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
            this.rbbMain.Size = new System.Drawing.Size(970, 62);
            // 
            // 
            // 
            this.rbbMain.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.rbbMain.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(339, 8);
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
            this.cmbBusqueda.Location = new System.Drawing.Point(649, 21);
            this.cmbBusqueda.SelectedIndexChanged += new System.EventHandler(this.cmbBusqueda_SelectedIndexChanged);
            // 
            // cmbBusqSec
            // 
            this.cmbBusqSec.Location = new System.Drawing.Point(756, 21);
            this.cmbBusqSec.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbBusqSec.Size = new System.Drawing.Size(94, 21);
            this.cmbBusqSec.SelectedIndexChanged += new System.EventHandler(this.cmbBusqSec_SelectedIndexChanged);
            // 
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscar.Location = new System.Drawing.Point(427, 21);
            this.txtBuscar.Size = new System.Drawing.Size(192, 20);
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
            // 
            // 
            // 
            this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // lblCantidad
            // 
            this.lblCantidad.Location = new System.Drawing.Point(839, 67);
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
            // panelPreview
            // 
            this.panelPreview.Location = new System.Drawing.Point(0, 0);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(970, 424);
            this.panelPreview.TabIndex = 10;
            // 
            // FormDataProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 424);
            this.Controls.Add(this.panelPreview);
            this.Name = "FormDataProductos";
            this.Text = "Productos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDataProductos_FormClosing);
            this.Load += new System.EventHandler(this.FormDataProductos_Load);
            this.Resize += new System.EventHandler(this.FormDataProductos_Resize);
            this.Controls.SetChildIndex(this.rbbMain, 0);
            this.Controls.SetChildIndex(this.lblCantidad, 0);
            this.Controls.SetChildIndex(this.panelPreview, 0);
            this.rbbMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonItem btnVer;
        public System.Windows.Forms.FlowLayoutPanel panelPreview;
    }
}