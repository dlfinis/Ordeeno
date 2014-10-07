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

namespace Presentacion.Venta
{
    public partial class FormVenta : Base.FormFactura
    {

        NVenta addVenta = new NVenta();
        NPersona getPersona = new NPersona();
        public EVenta eventa = new EVenta();
        public EDetalleVenta edventa = new EDetalleVenta();
        NDetalleVenta addDetalleVenta = new NDetalleVenta();

       public  bool grabar = false;
        #region conexion



        private static FormVenta ventap;

        public static FormVenta VentaP
        {
            get { return FormVenta.ventap; }
            set { FormVenta.ventap = value; }
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
       
        public void fillDatos(int codPer)
        {
            try
            {
                var t = this.getPersona.getDatos(codPer);
                if (codPer > 0)
                {

                    this.txtCliente.Text = t.Nombre + " " + t.Apellido;

                    // MessageBox.Show(t.Nombre + " " + t.Apellido);
                    this.txtIdentificacion.Text = t.Identificacion;
                    eventa.Per_codigo = codPer;
                    // MessageBox.Show(eventa.Per_codigo + "");

                }
                else
                {

                    MessageBox.Show("Seleccione un cliente");
                }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        NProducto getProducto = new NProducto();


        public bool findProductoList(int procod)
        {
            //bool existencia = false;
            
            foreach (DataGridViewRow rowD in dtLista.Rows)
            {

                if ((rowD.Cells[0].Value+"").Equals(procod))
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

                List<Datos.TDetalle_Venta_Producto> lprod = addDetalleVenta.ListarP(Convert.ToInt32(txtCodigo.Text));

                if (lprod.Count > 0)
                {


                    foreach (Datos.TDetalle_Venta_Producto row in lprod)
                    {


                        dtLista.Rows.Add(
                            row.Codigo,
                            row.CodProd,
                            row.Producto,
                            row.Venta,
                            ((row.IVA.Equals('S') ? (row.Venta + (row.Venta * getProducto.getIVA_Valor())) : 0)),
                            row.Cantidad,
                            0.0,
                            0.0,
                            row.Total,
                            row.IVA);



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

                        if (!findProductoList(Convert.ToInt32(row.Cells[0].Value)))
                        {
                            dtLista.Rows.Add(
                                row.Cells[0].Value,
                                row.Cells["CodProd"].Value,
                                row.Cells["Nombre"].Value,
                                row.Cells["Venta"].Value,
                                (Parse(row.Cells["Venta"].Value + "") + (Parse(row.Cells["Venta"].Value + "") * getProducto.getIVA_Valor())),
                                0,
                                0.0,
                                0.0,
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



        public void fillDatosProducto(DataGridViewRow data,int fila)
        {

            try
            {

                dtLista.Rows[fila].Cells[0].Value = data.Cells[0].Value;
                dtLista.Rows[fila].Cells["CodProd"].Value=data.Cells["CodProd"].Value;
                dtLista.Rows[fila].Cells["Nombre"].Value=data.Cells["Nombre"].Value;
                dtLista.Rows[fila].Cells["Venta"].Value=data.Cells["Venta"].Value;
                dtLista.Rows[fila].Cells["VentaIVA"].Value = (Parse(data.Cells["Venta"].Value + "") + (Parse(data.Cells["Venta"].Value + "") * getProducto.getIVA_Valor()));
                dtLista.Rows[fila].Cells["IVA"].Value=data.Cells["IVA"].Value;
                f2 = false;
                //
               
                //dtLista.EndEdit();
                
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message,"Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void fillDatosProducto(Datos.TProducto_Caracteristica_Foreign data, int fila)
        {

            try
            {

                dtLista.Rows[fila].Cells[0].Value = data.Codigo;
                dtLista.Rows[fila].Cells["CodProd"].Value = data.CodProd;
                dtLista.Rows[fila].Cells["Nombre"].Value = data.Nombre;
                dtLista.Rows[fila].Cells["Venta"].Value = data.Venta;
                dtLista.Rows[fila].Cells["VentaIVA"].Value = data.IVA.Equals('S') ? data.VentaConIVA:0;
                //(Parse(data.Venta+"") + (Parse(data.Venta+"") * getProducto.getIVA_Valor()));
                dtLista.Rows[fila].Cells["IVA"].Value = data.IVA;


            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message,"Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void fillDatosProducto(DataGridViewRow data)
        {

            try
            {
                dtLista.Rows.Add(
                data.Cells[0].Value,
                data.Cells["CodProd"].Value,
                 data.Cells["Nombre"].Value,
                data.Cells["Venta"].Value,
                data.Cells["IVA"].Value.Equals("S") ?(Parse(data.Cells["Venta"].Value + "") + (Parse(data.Cells["Venta"].Value + "") * getProducto.getIVA_Valor())):0,
               
                0.0,
                0,
                0.0,
                0.0,
                data.Cells["IVA"].Value
                );

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        Producto.FormSeleccionProducto frm_producto = new Producto.FormSeleccionProducto();

        bool f2 = false;
        private void teclaBusqueda_KeyDown(object sender, KeyEventArgs e)
        {


            if (dtLista.Rows.Count>0)
            {
                // MessageBox.Show(e.KeyData+"=="+e.KeyValue);
                int column = dtLista.CurrentCell.ColumnIndex;
                int row = dtLista.CurrentCell.RowIndex;

                if (e.KeyData.ToString().Equals("F2"))
                {
                    f2 = true;
                    if (column <3)
                    {

                        try
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            dtLista.EndEdit();
                            frm_producto.txtBuscar.Text = "" + dtLista.CurrentCell.Value;
                            frm.Lista();
                            Producto.FormSeleccionProducto.Origen = "Venta";
                            Producto.FormSeleccionProducto.Fila = row;
                            this.Enabled = false;
                            Cursor.Current = Cursors.AppStarting;
                            frm_producto.Show();
                            frm_producto.dtLista.Focus();
                            

                        }

                        catch (System.ObjectDisposedException)
                        {
                            dtLista.EndEdit();
                            frm_producto = new Producto.FormSeleccionProducto();
                           // dtLista.EndEdit();
                            frm_producto.txtBuscar.Text = "" + dtLista.CurrentCell.Value;
                            frm.Lista();
                            Producto.FormSeleccionProducto.Origen = "Venta";
                            this.Enabled = false;
                            frm_producto.Show();
                            //dtLista.EndEdit();
                            frm_producto.dtLista.Focus();
                        }
                    }

                   
                     }

                if (e.KeyData.ToString().Equals("F1"))
                {
                    if (column ==2)
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

            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 6)
            {
                NumeroDecimal = true;

                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);

            }
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex)==2)
            {
                
                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtNombre_KeyPress);
                tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.teclaBusqueda_KeyDown);

                if (tb != null)
                {
                    
                    tb.AutoCompleteCustomSource = FormVenta.LoadAutoCompleteProducto();
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
                     
                     tb.AutoCompleteCustomSource = FormVenta.LoadAutoCompleteCodigoProducto();
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
            double desc = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);
            double vdesc = 0.0;

            double total = 0.0;
            vdesc = Math.Round(((subt0 + subt12 + tiva) * desc), 2);

            txtVDescuento.Text = String.Format("{0:C2}", vdesc);

            total = Math.Round(((subt0 + subt12 + tiva) - vdesc), 2);

            txtTotal.Text = String.Format("{0:C2}",total);
           // MessageBox.Show(vdesc +"\n"+total );
        }

       
            //txtSub0.Text = String.Format("{0:C2}", "0");
            //txtSub12.Text = String.Format("{0:C2}", "0");
            //txtTotal.Text = String.Format("{0:C2}", "0");
            //txtIVA.Text = String.Format("{0:C2}", "0");
            //txtVDescuento.Text = String.Format("{0:C2}", "0");
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
                    double desc = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);

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

                        //txtTotal.Text = String.Format("{0:C2}", total);
                        calcularDescuento();
                    }
                }

            }
            #endregion


        }

      
        private void dtLista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
                int cantidad = 0;
                double descuento = 0.0;
                double aumento = 0.0;
                double precio = 0.0;
                //MessageBox.Show(""+f3);
                if (dtLista.Rows.Count > 0
                    && !String.IsNullOrEmpty(dtLista.Rows[e.RowIndex].Cells[0].Value + "")
                    && !String.IsNullOrEmpty(dtLista.Rows[e.RowIndex].Cells[1].Value + "")
                   && ((dtLista.Columns[e.ColumnIndex].Name.Equals("Cantidad") || (dtLista.Columns[e.ColumnIndex].Name.Equals("Aumento") || dtLista.Columns[e.ColumnIndex].Name.Equals("Descuento")))))
                {


                    var tmpcant = dtLista.Rows[e.RowIndex].Cells["Cantidad"].Value + "";
                    var tmpaumento = dtLista.Rows[e.RowIndex].Cells["Aumento"].Value + "";
                    var tmpdescuento = dtLista.Rows[e.RowIndex].Cells["Descuento"].Value + "";

                    precio = Convert.ToDouble(Parse(dtLista.Rows[e.RowIndex].Cells["Venta"].Value + ""));
                    cantidad = Convert.ToInt32(String.IsNullOrEmpty(tmpcant) ? "0" : tmpcant.ToString());
                    aumento = Convert.ToDouble(String.IsNullOrEmpty(tmpaumento) ? "0" : tmpaumento.ToString());
                    descuento = Convert.ToDouble(String.IsNullOrEmpty(tmpdescuento) ? "0" : tmpdescuento.ToString());

                    if (cantidad < 1 && (aumento > 0 || descuento > 0))
                       dtLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0.0";
                   
                    if (precio > 0 && cantidad > 0)
                    {
                        int stock = (int)getProducto.getDatos(Convert.ToInt32(dtLista.Rows[e.RowIndex].Cells[0].Value)).Stock;

                        try
                        {
                           // double vaumento = Convert.ToDouble((new NConfiguracion().getDatos("AUMENTO").conf_valor));
                            if (!(descuento >= 0 && descuento <= vdescuento))
                            {
                                MessageBox.Show("Esta excediendo los limites\n Entre 0.0 y " + vdescuento, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dtLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0.0";
                                return;
                            }

                            //if (!(aumento >= 0 && aumento <= vaumento))
                            //{
                            //    MessageBox.Show("Esta excediendo los limites\n Entre 0.0 y " + vaumento, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    dtLista.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0.0";
                            //    return;
                            //}


                            if (rdbFactura.Checked)
                            {
                                if ((cantidad > stock))
                                {

                                    MessageBox.Show("Ingrese un numero adecuado en cantidad\n Stock Actual del producto a: " + stock, "Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dtLista.Rows[e.RowIndex].Cells["Cantidad"].Value = "0";

                                    return;
                                }
                                else
                                {

                                    Cursor.Current = Cursors.WaitCursor;
                                    // MessageBox.Show((precio * descuento) + "");
                                    dtLista.Rows[e.RowIndex].Cells["Total"].Value =
                                       Math.Round((((precio * cantidad) - ((precio * cantidad) * descuento)) + ((precio * cantidad) * aumento)), 2);
                                    calcularTotal();

                                }
                            }
                            else
                            {

                                Cursor.Current = Cursors.WaitCursor;
                                dtLista.Rows[e.RowIndex].Cells["Total"].Value =
                                        Math.Round((((precio * cantidad) - ((precio * cantidad) * descuento)) + ((precio * cantidad) * aumento)), 2);
                                calcularTotal();

                            }






                        }
                        catch (Exception ex)
                        {

                            Datos.Excepciones.Gestionar(ex);
                            MessageBox.Show("No se pudieron modificar los datos\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //MessageBox.Show((precio * cantidad) - (precio * descuento) + "");

                    }
                }

                Cursor.Current = Cursors.AppStarting;

           
        }

        #endregion 


        public FormVenta()
        {
            InitializeComponent();
            //dateTimePicker1.Value = DateTime.Now;

          
        }

        private void btnPSeleccion_Click(object sender, EventArgs e)
        {
            FormDataPersonas frm = new FormDataPersonas();
            FormDataPersonas.GridSeleccion = true;
           
            FormDataPersonas.Origen = "Venta";
            this.pnlDetalle.Enabled = true;
            frm.Opacity = 80;
            frm.ShowDialog();
           
           //btnPSeleccion.Enabled = false;
        
        
        }

        NPersona getCliente = new NPersona();

        public DateTime date;
        private void FormVenta_Load(object sender, EventArgs e)
        {
            VentaP = this;

             eventa.Ven_estado='N';

       

            txtIdentificacion.AutoCompleteCustomSource = FormVenta.LoadAutoCompleteIdentificacion();
            txtIdentificacion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtIdentificacion.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;

            toolTip1.SetToolTip(txtDescuento, "Ingrese entre 0.0 y limite del Sistema <= "+vdescuento);

            FormMDI.usuarioValido(dtLista,"Aumento",60);
            FormMDI.usuarioValido(dateTimePicker1);

            dateTimePicker1.Value = date;

            
        }

        private void rdbCotizacion_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCotizacion.Checked)
            {
                rdbFactura.Checked = false;
                eventa.Ven_estado = 'N';


            }

           }

        private void rdbFactura_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFactura.Checked)
            {
                rdbCotizacion.Checked = false;
                eventa.Ven_estado = 'S';


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
                        DialogResult dresult = (MessageBox.Show("Desea Eliminar el producto de la factura", "Borrar Producto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2));
                        if (dresult == DialogResult.OK)
                        {
                            //MessageBox.Show(Convert.ToInt32(txtCodigo.Text) + "--" + (Int32)dtLista.Rows[dtLista.CurrentRow.Index].Cells[0].Value + "");
                            try
                            {
                                addDetalleVenta.Eliminar(Convert.ToInt32(txtCodigo.Text), (Int32)dtLista.Rows[dtLista.CurrentRow.Index].Cells[0].Value);


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
                DialogResult dresult = (MessageBox.Show("Desea almacenar esta Factura-Venta?",
                       "Grabar Factura-Venta",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {


                    if (dtLista.Rows.Count > 0 )
                    {
                        dtLista.EndEdit();
                        int cn = 0;
                        int stock = 0;
                        
                        int ccan = 0;
                        foreach (DataGridViewRow row in dtLista.Rows)
                        {

                            if (!String.IsNullOrEmpty(row.Cells[0].Value + ""))
                            {
                                stock = (int)getProducto.getDatos(Convert.ToInt32((row.Cells[0].Value + ""))).Stock;

                                if (Convert.ToDouble(Parse(row.Cells["Total"].Value + "")) > 0.0)
                                {
                                    cn += 1;
                                }
                                if (Convert.ToInt32(Parse(row.Cells["Cantidad"].Value + "")) > stock)
                                {
                                    ccan += 1;
                                }
                            }
                            else

                            {
                                cn = -1;
                            }
                        
                        
                        }

                        //MessageBox.Show("Producto "+cn +"--CANN"+ccan+"\nContar"+dtLista.Rows.Count);
                       
                        if (rdbFactura.Checked && (ccan > 0))
                        {
                        MessageBox.Show("Tienes cantidades sobre el nivel actual de stock,respectivamente","Atencion..!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                return;
                        }
                        else
                           if (cn != dtLista.Rows.Count  )
                        {

                            MessageBox.Show("No todos los productos estan calculados o definidos", "Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            
                        }
                        else
                        {
                            //MessageBox.Show("Entro");
                            try
                            {
                                try
                                {
                                    eventa.Ven_estado = rdbFactura.Checked ? 'S' : 'N';

                                    eventa.Ven_descuento = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);
                                    eventa.Ven_date = dateTimePicker1.Value.Date;
                                    txtCodigo.Text = addVenta.Insertar(eventa) + "";
                                }
                                catch (Exception ex)
                                {
                                    Datos.Excepciones.Gestionar(ex);
                                    MessageBox.Show("Error al Ingreso de la Venta-Cabecera\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                               
                               // btnGrabarDetalle.Enabled = false;

                                
                                foreach (DataGridViewRow row in dtLista.Rows)
                                {
                                    edventa.Ven_codigo = Convert.ToInt32(txtCodigo.Text);
                                    edventa.Prod_codigo = Convert.ToInt32(row.Cells[0].Value);
                                    edventa.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                                    edventa.Dven_precio = Parse(row.Cells["Venta"].Value+"");

                                    if ((Convert.ToDouble(row.Cells["Aumento"].Value)) > 0 || (Convert.ToDouble(row.Cells["Descuento"].Value) > 0))
                                    {

                                        edventa.Dven_aumento = Convert.ToDouble(row.Cells["Aumento"].Value);
                                        edventa.Dven_descuento = Convert.ToDouble(row.Cells["Descuento"].Value);

                                    }

                                    addDetalleVenta.Insertar(edventa);
                                   
                                }
                                grabar = true;

                                btnNuevo.Text = "Editar";
                                btnVer.Enabled = true;

                                MessageBox.Show("Registro insertado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                Datos.Excepciones.Gestionar(ex);
                                MessageBox.Show("Error al Ingreso " + ex.Message);
                                return;
                            }

                          
                        }
                        //MessageBox.Show("" + cn + "---" + dtLista.Rows.Count);
                       
                    }
                    else
                    {
                       
                    }
                }
                #endregion

                grabar = true;
                FormMDI.usuarioValido(btnNuevo);    
            }
            else
            {
                #region previo
                DialogResult dresult = (MessageBox.Show("Desea actualizar esta Factura-Venta?",
                       "Actualizar Factura -Venta ",
                                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.Yes)
                {


                    if (dtLista.Rows.Count > 0)
                    {
                        dtLista.EndEdit();
                        int cn = 0;
                        int stock = 0;

                        int ccan = 0;
                        foreach (DataGridViewRow row in dtLista.Rows)
                        {

                            if (!String.IsNullOrEmpty(row.Cells[0].Value + ""))
                            {
                                stock = (int)getProducto.getDatos(Convert.ToInt32((row.Cells[0].Value + ""))).Stock;

                                if (Convert.ToDouble(Parse(row.Cells["Total"].Value + "")) > 0.0)
                                {
                                    cn += 1;
                                }
                                if (Convert.ToInt32(Parse(row.Cells["Cantidad"].Value + "")) > stock)
                                {
                                    ccan += 1;
                                }
                            }
                            else
                            {
                                cn = -1;
                            }


                        }

                       //MessageBox.Show("ProductoEdit "+cn +"--CANN"+ccan+"\nContar"+dtLista.Rows.Count);
                       if (rdbFactura.Checked && (ccan > 0))
                       {
                           MessageBox.Show("Tienes cantidades sobre el nivel actual de stock,respectivamente", "Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                           return;
                       }
                       else
                         if (cn != dtLista.Rows.Count)
                           {

                               MessageBox.Show("No todos los productos estan calculados o definidos", "Atencion ..!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                               return;


                           }
                        else
                        {
                           // MessageBox.Show("EntroEdit");
                            
                            try
                            {

                                try
                                {
                                    eventa.Ven_codigo = int.Parse(txtCodigo.Text);
                                    eventa.Ven_estado = rdbFactura.Checked ? 'S' : 'N';
                                     eventa.Ven_descuento = Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text);
                                     eventa.Ven_date = dateTimePicker1.Value.Date;
                                     
                                    addVenta.Editar(eventa);
                                }
                                catch (Exception ex)
                                {
                                    Datos.Excepciones.Gestionar(ex);
                                    MessageBox.Show("Error al Actualizar de la Venta-Cabecera\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                               
                                edventa.Ven_codigo = eventa.Ven_codigo;
                                foreach (DataGridViewRow row in dtLista.Rows)
                                {
                                
                                    edventa.Prod_codigo = Convert.ToInt32(row.Cells[0].Value);
                                    edventa.Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                                    edventa.Dven_precio =Parse(row.Cells["Venta"].Value+"");
                                    
                                        edventa.Dven_aumento = Convert.ToDouble(row.Cells["Aumento"].Value);
                                        edventa.Dven_descuento = Convert.ToDouble(row.Cells["Descuento"].Value);




                                        addDetalleVenta.Editar(edventa);

                                   

                                }
                                MessageBox.Show("Registro actualizado completo", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnVer.Enabled = true;
                                grabar = true;
                            }
                            catch (Exception ex)
                            {
                                Datos.Excepciones.Gestionar(ex);
                                MessageBox.Show("Error al Actualizar " + ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                         






                        }
                        //MessageBox.Show("" + cn + "---" + dtLista.Rows.Count);
                    }
                    else
                    {
                        MessageBox.Show("Registro actualizado completo \n No existen Campos", "Actualizacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            

                    }
                }
                #endregion

            }
            Cursor.Current = Cursors.AppStarting;
        }

        private void chkDescuento_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDescuento.Checked == true)
            {
                txtDescuento.Enabled = true;

                if (!String.IsNullOrEmpty(txtDescuento.Text.Trim()))
                {

                    if (Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text) < 1)
                    {
                        double tiva =Parse(txtIVA.Text);
                        double subt0 = Parse(txtSub0.Text);
                        double subt12 = Parse(txtSub12.Text);
                        double desc = Convert.ToDouble(txtDescuento.Text);
                        double vdesc = 0.0;

                        double total = 0.0;
                        vdesc = Math.Round(((subt0 + subt12 + tiva) * desc),2);

                        txtVDescuento.Text = String.Format("{0:C2}", vdesc);

                        total = Math.Round(((subt0 + subt12 + tiva) - vdesc) ,2);

                        txtTotal.Text = String.Format("{0:C2}", total);
                    }
                    else
                    {
                       
                        txtDescuento.Text = "0.0";
                    }

                }
            }
            else
            {
                txtDescuento.Enabled = false;
                txtDescuento.Text = "0.0";
               
            }



        }
        double vdescuento = Convert.ToDouble((new NConfiguracion().getDatos("DESCUENTO").conf_valor));
          
        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
             if (!String.IsNullOrEmpty(txtDescuento.Text.Trim()))
            {

                if (Convert.ToDouble(String.IsNullOrEmpty(txtDescuento.Text) ? "0" : txtDescuento.Text) <= vdescuento)
                {
                    double tiva = Parse(txtIVA.Text);
                    double subt0 = Parse(txtSub0.Text);
                    double subt12 = Parse(txtSub12.Text);
                    double desc = Parse(txtDescuento.Text);
                    double vdesc = 0.0;

                    double total = 0.0;
                    vdesc = Math.Round((((subt0 + subt12 + tiva) * desc)) ,2);
                    
                    txtVDescuento.Text = "" + vdesc;

                    total = Math.Round(((subt0 + subt12 + tiva) - vdesc),2);

                    txtTotal.Text =String.Format("{0:C2}",total);
                }
                else
                {
                    txtDescuento.Text = "0.0";
                    MessageBox.Show("No es posible ese Descuento limite del Sistema  es <= " + vdescuento,"Atencion ...!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
                }
              
            }



        }



        public static AutoCompleteStringCollection LoadAutoCompleteIdentificacion()
        {
            NPersona getLista = new NPersona();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TPersona_TCiudad row in getLista.Listar(""))
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
            { pnlDetalle.Enabled = true; }
            else
            { pnlDetalle.Enabled = false; }
        }

        

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnVer_Click(object sender, EventArgs e)
        {
            int Venta_codigo = Convert.ToInt32(txtCodigo.Text);
            string reporteFile = "Presentacion.Reportes.ReportDetalleVentas.rdlc";

            Cursor.Current = Cursors.WaitCursor;
           

            Base.FormViewReporte report = new Base.FormViewReporte();
            report.rptView.LocalReport.DataSources.Clear();
            report.rptView.LocalReport.Dispose();




            report.rptView.Reset();
            report.rptView.ProcessingMode = ProcessingMode.Local;

            Datos.DataDetalleVentasTableAdapters.TVenta_ForeignTableAdapter ta
                  = new Datos.DataDetalleVentasTableAdapters.TVenta_ForeignTableAdapter();

            Datos.DataDetalleVentasTableAdapters.TDetalle_Venta_ForeignTableAdapter dta
                = new Datos.DataDetalleVentasTableAdapters.TDetalle_Venta_ForeignTableAdapter();


            Datos.DataDetalleVentas.TVenta_ForeignDataTable tabla = new Datos.DataDetalleVentas.TVenta_ForeignDataTable();

            Datos.DataDetalleVentas.TDetalle_Venta_ForeignDataTable dtabla = new Datos.DataDetalleVentas.TDetalle_Venta_ForeignDataTable();


            ta.FillByCodigo(tabla, Venta_codigo);
            dta.FillByVentaCod1(dtabla, Venta_codigo);
            report.rptView.LocalReport.DataSources.Clear();
            report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataDetalleVenta_Foreign",
           (DataTable)dtabla));
            report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataVenta",
             (DataTable)tabla));
            report.rptView.LocalReport.ReportEmbeddedResource = reporteFile;




            report.Text = "Detalle Ventas";

            // report.rptView.Refresh();

            report.rptView.SetDisplayMode(DisplayMode.PrintLayout);
            report.rptView.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            report.rptView.ZoomPercent = 100;
            report.rptView.RefreshReport();
         
            report.ShowDialog();
            Cursor.Current = Cursors.AppStarting;
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

                Producto.FormSeleccionProducto.Origen = "Venta";
                if (dtLista.Rows.Count > 0)
                {
                    if (dtLista.CurrentCell.ColumnIndex == 2)
                    {
                        frm.txtBuscar.Text = dtLista.CurrentRow.Cells["Nombre"].Value + "";
                        frm.Lista();
                     
                    }
                    if (dtLista.CurrentCell.ColumnIndex == 1)
                    {
                        frm.txtBuscar.Text = dtLista.CurrentRow.Cells["CodProd"].Value + "";
                        frm.Lista();

                    }
                    Producto.FormSeleccionProducto.Fila = dtLista.CurrentRow.Index;
                }
                else
                {
                    Producto.FormSeleccionProducto.Fila = -1;
                    frm.txtBuscar.Text = "";

                }

                   
                frm.dtLista.Focus();

                frm.Show();

            }
            catch (System.ObjectDisposedException)
            {
                frm = new Producto.FormSeleccionProducto();

                //System.Threading.Thread.Sleep(50);
                //dtLista.EndEdit();
                frm.txtBuscar.Text = dtLista.CurrentRow.Cells["Nombre"].Value + "";
                frm.Lista();
                Producto.FormSeleccionProducto.Origen = "Venta";
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

                            addDetalleVenta.Eliminar(Convert.ToInt32(txtCodigo.Text), (Int32)row.Cells[0].Value);
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
                double precio = Convert.ToDouble(Parse(dtLista.CurrentRow.Cells["Venta"].Value + ""));
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
                        dtLista.Rows[r].Cells["Venta"].Value = "0.0";
                        dtLista.Rows[r].Cells["Aumento"].Value = "0.0";
                        dtLista.Rows[r].Cells["Descuento"].Value = "0.0";
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
                double precio = Convert.ToDouble(Parse(dtLista.CurrentRow.Cells["Venta"].Value + ""));
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
                        dtLista.Rows[r].Cells["Venta"].Value = "0.0";
                        dtLista.Rows[r].Cells["Aumento"].Value = "0.0";
                        dtLista.Rows[r].Cells["Descuento"].Value = "0.0";
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
        public bool findProductoListByCodigo(string codigo)
        {
            //bool existencia = false;


            //Convert.ToInt32((rowD.Cells[0].Value)) == procod)
           
                foreach (DataGridViewRow rowD in dtLista.Rows)
                {

                    if ((rowD.Cells["CodProd"].Value+"").Equals(codigo+""))
                    {
                        return true;
                    }

                }
            


            return false;


        }
        public static AutoCompleteStringCollection LoadAutoCompleteCodigoProducto()
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();


            var lista = getLista.Listar("").Select(p => p.CodProd).ToList();

            foreach (String row in lista)
            {
               if(!FormVenta.VentaP.findProductoListByCodigo(row)) 
                  stringCol.Add(row);

            }
            return stringCol;
        }

        public bool findProductoListByNombre(string nombre)
        {
            
                foreach (DataGridViewRow rowD in dtLista.Rows)
                {

                    if ((rowD.Cells["Nombre"].Value+"").Equals(nombre))
                    {
                        return true;
                    }

                }

            
            return false;

        }
        public static AutoCompleteStringCollection LoadAutoCompleteProducto()
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();


            var lista = getLista.Listar("").Select(p => p.Nombre).ToList();

            

            foreach (String row in lista)
            {
                if(!FormVenta.VentaP.findProductoListByNombre(row))
                   stringCol.Add(row);

            }
            return stringCol;
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
                    Datos.TPersona_TCiudad item = getCliente.getDatosCodProd(txtIdentificacion.Text);
                    string tprove = item.Nombre + " " + item.Apellido;
                    if (!String.IsNullOrEmpty(tprove))
                    {
                        // MessageBox.Show(tprove + "");
                        txtCliente.Text = tprove;

                        eventa.Per_codigo = item.Codigo;
                       
                        dtLista.Focus();

                    }
                    else
                    {
                        txtCliente.Text = "";

                    }
                }

                //if (e.KeyData == Keys.F2)
                //{


                //    FormDataPersonas frm = new FormDataPersonas();
                //    FormDataPersonas.GridSeleccion = true;
                //    frm.txtBuscar.Text = txtIdentificacion.Text;
                //    frm.dtLista.Focus();
                //    frm.ShowDialog();
                //    dtLista.Enabled = true;


                //}
            }
            catch
            {
                MessageBox.Show("Error, Identificacion de Cliente Incorrecta ", "Cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCliente.Text = "";
            }

        
        }
    }

  
}
