using Microsoft.Reporting.WinForms;
using Negocios;
using Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Pedido
{
    public partial class FormPedido : Base.FormFactura
    {

        NPedido addPedido = new NPedido();
        NProveedor getProv = new NProveedor();
        public EPedido epedido = new EPedido();
        public EDetallePedido edpedido = new EDetallePedido();
        NDetallePedido addDetallePedido = new NDetallePedido();

        Producto.FormSeleccionProducto frm_producto = new Producto.FormSeleccionProducto();

        bool f2 = false;

        public bool grabar = false;
        public bool f3 = false;
        NProducto getProducto = new NProducto();

        #region conexion



        private static FormPedido pedidop;

        public static FormPedido PedidoP
        {
            get { return FormPedido.pedidop; }
            set { FormPedido.pedidop = value; }
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
        public void fillDatos(int codPer)
        {
            try
            {
                var t = this.getProveedor.getDatos(codPer);
                if (codPer > 0)
                {

                    this.txtCliente.Text = t.Nombre;

                    // MessageBox.Show(t.Nombre + " " + t.Apellido);
                    this.txtIdentificacion.Text = t.Identificacion;
                    epedido.Prov_codigo = codPer;
                    // MessageBox.Show(eventa.Per_codigo + "");

                }
                else
                {

                    MessageBox.Show("Seleccione un proveedor");
                }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
       
        public bool findProductoList(int procod)
        {
            //bool existencia = false;

            foreach (DataGridViewRow rowD in dtLista.Rows)
            {

                if ((rowD.Cells[0].Value + "").Equals(procod))
                {
                    return true;
                }

            }


            return false;

        }
       



        public void fillDatosProductos(int vencodigo)
        {

            try
            {
                List<Datos.TDetalle_Pedido_Producto> lprod = addDetallePedido.ListarP(Convert.ToInt32(txtCodigo.Text));

                if (lprod.Count > 0)
                {


                    foreach (Datos.TDetalle_Pedido_Producto row in lprod)
                    {


                        dtLista.Rows.Add(
                            row.Codigo,
                            row.CodProd,
                            row.Producto,
                            row.Pedido,
                            row.cantidad,
                            row.Total,
                            row.IVA);

                        f2 = false;

                    }
                    dtLista.Enabled = true;


                }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        public void fillDatosProductos(List<DataGridViewRow> data)
        {
            try
            {
                if (data.Count > 0)
                {


                    foreach (DataGridViewRow row in data)
                    {

                        if (!findProductoList(Convert.ToInt32(row.Cells[0].Value + "")))
                        {
                            dtLista.Rows.Add(
                                row.Cells[0].Value,
                                row.Cells["CodProd"].Value,
                                row.Cells["Nombre"].Value,
                                row.Cells[3].Value,
                                0,
                                0.0,
                                row.Cells["IVA"].Value);


                        }

                    }
                    dtLista.Enabled = true;


                }
                else
                {

                    MessageBox.Show("Seleccione un producto");
                }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }



       
       
        private void teclaNumero(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;

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
                    && txt.Text.IndexOf('.') > -1)
                {
                    //System.Windows.Forms.MessageBox.Show("" + this.Text.IndexOf('.')+"--"+this.Text.Length);
                    e.Handled = true;

                }
                Boolean dot = false;


                foreach (char value in txt.Text)
                {
                    if (value == '.')
                    { dot = true; }
                }




                if (dot && char.IsDigit(e.KeyChar)
                   && txt.Text.IndexOf('.') + 3 == txt.TextLength)
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

      
       

        public bool findProductoListByCodigo(string codigo)
        {
            if (dtLista.Rows.Count > 0)
                foreach (DataGridViewRow rowD in dtLista.Rows)
                {

                    if (Convert.ToString(rowD.Cells[1].Value).Equals(codigo + ""))
                    {
                        return true;
                    }

                }


            return false;


        }

        public bool findProductoListByNombre(string codigo)
        {
             if (dtLista.Rows.Count > 0)
            {
                foreach (DataGridViewRow rowD in dtLista.Rows)
                {

                    if (Convert.ToString(rowD.Cells[2].Value).Equals(codigo + ""))
                    {
                        return true;
                    }

                }

            }
            return false;

        }


        public void fillDatosProducto(DataGridViewRow data, int fila)
        {
                try
                {

                    dtLista.Rows[fila].Cells[0].Value = data.Cells["Codigo"].Value;
                    dtLista.Rows[fila].Cells[1].Value = data.Cells["CodProd"].Value;
                    dtLista.Rows[fila].Cells[2].Value = data.Cells["Nombre"].Value;
                    dtLista.Rows[fila].Cells["Precio"].Value = data.Cells["Compra"].Value;
                    dtLista.Rows[fila].Cells["IVA"].Value = data.Cells["IVA"].Value;

                    f2 = false;
                }
                catch (Exception ex)
                {
                    Datos.Excepciones.Gestionar(ex);
                    MessageBox.Show("No se puede LLenar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
           

        }
        public void fillDatosProducto(Datos.TProducto_Caracteristica_Foreign data, int fila)
        {

            try
            {

                dtLista.Rows[fila].Cells[0].Value = data.Codigo;
                dtLista.Rows[fila].Cells[1].Value = data.CodProd;
                dtLista.Rows[fila].Cells[2].Value = data.Nombre;
                dtLista.Rows[fila].Cells[3].Value = data.Compra;
                dtLista.Rows[fila].Cells[6].Value = data.IVA;


            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Llenar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void fillDatosProducto(DataGridViewRow data)
        {

            try
            {
                dtLista.Rows.Add(
                data.Cells["Codigo"].Value,
                data.Cells["CodProd"].Value,
                 data.Cells["Nombre"].Value,
                data.Cells[3].Value,
               
                0,
                0.0,
                data.Cells["IVA"].Value
                );

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Llenar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
          private void teclaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {


            if (dtLista.Rows.Count > 0)
            {
                // MessageBox.Show(e.KeyData+"=="+e.KeyValue);
                int column = dtLista.CurrentCell.ColumnIndex;
                int row = dtLista.CurrentCell.RowIndex;

                if (e.KeyData.ToString().Equals("F2"))
                {
                    f2 = true;
                    if (column < 3)
                    {

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            dtLista.EndEdit();
                            frm_producto.txtBuscar.Text = "" + dtLista.CurrentCell.Value;
                            frm_producto.Lista();
                            Presentacion.Producto.FormSeleccionProducto.Origen = "Pedido";
                            Presentacion.Producto.FormSeleccionProducto.Fila = row;
                            this.Enabled = false;
                            Cursor.Current = Cursors.AppStarting;
                            frm_producto.Show();
                            frm_producto.dtLista.Focus();


                        }

                        catch (System.ObjectDisposedException)
                        {
                            dtLista.EndEdit();
                          
                            frm_producto = new Producto.FormSeleccionProducto();
                            frm_producto.txtBuscar.Text = "" + dtLista.CurrentCell.Value;
                            frm_producto.Lista();
                            Presentacion.Producto.FormSeleccionProducto.Origen = "Pedido";
                            this.Enabled = false;
                            frm_producto.Show();
                          
                            frm_producto.dtLista.Focus();
                        }
                    }


                }

                if (e.KeyData.ToString().Equals("F1"))
                {
                    if (column == 2)
                    {
                        //dtLista.NotifyCurrentCellDirty(true);
                        //dtLista.EndEdit();
                        //dtLista.NotifyCurrentCellDirty(false);

                        this.dtNombre_TextChanged();


                    }

                    if (column == 1)
                    {
                        //dtLista.NotifyCurrentCellDirty(true);
                        //dtLista.EndEdit();
                        //dtLista.NotifyCurrentCellDirty(false);

                        dtCodigoProd_TextChanged();

                    }

                }

                f2 = false;
            }

        }


        private void dtLista_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {


            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 3)
            {
                NumeroDecimal = true;

                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);

            }
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 4)
            {
                NumeroDecimal = false;
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);
            }

            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 5)
            {
                NumeroDecimal = true;

                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);

            }

           
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 2)
            {

                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtNombre_KeyPress);
                tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teclaBusqueda_KeyDown);

                if (tb != null)
                {

                    tb.AutoCompleteCustomSource = FormPedido.LoadAutoCompleteProducto();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

            }

            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 1)
            {
                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtCodigo_KeyPress);
                tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teclaBusqueda_KeyDown);
                if (tb != null)
                {

                    tb.AutoCompleteCustomSource = FormPedido.LoadAutoCompleteCodigoProducto();
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }


            }


            
   
        }

        public void calcularDescuento()
        {

            double tiva = Parse(txtIVA.Text);
            double subt0 = Parse(txtSub0.Text);
            double subt12 = Parse(txtSub12.Text);
            double desc = Parse(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);
          

            double total = 0.0;
                     

            total = Math.Round(((subt0 + subt12 + tiva) - desc), 2);

            txtTotal.Text = String.Format("{0:C2}", total);
        }

        public void calcularTotal()
        {
            double total = 0.0;
            double subt12 = 0.0;
            double subt0 = 0.0;
            double vdescuento = 0.0;
            double tiva = 0.0;
            #region
            foreach (DataGridViewRow row in dtLista.Rows)
            {

                if ((row.Cells["IVA"].Value + "").Equals("S"))
                {
                    //MessageBox.Show("Alfa");
                    double desc = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text)?"0":txtDescuento.Text);

                    if (desc > 0.00)
                    {
                        double viva;

                        subt12 += (Parse(row.Cells["Total"].Value + ""));
                        viva = Math.Round((Parse(row.Cells["Total"].Value + "") * new EProducto().Prod_iva_valor), 2);



                        tiva += viva;


                        txtSub12.Text = String.Format("{0:C2}", subt12);
                        txtIVA.Text = String.Format("{0:C2}", tiva);
                        calcularDescuento();
                    }
                    else
                    {
                        double viva;

                        subt12 += (Parse("" + row.Cells["Total"].Value));
                        viva = Math.Round((Parse("" + row.Cells["Total"].Value) * new EProducto().Prod_iva_valor), 2);


                        tiva += viva;

                        //total += Math.Round(((subt12 + tiva)), 2);


                        txtSub12.Text = String.Format("{0:C2}", subt12);
                        txtIVA.Text = String.Format("{0:C2}", tiva);
                        //txtTotal.Text = String.Format("{0:C2}", total);
                        calcularDescuento();

                    }

                }
                else
                {
                   
                    double desc = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);

                    if (desc > 0.00 && desc < 1)
                    {
                        subt0 += (Parse(row.Cells["Total"].Value + ""));
                        vdescuento += Math.Round(((Parse(row.Cells["Total"].Value + "") * desc)), 2);



                        total += Math.Round(((subt0) - vdescuento), 2);


                        txtSub0.Text = String.Format("{0:C2}", subt0);

                        calcularDescuento();
                    }
                    else
                    {
                        subt0 += (Convert.ToDouble(row.Cells["Total"].Value));



                        total += Math.Round(((subt0)), 2);


                        txtSub0.Text = String.Format("{0:C2}", subt0);

                        calcularDescuento();
                    }
                }

            }
            #endregion


        }


        private void dtLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int cantidad = 0;
          
            double precio = 0.0;
            //MessageBox.Show(""+f3);

            //if ( (dtLista.Columns[e.ColumnIndex].Name.Equals("Cantidad") || dtLista.Columns[e.ColumnIndex].Name.Equals("Precio")))
           
            if (dtLista.Rows.Count > 0 
                && !String.IsNullOrEmpty(dtLista.Rows[e.RowIndex].Cells[0].Value + "") 
                && !String.IsNullOrEmpty(dtLista.Rows[e.RowIndex].Cells[1].Value + "")
                && (dtLista.Columns[e.ColumnIndex].Name.Equals("Cantidad") || dtLista.Columns[e.ColumnIndex].Name.Equals("Precio")))
            {
                precio = Convert.ToDouble(Parse(dtLista.Rows[e.RowIndex].Cells[3].Value + ""));
                cantidad = Convert.ToInt32(dtLista.Rows[e.RowIndex].Cells[4].Value);

                if ((precio <=0 && (cantidad > 0) ))
                    dtLista.Rows[e.RowIndex].Cells["Cantidad"].Value = "0.0";
                
                int stock = (int)getProducto.getDatos(Convert.ToInt32(dtLista.Rows[e.RowIndex].Cells[0].Value)).Stock;

                if (precio == 0 && dtLista.CurrentRow.Index > -1 && cantidad > 0)
                {
                    MessageBox.Show("No es posible precio = 0\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  
                     dtLista.CurrentCell = dtLista.CurrentRow.Cells[e.ColumnIndex];
                     return;
                }
                if (precio > 0 && cantidad > 0)
                {
                    try
                    {       dtLista.Columns["Cantidad"].ToolTipText = "Tiene en  Stock Actual del producto a: " + stock;
                            dtLista.Rows[e.RowIndex].Cells["Total"].Value =
                               Math.Round((precio * cantidad) , 2);
                            calcularTotal();
                    }
                    catch (Exception ex)
                    {
                        Datos.Excepciones.Gestionar(ex);
                        MessageBox.Show("No se pudieron modificar los datos\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //MessageBox.Show((precio * cantidad) - (precio * descuento) + "");
                }
            }


        }

        #endregion


        public FormPedido()
        {
            InitializeComponent();


        }

        private void btnPSeleccion_Click(object sender, EventArgs e)
        {
            FormDataProveedores frm = new FormDataProveedores();
            FormDataProveedores.GridSeleccion = true;

           // FormDataProveedores.Origen = "Pedido";
            this.pnlDetalle.Enabled = true;
            frm.Opacity = 80;
            frm.ShowDialog();

           
            //btnPSeleccion.Enabled = false;


        }

        NProveedor getProveedor = new NProveedor();
        public DateTime date;
        private void FormPedido_Load(object sender, EventArgs e)
        {
            PedidoP = this;

            epedido.Ped_estado = 'N';



            txtIdentificacion.AutoCompleteCustomSource = FormPedido.LoadAutoCompleteIdentificacion();
            txtIdentificacion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtIdentificacion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (FormMDI.Usuario.Equals("ADMIN"))
            {

                dtLista.Columns["Precio"].ReadOnly = false;

            }
            else
            {
                dtLista.Columns["Precio"].ReadOnly = true;
            }
            FormMDI.usuarioValido(dateTimePicker1);
            FormMDI.usuarioValido(txtDescuento);
            dateTimePicker1.Value = date;

        }

        private void rdbCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCotizacion.Checked)
            {
                rdbFactura.Checked = false;
                epedido.Ped_estado = 'N';
            }

        }

        private void rdbFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFactura.Checked)
            {
                rdbCotizacion.Checked = false;
                epedido.Ped_estado = 'S';

            }
           
        }




        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dtLista.CurrentRow.Index > -1)
                if (!grabar)
                {
                    if (dtLista.Rows.Count > 0)
                    {
                        DialogResult dresult = (MessageBox.Show("Desea eliminar este producto de la lista ?",
                           "eliminar",
                                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                        if (dresult == DialogResult.Yes)
                        {
                            dtLista.Rows.RemoveAt(dtLista.CurrentRow.Index);
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(dtLista.Rows[dtLista.CurrentRow.Index].Cells[0].Value+""))
                    {
                        DialogResult dresult = (MessageBox.Show("Desea Eliminar el producto del Pedido", "Borrar Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2));
                        if (dresult == DialogResult.OK)
                        {
                            //MessageBox.Show(Convert.ToInt32(txtCodigo.Text) + "--" + (Int32)dtLista.Rows[dtLista.CurrentRow.Index].Cells[0].Value + "");
                            try
                            {
                                addDetallePedido.Eliminar(Convert.ToInt32(txtCodigo.Text), (Int32)dtLista.Rows[dtLista.CurrentRow.Index].Cells[0].Value);


                            }
                            catch (Exception ex)
                            {
                                Datos.Excepciones.Gestionar(ex);
                                MessageBox.Show(Datos.Excepciones.MensajePersonalizado, "Error.. Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;

                            }
                            dtLista.Rows.RemoveAt(dtLista.CurrentRow.Index);
                        }
                    }
                    else
                    {
                        dtLista.Rows.RemoveAt(dtLista.CurrentRow.Index);
                    }


                }


        }

      
        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            if (!grabar)
            {
                #region previo
                DialogResult dresult = (MessageBox.Show("Desea almacenar esta Factura-Pedido?",
                       "Grabar Factura-Pedido",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {


                    if (dtLista.Rows.Count > 0)
                    {
                        int cn = 0;
                       
                        foreach (DataGridViewRow row in dtLista.Rows)
                        {

                            if (!String.IsNullOrEmpty(row.Cells[0].Value + ""))
                            {

                                
                                if (Convert.ToDouble(Parse(row.Cells["Total"].Value + "")) > 0.0)
                                {
                                    cn += 1;
                                }
                                else
                                {
                                    cn -= 1;
                                }

                          }
                            else
                            {

                                cn = -1;
                            }

                        }

                        if (cn != dtLista.Rows.Count)
                        {
                            MessageBox.Show("No todos los productos estan calculados o definidos", "Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {

                            try
                            {
                                try
                                {


                                    
                                    epedido.Ped_estado = rdbFactura.Checked ? 'S' : 'N';
                                    epedido.Ped_descuento =Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);
                                    epedido.Ped_date = dateTimePicker1.Value.Date;
                                   // MessageBox.Show(epedido.Ped_codigo+"\n"+epedido.Prov_codigo + "\n" + epedido.Ped_estado + "\n" + epedido.Ped_descuento + "\n" + epedido.Ped_date);
                                    
                                    txtCodigo.Text = addPedido.Insertar(epedido) + "";

                                }
                                catch (Exception ex)
                                {
                                    Datos.Excepciones.Gestionar(ex);
                                    MessageBox.Show("Error al Ingreso de la Pedido-Cabecera\n" + ex.Message);
                                    return;
                                }

                                // btnGrabarDetalle.Enabled = false;

                                dtLista.Enabled = false;
                                foreach (DataGridViewRow row in dtLista.Rows)
                                {
                                    edpedido.Ped_codigo = Convert.ToInt32(txtCodigo.Text);
                                    edpedido.Prod_codigo = Convert.ToInt32(row.Cells["Codigo"].Value);
                                    edpedido.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                                    edpedido.Dped_precio = Parse(row.Cells["Precio"].Value + "");



                                    addDetallePedido.Insertar(edpedido);

                                }

                              
                                btnNuevo.Text = "Editar";
                                btnVer.Enabled = true;


                                MessageBox.Show("Registro insertado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                Datos.Excepciones.Gestionar(ex);
                                MessageBox.Show("Error al Ingreso  del Pedido" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }



                        }
                        //MessageBox.Show("" + cn + "---" + dtLista.Rows.Count);

                    }
                    else
                    {
                        MessageBox.Show("No existen campos");

                    }
                }
                #endregion
                grabar = true;


                    FormMDI.usuarioValido(btnNuevo);
                
            }
            else
            {
                #region previo
                DialogResult dresult = (MessageBox.Show("Desea actualizar esta Factura-Pedido?",
                       "Actualizar Factura -Pedido ",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {


                    if (dtLista.Rows.Count > 0)
                    {
                        int cn = 0;
                        foreach (DataGridViewRow row in dtLista.Rows)
                        {


                            if (!String.IsNullOrEmpty(row.Cells[0].Value + ""))
                            {


                                if (Convert.ToDouble(Parse(row.Cells["Total"].Value + "")) > 0.0)
                                {
                                    cn += 1;
                                }
                                else
                                {
                                    cn -= 1;
                                }

                            }
                            else
                            {

                                cn = -1;
                            }

                        }

                        if (cn != dtLista.Rows.Count)
                        {
                            MessageBox.Show("No todos los productos estan calculados o definidos", "Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else
                        {

                            try
                            {

                                try
                                {
                                    epedido.Ped_codigo = int.Parse(txtCodigo.Text);
                                    epedido.Ped_estado = rdbFactura.Checked ? 'S' : 'N';
                                    epedido.Ped_descuento = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text)?"0":txtDescuento.Text);
                                    epedido.Ped_date = dateTimePicker1.Value.Date;

                                    //MessageBox.Show(epedido.Ped_codigo + "\n" + epedido.Ped_estado + "\n" + epedido.Ped_date);
                                    addPedido.Editar(epedido);

                              
                                }
                                catch (Exception ex)
                                {
                                    Datos.Excepciones.Gestionar(ex);
                                    MessageBox.Show("Error al Actualizar del Pedido-Cabecera\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                             
                                
                                edpedido.Ped_codigo = epedido.Ped_codigo;
                                foreach (DataGridViewRow row in dtLista.Rows)
                                {

                                   // edpedido.Ped_codigo = Convert.ToInt32(txtCodigo.Text);
                                    edpedido.Prod_codigo = Convert.ToInt32(row.Cells["Codigo"].Value);
                                    edpedido.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                                    edpedido.Dped_precio = Parse(row.Cells["Precio"].Value + "");

                                   // MessageBox.Show(edpedido.Cantidad + "\n" + edpedido.Prod_codigo +"\n"+edpedido.Dped_precio);



                                   // MessageBox.Show(edpedido.Prod_codigo + "\n"+edpedido.Cantidad);

                                    addDetallePedido.Editar(edpedido);



                                }
                                MessageBox.Show("Registro actualizado completo", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnVer.Enabled = true;
                            }
                            catch (Exception ex)
                            {
                                Datos.Excepciones.Gestionar(ex);
                                MessageBox.Show("Error al Actualizar " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("No existen campos");

                    }
                }
                #endregion
            }
            Cursor.Current = Cursors.AppStarting;

         
        }

          double vdescuento = Convert.ToDouble((new NConfiguracion().getDatos("DESCUENTO").conf_valor));

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            //txtDescuento.Text = string.Format("{0:C4}", Parse(txtDescuento.Text));
               
                if (!String.IsNullOrEmpty(txtDescuento.Text.Trim()))
                {

                    double tiva = Parse(txtIVA.Text);
                    double subt0 = Parse(txtSub0.Text);
                    double subt12 = Parse(txtSub12.Text);
                    double total = 0.0;

                   


                        
                        // vdesc = Math.Round((((subt0 + subt12 + tiva) * desc)), 2);


                        //MessageBox.Show(String.Format("{0:C2}", txt.Text));
                    double vdesc = Parse(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);
                       // MessageBox.Show(vdesc + "");
                        total = Math.Round(((subt0 + subt12 + tiva) - vdesc), 2);
                    
                   
                        
                          if ( (subt0 + subt12 + tiva)<=vdesc)
                        {
                            txtDescuento.Text = 0.0 + "";
                            epedido.Ped_descuento = 0.0;
                            MessageBox.Show("No es posible ese Descuento,  este  es mayor a la Cantidad");
                        }
                        else
                        {
                            txtTotal.Text = String.Format("{0:C2}", total);
                            epedido.Ped_descuento = Parse(txtDescuento.Text);
                        }
                        }


                
                else
                {
                   
                    epedido.Ped_descuento = 0;
                   // txtDescuento.Text =String.Format("{0:C2}",0.0);
                }





        }
        public static AutoCompleteStringCollection LoadAutoCompleteProducto()
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();


            var lista = getLista.Listar("").Select(p => p.Nombre).ToList();



            foreach (String row in lista)
            {
                if (!FormPedido.PedidoP.findProductoListByNombre(row))
                    stringCol.Add(row);

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteCodigoProducto()
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();


            var lista = getLista.Listar("").Select(p => p.CodProd).ToList();

            foreach (String row in lista)
            {
                if (!FormPedido.PedidoP.findProductoListByCodigo(row))
                    stringCol.Add(row);

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteIdentificacion()
        {
            NProveedor getLista = new NProveedor();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TProveedor_TCiudad row in getLista.Listar(""))
            {

                stringCol.Add(Convert.ToString(row.Identificacion));

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteCliente(String tipo)
        {
            NPersona getLista = new NPersona();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (String row in getLista.Listar("").Where(p => (p.Nombre + " " + p.Apellido).Contains(tipo)).Select(c => c.Nombre + " " + c.Apellido))
            {

                stringCol.Add(row);

            }
            return stringCol;
        }

      











        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCliente.Text.Trim()))
            { pnlDetalle.Enabled = true;
            txtDescuento.ReadOnly = false;
            }
            else
            { pnlDetalle.Enabled = false;
            txtDescuento.ReadOnly = true;
            }
           
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void btnVer_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int Pedido_codigo = Convert.ToInt32(txtCodigo.Text);
            string reporteFile = "Presentacion.Reportes.ReportDetallePedidos.rdlc";

            Base.FormViewReporte report = new Base.FormViewReporte();
            report.rptView.LocalReport.DataSources.Clear();
            report.rptView.LocalReport.Dispose();




            report.rptView.Reset();
            report.rptView.ProcessingMode = ProcessingMode.Local;

            Datos.DataDetallePedidosTableAdapters.TPedido_ForeignTableAdapter ta
                  = new Datos.DataDetallePedidosTableAdapters.TPedido_ForeignTableAdapter();

            Datos.DataDetallePedidosTableAdapters.TDetalle_Pedido_ForeignTableAdapter dta
                = new Datos.DataDetallePedidosTableAdapters.TDetalle_Pedido_ForeignTableAdapter();


            Datos.DataDetallePedidos.TPedido_ForeignDataTable tabla = new Datos.DataDetallePedidos.TPedido_ForeignDataTable();

            Datos.DataDetallePedidos.TDetalle_Pedido_ForeignDataTable dtabla = new Datos.DataDetallePedidos.TDetalle_Pedido_ForeignDataTable();


            ta.FillByCodigo(tabla, Pedido_codigo);
            dta.FillByPedidoCod1(dtabla, Pedido_codigo);
            report.rptView.LocalReport.DataSources.Clear();
            report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataDetallePedido_Foreign",
           (DataTable)dtabla));
            report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataPedido",
             (DataTable)tabla));
            report.rptView.LocalReport.ReportEmbeddedResource = reporteFile;




            report.Text = "Detalle Pedidos";

            // report.rptView.Refresh();

            report.rptView.SetDisplayMode(DisplayMode.PrintLayout);
            report.rptView.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            report.rptView.ZoomPercent = 100;
            report.rptView.RefreshReport();

            report.ShowDialog();

        }

        private void cntInsertar_Click(object sender, EventArgs e)
        {
           dtLista.Rows.Add();
           dtLista.CurrentCell = dtLista.Rows[dtLista.Rows.Count - 1].Cells["CodProd"];

        }

        private void cntEliminar_Click(object sender, EventArgs e)
        {
            btnEliminar_Click(sender, e);
        }



        Producto.FormSeleccionProducto frm = new Producto.FormSeleccionProducto();

        private void cntBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                System.Threading.Thread.Sleep(50);
                dtLista.EndEdit();
            
                Presentacion.Producto.FormSeleccionProducto.Origen = "Pedido";
                if (dtLista.Rows.Count > 0)
                {
                    if (dtLista.CurrentCell.ColumnIndex == 2)
                    {
                        frm.txtBuscar.Text = dtLista.CurrentRow.Cells[2].Value + "";

                    }
                    if (dtLista.CurrentCell.ColumnIndex == 1)
                    {
                        frm.txtBuscar.Text = dtLista.CurrentRow.Cells[1].Value + "";

                    }
                    Presentacion.Producto.FormSeleccionProducto.Fila = dtLista.CurrentRow.Index;
                }
                else
                {
                    Presentacion.Producto.FormSeleccionProducto.Fila = -1;
                    frm.txtBuscar.Text = "";

                }


                frm.dtLista.Focus();

                frm.Show();

            }
            catch (System.ObjectDisposedException)
            {
                frm = new Producto.FormSeleccionProducto();

                System.Threading.Thread.Sleep(50);
                dtLista.EndEdit();
                frm.txtBuscar.Text = dtLista.CurrentRow.Cells[2].Value + "";
               Presentacion.Producto.FormSeleccionProducto.Origen = "Pedido";
                frm.dtLista.Focus();

                frm.Show();



            }
        }

        private void cntLimpiar_Click(object sender, EventArgs e)
        {
            if (dtLista.Rows.Count > 0)
            {
                if (!grabar)
                {
                    DialogResult dresult = (MessageBox.Show("Desea Eliminar todas las filas", "Limpiar Detalle", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2));
                    if (dresult == DialogResult.OK)
                    { this.dtLista.Rows.Clear(); }

                }
                else
                {

                    DialogResult dresult = (MessageBox.Show("Desea Eliminar todas las filas grabadas", "Limpiar Detalle", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2));
                    if (dresult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in dtLista.Rows)
                        {

                            addDetallePedido.Eliminar(Convert.ToInt32(txtCodigo.Text), (Int32)row.Cells[0].Value);
                        }
                    }



                }
            }
        }
        
        private void dtCodigoProd_TextChanged()
        {

            NProducto getProducto = new NProducto();
            Cursor.Current = Cursors.WaitCursor;
            if (dtLista.CurrentRow.Index > -1)
            {
                double precio = Convert.ToDouble(Parse(dtLista.CurrentRow.Cells["Precio"].Value + ""));
                string txt = dtLista.CurrentRow.Cells["CodProd"].Value + "";
                if (!(precio > 0.0) && !String.IsNullOrEmpty(txt))
                {



                    List<Datos.TProducto_Caracteristica_Foreign> tlist = getProducto.Listar(txt, "CodigoProd");



                    int r = dtLista.CurrentRow.Index;
                    int c = dtLista.CurrentCell.ColumnIndex;

                    // MessageBox.Show(tlist.Count+" }}");
                    //var t= getProducto.getDatos(12);

                    if (tlist.Count == 1)
                    {

                        fillDatosProducto(tlist[0], r);
                        //dtLista.EndEdit();

                        dtLista.CurrentCell = dtLista.Rows[r].Cells[c];


                    }
                    else
                    {
                        dtLista.Rows[r].Cells[0].Value = "";
                        dtLista.Rows[r].Cells["CodProd"].Value = "";
                        dtLista.Rows[r].Cells["Nombre"].Value = "";
                        dtLista.Rows[r].Cells["Precio"].Value = "0.0";
                        dtLista.Rows[r].Cells["Total"].Value = "0.0";
                        dtLista.Rows[r].Cells["IVA"].Value = "";

                    }

                }


            }
            Cursor.Current = Cursors.AppStarting;

            




        }
        
           private void dtNombre_TextChanged()
        {
           // dtLista.EndEdit();
            NProducto getProducto = new NProducto();
            Cursor.Current = Cursors.WaitCursor;
            if (dtLista.CurrentRow.Index > -1)
            {
                double precio = Convert.ToDouble(Parse(dtLista.CurrentRow.Cells["Precio"].Value + ""));
                string txt = dtLista.CurrentRow.Cells["Nombre"].Value + "";
                if (!(precio > 0.0) && !String.IsNullOrEmpty(txt) )
                {



                    List<Datos.TProducto_Caracteristica_Foreign> tlist = getProducto.Listar(txt, "Nombre");


                
                    int r = dtLista.CurrentRow.Index;
                    int c = dtLista.CurrentCell.ColumnIndex;

                    // MessageBox.Show(tlist.Count+" }}");
                    //var t= getProducto.getDatos(12);

                    if (tlist.Count==1)
                    {
                        
                        fillDatosProducto(tlist[0], r);
                        //dtLista.EndEdit();

                        dtLista.CurrentCell = dtLista.Rows[r].Cells[c];
                        

                   }
                    else
                    {
                        dtLista.Rows[r].Cells[0].Value = "";
                        dtLista.Rows[r].Cells["CodProd"].Value = "";
                        dtLista.Rows[r].Cells["Nombre"].Value = "";
                        dtLista.Rows[r].Cells["Precio"].Value = "0.0";
                        dtLista.Rows[r].Cells["Total"].Value = "0.0";
                        dtLista.Rows[r].Cells["IVA"].Value = "";
                       
                    }

                }


            }
            Cursor.Current = Cursors.AppStarting;


        }
            

        private void dtLista_KeyDown(object sender, KeyEventArgs e)
        {


            int cn = 0;
            if (dtLista.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dtLista.Rows)
                {
                    if (String.IsNullOrEmpty(row.Cells[0].Value + ""))
                        cn += 1;

                }
            }

            if (e.KeyData.ToString().Equals("Insert") && cn < 2)
            {


                dtLista.Rows.Add();
                dtLista.CurrentCell = dtLista.Rows[dtLista.Rows.Count - 1].Cells["CodProd"];
            }

            if (e.KeyData.ToString().Equals("Delete") && dtLista.Rows.Count > 0)
            {
                btnEliminar_Click(sender, e);
            }



        }
        private void dtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar) || e.KeyChar == '-')
            {
                e.Handled = false;

            }


            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;
            TextBox txt = (TextBox)sender;

            if (e.KeyChar == ' ')
                e.Handled = true;

            if (e.KeyChar == '-' && txt.Text[0] == '-')
                e.Handled = true;

            if (e.KeyChar == '-'
                   && txt.Text.IndexOf('-') > -1)
            {
                //System.Windows.Forms.MessageBox.Show("" + this.Text.IndexOf('.')+"--"+this.Text.Length);
                e.Handled = true;

            }

            if (txt.Text.Length > 15)
                e.Handled = true;





        }
        private void dtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
                e.KeyChar -= (char)32;


        }
     
       

        public double Parse(string input)
        {
            if (String.IsNullOrEmpty(input))
                return 0.0;
            return double.Parse(System.Text.RegularExpressions.Regex.Replace(input, @"[^\d.]", ""));
        }

        private void dtLista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int column = e.ColumnIndex;
            if(column==2 || column==1)
            if (!f2)
            {

                if (column == 2)
                {
                    // dtLista.NotifyCurrentCellDirty(true);
                    //dtLista.EndEdit();


                    this.dtNombre_TextChanged();
                    //dtLista.NotifyCurrentCellDirty(false);


                }

                if (column == 1)
                {
                    // dtLista.NotifyCurrentCellDirty(true);
                    //dtLista.EndEdit();

                    dtCodigoProd_TextChanged();
                    //dtLista.NotifyCurrentCellDirty(false);

                }

            }
        }

        

        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyData == Keys.Enter)
                {
                    Datos.TProveedor_TCiudad item = getProv.getDatosCodProd(txtIdentificacion.Text);
                    string tprove = item.Nombre;
                    if (!String.IsNullOrEmpty(tprove))
                    {
                        // MessageBox.Show(tprove + "");
                        txtCliente.Text = tprove;
                        epedido.Prov_codigo = item.Codigo;
                        dtLista.Focus();

                    }
                    else
                    {
                        txtCliente.Text = "";

                    }
                }

            }catch
            {

                MessageBox.Show("Error, Identificacion de Proveedor Incorrecto ", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Text = "";
            }

        }

    }


}
