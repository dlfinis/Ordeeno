using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class FormReporte : Negocios.Base.FormBase
    {
        char nconf = 'S';
       
       
        int codigoProd = 0;

        DateTime finicial,ffinal;
        

        public FormReporte()
        {
            InitializeComponent();
            
           // dateFechaFinal.Value = DateTime.Today;
           // dateFechaInicial.Value = DateTime.Today.AddDays(-1);

        }

        private void chkConfirmar_CheckedChanged(object sender, EventArgs e)
        {
            
            nconf = Convert.ToChar(chkVenta.CheckValue);
           
        }


        private void reporteVentas()
        {
            string reporteFile = "Presentacion.Reportes.ReportAnalisisVentas.rdlc";

            Base.FormViewReporte report = new Base.FormViewReporte();
            report.rptView.LocalReport.DataSources.Clear();
            report.rptView.LocalReport.Dispose();

            report.rptView.Reset();
            report.rptView.Clear();

            Datos.DataAnalisisVentasTableAdapters.TVenta_AnalisisTableAdapter ta
                    = new Datos.DataAnalisisVentasTableAdapters.TVenta_AnalisisTableAdapter();

            Datos.DataAnalisisVentas.TVenta_AnalisisDataTable tabla = new Datos.DataAnalisisVentas.TVenta_AnalisisDataTable();

            if (chkVenta.Checked)
                ta.Fill(tabla, finicial + "", ffinal + "");
            else
                ta.FillBySNVentas(tabla, finicial + "", ffinal + "");

            report.rptView.LocalReport.DataSources.Clear();

            report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataAnalisisVentas",
             (DataTable)tabla));
            report.rptView.LocalReport.ReportEmbeddedResource = reporteFile;

            report.Text = "Analisis de Ventas";

            // report.rptView.Refresh();

            report.rptView.SetDisplayMode(DisplayMode.PrintLayout);
            report.rptView.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            report.rptView.ZoomPercent = 100;
            report.rptView.RefreshReport();

            report.ShowDialog();
        
        }

        private void reportePedidos()
        {
            string reporteFile = "Presentacion.Reportes.ReportAnalisisPedidos.rdlc";

            Base.FormViewReporte report = new Base.FormViewReporte();
            report.rptView.LocalReport.DataSources.Clear();
            report.rptView.LocalReport.Dispose();

            report.rptView.Reset();
            report.rptView.Clear();
            Datos.DataAnalisisPedidosTableAdapters.TPedido_AnalisisTableAdapter ta
                    = new Datos.DataAnalisisPedidosTableAdapters.TPedido_AnalisisTableAdapter();

            Datos.DataAnalisisPedidos.TPedido_AnalisisDataTable tabla = new Datos.DataAnalisisPedidos.TPedido_AnalisisDataTable();

            if (chkPedido.Checked)
                ta.Fill(tabla, finicial + "", ffinal + "");
            else
                ta.FillBySNPedidos(tabla, finicial + "", ffinal + "");

            report.rptView.LocalReport.DataSources.Clear();

            report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataAnalisisPedidos",
             (DataTable)tabla));
            report.rptView.LocalReport.ReportEmbeddedResource = reporteFile;

            report.Text = "Analisis de Pedidos";

            // report.rptView.Refresh();

            report.rptView.SetDisplayMode(DisplayMode.PrintLayout);
            report.rptView.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            report.rptView.ZoomPercent = 100;
            report.rptView.RefreshReport();

            report.ShowDialog();
           

        }

        private void reporteUtilidades()
        {
            try
            {
                string reporteFile = "Presentacion.Reportes.ReportAnalisisUtilidades.rdlc";

                Base.FormViewReporte report = new Base.FormViewReporte();
                report.rptView.LocalReport.DataSources.Clear();
                report.rptView.LocalReport.Dispose();

                report.rptView.Reset();
                report.rptView.Clear();

                Datos.DataAnalisisUtilidadesTableAdapters.AnalisisGeneralTableAdapter ta
                        = new Datos.DataAnalisisUtilidadesTableAdapters.AnalisisGeneralTableAdapter();

                Datos.DataAnalisisUtilidades.AnalisisGeneralDataTable tabla = new Datos.DataAnalisisUtilidades.AnalisisGeneralDataTable();

                //MessageBox.Show(finicial + "--" + ffinal.Date);
                nconf = !chkVentaUtilidad.Checked ? 'S':'N';
                if (!chkProducto.Checked)
                    ta.Fill(tabla, finicial, ffinal , nconf + "");
                else
                    ta.FillByProducto(tabla, finicial, ffinal, nconf + "", codigoProd);

                
             

                report.rptView.LocalReport.DataSources.Add(new ReportDataSource("DataAnalisisUtilidad",
                 (DataTable)tabla));
                report.rptView.LocalReport.ReportEmbeddedResource = reporteFile;

                report.Text = "Analisis de Utilidades";

                // report.rptView.Refresh();

                report.rptView.SetDisplayMode(DisplayMode.PrintLayout);
                report.rptView.ZoomMode = ZoomMode.Percent;
                //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
                report.rptView.ZoomPercent = 100;
                report.rptView.RefreshReport();

                report.ShowDialog();

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message);
            }

        }
        
        
        private void btnGenerar_Click(object sender, EventArgs e)
        {

           // MessageBox.Show(tbpPanel.SelectedTab.Text);
           try

            {
            Cursor.Current = Cursors.WaitCursor;

             switch (tbpPanel.SelectedTab.Text)
             {
                 case "Ventas" :
                     reporteVentas();
                     break;
                 case "Utilidades":
                     reporteUtilidades();
                     break;
                 case "Compras":
                     reportePedidos();
                     break;
                
                 default: break;
            
             }
            
           }
            catch(Exception ex) {
                Datos.Excepciones.Gestionar(ex);

                MessageBox.Show(Datos.Excepciones.MensajePersonalizado,"Error.. Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
           //MessageBox.Show("Debe Elegir una fecha de Inicio que se menor ", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
              
        }

        private void dateFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dateFechaInicial.Value.Date >= dateFechaFinal.Value.Date)
            {

                MessageBox.Show("No puede ser la Fecha Inicial Mayor o igual a la Fecha Final","Fecha Inicial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateFechaInicial.Value = dateFechaFinal.Value.Date.AddDays(-1);
            }
            else
            {
               // dateFechaFinal.MinDate = dateFechaInicial.Value.Date;
                finicial = dateFechaInicial.Value.Date;
            }
        
        }

        private void dateFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            if (dateFechaFinal.Value.Date <= dateFechaInicial.Value.Date)
            {

                MessageBox.Show("No puede ser la Fecha Final Menor o igual a la Fecha Inicial","Fecha Final",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                dateFechaFinal.Value = DateTime.Today;

            }
            else
            {
                dateFechaInicial.MaxDate = dateFechaFinal.Value.Date;
                ffinal = dateFechaFinal.Value.Date;
            }

        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            
            if (!chkFecha.Checked)
            {

                finicial = new DateTime(DateTime.Today.Year, 1, 1);
                finicial = finicial >= ffinal ? finicial.AddDays(-1) : finicial;
                ffinal = DateTime.Today;

                dateFechaInicial.Enabled = false;
                dateFechaFinal.Enabled = false;
            }
            if (chkFecha.Checked)
            {
               
                //MessageBox.Show(chkFecha.Checked +"--"+chkFecha.CheckValueChecked);
                dateFechaInicial.Enabled = true;
                dateFechaFinal.Enabled = true;
                finicial = dateFechaInicial.Value.Date;
                ffinal = dateFechaFinal.Value.Date;
            }
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            
            

          

           // dateFechaInicial.MaxDate = DateTime.Today.AddDays(-1);
           // dateFechaFinal.MaxDate = DateTime.Today;
            btnGenerar.Focus();
            chkFecha_CheckedChanged(new Object(), new EventArgs());
            txtNombre.AutoCompleteCustomSource = FormReporte.LoadAutoCompleteNombre();
            txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            chkFecha.Checked = false;
            
            chkProducto.Checked = false;
            finicial = new DateTime(DateTime.Today.Year, 1, 1);
            ffinal = DateTime.Today;
            

        }

        private void chkProducto_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = chkProducto.Checked;
            if (!chkProducto.Checked)
            {
                txtNombre.Text = "";
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

            else
            {
                e.Handled = true;

            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == Convert.ToChar(Keys.Enter))
            {
                
                e.Handled = false;

                
                Negocios.NProducto getProducto = new Negocios.NProducto();



                List<Datos.TProducto_Caracteristica_Foreign> tlist = getProducto.Listar(txtNombre.Text, "Nombre");


                // MessageBox.Show(tlist.Count+" }}");

                if (tlist.Count == 1)
                {

                    
                    codigoProd=((int)tlist[0].Codigo);


                }
                else
                {
                    codigoProd = 0;
                    MessageBox.Show("No existe ese Producto", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
                //MessageBox.Show(codigoProd + "--");

            }

           
          
        }

        private void FormReporte_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        public static AutoCompleteStringCollection LoadAutoCompleteNombre()
        {
            Negocios.NProducto getLista = new Negocios.NProducto();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (String row in getLista.Listar("", "Nombre").Select(p => p.Nombre))
            {

                stringCol.Add(row);

            }
            return stringCol;
        }

        private void chkPedido_Click(object sender, EventArgs e)
        {
            nconf = Convert.ToChar(chkPedido.CheckValue);
        }
    
    }
}
