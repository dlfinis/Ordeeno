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

namespace Presentacion.Venta
{
    public partial class FormConsulta : Negocios.Base.FormBase
    {
        #region conexion


        
        private static FormConsulta consulta;

        public static FormConsulta Consulta
        {
            get { return FormConsulta.consulta; }
            set { FormConsulta.consulta = value; }
        }
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormConsulta.dtSeleccion; }
            set { FormConsulta.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormConsulta.gridSeleccion; }
            set { FormConsulta.gridSeleccion = value; }
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


        NProducto getProducto = new NProducto();

        public void fillDatos(int codProd)
        {
            try
            {
                var t = this.getProducto.getDatosCar(codProd);
                //MessageBox.Show(codProd + "--"+ t.CodDcar+"\n"+t.Nombre);
                if (codProd > 0)
                {

                    this.txtNombre.Text = t.Nombre;
                    dtNombre.Rows[0].Cells["CodProd"].Value = t.CodProd;
                    dtNombre.Rows[0].Cells["Marca"].Value = t.Marca;
                    dtNombre.Rows[0].Cells["Descripcion"].Value = t.Descripcion;
                    dtNombre.Rows[0].Cells["Categoria"].Value = t.Categoria;
                    //this.txtColor.Text = t.Color;
                    dtNombre.Rows[0].Cells["Unidad"].Value = t.Unidad;
                    // this.txtDimension.Text = t.Dimension;


                    dtAlmacen.Rows[0].Cells["Stock"].Value = "" + t.Stock;
                    dtAlmacen.Rows[0].Cells["StockMin"].Value = "" + t.StockMin;

                    dtAlmacen.Rows[0].Cells["PrecioCompra"].Value = "" + t.Compra;
                    dtAlmacen.Rows[0].Cells["PrecioVenta"].Value = "" + t.Venta;
                    dtAlmacen.Rows[0].Cells["PrecioVentaIVA"].Value = "" + (t.Venta + (t.Venta * getProducto.getIVA_Valor()));
                    dtAlmacen.Rows[0].Cells["ValorIVA"].Value = t.IVA == 'S' ? true : false;

                    dtConsulta.Rows[0].Cells[0].Value = t.Venta;

                    fillCaracteristica((int)t.CodDcar, (int)t.Codigo);
                    //panelEx2.Visible = true;
                    panelEx3.Enabled = true;
                    dtConsulta.EndEdit();
                    dtConsulta.Focus();
                    dtConsulta.CurrentCell = dtConsulta.Rows[0].Cells[1];
                    dtConsulta.BeginEdit(true);
                }
                else
                {

                    MessageBox.Show("Seleccione");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void fillCaracteristica(int dcarcodigo, int codprod)
        {
            try{

            NDetalleCaracteristica ndprodcar = new NDetalleCaracteristica();
            dtCaracteristicaR.Rows.Clear();
           
            // MessageBox.Show(codigo + "=+++=" +codprod);
            List<Datos.TDetalleProducto_Caracteristica> dt = ndprodcar.Listar(dcarcodigo, codprod);

            // MessageBox.Show(dt.Count + "");
            foreach (Datos.TDetalleProducto_Caracteristica row in dt)
            {
                //  MessageBox.Show(row.Tipo + "==" + row.Valor);
                dtCaracteristicaR.Rows.Add(
                    row.Tipo, row.Valor
                    );
                
            }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void dtConsulta_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) != 1)
            {
                NumeroDecimal = true;

                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);

            }
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 1)
            {
                NumeroDecimal = false;
               
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);

            }



        }
        public double Parse(string input)
        {
            if (String.IsNullOrEmpty(input))
                return 0.0;
            return double.Parse(System.Text.RegularExpressions.Regex.Replace(input, @"[^\d.]", ""));
        }

        bool mstock = false;
        private void dtConsulta_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int cantidad = 0;
            double descuento = 0.0;
            double precio = 0.0;
            double tiva = 0.0;
            int stock=0;
            if (dtConsulta.Rows.Count > 0)
            {
                try
                {
                    precio = Parse(dtConsulta.Rows[0].Cells[0].Value+"");
                    cantidad = Convert.ToInt32(dtConsulta.Rows[0].Cells[1].Value);
                    descuento = Convert.ToDouble(dtConsulta.Rows[0].Cells[2].Value);
                    stock = Convert.ToInt32(dtAlmacen.Rows[0].Cells["Stock"].Value+"");
                   // MessageBox.Show(dtAlmacen.Rows[0].Cells["ValorIVA"].Value.ToString());
                    if (dtAlmacen.Rows[0].Cells["ValorIVA"].Value.ToString().Equals("True"))
                    {
                        tiva =( ((precio * cantidad)-descuento) * getProducto.getIVA_Valor());
                        dtConsulta.Rows[0].Cells[3].Value = tiva;
                    }
                    else
                    {
                        tiva = 0.0;
                        dtConsulta.Rows[0].Cells[3].Value = 0.0;
                    }

                    
                    
                        if (!(descuento >= 0 && descuento <= 0.99))
                        {
                            MessageBox.Show("Esta excediendo los limites\n Entre 0.0 y 0.99");
                            dtConsulta.Rows[0].Cells[2].Value = "0.0";
                            return;
                        }
                        else
                        {
                            // MessageBox.Show((precio * descuento) + "");
                            dtConsulta.Rows[0].Cells[4].Value =
                                Math.Round(((precio * cantidad) - ((precio * cantidad) * descuento)) * 100) / 100;
                            dtConsulta.Rows[0].Cells[5].Value =
                               Math.Round(((precio * cantidad + (tiva)) - ((precio * cantidad + (tiva)) * descuento)) * 100) / 100;
                        }

                        if (Convert.ToInt32(dtConsulta.Rows[0].Cells[1].Value) > stock && !mstock) 
                        {
                            MessageBox.Show("Ingrese un numero adecuado en cantidad\n Stock Actual del producto es: " + stock);
                            mstock = true;
                            //dtConsulta.Rows[0].Cells[1].Value = "0";
                            //return;
                        }
                }
                catch (Exception ex)
                {
                    Datos.Excepciones.Gestionar(ex);
                    MessageBox.Show(ex.Message);
                }
                //MessageBox.Show((precio * cantidad) - (precio * descuento) + "");
            }



        }

        #endregion 

        public FormConsulta()
        {
            InitializeComponent();
           

        }

        private void FormConsulta_Load(object sender, EventArgs e)
        {
           // this.dtConsulta.CellFormatting += this.dtConsulta_CellFormatting;

            
            
            this.dtConsulta.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dtConsulta.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
            this.dtConsulta.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.55F, System.Drawing.FontStyle.Bold);
            this.dtConsulta.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.DarkSlateGray;

            Consulta = this;
            //panelEx2.Visible = false;
           // pnlPrincipal.Enabled = false;
            panelEx3.Enabled = false;
           // dtConsulta.Enabled=false;
            dtConsulta.Rows.Add(1);
            dtAlmacen.Rows.Add(1);
            dtNombre.Rows.Add(1);

            txtNombre.AutoCompleteCustomSource = FormConsulta.LoadAutoCompleteNombre();
            txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            panelPreview.Visible = false;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteNombre()
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (String row in getLista.Listar("","Nombre").Select(p => p.Nombre))
            {

                stringCol.Add(row);

            }
            return stringCol;
        }
    
        private void btnProducto_Click(object sender, EventArgs e)
        {

            
            try
            {
                
                Producto.FormDataProductos frm = new Producto.FormDataProductos();
                frm.Opacity = 75;
                Producto.FormDataProductos.GridSeleccion = true;
                Producto.FormDataProductos.Origen = "Consulta";
                

                dtConsulta.Rows.Clear();
                dtNombre.Rows.Clear();
                dtAlmacen.Rows.Clear();
                if (dtCaracteristicaR.Rows.Count > 0)
                {
                    dtCaracteristicaR.Rows.Clear();
                }
                dtConsulta.Rows.Add(1);
                dtNombre.Rows.Add(1);
                dtAlmacen.Rows.Add(1);
                mstock = false;
                frm.Show();
               
               
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FormConsulta_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void FormConsulta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue== Convert.ToChar(Keys.Enter))
            {
                mstock = false;
               // MessageBox.Show("Enter");
                e.Handled = false;
              
                    dtConsulta.EndEdit();
                    NProducto getProducto = new NProducto();



                    List<Datos.TProducto_Caracteristica_Foreign> tlist = getProducto.Listar(txtNombre.Text, "Nombre");


                    // MessageBox.Show(tlist.Count+" }}");

                    if (tlist.Count == 1)
                    {

                        fillDatos((int)tlist[0].Codigo);
                       


                        // MessageBox.Show(tlist[0].Codigo+"}}}");




                        //dtConsulta.EndEdit();
                        //dtConsulta.CurrentCell = dtConsulta.Rows[r].Cells[c];


                        // dtConsulta.Rows.Add();
                        //dtConsulta.CurrentCell = dtConsulta.CurrentRow.Cells[4];


                    }
                    else
                    {
                        dtConsulta.Rows.Clear();
                        dtNombre.Rows.Clear();
                        dtAlmacen.Rows.Clear();
                        dtCaracteristicaR.Rows.Clear();

                        dtConsulta.Rows.Add(1);
                        dtNombre.Rows.Add(1);
                        dtAlmacen.Rows.Add(1);
                       


                    }
                
            }
          

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false;
            }
           
            else if (Char.IsSymbol(e.KeyChar))
            {
                e.Handled = false;
            }
           
            else if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                 e.Handled = false;
            }
            
            else{
                 e.Handled = true;
            
            }

        }
    }
}
