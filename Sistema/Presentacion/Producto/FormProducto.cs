using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;
using Negocios.Entidades;
namespace Presentacion.Producto
{
    public partial class FormProducto : Base.FormMainC
    {

        private static FormProducto prod_principal;

        public static FormProducto Prod_principal
        {
            get { return FormProducto.prod_principal; }
            set { FormProducto.prod_principal = value; }
        }
         
        /// A?adir una variable para indicar al formulario
        /// si se quiere editar o eliminar
        public bool nuevo = false;
        public bool editar = false;
        public bool ver = false;
        /// instanciamos una clase
      public  EProducto c = new EProducto();
        /// instanciamos otra clase
        NProducto addProducto = new NProducto();
        NCategoria getCategoria = new NCategoria();
        NUnidad getUnidad = new NUnidad();
        NMarca getMarca = new NMarca();

        NTamanio getTamanio = new NTamanio();
       
        NColor getColor = new NColor();
        NCaracteristica getCaracteristica = new NCaracteristica();
        ECaracteristica caracteristica = new ECaracteristica();


        int  minima_cantidad = (new EProducto().Prod_mincantidad);
        double aumento = (new EProducto().Prod_aumento);
        double valor_iva = (new EProducto().Prod_iva_valor);

      
        public FormProducto()
        {
            InitializeComponent();
            Prod_principal = this;


                btnLimpiar.Visible = editar ? false:true;
                btnLimpiar.Visible = ver ? false : true;
            

            lblIVAP.Text = " "+aumento.ToString("P", System.Globalization.CultureInfo.InvariantCulture)  +
                           "+ IVA :" + valor_iva.ToString("P", System.Globalization.CultureInfo.InvariantCulture) ;
            inicioIngresoR();
            //txtNombre.Focus();
           // txtNombre.Size = new System.Drawing.Size(175, 22);
     

        
           txtMarca.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteMarca();
          txtMarca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           txtMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;




     
           txtUnidad.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteUnidad();
           txtUnidad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           txtUnidad.AutoCompleteSource = AutoCompleteSource.CustomSource;


          
           txtCategoria.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCategoria();
           txtCategoria.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           txtCategoria.AutoCompleteSource = AutoCompleteSource.CustomSource;


           //txtNombre.DataBindings = getCategoria.Listar("-");
           //txtNombre.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCategoria();
           //txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
          //txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;

           //cmbCaracteristicas.DataSource = getCaracteristica.Listar("");
           //cmbCaracteristicas.DisplayMember = "Tipo";
           //cmbCaracteristicas.ValueMember = "Codigo";
           //cmbCaracteristicas.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCaracteristica();
           //cmbCaracteristicas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           //cmbCaracteristicas.AutoCompleteSource = AutoCompleteSource.CustomSource;




           dtNombre.Enter +=  new System.EventHandler(dtNombre_GotFocus);
          

           dtAlmacen.Enter += new System.EventHandler(dtAlmacen_GotFocus);

           dtCaracteristicaR.Enter += new System.EventHandler(dtCaracteristicaR_GotFocus);


           dtNombre.Leave += new System.EventHandler(dtNombre_LostFocus);
           dtAlmacen.Leave += new System.EventHandler(dtAlmacen_LostFocus);

           dtCaracteristicaR.Leave += new System.EventHandler(dtCaracteristicaR_LostFocus);

           Cursor.Current = Cursors.AppStarting;
        }


        Color csp = Color.WhiteSmoke;
        void dtNombre_LostFocus(object sender, EventArgs e)
        {
            lblNombre.ForeColor = Color.Black;
        }

        void dtAlmacen_LostFocus(object sender, EventArgs e)
        {
            lblAlmacen.ForeColor = Color.Black;
        
        }

        void dtCaracteristicaR_LostFocus(object sender, EventArgs e)
        {
           lblCaracteristica.ForeColor = Color.Black;
        
        }

        void dtNombre_GotFocus(object sender, EventArgs e)
        {
            lblNombre.ForeColor =csp;
        }

        void dtAlmacen_GotFocus(object sender, EventArgs e)
        {
            lblAlmacen.ForeColor = csp;
        }

        void dtCaracteristicaR_GotFocus(object sender, EventArgs e)
        {
            lblCaracteristica.ForeColor = csp;
        }
       

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
                #region Edicion
                try
                {

                    this.c.Prod_codigo = int.Parse(this.txtCodigo.Text);
                    this.c.Prod_nombre = String.IsNullOrEmpty(this.txtNombre.Text)?this.txtCategoria.Text:txtNombre.Text;


                    this.c.Prod_descripcion = txtDescripcion.Text;

                    ////

                    //MessageBox.Show("" + getCategoria.getDatos(txtCategoria.Text).cat_codigo);
                    this.c.Cat_nombre =txtCategoria.Text;
                    this.c.Uni_nombre = txtUnidad.Text;
                    this.c.Mar_nombre = txtMarca.Text;


                    this.c.Codprod_codigo = txtCodProd.Text + "";
                   
                 
                  

                   // this.c.Prod_nombre = String.IsNullOrEmpty(txtNombre.Text)?txtCategoria.Text:txtNombre.Text;

                    //txtCompra.Text = String.IsNullOrEmpty(txtCompra.Text) == true ? 0.0 : Convert.ToDouble(this.txtCompra.Text);
                    //txtVentaText = String.IsNullOrEmpty(txtVenta.Text) == true ? 0.0 : Convert.ToDouble(this.txtVenta.Text);
                    //txtStockMin.Text = String.IsNullOrEmpty(txtStockMin.Text) == true ? -1 : Convert.ToInt32(this.txtStockMin.Text);
                    //txtStock.Text = String.IsNullOrEmpty(txtStock.Text) == true ? 0 : Convert.ToInt32(this.txtStock.Text);

                    txtDescripcion.Text = String.IsNullOrEmpty(txtDescripcion.Text) == true ? "NINGUNA" : this.txtDescripcion.Text;
                    txtCompra.Text = String.IsNullOrEmpty(txtCompra.Text) == true ? "0.0" : this.txtCompra.Text;
                    txtVenta.Text = String.IsNullOrEmpty(txtVenta.Text) == true ? "0.0" : (this.txtVenta.Text);
                    txtStockMin.Text = String.IsNullOrEmpty(txtStockMin.Text) == true ? "-1" : (this.txtStockMin.Text);
                    txtStock.Text = String.IsNullOrEmpty(txtStock.Text) == true ? "0" : (this.txtStock.Text);


                    this.c.Prod_compra = Parse(this.txtCompra.Text);
                    this.c.Prod_venta = Parse(this.txtVenta.Text);
                    this.c.Prod_iva = chkIva.CheckState == CheckState.Checked ?'S':'N';
                    this.c.Prod_stock = Convert.ToInt32(this.txtStock.Text);
                    this.c.Prod_stock_min = Convert.ToInt32(this.txtStockMin.Text);

                    
                    
                                      






                    //preguntamos si fue pulsado
                    #region Nuevo
                    if (nuevo && !editar)
                    {
                        if (this.btnNuevo.Text == "Grabar")
                        {
                            //insertar
                           // MessageBox.Show(txtCodProd.Text);
                            if ((bool)new NProducto().getCodProd(txtCodProd.Text + ""))
                            {
                                MessageBox.Show("Ya existe un producto con ese codigo"
                                + "\nEl campo de Codigo  de producto  debe ser unico", "Codigo de Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            

                            try
                            {
                                if (verificarLCaracteristicas())
                                {
                                    int cod = this.addProducto.Insertar(this.c);

                                   //MessageBox.Show(this.c.Dcar_codigo + "\n"+c.Prod_stock_min);
                                    this.txtCodigo.Text = cod.ToString("0000");

                                    if (!guardarCaracteristica())
                                    {
                                        if (addProducto.getDatos(cod).CodDcar > 0)
                                        {
                                            ndprodcar.EliminarDetalle((int)addProducto.getDatos(cod).CodDcar);

                                        }
                                        addProducto.Eliminar(cod);

                                        return;
                                    }
                                }
                                else
                                {
                                    return;
                                }
                                 
                               
                            }
                            catch (Exception ex)
                            {
                                Datos.Excepciones.Gestionar(ex);
                                MessageBox.Show("Producto Ingreso C \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                if (int.Parse(this.txtCodigo.Text)>0)
                                 addProducto.Eliminar(int.Parse(this.txtCodigo.Text));
                               return;
                            }




                            MessageBox.Show("Registro insertado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.btnNuevo.Text = "Limpiar";
                            btnLimpiar.Enabled = false;
                            this.btnNuevo.Focus();
                        }
                        else
                        {
                            this.txtCodigo.Text = "00000";
                            //this.txtNombre.Text = "";
                           
                            this.txtDescripcion.Text = "";
                            this.txtCategoria.Text = "";
                            this.txtMarca.Text = "";
                            this.txtUnidad.Text = "";
                            this.chkIva.CheckState = CheckState.Checked;
                          //  this.chkPrecioVenta.CheckState = CheckState.Checked;
                            this.txtCompra.Text = "";
                            this.txtVenta.Text = "";
                            this.txtStockMin.Text = "";
                            this.txtStock.Text = "";

                            this.c.Dcar_codigo = 0;
                            limpiarIngresoR();
                            btnLimpiar.Enabled = true;
                            this.btnNuevo.Text = "Grabar";
                            //this.txtNombre.Focus();
                            this.nuevo = true;

                        }
                    }
                    #endregion


                    #region Editar
                    if (this.editar && btnNuevo.Text == "Editar")
                    {
                        try
                        {


                            if ((bool)new NProducto().getCodProd(txtCodProd.Text + "") && c.Codprod_codigo != txtCodProd.Text+"")
                            {
                                MessageBox.Show("Ya existe un producto con ese codigo"
                                + "\nEl campo de Codigo  de producto  debe ser unico", "Codigo de Producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (verificarLCaracteristicas())
                            {
                                //MessageBox.Show(verificarLCaracteristicas() + "--"
                                //    + guardarCaracteristica() + "\n" + c.Dcar_codigo + "\n" + c.Mar_codigo + "\n"
                                //    + c.Prod_codigo + "\n"
                                //    + c.Prod_nombre + "\n"
                                //    +c.Mar_nombre+ "\n"
                                //    + c.Uni_nombre + "\n"
                                //    + c.Cat_nombre + "\n");
                                if (guardarCaracteristica())
                                {

                                    this.addProducto.Editar(this.c);
                                    MessageBox.Show("Registro actualizado completo", "Edicion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                           
                            // this.txtNombre.Focus();
                        }
                        catch (Exception ex)
                        {

                            Datos.Excepciones.Gestionar(ex);
                            MessageBox.Show(Datos.Excepciones.MensajePersonalizado, "Ingreso de Caracteristicas");
                       
                        
                        }

                       



                    }
                    if (ver && FormMDI.Usuario.Equals("ADMIN"))
                    {
                        DialogResult dresult = (MessageBox.Show("Desea Entrar en Edicion : "+txtCodProd.Text,"Edicion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                        if (dresult == DialogResult.OK)
                        {
                            editar = true;
                            btnNuevo.Text = "Editar";

                            this.tciVer.Visible = false;
                            

                            
                            this.pnlTab1.Enabled = true;
                            this.pnlTab2.Enabled = true;
                            this.pnlTab3.Enabled = true;
                            tabControl.SelectedTab = this.tciIngreso;
                            ver = false;
                        }
                        else
                        {
                            editar = false;

                        }

                    }


                    #endregion



                }


                catch (Exception ex)
                {
                    Datos.Excepciones.Gestionar(ex);
                    MessageBox.Show("Producto \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   // throw new Exception("No se puede Editar \n" + ex.Message);
                    //Datos.Excepciones.Gestionar(ex);
                    // MessageBox.Show("No se puede Editar \n" + Datos.Excepciones.MensajePersonalizado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #endregion
            

        }

        
      
       
      
        
        //private void chkPrecioVenta_CheckedChanged(object sender, EventArgs e)
        //{

        //   // MessageBox.Show((chkPrecioVenta.CheckState == CheckState.Checked ? 'S' : 'N') + "--");
           
           
        //    if ((chkPrecioVenta.CheckState == CheckState.Checked) && !String.IsNullOrEmpty(txtCompra.Text))
        //    {
        //        double result = Convert.ToDouble(txtCompra.Text) + aumento * Convert.ToDouble(txtCompra.Text);

               
               
        //        this.c.Prod_venta = result;
        //        txtVenta.ReadOnly = true;
        //        txtVenta.Enabled = false;
        //        txtVenta.Text = "" + result;
        //    }
        //    else
        //    {
        //        txtVenta.ReadOnly = false;
        //        txtVenta.Enabled = true;

               
                
        //    }



        //}
        bool inicio = false;
       
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void chkIva_CheckedChanged(object sender, EventArgs e)
        {
            
              this.c.Prod_iva =chkIva.CheckState == CheckState.Checked ? 'S' : 'N';
              dtAlmacen.Rows[0].Cells[2].Value = dtAlmacen.Rows[0].Cells[1].Value;
              dtAlmacen.Rows[0].Cells[5].Value = chkIva.Checked ? true : false;
        }


       
        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

        private void chkStockMin_CheckedChanged(object sender, EventArgs e)
        {

            if ((chkStockMin.CheckState == CheckState.Checked) && !String.IsNullOrEmpty(txtStockMin.Text))
            {
                int result = (minima_cantidad);


                txtStockMin.Text = "" + result;
                //this.c.Prod_stock_min = result;
                txtStockMin.ReadOnly = true;
                txtStockMin.Enabled = false;

            }
            else
            {
                txtStockMin.ReadOnly = false;
                txtStockMin.Enabled = true;
            }
        }

        private void btnCaracteristicas_Click(object sender, EventArgs e)
        {
            Producto.FormDataCaracteristicas frm = new Producto.FormDataCaracteristicas();


         

            FormDataCaracteristicas.GridSeleccion = true;

            frm.Show();
           
        }

        private void cmbCaracteristicas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
        }

       

       
      


       

        private void dtCaracteristica_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void btnCaracteristicas_Click_1(object sender, EventArgs e)
        {
            Producto.FormDataCaracteristicas frm = new Producto.FormDataCaracteristicas();
  
            frm.Visible = true;
            frm.Show();



        }

        private void dtCaracR_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData.ToString().Equals("Insert"))
            {
                dtCaracteristicaR.EndEdit();
            }
            if (dtCaracteristicaR.Rows.Count > 0)
            {
                if (e.KeyData.ToString().Equals("Delete"))
                {

                    dtCaracteristicaR.EndEdit();
                }
            }
        }

        private void dtCaracteristicaR_KeyDown(object sender, KeyEventArgs e)
        {
        
         if (e.KeyData.ToString().Equals("Insert") )
                {


                    dtCaracteristicaR.Rows.Add();

                    dtCaracteristicaR2.Rows.Add();
                    dtCaracteristicaR.BeginEdit(true);

                    dtCaracteristicaR.CurrentCell = dtCaracteristicaR.Rows[dtCaracteristicaR.Rows.Count - 1].Cells[0];
                }
         if (dtCaracteristicaR.Rows.Count > 0)
         { 
               
                if (e.KeyData.ToString().Equals("Delete"))
                {
                    
                    
                   // MessageBox.Show(cl+"==");
                        
                    DialogResult dresult = (MessageBox.Show("Desea Eliminar: La caracteristica", !editar ? "Ingreso" : "Edicion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2));
                    if (dresult == DialogResult.OK)
                    {

                        int row = dtCaracteristicaR.CurrentRow.Index;
                       
                        
                        if (c.Dcar_codigo > 0)
                        {
                            c.Prod_codigo = Convert.ToInt32(txtCodigo.Text);
                            var t = new NDetalleCaracteristica().Listar(dtCaracteristicaR.Rows[row].Cells[0].Value + "", c.Prod_codigo);

                            if (t.Count > 0)
                            {
                                new NDetalleCaracteristica().Eliminar(new EDetalleCaracteristica(c.Dcar_codigo, dtCaracteristicaR.Rows[row].Cells[0].Value + "", ""));
                                dtCaracteristicaR.Rows.RemoveAt(row);
                                dtCaracteristicaR2.Rows.RemoveAt(row);
                                return;
                                                                //  dtCaracteristicaR.CurrentCell = dtCaracteristicaR.Rows[row - 1].Cells[0];
                            }

                        }
                        else
                        {

                            dtCaracteristicaR.Rows.RemoveAt(row);
                            dtCaracteristicaR2.Rows.RemoveAt(row);
                            return;
                            

                            //dtCaracteristicaR.CurrentCell = dtCaracteristicaR.Rows[row - 1].Cells[0];

                        }


                    

                    }
                   

                }

                if (e.KeyData.ToString().Equals("F2"))
                {
                    Producto.FormDataCaracteristicas frm = new Producto.FormDataCaracteristicas();


                    try
                    {

                        FormDataCaracteristicas.GridSeleccion = true;
                        dtCaracteristicaR.EndEdit();
                        frm.txtBuscar.Text = "" + dtCaracteristicaR.CurrentRow.Cells[1].Value;
                        frm.Show();
                        frm.dtLista.Focus();
                       

                    }
                    catch (System.ObjectDisposedException)
                    {
                        frm = new Producto.FormDataCaracteristicas();
                        dtCaracteristicaR.EndEdit();

                        frm.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                        frm.Show();
                        frm.dtLista.Focus();
                       

                    }

                }
        }

                Ubicacion_KeyDown(sender, e);

}
        private void Ubicacion_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyData.ToString().Equals("Up") && ((DataGridView)sender).Name.Equals("dtAlmacen"))
            {

                dtNombre.CurrentCell = dtNombre.Rows[0].Cells[0];
                dtNombre.EndEdit();
                    dtNombre.Focus();
            }

            if (e.KeyData.ToString().Equals("Up") && ((DataGridView)sender).Name.Equals("dtCaracteristicaR")&& dtCaracteristicaR.CurrentRow.Index==0)
            {

                dtAlmacen.CurrentCell = dtAlmacen.Rows[0].Cells[0];
                dtAlmacen.EndEdit();
                dtAlmacen.Focus();
            }

            if (e.KeyData.ToString().Equals("Down")&& ((DataGridView)sender).Name.Equals("dtNombre"))
            {

                dtAlmacen.CurrentCell = dtAlmacen.Rows[0].Cells[0];
                dtNombre.EndEdit();
                dtAlmacen.Focus();
            }

            if (e.KeyData.ToString().Equals("Down") && ((DataGridView)sender).Name.Equals("dtAlmacen"))
            {

                dtCaracteristicaR.Focus();
            }
        }


        

      /// <summary>
      ///  MEtodo para la busqueda de Datos
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>




        FormSeleccionProducto frm_producto = new FormSeleccionProducto();
       
       private void teclaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {


            
                // MessageBox.Show(e.KeyData+"=="+e.KeyValue);
                int column = dtNombre.CurrentCell.ColumnIndex;


                if (e.KeyData.ToString().Equals("F2"))
                {
                    if (column < 2)
                    {

                        try
                        {
                            dtNombre.EndEdit();
                            string txt ="" + dtNombre.CurrentCell.Value;




                            if (column == 0)
                            {
                                frm_producto.txtBuscar.Text = txt.Substring(0, txt.IndexOf('-') > 0 ? txt.IndexOf('-')  : txt.Length-1);
                                frm_producto.Lista();
                            }
                            else
                            {
                                frm_producto.txtBuscar.Text = txt;
                                frm_producto.Lista();
                            }
                            
                             FormSeleccionProducto.Origen = "Producto";
                            this.Enabled = false;
                            frm_producto.Show();
                            frm_producto.dtLista.Focus();


                        }

                        catch (System.ObjectDisposedException)
                        {
                            frm_producto = new FormSeleccionProducto();
                            dtNombre.EndEdit();
                            frm_producto.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                            frm_producto.Lista();

                             FormSeleccionProducto.Origen = "Producto";
                            this.Enabled = false;
                            frm_producto.Show();
                      
                            frm_producto.dtLista.Focus();
                        }
                    }
                    if (column == 2)
                    {



                        FormDataMarcas frm_marca = new FormDataMarcas();

                        try
                        {


                            FormDataMarcas.GridSeleccion = true;
                            dtNombre.EndEdit();
                            frm_marca.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                            this.Enabled = false;
                            frm_marca.Show();
                            // dtNombre.CurrentCell = dtNombre.CurrentRow.Cells[3];
                            dtNombre.EndEdit();
                            frm_marca.dtLista.Focus();

                        }
                        catch (System.ObjectDisposedException)
                        {

                            frm_marca = new FormDataMarcas();

                            FormDataMarcas.GridSeleccion = true;
                            dtNombre.EndEdit();
                            frm_marca.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                            this.Enabled = false;
                            frm_marca.Show();
                            frm_marca.dtLista.Focus();

                        }


                    }
                    if (column == 3)
                    {



                        FormDataCategorias frm_categoria = new FormDataCategorias();


                        try
                        {


                            FormDataCategorias.GridSeleccion = true;
                            dtNombre.EndEdit();
                            frm_categoria.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;

                            this.Enabled = false;
                            frm_categoria.Show();

                            frm_categoria.dtLista.Focus();

                        }
                        catch (System.ObjectDisposedException)
                        {
                            frm_categoria = new FormDataCategorias();
                            FormDataCategorias.GridSeleccion = true;
                            dtNombre.EndEdit();
                            frm_categoria.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;

                            frm_categoria.Show();

                            frm_categoria.dtLista.Focus();
                        }


                    }

                    if (column == 4)
                    {


                        FormDataUnidades frm_unidad = new FormDataUnidades();


                        try
                        {

                            FormDataUnidades.GridSeleccion = true;
                            dtNombre.EndEdit();
                            frm_unidad.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                            frm_unidad.Show();

                            frm_unidad.dtLista.Focus();
                        }
                        catch (System.ObjectDisposedException)
                        {
                            frm_unidad = new FormDataUnidades();


                            FormDataUnidades.GridSeleccion = true;
                            dtNombre.EndEdit();
                            frm_unidad.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                            frm_unidad.Show();

                            frm_unidad.dtLista.Focus();


                        }



                    }


                    //   dtNombre.CurrentCell = dtNombre.CurrentRow.Cells[cell];
                    // dtNombre.BeginEdit(true);


                }

            
           
        }

        private void dtNombre_KeyPress(object sender, KeyPressEventArgs e)
       {
           TextBox txt = (TextBox)sender;
           bool ps = false;
         foreach (char a in txt.Text)
         {
             if (a.Equals('-'))
             {
                 ps = true;

             }
         }
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '-' && !ps && txt.Text.Length>0)
            {
                e.Handled = false;
            }
           
            else
            {
                e.Handled = true;
            }
           
          
           
          


        }
        private void dtIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
             if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
              else {
                e.Handled = true;
            }
            
            }
        private void dtNombre_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {



           

            int column =(int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex);
            if (column >= 2)
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtIngreso_KeyPress);

            }



            if (column == 2)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {

                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteMarca();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }

            if (column == 3)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {




                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCategoria();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }

            if (column == 4)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {




                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteUnidad();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }


            }
           
            if ( column== 0)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {


          
                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCodigoProducto();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtNombre_KeyPress);
                }
            }

              if (column == 1)
            {
               
                TextBox tb = e.Control as TextBox;
                
                if (tb != null)
                {

                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCategoria();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtCaracteristica_KeyPress);
            
                }
            }

              

             e.Control.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teclaBusqueda_KeyDown);
        }

        private void dtAlmacen_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) <= 1)
            {
               
                NumeroDecimal = true;

                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);

            }
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) >= 2)
            {
                NumeroDecimal = false;
                dtAlmacen.Columns[3].DefaultCellStyle.Format = "N0";
                dtAlmacen.Columns[4].DefaultCellStyle.Format = "N0";
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);
                // e.Control.TextChanged += new System.Windows.Forms.EventHandler

            }
        }

       

        private void dtCaracteristica_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           e.Control.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtCaracR_KeyDown);
           
            e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtCaracteristica_KeyPress);
            e.Control.BackColor = Color.WhiteSmoke;
            e.Control.ForeColor = Color.Black;
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 0)
            {
                TextBox tb = e.Control as TextBox;
              //  tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
           
           
                if (tb != null)
                {




                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCaracteristicaTipo();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }

            string tipo = "";

            tipo = String.IsNullOrEmpty((dtCaracteristicaR.Rows[dtCaracteristicaR.CurrentRow.Index].Cells[0].Value + "").Trim())
                ? String.IsNullOrEmpty((dtCaracteristicaR2.Rows[dtCaracteristicaR2.CurrentRow.Index].Cells[0].Value + "").Trim())
                ? "" : (dtCaracteristicaR2.Rows[dtCaracteristicaR2.CurrentRow.Index].Cells[0].Value + "")
                : (dtCaracteristicaR.Rows[dtCaracteristicaR.CurrentRow.Index].Cells[0].Value + "");

            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 1)
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {

                    tb.AutoCompleteCustomSource = FormProducto.LoadAutoCompleteCaracteristicaValor(tipo);
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }


        }

        private void dtNombre_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            
          int columnN = (dtNombre.Rows.Count < 1) ? -1 : dtNombre.CurrentCell.ColumnIndex;
            if(columnN>-1)
            {

                
            if (columnN == 0)
            {
                txtCodProd.Text = dtNombre.CurrentRow.Cells[0].Value + "";

            }

            if (columnN == 1)
            {
                txtNombre.Text = dtNombre.CurrentRow.Cells[1].Value + "";
                if (dtNombre.Rows[0].Cells[3].Value==null && new NCategoria().Listar(txtNombre.Text).Count>0 )
                {

                    txtCategoria.Text = dtNombre.CurrentRow.Cells[1].Value + "";
                    dtNombre.CurrentRow.Cells[3].Value = dtNombre.CurrentRow.Cells[1].Value;
                }
            }
            if (columnN == 2)
            {
                txtMarca.Text = dtNombre.CurrentRow.Cells[2].Value + "";

            }
            if (columnN == 3)
            {
                txtCategoria.Text = dtNombre.CurrentRow.Cells[3].Value + "";
                if (dtNombre.Rows[0].Cells[1].Value == null)
                {

                    txtNombre.Text = dtNombre.CurrentRow.Cells[3].Value + "";
                    dtNombre.CurrentRow.Cells[1].Value = dtNombre.CurrentRow.Cells[3].Value;
                }
            }
            if (columnN == 4)
            {
                txtUnidad.Text = dtNombre.CurrentRow.Cells[4].Value + "";

            }
        }

      
        }
        private void dgvcellStock_TextChanged(object sender, EventArgs e)
        {
            int st = Convert.ToInt32(dtAlmacen.CurrentRow.Cells[4].Value);
            txtStock.Text = st + "";
        }
        private void dgvcellStockMin_TextChanged(object sender, EventArgs e)
        {
            int st = Convert.ToInt32(dtAlmacen.CurrentRow.Cells[3].Value);
            txtStockMin.Text = st + "";
        }
       

        private void dgvcellCompra_TextChanged(object sender, EventArgs e)
        {
            double compra = Convert.ToDouble(dtAlmacen.CurrentRow.Cells[0].Value);
                    //MessageBox.Show("" + compra);
                    txtCompra.Text = compra + "";

                   
                        txtVenta.Text =  Math.Round(compra + aumento * compra,4) + "";

                    

                    dtAlmacen.CurrentRow.Cells[1].Value =  Math.Round(compra + aumento * compra,4);
    }

        private void dgvcellVenta_TextChanged(object sender, EventArgs e)
        {

            bool parse = false;
            double venta = 0.0;
            parse = Double.TryParse(dtAlmacen.CurrentRow.Cells[1].Value + "", out venta);
            if (parse)
            {
             txtVenta.Text = venta + "";

            }
            else
                txtVenta.Text = 0 + "";
        }

        private void dgvcellVentaIVA_TextChanged(object sender, EventArgs e)
        {
           
            bool parse = false;
            double venta = 0.0;

            double ventaiva = 0.0;
            parse = Double.TryParse(dtAlmacen.CurrentRow.Cells[1].Value + "", out venta);
            if (parse)
            {
                ventaiva = venta + venta * valor_iva;
                txtVenta.Text = venta + "";

            }
            else
            {
                txtVenta.Text = 0 + "";

                txtVentaIVA.Text = 0 + "";
            }
        }


        private void dtAlmacen_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            
            int columnA = (dtAlmacen.Rows.Count < 1) ? -1 : dtAlmacen.CurrentCell.ColumnIndex;
            if(columnA>-1)
            {
                if (columnA == 5)
                {

                   // MessageBox.Show("" + dtAlmacen.CurrentCell.Value + "--" + Convert.ToBoolean(dtAlmacen.CurrentCell.Value));

                          //  chkIva.CheckState = Convert.ToString(dtAlmacen.CurrentCell.Value).Equals("True") ? CheckState.Checked : CheckState.Unchecked;
                    chkIva.CheckValue = dtAlmacen.CurrentCell.Value;
                    double venta = Parse(dtAlmacen.CurrentRow.Cells[1].Value.ToString());

                    //MessageBox.Show("" + compra);
                    txtVenta.Text = String.Format("{0:C4}", venta);
                    if (dtAlmacen.CurrentCell.Value.ToString().Equals("S"))
                    {
                        dtAlmacen.CurrentRow.Cells[2].Value = Math.Round(venta + (venta * valor_iva), 4);
                        txtVentaIVA.Text = String.Format("{0:C4}", Math.Round(venta + (venta * valor_iva), 4));
                    }
                    else
                    {
                        dtAlmacen.CurrentRow.Cells[2].Value = venta;
                        txtVentaIVA.Text = String.Format("{0:C4}", venta);
                    }
                
                }


                if (columnA == 0)
                {
                   // MessageBox.Show(String.Format("{0:N4}",dtAlmacen.CurrentRow.Cells[0].Value)+"\n"+dtAlmacen.CurrentRow.Cells[0].Value);

                    double compra = Parse(dtAlmacen.CurrentRow.Cells[0].Value.ToString());                  //MessageBox.Show("" + compra);
                  
                    
                    txtCompra.Text = String.Format("{0:C4}",compra);


                    txtVenta.Text =  String.Format("{0:C4}",Math.Round(compra + aumento * compra,4));

                    dtAlmacen.CurrentRow.Cells[0].Value = compra;

                    dtAlmacen.CurrentRow.Cells[1].Value = Math.Round(compra + aumento * compra, 4);
                    double venta = Parse(dtAlmacen.CurrentRow.Cells[1].Value.ToString());     
                    if (chkIva.Checked)
                    {
                        dtAlmacen.CurrentRow.Cells[2].Value = Math.Round(venta + (venta * valor_iva), 4);
                        txtVentaIVA.Text = String.Format("{0:C4}",Math.Round(venta + (venta * valor_iva), 4));
                    }
                    else
                    {
                        dtAlmacen.CurrentRow.Cells[2].Value = venta;
                        txtVentaIVA.Text = String.Format("{0:C4}",venta );
                    }
                }

                if (columnA == 1)
                {
                    double venta = Parse(dtAlmacen.CurrentRow.Cells[1].Value.ToString());     
                
                    //MessageBox.Show("" + compra);
                    txtVenta.Text = String.Format("{0:C4}", venta);
                    if (chkIva.Checked)
                    {
                        dtAlmacen.CurrentRow.Cells[2].Value = Math.Round(venta + (venta * valor_iva), 4);
                        txtVentaIVA.Text = String.Format("{0:C4}", Math.Round(venta + (venta * valor_iva), 4));
                    }
                    else
                    {
                        dtAlmacen.CurrentRow.Cells[2].Value = venta;
                        txtVentaIVA.Text = String.Format("{0:C4}", venta);
                    }
                    

                }
             
                if (columnA == 3)
                {
                    int stock = Convert.ToInt32(Parse(dtAlmacen.CurrentRow.Cells[3].Value + ""));
                    //MessageBox.Show("" + compra);
                    if (stock != this.minima_cantidad)
                    {
                        txtStockMin.Text = stock + "";
                        chkStockMin.Checked = false;
                    }


                }
                if (columnA == 4)
                { string txt =dtAlmacen.CurrentRow.Cells[4].Value + "";
                if (!String.IsNullOrEmpty(txt))
                {
                    int stock = Convert.ToInt32(txt);
                    //MessageBox.Show("" + compra);

                    txtStock.Text = stock + "";
                }

                }
            }
           
        }

        private void dtCaracteristicaR_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnA = (dtCaracteristicaR.Rows.Count < 1) ? -1 : dtCaracteristicaR.CurrentCell.ColumnIndex;
            if (columnA > -1)
            {

                if (columnA == 0)
                {

                    dtCaracteristicaR2.Rows[e.RowIndex].Cells[0].Value = dtCaracteristicaR.Rows[e.RowIndex].Cells[0].Value;
                
                }

                if (columnA == 1)
                {

                    dtCaracteristicaR2.Rows[e.RowIndex].Cells[1].Value = dtCaracteristicaR.Rows[e.RowIndex].Cells[1].Value;

                }
            }
        }

        private void dtCaracteristicaR2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int columnA = (dtCaracteristicaR.Rows.Count < 1) ? -1 : dtCaracteristicaR.CurrentCell.ColumnIndex;
            if (columnA > -1)
            {

                if (columnA == 0)
                {

                    dtCaracteristicaR.Rows[e.RowIndex].Cells[columnA].Value = dtCaracteristicaR2.Rows[e.RowIndex].Cells[columnA].Value;

                }

                if (columnA == 1)
                {

                    dtCaracteristicaR.Rows[e.RowIndex].Cells[columnA].Value = dtCaracteristicaR2.Rows[e.RowIndex].Cells[columnA].Value;

                }
            }
        }



        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            dtNombre.Rows[0].Cells[1].Value = txtNombre.Text;
        }

        private void txtCodProd_TextChanged(object sender, EventArgs e)
        {

            dtNombre.Rows[0].Cells[0].Value = txtCodProd.Text;
        }


      
        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            dtNombre.Rows[0].Cells[2].Value = txtMarca.Text;
        }
        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            
            dtNombre.Rows[0].Cells[3].Value = txtCategoria.Text;



        }

        private void txtUnidad_TextChanged(object sender, EventArgs e)
        {
            dtNombre.Rows[0].Cells[4].Value = txtUnidad.Text;
        }
        private void txtCompra_TextChanged(object sender, EventArgs e)
        {
          
            dtAlmacen.Rows[0].Cells[0].Value = txtCompra.Text;
            if (editar && !inicio)
            {
               
                inicio = true;
            }

            ////MessageBox.Show(chkPrecioVenta.CheckState+"");
            if ( !String.IsNullOrEmpty(txtCompra.Text))
            {

                double result = Math.Round( Parse(txtCompra.Text) + aumento * Parse(txtCompra.Text),4);
                dtAlmacen.Rows[0].Cells[1].Value = result;
                txtVenta.Text = String.Format("{0:C4}",result);
            }
            if ((String.IsNullOrEmpty(txtCompra.Text.Trim())))
            {
                dtAlmacen.Rows[0].Cells[1].Value = 0;
                txtVenta.Text = String.Format("{0:C4}", 0);
            }

        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            dtAlmacen.Rows[0].Cells[4].Value = txtStock.Text;
        }

        private void txtStockMin_TextChanged(object sender, EventArgs e)
        {
            dtAlmacen.Rows[0].Cells[3].Value = txtStockMin.Text;
        }

        private void txtVenta_TextChanged(object sender, EventArgs e)
        {
            dtAlmacen.Rows[0].Cells[1].Value = txtVenta.Text; 
        }

       

      


        private void tlmInsertar_Click(object sender, EventArgs e)
        {
      
               
                dtCaracteristicaR.Rows.Add();
               
                dtCaracteristicaR2.Rows.Add();
                dtCaracteristicaR.BeginEdit(true);
             
                dtCaracteristicaR.CurrentCell = dtCaracteristicaR.Rows[ dtCaracteristicaR.Rows.Count-1].Cells[1];
            

        }

        private void tlmEliminar_Click(object sender, EventArgs e)
        {
            if (dtCaracteristicaR.Rows.Count > 0)
            {
                DialogResult dresult = (MessageBox.Show("Desea Eliminar: La caracteristica", !editar ? "Ingreso" : "Edicion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2));
                if (dresult == DialogResult.OK)
                {
                    dtCaracteristicaR.EndEdit();
                    int row = dtCaracteristicaR.CurrentRow.Index;

                    if (c.Dcar_codigo > 0)
                    {
                        c.Prod_codigo = Convert.ToInt32(txtCodigo.Text);
                        var t = new NDetalleCaracteristica().Listar(dtCaracteristicaR.Rows[row].Cells[0].Value + "", c.Prod_codigo);

                        if (t.Count > 0)
                        {
                            new NDetalleCaracteristica().Eliminar(new EDetalleCaracteristica(c.Dcar_codigo, dtCaracteristicaR.Rows[row].Cells[0].Value + "", ""));
                            dtCaracteristicaR.Rows.RemoveAt(row);
                            dtCaracteristicaR2.Rows.RemoveAt(row);
                            return;
                        }

                    }

                    dtCaracteristicaR.Rows.RemoveAt(row);
                    dtCaracteristicaR2.Rows.RemoveAt(row);
                }
            }
        }

        private void tlmBuscar_Click(object sender, EventArgs e)
        {
            Producto.FormDataCaracteristicas frm = new Producto.FormDataCaracteristicas();


            try
            {
                System.Threading.Thread.Sleep(50);
                FormDataCaracteristicas.GridSeleccion = true;
                frm.txtBuscar.Text = "" + dtCaracteristicaR.CurrentRow.Cells[1].Value;
                frm.Show();
                frm.dtLista.Focus();
            }
            catch (System.ObjectDisposedException)
            {
                frm = new Producto.FormDataCaracteristicas();

                System.Threading.Thread.Sleep(50);
                frm.txtBuscar.Text = "" + dtNombre.CurrentCell.Value;
                frm.Show();
                frm.dtLista.Focus();


            }
        }

        private void dtNombre_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex < 4)
            //    {
            //        dtNombre.CurrentCell = dtNombre.Rows[0].Cells[e.ColumnIndex + 1];

            //        dtNombre.BeginEdit(true);
            //    }
            //    else
            //    {
            //        dtNombre.EndEdit();
            //        dtAlmacen.Focus();
            //        dtAlmacen.CurrentCell = dtAlmacen.Rows[0].Cells[0];
            //        dtAlmacen.BeginEdit(true);
            //    }
            //}
            //catch { }
        }

        private void dtAlmacen_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (btnNuevo.Text != "Limpiar")
            {
                DialogResult dresult = (MessageBox.Show("Desea Limpiar todo el contenido  del " + (!editar ? "Ingreso" : "De la Edicion") + " de Producto", !editar ? "Ingreso" : "Edicion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2));
                if (dresult == DialogResult.OK)
                {

                    limpiarIngresoR();
                }
                else
                {
                    DialogResult dr = (MessageBox.Show("Desea Limpiar todo el contenido  de la tabla Caracteristicas", !editar ? "Ingreso" : "Edicion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2));
                    if (dr == DialogResult.OK)
                    {
                        dtCaracteristicaR.Rows.Clear();
                    }
                }



            }

        }
       

     

       
      

       
    }
    
}
