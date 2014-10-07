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
    public partial class FormProducto
    {

        public void inicioIngresoR()
        {
            if (dtNombre.Rows.Count < 1)
            {
                dtNombre.Rows.Add();
                dtAlmacen.Rows.Add();

                txtCompra.Text = 0.0 + "";
                txtVenta.Text = 0.0 + "";
                txtStockMin.Text = "" + minima_cantidad;
                txtStock.Text = "" + 0;
                dtAlmacen.Rows[0].Cells[3].Value = minima_cantidad;

                dtAlmacen.Rows[0].Cells["Stock"].Value = 0;

                dtAlmacen.Rows[0].Cells["IVA"].Value = true;
            }

        }

        public void limpiarIngresoR()
        {

            dtNombre.Rows.Clear();
            dtAlmacen.Rows.Clear();
            dtCaracteristicaR2.Rows.Clear();
            dtCaracteristicaR.Rows.Clear();
            inicioIngresoR();

            txtCategoria.Text = "";
            txtMarca.Text = "";
           
            txtNombre.Text = "";
           // txtStock.Text = "";
            txtStockMin.Text = minima_cantidad+"";

            c.Dcar_codigo = -1;
            c.Prod_codigo = -1;
           // txtCompra.Text = "0.0";
            //txtVenta.Text = "0.0";

        }

        #region Llenado de Datos

        public String fillCaracteristicaVista(int dcarcodigo, int codprod)
        {

            String temp = "";
            List<Datos.TDetalleProducto_Caracteristica> dt = ndprodcar.Listar(dcarcodigo, codprod);

            // MessageBox.Show(dt.Count + "");
            foreach (Datos.TDetalleProducto_Caracteristica row in dt)
            {
               
                  temp +="\t\t"+row.Tipo+": "+ row.Valor+"\n";

            }
            return temp;
        }

        public void fillVista(int codigo)
        {
            var prd = addProducto.getDatosCar(codigo);
            tabControl.SelectedTab = this.tciVer;
            // txtCodigo.Text=prd.Codigo+"";
            String cadena = "Vista de Producto \n";
            String salto = "\n";
           
            cadena +="\tCodigo : "+ prd.CodProd+salto+
                   "\tNombre : "+prd.Nombre+salto+salto+
                   "\t\tMarca : " +prd.Marca+salto+
                   "\t\tCategoria : "+prd.Categoria+salto+
                   "\t\tUnidad : " +prd.Unidad+salto+salto+
                   "\t\tDescripcion : "+prd.Descripcion+salto+salto+
                   "\tAlmacen"+salto+
                   "\t\tPrecio de Compra :  " + String.Format("{0:C}", prd.Compra) + salto +
                    "\t\tPrecio de Venta :  " + String.Format("{0:C}", prd.Venta) + salto +
                    "\t\tPrecio de Venta (10%) + IVA(12%) :  " + String.Format("{0:C}", prd.Venta + (prd.Venta*valor_iva)) + salto + salto +
                   "\t\tStock Minimo :  "+prd.StockMin+salto+
                   "\t\tStock :  "+prd.Stock+salto+salto+
                   "\t\tIVA :  "+ (prd.IVA=='S'?"Si":"No")+salto+salto+
                   "\tCaracteristicas Definidad "+salto+salto  ;

            txtVista.Text = cadena + fillCaracteristicaVista((int)prd.CodDcar,(int)prd.Codigo);
            fillProducto((int)prd.Codigo);
        }
        public void fillCaracteristica(int dcarcodigo, int codprod)
        {



            dtCaracteristicaR.Rows.Clear();
            dtCaracteristicaR2.Rows.Clear();
            // MessageBox.Show(codigo + "=+++=" +codprod);
            List<Datos.TDetalleProducto_Caracteristica> dt = ndprodcar.Listar(dcarcodigo, codprod);

            // MessageBox.Show(dt.Count + "");
            foreach (Datos.TDetalleProducto_Caracteristica row in dt)
            {
                //  MessageBox.Show(row.Tipo + "==" + row.Valor);
                dtCaracteristicaR.Rows.Add(
                    row.Tipo, row.Valor
                    );
                dtCaracteristicaR2.Rows.Add(
                      row.Tipo, row.Valor
                      );

            }



        }

        public void fillProducto(int codigo)
        {

            var prd = addProducto.getDatos(codigo);
            var nom = addProducto.getDatosBase(codigo);

            // txtCodigo.Text=prd.Codigo+"";

            txtCodProd.Text = "" + prd.CodProd;

            txtNombre.Text = "" + nom.pro_nombre;
            txtMarca.Text = "" + prd.Marca;
            txtCategoria.Text = "" + prd.Categoria;
            txtUnidad.Text = "" + prd.Unidad;
            txtDescripcion.Text = "" + prd.Descripcion;



            dtAlmacen.Rows[0].Cells[1].Value = prd.Venta;
            dtAlmacen.Rows[0].Cells[0].Value = prd.Compra;



            txtVenta.Text = "" +String.Format("{0:C}", prd.Venta);
            txtCompra.Text = "" + String.Format("{0:C}",prd.Compra);
            txtStockMin.Text = "" + prd.StockMin;
            txtStock.Text = "" + prd.Stock;
            chkIva.CheckState = prd.IVA == 'S' ? CheckState.Checked : CheckState.Unchecked;
            //chkPrecioVenta.CheckState = CheckState.Unchecked;

            chkStockMin.CheckState = CheckState.Unchecked;
            c.Dcar_codigo = Convert.ToInt32(prd.CodDcar);
            fillCaracteristica((int)(prd.CodDcar), (int)prd.Codigo);

           


        }

        public void fillProductoSeleccion(int codigo)
        {

            var prd = addProducto.getDatos(codigo);
            // txtCodigo.Text=prd.Codigo+"";

          string txt = dtNombre.Rows[0].Cells[0].Value+"";
          string cp = prd.CodProd;

            txt =txt.Substring(0, txt.IndexOf('-') > 0 ? txt.IndexOf('-') - 1 : 0);
            cp=cp.Substring(0, cp.IndexOf('-') > 0 ? cp.IndexOf('-') - 1 :0);
         
            if (!(txt.Equals(cp)))
          {
              //dtNombre.Rows[0].Cells[0].Value = prd.CodProd;
              //txtCodProd.Text = dtNombre.Rows[0].Cells[0].Value+"";
          }
          else

          {
              //dtNombre.Rows[0].Cells[0].Value = prd.CodProd;
              //txtCodProd.Text = prd.CodProd+"";
          }

          
     
           txtNombre.Text = "" + prd.Nombre;
           txtMarca.Text = "" + prd.Marca;
           txtCategoria.Text = "" + prd.Categoria;
           txtUnidad.Text = "" + prd.Unidad;
           txtDescripcion.Text = "" + prd.Descripcion;







            chkIva.CheckState = prd.IVA == 'S' ? CheckState.Checked : CheckState.Unchecked;
            //chkPrecioVenta.CheckState = CheckState.Unchecked;

            chkStockMin.CheckState = CheckState.Unchecked;
            c.Dcar_codigo = Convert.ToInt32(prd.CodDcar);
            fillCaracteristica((int)(prd.CodDcar), (int)prd.Codigo);
            c.Dcar_codigo = 0;


        }
        #endregion

        #region Autocompletadore
        public static AutoCompleteStringCollection LoadAutoCompleteCategoria()
        {
            NCategoria getLista = new NCategoria();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TCategoria row in getLista.Listar(""))
            {

                stringCol.Add(Convert.ToString(row.cat_nombre));

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteUnidad()
        {
            NUnidad getLista = new NUnidad();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TUnidad row in getLista.Listar(""))
            {

                stringCol.Add(Convert.ToString(row.uni_nombre));

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteMarca()
        {
            NMarca getLista = new NMarca();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TMarca_Foreign row in getLista.Listar(""))
            {

                stringCol.Add(Convert.ToString(row.Nombre));

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteCaracteristicaTipo()
        {
            NCaracteristica getLista = new NCaracteristica();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TCaracteristica_Detalle row in getLista.Listar(""))
            {

                stringCol.Add(Convert.ToString(row.Tipo));

            }
            return stringCol;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteCaracteristicaValor(string tipo)
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (String row in getLista.ListarCaracteristicas(tipo))
            {

                stringCol.Add(row);

            }
            return stringCol;
        }


        private static string getZero(int num)
        {
            string tmp = "";
            for (int i = 0; i < num; i++)
            {
                tmp += "0";
            }
            return tmp;
        }
        public static AutoCompleteStringCollection LoadAutoCompleteCodigoProducto()
        {
            NProducto getLista = new NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();


            var t = getLista.Listar("");

               var tmp= (from p in t
                        
                           select p.CodProd.Substring(0, p.CodProd.IndexOf('-') > 0 ? p.CodProd.IndexOf('-')-1 : 0)).ToList();

            
            

            List<String> lista = new List<String>();

            
            foreach (String row in tmp)
            {
                var tm = (from p in t
                         where
                           p.CodProd.Contains(row)
                          orderby p.CodProd descending
                          select p.CodProd).First();


                lista.Add(tm);
            
            }


            foreach (String row in lista)
            {
                string txt = (row).Substring(0, row.IndexOf('-') > 0 ? row.IndexOf('-') : row.Length - 1);


                string codigo = (row).Substring(row.IndexOf('-') > 0 ? row.IndexOf('-') + 1 : 0);


                int cn = 0;

                bool ps = true;
                foreach (char a in codigo)
                {
                    if (Char.IsLetter(a))
                        ps = false;
                }
               


                if (!ps)
                {
                    codigo="" ;
                }
                else
                {
                    cn= Int32.Parse(codigo);
                    
                }
               


                codigo = codigo.Length > 5 ?
                    "" :
                    getZero(4-((cn+1)+"").Length) 
                    +
                    (cn+1)
                    ;
               // MessageBox.Show(row.CodProd.IndexOf('-')  + "--" + row.CodProd.Substring(row.CodProd.IndexOf('-') + 1));
                
              codigo = codigo.Length > 1 ? "-" + codigo : "" ;
                stringCol.Add(txt + codigo);

            }
            return stringCol;
        }

        #endregion

        #region Metodos
        public  double Parse(string input)
        {
            if (String.IsNullOrEmpty(input))
                return 0.0;
            return double.Parse(System.Text.RegularExpressions.Regex.Replace(input, @"[^\d.]", ""));
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
                   && txt.Text.IndexOf('.') + 5 == txt.TextLength)
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
       
        #endregion

        #region DetalleCaracteristica

        NProducto_Caracteristica nprodcar = new NProducto_Caracteristica();
        EProductoCaracteristica eprodcar = new EProductoCaracteristica();

        EDetalleCaracteristica edprodcar = new EDetalleCaracteristica();
        NDetalleCaracteristica ndprodcar = new NDetalleCaracteristica();


        public Boolean duplicaCaracteristica(string caracteristica)
        {

            int count = 0;
            foreach (DataGridViewRow row in dtCaracteristicaR.Rows)
            {

                if (caracteristica.Equals(row.Cells[0].Value + ""))
                {
                    count += 1;
                }


            }
            if (count > 1)
            {
                return true;
            }
            else
            {
                return false;

            }

        }

        public bool verificarLCaracteristicas()
        {

           
            dtCaracteristicaR.EndEdit();
            foreach (DataGridViewRow row in dtCaracteristicaR.Rows)
            {

                if (String.IsNullOrEmpty(row.Cells[1].Value + "") || String.IsNullOrEmpty((row.Cells[0].Value + "").Trim()))
                {
                    MessageBox.Show("Las Caracteristicas no esta correctas\n" +
                             "No es posible tener caracteristicas vacias ,en su caso elimene", "Reviselas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                }
                if (duplicaCaracteristica(row.Cells[0].Value + ""))
                {

                    MessageBox.Show("Las Caracteristicas no esta correctas\n" +
                     "No es posible tener dos tipos de caracteristicas iguales", "Reviselas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


            }
            return true;
        }
        public Boolean guardarCaracteristica()
        {
            try
            {

                eprodcar.Prod_codigo = int.Parse(txtCodigo.Text);
                if (dtCaracteristicaR.Rows.Count > 0)
                {


                    eprodcar.Dcar_codigo = new NProducto_Caracteristica().getDatos(eprodcar.Prod_codigo).dcar_codigo;

                    //MessageBox.Show(eprodcar.Dcar_codigo + " Entrada +++");
                    if (eprodcar.Dcar_codigo > 0)
                    {
                        if (c.Dcar_codigo > 0)
                        {
                            //MessageBox.Show("EP+++" + c.Dcar_codigo + "===" + eprodcar.Dcar_codigo);
                            eprodcar.Dcar_codigo = c.Dcar_codigo;

                            nprodcar.Editar(eprodcar);
                        }
                        else
                        {
                            c.Dcar_codigo = eprodcar.Dcar_codigo;
                            nprodcar.Editar(eprodcar);
                        }
                        //MessageBox.Show("EP+++" + c.Dcar_codigo + "===" + eprodcar.Dcar_codigo);


                        //  MessageBox.Show("Ed+++" + c.Dcar_codigo + "===" + eprodcar.Dcar_codigo);

                    }
                    else
                    {
                        try
                        {
                            eprodcar.Dcar_codigo = nprodcar.Insertar(eprodcar);
                            c.Dcar_codigo = eprodcar.Dcar_codigo;
                            //MessageBox.Show("Ed+++" + c.Dcar_codigo + "===" + eprodcar.Dcar_codigo);
                            this.c.Prod_codigo = int.Parse(this.txtCodigo.Text);
                            addProducto.Editar(this.c);


                        }
                        catch (Exception ex)
                        {
                            Datos.Excepciones.Gestionar(ex);
                            MessageBox.Show("Producto Ingreso C2 \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }

                    }





                    //  MessageBox.Show("+++" + c.Dcar_codigo + "===" + eprodcar.Dcar_codigo);


                    if (eprodcar.Dcar_codigo > 0)
                    {
                        
                            
                            foreach (DataGridViewRow row in dtCaracteristicaR.Rows)
                            {


                                edprodcar.Dcar_codigo = eprodcar.Dcar_codigo;

                                edprodcar.Car_tipo = (row.Cells[0].Value + "").TrimEnd().TrimStart();
                                edprodcar.Car_valor = (row.Cells[1].Value + "").TrimEnd().TrimStart();
                                //                              MessageBox.Show(ing + "\n" +
                                //edprodcar.Dcar_codigo + "\n===" +
                                //edprodcar.Car_tipo + "\n]]]" +
                                //edprodcar.Car_valor);

                               

                                try
                                {
                                    
                                        ndprodcar.Editar(edprodcar);
                                    
                                }
                                catch (Exception ex)
                                {


                                    Datos.Excepciones.Gestionar(ex);
                                    MessageBox.Show(Datos.Excepciones.MensajePersonalizado, "Caracteristicas Detalle");

                                    return false;
                                }



                            

                            

                        }
                        
                    }
                }
                
                
            }
            catch (Exception ex)
            {


                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(Datos.Excepciones.MensajePersonalizado, "Caracteristicas Detalle");

                return false;
            }

            return true;
        }

#endregion
    }
}
