using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;

namespace Presentacion.Producto
{
    public partial class FormDataProductosSeleccion : Negocios.Base.FormBase
    {
        #region conexion

        private static String origen;

        public static String Origen
        {
            get { return FormDataProductosSeleccion.origen; }
            set { FormDataProductosSeleccion.origen = value; }
        }
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataProductosSeleccion.dtSeleccion; }
            set { FormDataProductosSeleccion.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataProductosSeleccion.gridSeleccion; }
            set { FormDataProductosSeleccion.gridSeleccion = value; }
        }
        DataGridViewCheckBoxColumn dgvcheck = new DataGridViewCheckBoxColumn();
           

        List<CSeleccion> CellSelection = new List<CSeleccion>();

        private void dtLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dtLista.CurrentCell.ColumnIndex;
            int row = dtLista.CurrentRow.Index;
            string headerText = dtLista.Columns[column].HeaderText;
           
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 13)
            {
                CheckBox tb = e.Control as CheckBox;
                if (tb.Checked)
                {
                    MessageBox.Show(dtLista.Rows[row].Cells[2].Value+"");
                    rowSelected.Add(dtLista.Rows[row]);
                }
               


            }
        
        }

       
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //try
            //{
            //    DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)dtLista.Rows[e.RowIndex].Cells[13];
            //    bool isChecked = (bool)checkbox.EditedFormattedValue;
            //    MessageBox.Show("" + isChecked + "--" + e.RowIndex);
            //}
            //catch{}



            if (GridSeleccion)
            {


                if (dtLista.Columns[e.ColumnIndex].Name.Equals("Seleccione") && 
                    (Convert.ToBoolean(dtLista.Rows[e.RowIndex].Cells["Seleccione"].Value)==false 
                    ||Convert.ToBoolean(dtLista.Rows[e.RowIndex].Cells["Seleccione"].Selected)==false))
              
                {
                    dtLista.Rows[e.RowIndex].Cells["Seleccione"].Value = true;
                    dtLista.Rows[e.RowIndex].Cells["Seleccione"].Selected = true;
                    #region SVenta
                    if (Origen == "Venta")
                    {

                        CSeleccion cs = new CSeleccion();

                            foreach (DataGridViewRow row in dtLista.Rows)
                            {

                                cs.Codigo = e.RowIndex;
                                cs.Dgv = row;
                              
                                DataGridViewCheckBoxCell cellSelecion =
                                    row.Cells["Seleccione"] as DataGridViewCheckBoxCell;

                                if (Convert.ToBoolean(cellSelecion.Value))
                                {
                                    rowSelected.Add(row);
                                     CellSelection.Add(cs);
                                }
                            }

                            if (rowSelected.Count > 0)
                            {
                               // Venta.FormVenta.VentaP.fillDatosProductos(rowSelected);
                              
                            }
                           

                        



                    }
                    #endregion
                }

                
                #region Venta
                if (Origen != "Venta")
                {
                    DialogResult dresult = (MessageBox.Show("Selecciono el Producto : " + dtLista.Rows[e.RowIndex].Cells[1].Value,
                                                        "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                    if (dresult == DialogResult.OK)
                    {
                        DtSeleccion = dtLista.Rows[e.RowIndex];

                        if (Origen == "Consulta")
                        {

                            Venta.FormConsulta.Consulta.fillDatos(Convert.ToInt32(DtSeleccion.Cells[0].Value));

                        }


                        // Producto.FormProducto.Prod_principal.cmbDimension.SelectedValue = Convert.ToInt32(DtSeleccion.Cells[0].Value);
                        GridSeleccion = false; this.Hide();

                    }
                    else
                    {
                        txtBuscar.Text = "";


                    }

                }
                
               
#endregion

                
            }

        }

        private void dtLista_CellFormatting(object sender,
      System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
           


            if (this.dtLista.Columns[e.ColumnIndex].Name.Equals("IVA"))
            {

                dtLista.Columns[e.ColumnIndex].Width = 35;
            }

            try
            {
                if (this.dtLista.Columns[e.ColumnIndex].Name.Equals("Codigo"))
                {

                    dtLista.Columns[e.ColumnIndex].Visible = false;
                }
            }
            catch { }



            // Set the background to red for negative values in the Balance column. 
            if (dtLista.Columns[e.ColumnIndex].Name.Equals("Stock"))
            {

                if (Convert.ToInt32(e.Value) <= addProducto.getCantidadMinima())
                {
                    e.CellStyle.BackColor = Color.DarkOrange;

                }
            }



        }

        #endregion
        public FormDataProductosSeleccion()
        {

            InitializeComponent();

            //cmbBusqueda.DataBindings.Add("SelectedItem",Enum.GetValues(typeof(Negocios.ETProducto)),"SelectedItem");


            

            //string alfa=Enum.GetName(cmbBusqueda.SelectedValue,alfa);
            // this.dtLista.CellContentClick +=
            // new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);


        }




        NProducto addProducto = new NProducto();
        ENBusqueda tbusqueda;
        ENBusquedaOpcion topcion;
        NProveedor getProveedor = new NProveedor();
        enum ENBusqueda
        {

            Seleccione = 0,
            Nombre = 1,
            Descripcion = 2,
            Dimension = 3,
            Color = 4,
            Categoria = 5,
            Unidad = 6,
            Stock = 7,
            StockMinimo = 8,
            Compra = 9,
            Venta = 10,
            IVA = 11,
            Marca= 12
        }

        enum ENBusquedaOpcion
        {

            Seleccione = 0,
            Mayor = 1,
            Menor = 2,
            Si = 3,
            No = 4
        }

     
        private void FormDataProductosSeleccion_Load(object sender, EventArgs e)
        {



            cmbBusqueda.DataSource = Enum.GetValues(typeof(ENBusqueda));
            cmbBusqSec.Visible = true;
            cmbBusqSec.Items.Add("Seleccione");
            cmbBusqSec.Items.Add("Mayor");
            cmbBusqSec.Items.Add("Menor");
            cmbBusqSec.Items.Add("Si");
            cmbBusqSec.Items.Add("No");
            this.Lista();
            this.dtLista.CellFormatting += this.dtLista_CellFormatting;
            this.dtLista.CellContentClick += dtLista_CellContentClick;
            dgvcheck.Name = "Seleccione";
           dgvcheck.TrueValue = true;
            dgvcheck.FalseValue = false;
            dtLista.Columns.Add(dgvcheck);
            foreach (DataGridViewColumn dc in dtLista.Columns)
            {
                if (dc.Index<dtLista.Columns.Count-1)
                {

                    dc.ReadOnly = true;
                }
                else {
                    dc.ReadOnly = false;
                }
            }


            dtLista.CellContentClick+=dtLista_CellContentClick;
            dtLista.EditingControlShowing += dtLista_EditingControlShowing;
            //cmbBusqSec.DataSource = Enum.GetValues(typeof(ENBusquedaOpcion));

        }

        //void dtLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataGridViewCheckBoxCell chk=(DataGridViewCheckBoxCell)dtLista.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
        //    MessageBox.Show("chk"+chk.Selected);


        //}


        //Listado Genral Seleccionado

        List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();


       
        private void getSelectedRow()
        {
            ////rowSelected.Clear();
            foreach (DataGridViewRow row in dtLista.Rows)
            {

                DataGridViewCheckBoxCell cellSelecion =
                    row.Cells["Seleccione"] as DataGridViewCheckBoxCell;





               // MessageBox.Show("---"+Convert.ToBoolean(cellSelecion.Value));
                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    rowSelected.Add(row);
                }


               
            }
            //rowSelected.Clear();
            
            



        }
        private void SelectedRow()
        {


            
                foreach (DataGridViewRow rowf in rowSelected)
                {      DataGridViewCheckBoxCell cellSelecion =
                          rowf.Cells["Seleccione"] as DataGridViewCheckBoxCell;
                        MessageBox.Show("+++" + rowf.Cells[0].Value + "--" + rowf.Cells[1].Value + "==" + Convert.ToBoolean(cellSelecion.Value));
                    

                }    
            
            
        
        }

    
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
               
                //if (dtLista.RowCount > 0)
                //{ 
                
                //    #region Seleccion


               
               // MessageBox.Show(""+)
              

                        
                       



                    
                //    #endregion
                
                //}

                this.dtLista.DataSource = this.addProducto.Listar("");
                
                //  MessageBox.Show(this.addProducto.Listar("").Count + "--");

                if (dtLista.RowCount > 0)
                {
                    this.dtLista.Columns[0].Visible = false;
                    //this.dtLista.Columns[6].Visible = false;
                    this.dtLista.Columns[11].Visible = false;

                  
                    if(dtLista.Columns.Count>12)
                    {
                    dtLista.Columns["Seleccione"].Visible = true;
                    dtLista.Columns["Seleccione"].ReadOnly = false;
                

                   // MessageBox.Show("+" + rowSelected.Count);
                    
                    }

                  

                }


            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(Datos.Excepciones.MensajePersonalizado+"--23");
                
            }

        }

        private void Lista(ENBusqueda nprov)
        {
            //MessageBox.Show("Lista");
            try
            {
                

                if (String.IsNullOrEmpty(this.txtBuscar.Text.Trim()))
                {
                    Lista();
                }
                else
                {

                    this.dtLista.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd());

                }

                if (dtLista.RowCount > 0)
                {
                    this.dtLista.Columns[0].Visible = false;
                    this.dtLista.Columns[11].Visible = false;

                    dtLista.Columns["Seleccione"].Visible = true;
                    dtLista.Columns["Seleccione"].ReadOnly = false;
                   
                    //MessageBox.Show("+" + rowSelected.Count);
                }

            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }


        private void Lista(ENBusqueda nprov, ENBusquedaOpcion nopc)
        {
            //MessageBox.Show("Lista");
            try
            {
                
                if (nprov.ToString().TrimEnd().Equals("IVA"))
                {
                    this.dtLista.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());
                }
                else
                {
                    if (String.IsNullOrEmpty(this.txtBuscar.Text.Trim()))
                    {
                        Lista();
                        // cmbBusqueda.SelectedIndex = 0;
                        //this.cmbBusqSec.SelectedIndex = 0;

                    }
                    else
                    {



                        this.dtLista.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());
                    }
                }


                if (dtLista.RowCount > 0)
                {

                    this.dtLista.Columns[0].Visible = false;
                    this.dtLista.Columns[11].Visible = false;

                    dtLista.Columns["Seleccione"].Visible = true;
                    dtLista.Columns["Seleccione"].ReadOnly = false;
                 
                }





            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbBusqueda.SelectedIndex == 0)
            {
                txtBuscar.Text = "";
                this.Lista();
                cmbBusqSec.Enabled = false;
            }

            if (cmbBusqueda.SelectedIndex != 0 && !(cmbBusqueda.SelectedIndex >= 7 && cmbBusqueda.SelectedIndex <= 10))
            {
                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                this.Lista(tbusqueda);
                cmbBusqSec.Enabled = false;
                //MessageBox.Show("----"+tbusqueda);
            }



            if (cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Stock")
                   || cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("StockMinimo")
                   || cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Compra")
                   || cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Venta")
                   || cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("StockMin")
                   )
            {
                txtBuscar.MaxLength = 15;


                if (cmbBusqSec.Items.Contains("Si") && cmbBusqSec.Items.Contains("No"))
                {
                    cmbBusqSec.Items.Remove("Si");
                    cmbBusqSec.Items.Remove("No");
                }

                if (!cmbBusqSec.Items.Contains("Mayor") && !cmbBusqSec.Items.Contains("Menor"))
                {
                    cmbBusqSec.Items.Add("Mayor");
                    cmbBusqSec.Items.Add("Menor");
                }
                cmbBusqSec.Enabled = true;
                cmbBusqSec.SelectedIndex = 0;


                NumeroDecimal = cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Compra") == true ||
                cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Venta") == true ? true : false;
                txtBuscar.Text = borrarLetras(txtBuscar.Text);
                txtBuscar.SendToBack();
                //  MessageBox.Show(NumeroDecimal + "--0sCCc");

                // this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);




            }
            else
            {

                txtBuscar.Enabled = true;
                txtBuscar.MaxLength = 300;
                cmbBusqSec.Enabled = false;
                cmbBusqSec.SelectedItem = "Seleccione";

                //cmbBusqSec.SelectedItem = "Seleccione";
                // this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);

            }
            if (cmbBusqueda.SelectedIndex == 11)
            {
                txtBuscar.Text = "";
                txtBuscar.Enabled = false;
                cmbBusqSec.Enabled = true;
                //  this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
                //MessageBox.Show("IVA");

                if (!cmbBusqSec.Items.Contains("Si") && !cmbBusqSec.Items.Contains("No"))
                {
                    cmbBusqSec.Items.Add("Si");
                    cmbBusqSec.Items.Add("No");
                }

                if (cmbBusqSec.Items.Contains("Mayor") && cmbBusqSec.Items.Contains("Menor"))
                {
                    cmbBusqSec.Items.Remove("Mayor");
                    cmbBusqSec.Items.Remove("Menor");
                }

                cmbBusqSec.SelectedIndex = 0;
            }









        }

        private void cmbBusqSec_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbBusqSec.SelectedIndex != 0)
            {

                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                topcion = (ENBusquedaOpcion)Enum.Parse(typeof(ENBusquedaOpcion), cmbBusqSec.SelectedItem.ToString());
                // MessageBox.Show(tbusqueda+"--"+topcion);
                this.Lista(tbusqueda, topcion);



            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            #region SVenta
            if (Origen == "Venta")
            {
                DialogResult dresult = (MessageBox.Show("Desea Pasar esta Seleccion de Productos?",
                    "Seleccion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {

                   
                    if (this.rowSelected.Count > 0)
                    {
                        Venta.FormVenta.VentaP.fillDatosProductos(rowSelected);
                    }

                }
                else
                {

                    GridSeleccion = false; this.Hide();

                }



            }
            #endregion

            #region SPedido
            if (Origen == "Pedido")
            {
                DialogResult dresult = (MessageBox.Show("Desea Pasar esta Seleccion de Productos?",
                    "Seleccion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {
                  

                    
                    if (rowSelected.Count > 0)
                    {
                        Pedido.FormPedido.PedidoP.fillDatosProductos(rowSelected);
                    }

                }
                else
                {

                    GridSeleccion = false; this.Hide();

                }



            }
            #endregion
            GridSeleccion = false;

            this.Hide();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtBuscar.Text))
            {




                if (cmbBusqSec.Enabled)
                {
                    //txtBuscar.Text = borrarLetras(txtBuscar.Text);
                    //  NumeroDecimal = cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Compra") == true ||
                    // cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Venta") == true ? true : false;
                    txtBuscar.Text = borrarLetras(txtBuscar.Text);
                    txtBuscar.SendToBack();
                    if (cmbBusqSec.SelectedIndex != 0)
                    {

                        tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                        topcion = (ENBusquedaOpcion)Enum.Parse(typeof(ENBusquedaOpcion), cmbBusqSec.SelectedItem.ToString());
                        // MessageBox.Show(tbusqueda+"--"+topcion);
                        this.Lista(tbusqueda, topcion);


                    }


                }
                else
                {

                    tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                    this.Lista(tbusqueda);
                    cmbBusqSec.Enabled = false;
                    //MessageBox.Show("----"+tbusqueda);
                }


            }
            else
            {

                this.Lista();
            }


        }

        private void FormDataProductosSeleccion_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.addProducto.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    this.Lista();

                }

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Eliminar\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormProducto frm = new FormProducto();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormProducto frm = new FormProducto();
                var t = this.addProducto.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text = "0000" + t.Codigo.ToString();
                frm.txtNombre.Text = t.Nombre;
                frm.txtCategoria.Text = t.Categoria;
               // frm.cmbColor.SelectedText = t.Color;
                //frm.cmbDimension.SelectedText = t.Dimension;
                frm.txtUnidad.Text = t.Unidad;

                frm.txtStock.Text = "" + t.Stock;
                frm.txtStockMin.Text = "" + t.StockMin;
                frm.txtVenta.Text = "" + t.Venta;
                frm.txtCompra.Text = "" + t.Compra;
                frm.txtDescripcion.Text = t.Descripcion;
                frm.chkIva.CheckState = t.IVA == 'S' ? CheckState.Checked : CheckState.Unchecked;
              //  frm.chkPrecioVenta.CheckState = CheckState.Unchecked;
                //frm.txtMarca.Text = t.Marca;





                frm.btnNuevo.Text = "Editar";
                frm.ShowDialog();
                this.Lista();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDataProductosSeleccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (GridSeleccion)
            //{
            //    Producto.FormProducto.Prod_principal.Show();
            //    GridSeleccion = false;
            //}
            #region SVenta
            if (Origen == "Venta")
            {
                DialogResult dresult = (MessageBox.Show("Desea Pasar esta Seleccion de Productos?",
                    "Seleccion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {
                   
                    
                    if (rowSelected.Count > 0)
                    {
                        Venta.FormVenta.VentaP.fillDatosProductos(rowSelected);
                    }

                }
                if (dresult == DialogResult.No)
                {
                    
                    GridSeleccion = false; this.Hide();

                }



            }
            #endregion

            #region SVenta
            if (Origen == "Pedido")
            {
                DialogResult dresult = (MessageBox.Show("Desea Pasar esta Seleccion de Productos?",
                    "Seleccion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {
                  
                    
                    if (rowSelected.Count > 0)
                    {
                        Pedido.FormPedido.PedidoP.fillDatosProductos(rowSelected);
                    }

                }
                if (dresult == DialogResult.No)
                {

                    GridSeleccion = false; this.Hide();

                }



            }
            #endregion
            GridSeleccion = false;

            this.Hide();
        }







        private bool numeroDecimal = false;
        public bool NumeroDecimal
        {
            set
            {
                this.numeroDecimal = value;
            }

            get
            {
                return this.numeroDecimal;
            }
        }

        private void teclaNumero(object sender, KeyPressEventArgs e)
        {

            if (NumeroDecimal)
            {
                //txtBuscar.Text = borrarLetras(txtBuscar.Text);
                if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.'
                    && this.txtBuscar.Text.IndexOf('.') > -1)
                {
                    //System.Windows.Forms.MessageBox.Show("" + this.Text.IndexOf('.')+"--"+this.Text.Length);
                    e.Handled = true;

                }
                Boolean dot = false;


                foreach (char value in this.txtBuscar.Text)
                {
                    if (value == '.')
                    { dot = true; }
                }




                if (dot && char.IsDigit(e.KeyChar)
                   && this.txtBuscar.Text.IndexOf('.') + 3 == this.txtBuscar.TextLength)
                {
                    // System.Windows.Forms.MessageBox.Show("" + this.Text.IndexOf('.') + "--" + this.Text.Length);
                    e.Handled = true;

                }
            }
            else
            {
                //  txtBuscar.Text=borrarLetras(txtBuscar.Text);
                if (!char.IsControl(e.KeyChar)
                     && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }


        }

        private string borrarLetras(string texto)
        {
            string temp = "";
            int dot = 0;
            texto = texto.Trim();
            if (!String.IsNullOrEmpty(texto))
            {




                foreach (char value in texto)
                {


                    if (NumeroDecimal)
                    {
                        if (value == '.')
                        {
                            dot += 1;
                            //   MessageBox.Show(dot+"---0");
                        }

                        if (Char.IsDigit(value) || (dot < 2 && value == '.'))

                        { temp += value; }



                    }
                    else
                    {

                        if (Char.IsDigit(value))
                        { temp += value; }

                    }



                }



                return temp;
            }
            else
            {
                return "";
            }
        }




        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                FormProducto frm = new FormProducto();
                var t = this.addProducto.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text = "0000" + t.Codigo.ToString();
                frm.txtNombre.Text = t.Nombre;
                frm.txtCategoria.Text = t.Categoria;
                //frm.cmbColor.SelectedText = t.Color;
                //frm.cmbDimension.SelectedText = t.Dimension;
                frm.txtUnidad.Text = t.Unidad;

                frm.txtStock.Text = "" + t.Stock;
                frm.txtStockMin.Text = "" + t.StockMin;
                frm.txtVenta.Text = "" + t.Venta;
                frm.txtCompra.Text = "" + t.Compra;
                frm.txtDescripcion.Text = t.Descripcion;
                frm.chkIva.CheckState = t.IVA == 'S' ? CheckState.Checked : CheckState.Unchecked;
                //frm.chkPrecioVenta.CheckState = CheckState.Unchecked;
                //frm.txtMarca.Text = t.Marca;


                frm.panelEx1.Enabled = false;

                frm.btnNuevo.Text = "Habilitar Edicion";
                frm.btnNuevo.Visible = true;
               
               // frm.chkPrecioVenta.Visible = false;
               // frm.label14.Visible = false;
                frm.ver = true;


                frm.ShowDialog();
                //this.Lista();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }

    class CSeleccion
    {

        private int codigo;

        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private DataGridViewRow dgv;

        public DataGridViewRow Dgv
        {
            get { return dgv; }
            set { dgv = value; }
        }

        public void seleccion(int codigo, DataGridViewRow row)
        {

            this.Codigo = codigo;
            this.Dgv = row;
        }

    

    }
}