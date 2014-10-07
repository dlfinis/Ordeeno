using System.Drawing;
using System.Windows.Forms;
namespace Presentacion.Base
{
    partial class FormData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtBuscar = new Negocios.Componente.DevStringWTextBox(this.components);
            this.btnNuevo = new DevComponents.DotNetBar.ButtonItem();
            this.btnEditar = new DevComponents.DotNetBar.ButtonItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.controlContainerItem1 = new DevComponents.DotNetBar.ControlContainerItem();
            this.controlContainerItem2 = new DevComponents.DotNetBar.ControlContainerItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.btnSalir = new DevComponents.DotNetBar.ButtonItem();
            this.dtLista = new System.Windows.Forms.DataGridView();
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
            resources.ApplyResources(this.ribbonBar1, "ribbonBar1");
            this.ribbonBar1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar,
            this.controlContainerItem1,
            this.controlContainerItem2,
            this.labelItem1,
            this.btnSalir});
            this.ribbonBar1.ItemSpacing = 2;
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
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
            resources.ApplyResources(this.labelX2, "labelX2");
            this.labelX2.Image = ((System.Drawing.Image)(resources.GetObject("labelX2.Image")));
            this.labelX2.Name = "labelX2";
            // 
            // txtBuscar
            // 
            // 
            // 
            // 
            this.txtBuscar.Border.Class = "TextBoxBorder";
            this.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBuscar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            resources.ApplyResources(this.txtBuscar, "txtBuscar");
            this.txtBuscar.Name = "txtBuscar";
            // 
            // btnNuevo
            // 
            this.btnNuevo.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnNuevo.FontBold = true;
            this.btnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.Image")));
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.SubItemsExpandWidth = 14;
            resources.ApplyResources(this.btnNuevo, "btnNuevo");
            // 
            // btnEditar
            // 
            this.btnEditar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEditar.FontBold = true;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.SubItemsExpandWidth = 14;
            resources.ApplyResources(this.btnEditar, "btnEditar");
            // 
            // btnEliminar
            // 
            this.btnEliminar.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnEliminar.FontBold = true;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.SubItemsExpandWidth = 14;
            resources.ApplyResources(this.btnEliminar, "btnEliminar");
            // 
            // controlContainerItem1
            // 
            this.controlContainerItem1.AllowItemResize = false;
            this.controlContainerItem1.Control = this.labelX2;
            this.controlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem1.Name = "controlContainerItem1";
            // 
            // controlContainerItem2
            // 
            this.controlContainerItem2.AllowItemResize = false;
            this.controlContainerItem2.Control = this.txtBuscar;
            this.controlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways;
            this.controlContainerItem2.Name = "controlContainerItem2";
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.Transparent;
            this.labelItem1.Name = "labelItem1";
            resources.ApplyResources(this.labelItem1, "labelItem1");
            // 
            // btnSalir
            // 
            this.btnSalir.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.btnSalir.FontBold = true;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.SubItemsExpandWidth = 14;
            resources.ApplyResources(this.btnSalir, "btnSalir");
            // 
            // dtLista
            // 
            this.dtLista.AllowUserToAddRows = false;
            this.dtLista.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.LightGray;
            this.dtLista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dtLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dtLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtLista.DefaultCellStyle = dataGridViewCellStyle8;
            resources.ApplyResources(this.dtLista, "dtLista");
            this.dtLista.MultiSelect = false;
            this.dtLista.Name = "dtLista";
            this.dtLista.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtLista.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.Orange;
            this.dtLista.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dtLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // FormData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtLista);
            this.Controls.Add(this.ribbonBar1);
            this.Name = "FormData";
            this.Resize += new System.EventHandler(this.FormData_Resize);
            this.ribbonBar1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.RibbonBar ribbonBar1;
        public DevComponents.DotNetBar.LabelX labelX2;
        public Negocios.Componente.DevStringWTextBox txtBuscar;
        public DevComponents.DotNetBar.ButtonItem btnNuevo;
        public DevComponents.DotNetBar.ButtonItem btnEditar;
        public DevComponents.DotNetBar.ButtonItem btnEliminar;
        public DevComponents.DotNetBar.ControlContainerItem controlContainerItem1;
        public DevComponents.DotNetBar.ControlContainerItem controlContainerItem2;
        public DevComponents.DotNetBar.LabelItem labelItem1;
        public DevComponents.DotNetBar.ButtonItem btnSalir;
        public DataGridView dtLista;



    }
}