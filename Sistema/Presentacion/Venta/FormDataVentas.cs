using Microsoft.Reporting.WinForms;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Venta
{
    public partial class FormDataVentas : Base.FormDataBusq
    {
        string reporteFile = "Presentacion.Reportes.ReportDetalleVentas.rdlc";

   #region conexion

        private static String origen;

        public static String Origen
        {
            get { return FormDataVentas.origen; }
            set { FormDataVentas.origen = value; }
        }
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataVentas.dtSeleccion; }
            set { FormDataVentas.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataVentas.gridSeleccion; }
            set { FormDataVentas.gridSeleccion = value; }
        }
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try{
            try
            {
                Venta_codigo = Convert.ToInt32(dtLista.Rows[e.RowIndex].Cells[0].Value);
            }
            catch { }
            if (GridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono el Venta : " + dtLista.Rows[e.RowIndex].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {
                    DtSeleccion = dtLista.Rows[e.RowIndex];

                    if (Origen=="Consulta")
                    {

                        Venta.FormConsulta.Consulta.fillDatos( Convert.ToInt32(DtSeleccion.Cells[0].Value));
                
                    }
                   // Venta.FormVenta.Prod_principal.cmbDimension.SelectedValue = Convert.ToInt32(DtSeleccion.Cells[0].Value);
                    GridSeleccion = false; this.Hide();

                }
                else
                {
                    txtBuscar.Text = "";


                }


            }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dtLista_CellFormatting(object sender,
      System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dtLista.Columns[e.ColumnIndex].Name.Equals("Estado"))
                {

                    if ((e.Value.ToString()).Contains("COTIZACION"))
                    {
                        e.CellStyle.BackColor = Color.OrangeRed;

                    }
                }
            }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
       
        #endregion 
        public FormDataVentas()
        {
            try
            {

                InitializeComponent();

                //cmbBusqueda.DataBindings.Add("SelectedItem",Enum.GetValues(typeof(Negocios.ETVenta)),"SelectedItem");

                dtLista.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.None);
                loadColumn();

                //string alfa=Enum.GetName(cmbBusqueda.SelectedValue,alfa);
                // this.dtLista.CellContentClick +=
                // new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);
            }
            
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
        }


   

        NVenta addVenta = new NVenta();
        ENBusqueda tbusqueda;
        ENBusquedaOpcion topcion;
        NProveedor getProveedor = new NProveedor();

        List<Datos.TVenta_Foreign> lista = new List<Datos.TVenta_Foreign>();

        DataTable TLista = new DataTable();

        DataRow fila;

        int filasPagina = 13; // Definimos el numero de filas que deseamos ver por pagina, tambien puede leerse desde un archivo de configuracion.
        int nroPagina = 1;//Esto define el numero de pagina actual en al que  nos encontramos
        int ini = 0; //inicio del paginado
        int fin = 0;//fin del paginado

        int numeroRegistro;


        enum ENBusqueda
        {

            Seleccione = 0,
            Identificacion,
            Persona ,
            Fecha, 
            Estado,
            Monto
        }

        enum ENBusquedaOpcion
        {

            Seleccione = 0,
            Mayor = 1,
            Menor = 2,
            Factura = 3,
            Cotizacion = 4
             }

        public void loadColumn()
        {
            try
            {
                List<String> col = new List<string>();
                col.Add("Codigo");
                col.Add("IdComprador");
                col.Add("Comprador");
                col.Add("Total IVA");
                col.Add("Total Descuento");
                col.Add("Total Base");
                col.Add("Total BaseIVA");
                col.Add("Total");
                col.Add("Fecha");
                col.Add("Estado");

                foreach (String mn in col)
                {
                    DataGridViewColumn column = new DataGridViewColumn();
                    DataGridViewCell cell = new DataGridViewTextBoxCell();
                    column.Name = mn;
                    column.HeaderText = mn;

                    column.CellTemplate = cell;
                    dtLista.Columns.Add(column);

                }

                foreach (DataGridViewColumn mn in dtLista.Columns)
                {
                    if (mn.HeaderText.Equals("Codigo"))
                    {
                        mn.Width = 60;

                    }
                    if (mn.HeaderText.Equals("IdComprador"))
                    {
                        mn.Width = 80;

                    }
                    if (mn.HeaderText.Equals("Total IVA"))
                    {
                        mn.Width = 60;

                    }
                    if (mn.HeaderText.Equals("Total Descuento"))
                    {
                        mn.Width = 70;

                    }
                    if (mn.HeaderText.Equals("Total Base"))
                    {
                        mn.FillWeight = 70;


                    }
                    if (mn.HeaderText.Equals("Total BaseIVA"))
                    {
                        mn.FillWeight = 70;

                    }
                    if (mn.HeaderText.Equals("Total"))
                    {
                        mn.FillWeight = 70;

                    }
                    if (mn.HeaderText.Equals("Estado"))
                    {
                        mn.FillWeight = 80;

                    }
                    if (mn.HeaderText.Equals("Fecha"))
                    {
                        mn.FillWeight = 90;


                    }

                }

                dtLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dtLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void paginar()
        {

            nroPagina = Convert.ToInt32(bndPagActual.Text); //Obtenemos el numero de pagina atual
            if (lista.Count > filasPagina)
            {
                this.ini = nroPagina * filasPagina - filasPagina;
                this.fin = nroPagina * filasPagina;
                if (fin > lista.Count)
                    fin = lista.Count;
            }
            else
            {
                this.ini = 0;
                this.fin = lista.Count;
            }

            if (dtLista.Rows.Count > 0)
                dtLista.Rows.Clear();
            //int indiceInsertar;//
            numeroRegistro = this.ini;
            for (int i = ini; i < fin; i++)
            {


                fila = TLista.Rows[i];


                dtLista.Rows.Add();


                int indiceInsertar = dtLista.Rows.Count - 1;
                if (indiceInsertar > -1)
                {
                    dtLista.Rows[indiceInsertar].Cells[0].Value = fila[0];
                    dtLista.Rows[indiceInsertar].Cells[1].Value = fila[1];
                    dtLista.Rows[indiceInsertar].Cells[2].Value = fila[2];
                    dtLista.Rows[indiceInsertar].Cells[3].Value = fila[3];
                    dtLista.Rows[indiceInsertar].Cells[4].Value = fila[4];
                    dtLista.Rows[indiceInsertar].Cells[5].Value = fila[5];
                    dtLista.Rows[indiceInsertar].Cells[6].Value = fila[6];
                    dtLista.Rows[indiceInsertar].Cells[7].Value = fila[7];
                    dtLista.Rows[indiceInsertar].Cells[8].Value = Convert.ToDateTime(fila[8]+"").ToString("yyyy-MM-dd");
                    dtLista.Rows[indiceInsertar].Cells[9].Value = fila[9];

                    
                }



            }

        }

        /*Esta funcion define los valores para el numero total de pagina y  el cambio en el numero de pagina actual*/

        private void numPaginas()
        {
            if (lista.Count % filasPagina == 0)
                bndPagTotal.Text = (lista.Count / filasPagina).ToString();
            else
            {
                double valor = lista.Count / filasPagina;
                bndPagTotal.Text = (Convert.ToInt32(valor) + 1).ToString();

            }
            bndPagActual.Text = "1";
        }

        
        private void FormDataVentas_Load(object sender, EventArgs e)
        {

            try{
            cmbBusqueda.DataSource = Enum.GetValues(typeof(ENBusqueda));
            cmbBusqSec.Visible = true;
            cmbBusqSec.Items.Add("Seleccione");
            cmbBusqSec.Items.Add("Mayor");
            cmbBusqSec.Items.Add("Menor");
            cmbBusqSec.Items.Add("Factura");
            cmbBusqSec.Items.Add("Cotizacion");
            cmbBusqSec.SelectedIndex = 0;
            cmbBusqueda.SelectedIndex = 0;
            this.Lista();
            this.dtLista.CellFormatting += this.dtLista_CellFormatting;
            this.dtLista.CellContentClick+=dtLista_CellContentClick;
            this.bndUltimo.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
            this.bndSiguiente.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            this.bndPrimero.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
            this.bndAtras.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);

            this.bndPagActual.TextChanged += new System.EventHandler(this.bndPagActual_TextChanged);

            panelPreview.Visible = false;


            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
            //cmbBusqSec.DataSource = Enum.GetValues(typeof(ENBusquedaOpcion));

            
            }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }


      

       
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {


                lista = this.addVenta.Listar();
                TLista = addVenta.LINQToDataTable(lista.AsEnumerable());
                if (lista.Count > 0)
                {
                   
                    this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                    this.paginar();//empezamos con la paginacion
                    lblCantidad.Text = "#Venta: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                    dtLista.Select();
                }
                else
                {
                    dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                    lblCantidad.Text = "#Venta: 0 ";//Cantidad totoal de registros encontrados
                    bndPagTotal.Text = "1";
                }


                //  MessageBox.Show(this.addVenta.Listar("").Count + "--");
                  System.Windows.Forms.DataGridViewCellStyle dataCurrency = new System.Windows.Forms.DataGridViewCellStyle();



                  if (dtLista.Rows.Count> 0)
                  {
                      dataCurrency.Format = "C2";
                      dataCurrency.NullValue = "0.0";
                      dtLista.Columns["Total"].DefaultCellStyle = dataCurrency;
                      dtLista.Columns[3].DefaultCellStyle = dataCurrency;
                      dtLista.Columns[4].DefaultCellStyle = dataCurrency;
                      dtLista.Columns[5].DefaultCellStyle = dataCurrency;
                      dtLista.Columns[6].DefaultCellStyle = dataCurrency;
                  
                  }

            }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    lista = this.addVenta.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd());
                    TLista = addVenta.LINQToDataTable(lista.AsEnumerable());
                    if (lista.Count > 0)
                    {
                        this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                        this.paginar();//empezamos con la paginacion
                        lblCantidad.Text = "#Venta: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                        dtLista.Select();
                    }
                    else
                    {
                        dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                        lblCantidad.Text = "#Venta: 0 ";//Cantidad totoal de registros encontrados

                    }
                }
               
             }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
              MessageBox.Show("No se puede Listar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
  


          
        }


        private void Lista(ENBusqueda nprov,ENBusquedaOpcion nopc)
        {
            //MessageBox.Show("Lista");
            try
            {
               if (nprov.ToString().TrimEnd().Equals("Estado"))
                {
                    lista = this.addVenta.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());
                    TLista = addVenta.LINQToDataTable(lista.AsEnumerable());
                    if (lista.Count > 0)
                    {
                        this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                        this.paginar();//empezamos con la paginacion
                        lblCantidad.Text = "#Venta: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                        dtLista.Select();
                    }
                    else
                    {
                        dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                        lblCantidad.Text = "#Venta: 0 ";//Cantidad totoal de registros encontrados

                    }
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
                        lista= this.addVenta.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());
                        TLista = addVenta.LINQToDataTable(lista.AsEnumerable());
                        if (lista.Count > 0)
                        {
                            this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                            this.paginar();//empezamos con la paginacion
                            lblCantidad.Text = "#Venta: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                            dtLista.Select();
                        }
                        else
                        {
                            dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                            lblCantidad.Text = "#Venta: 0 ";//Cantidad totoal de registros encontrados

                        }
                    }
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

            try{

            if (cmbBusqueda.SelectedIndex == 0)
            {
                txtBuscar.Text = "";
                this.Lista();
                cmbBusqSec.Enabled = false;
            }
            if (cmbBusqueda.SelectedIndex != 0 && !(cmbBusqueda.SelectedIndex == 1))
            {
                txtBuscar.MaxLength = 15;
                txtBuscar.Text = borrarLetras(txtBuscar.Text);
                // NumeroDecimal = false;
                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                this.Lista(tbusqueda);
                cmbBusqSec.Enabled = false;
                //MessageBox.Show("----"+tbusqueda);
            }
            if (cmbBusqueda.SelectedIndex != 0 && !(cmbBusqueda.SelectedIndex == 2))
            {
                //txtBuscar.MaxLength = 300;
                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                this.Lista(tbusqueda);
                cmbBusqSec.Enabled = false;
                //MessageBox.Show("----"+tbusqueda);
            }


            if (cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Estado"))
            {

                txtBuscar.Enabled = false;
                if (!cmbBusqSec.Items.Contains("Factura") && !cmbBusqSec.Items.Contains("Cotizacion"))
                {
                    cmbBusqSec.Items.Add("Factura");
                    cmbBusqSec.Items.Add("Cotizacion");
                }

                if (cmbBusqSec.Items.Contains("Mayor") && cmbBusqSec.Items.Contains("Menor"))
                {
                    cmbBusqSec.Items.Remove("Mayor");
                    cmbBusqSec.Items.Remove("Menor");
                }
                cmbBusqSec.Enabled = true;
                cmbBusqSec.SelectedIndex = 0;

                txtBuscar.Text = "";

                txtBuscar.SendToBack();
                //  MessageBox.Show(NumeroDecimal + "--0sCCc");

                // this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);




            }
            else
            {
                if (cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Monto"))
                {


                    if (cmbBusqSec.Items.Contains("Factura") && cmbBusqSec.Items.Contains("Cotizacion"))
                    {
                        cmbBusqSec.Items.Remove("Factura");
                        cmbBusqSec.Items.Remove("Cotizacion");
                    }

                    if (!cmbBusqSec.Items.Contains("Mayor") && !cmbBusqSec.Items.Contains("Menor"))
                    {
                        cmbBusqSec.Items.Add("Mayor");
                        cmbBusqSec.Items.Add("Menor");
                    }

                    txtBuscar.Enabled = true;
                    txtBuscar.MaxLength = 15;
                    NumeroDecimal = true;
                    cmbBusqSec.Enabled = true;
                    cmbBusqSec.SelectedIndex = 0;

                    txtBuscar.Text = borrarLetras(txtBuscar.Text);
                    txtBuscar.SendToBack();
                    //  MessageBox.Show(NumeroDecimal + "--0sCCc");

                    // this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.teclaNumero);




                }
                else
                {

                    txtBuscar.Enabled = true;
                    txtBuscar.MaxLength = 300;
                    NumeroDecimal = false;
                    cmbBusqSec.Enabled = false;
                    cmbBusqSec.SelectedItem = "Seleccione";
                }
                //cmbBusqSec.SelectedItem = "Seleccione";
                // this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);

            }

           





            if (cmbBusqueda.SelectedIndex == 3)
            {
                txtBuscar.Text = "";
                txtBuscar.Enabled = false;
                cmbBusqSec.Enabled = true;
                //txtBuscar.Visible = false;

                //  this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
                //MessageBox.Show("IVA");

                //dateFecha.Size= new Size(156, 21);
                //dateFecha.Location = new Point(403,21);
                dateFecha.Enabled = true;
               // txtBuscar.Text = dateFecha.Value.Year + "-" + dateFecha.Value.Month + "-" + dateFecha.Value.Day;
                txtBuscar.Text = dateFecha.Value.ToShortDateString();

                if (cmbBusqSec.Items.Contains("Factura") && cmbBusqSec.Items.Contains("Cotizacion"))
                {
                    cmbBusqSec.Items.Remove("Factura");
                    cmbBusqSec.Items.Remove("Cotizacion");
                }

                if (!cmbBusqSec.Items.Contains("Mayor") && !cmbBusqSec.Items.Contains("Menor"))
                {
                    cmbBusqSec.Items.Add("Mayor");
                    cmbBusqSec.Items.Add("Menor");
                }

                cmbBusqSec.SelectedIndex = 0;
            }
            else {
                dateFecha.Enabled = false;
            }



            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
               
            
           

        }

        private void cmbBusqSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
            if (cmbBusqSec.SelectedIndex != 0)
            {

                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                topcion = (ENBusquedaOpcion)Enum.Parse(typeof(ENBusquedaOpcion), cmbBusqSec.SelectedItem.ToString());
               // MessageBox.Show(tbusqueda+"--"+topcion);
                this.Lista(tbusqueda,topcion);
              
            }
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            GridSeleccion = false;

            this.Hide();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

           
          
        }

        private void FormDataVentas_Resize(object sender, EventArgs e)
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
                if (dtLista.CurrentRow.Index > -1)
                {
                    DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {

                        var t = new NDetalleVenta().ListarP((Int32)(this.dtLista.CurrentRow.Cells[0].Value));

                        t.ForEach(p => new NDetalleVenta().Eliminar(p.CodVen,p.Codigo));
                        this.addVenta.Eliminar((Int32)(this.dtLista.CurrentRow.Cells[0].Value));

                        this.Lista();

                    }
                }

            }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(Datos.Excepciones.MensajePersonalizado,"Error.. Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Venta.FormVenta frm = new Venta.FormVenta();
                //frm.nuevo = true;
                frm.Opacity = 80;
                frm.date = DateTime.Now;
                frm.ShowDialog();
                this.Lista();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            try
            {
                FormVenta frm = new FormVenta();

                var t = this.addVenta.getDatos(int.Parse(this.dtLista.SelectedRows[0].Cells[0].Value.ToString()));
                frm.Opacity = 80;
                frm.grabar = true;
                Double desc = 0.0, tot = 0.0;

                frm.txtCodigo.Text = "" + t.ven_codigo;

                frm.eventa.Ven_codigo = t.ven_codigo;
                frm.btnVer.Enabled = true;
                //MessageBox.Show("" + t.ven_codigo + "--"+t.ven_estado);
               
                frm.dtLista.Enabled = false;
                frm.dtLista.ReadOnly = false;
                frm.fillDatosProductos(t.ven_codigo);
                frm.fillDatos(t.per_codigo);
                frm.eventa.Per_codigo = t.per_codigo;
                frm.txtTotal.NumeroDecimal = true;
                frm.txtIdentificacion.Text = "" + new NPersona().getDatos(t.per_codigo).Identificacion;
                var cliente = new NPersona().getDatos(t.per_codigo);
                frm.txtCliente.Text = "" + cliente.Nombre +" "+ cliente.Apellido;


                frm.eventa.Ven_estado = Convert.ToChar(t.ven_estado);
                // frm.edventa.Ven_codigo = t.ven_codigo;

                frm.rdbCotizacion.Checked = frm.eventa.Ven_estado == 'N' ? true : false;
                frm.rdbFactura.Checked = frm.eventa.Ven_estado == 'S' ? true : false;
                if (t.ven_descuento > 0.0)
                    frm.chkDescuento.Checked = true;

                frm.txtSub12.Text = String.Format("{0:C2}", t.ven_subtotal12);
                frm.txtSub0.Text = String.Format("{0:C2}", t.ven_subtotal0);
                frm.txtIVA.Text = String.Format("{0:C2}", t.ven_tiva);
                frm.txtDescuento.Text = "" + (t.ven_descuento + 0.0);

                desc = Convert.ToDouble(((t.ven_subtotal12 + t.ven_subtotal0 + t.ven_tiva) * t.ven_descuento));
                tot = (Convert.ToDouble((t.ven_subtotal12 + t.ven_subtotal0 + t.ven_tiva) - desc));
                frm.txtVDescuento.Text = String.Format("{0:C2}", desc);
                
                frm.txtTotal.Text = String.Format("{0:C2}", tot);
                
                frm.btnNuevo.Text = "Editar";

               frm.date = t.ven_fecha.Value;
                frm.ShowDialog();
                this.Lista();
               
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormDataVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (GridSeleccion)
            //{
            //    Venta.FormVenta.Prod_principal.Show();
            //    GridSeleccion = false;
            //}
            try
            {
                GridSeleccion = false;

                this.Hide();
            
             }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

                        if (Char.IsDigit(value) || (dot<2 && value == '.'))
                       
                        { temp += value; }
                     

                        
                    }
                    else {

                        if (Char.IsDigit(value))
                        { temp += value; }
                    
                    }

                    

                }



                return temp;
            }
            else {
                return "";
            }
        }

        private int venta_codigo;

        public int Venta_codigo
        {
            get { return venta_codigo; }
            set { venta_codigo = value; }
        }
      

        
        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dtLista.Rows.Count > 0)
            {
                Cursor.Current = Cursors.WaitCursor;
                Venta_codigo = (Int32)(dtLista.SelectedRows[0].Cells[0].Value);

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

                //try
                //{
                //    FormVenta frm = new FormVenta();
                //    var t = this.addVenta.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                //    frm.editar = true;

                //    frm.txtCodigo.Text = "0000" + t.Codigo.ToString();
                //    frm.txtCotizacionmbre.Text = t.Cotizacionmbre;
                //    frm.cmbCategoria.SelectedText = t.Categoria;
                //    frm.cmbColor.SelectedText = t.Color;
                //    frm.cmbDimension.SelectedText = t.Dimension;
                //    frm.cmbUnidad.SelectedText = t.Unidad;

                //    frm.txtStock.Text = "" + t.Stock;
                //    frm.txtStockMin.Text = "" + t.StockMin;
                //    frm.txtVenta.Text = "" + t.Venta;
                //    frm.txtCompra.Text = "" + t.Compra;
                //    frm.txtDescripcion.Text = t.Descripcion;
                //    frm.chkIva.CheckState = t.IVA == 'S' ? CheckState.Checked : CheckState.Unchecked;
                //    frm.chkPrecioVenta.CheckState = CheckState.Unchecked;
                //    frm.txtProveedor.Text = t.Proveedor;


                //    frm.panelEx1.Enabled = false;

                //    frm.btnNuevo.Text = "Habilitar Edicion";
                //    frm.btnNuevo.Visible = true;
                //    frm.btnProveedor.Visible = false;
                //    frm.chkPrecioVenta.Visible = false;
                //    frm.label14.Visible = false;
                //    frm.ver = true;


                //       frm.ShowDialog();
                //    //this.Lista();
                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }

        private void dateFecha_ValueChanged(object sender, EventArgs e)
        {
            txtBuscar.Text = dateFecha.Value.ToShortDateString();
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(bndPagActual.Text) && dtLista.Rows.Count > 0)
            {
                if (Convert.ToInt32(bndPagTotal.Text) > 1)
                {
                    this.nroPagina = 1;
                    bndPagActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }
            else
            {
         
                if (Convert.ToInt32(bndPagTotal.Text) > 1)
                {
                    this.nroPagina = 1;
                    bndPagActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }


        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(bndPagActual.Text) && dtLista.Rows.Count > 0)
            {
                if (Convert.ToInt32(bndPagActual.Text) > 1)
                {
                    this.nroPagina -= 1;
                    bndPagActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }

        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(bndPagActual.Text) && dtLista.Rows.Count > 0)
            {
                if ((Convert.ToInt32(bndPagActual.Text) < Convert.ToInt32(bndPagTotal.Text)) && Convert.ToInt32(bndPagActual.Text) > 0)
                {
                    this.nroPagina += 1;
                    bndPagActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }
        }


        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(bndPagActual.Text) && dtLista.Rows.Count > 0)
            {
                if (Convert.ToInt32(bndPagTotal.Text) > 1)
                {
                    this.nroPagina = Convert.ToInt32(bndPagTotal.Text);
                    bndPagActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }
            else
            {
                
                if (Convert.ToInt32(bndPagTotal.Text)>1)
                {
                    this.nroPagina = Convert.ToInt32(bndPagTotal.Text);
                    bndPagActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }

            }
        }

        private void bndPagActual_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(bndPagActual.Text) && dtLista.Rows.Count > 0)
            {

                if ((Convert.ToInt32(bndPagActual.Text) <= Convert.ToInt32(bndPagTotal.Text)) && Convert.ToInt32(bndPagActual.Text) > 0)
                {
                    this.paginar();
                }
                else
                {
                    bndPagActual.Text = "1";
                }
            }


        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtBuscar.Text))
                {




                    if (cmbBusqSec.Enabled)
                    {



                        if (cmbBusqueda.SelectedIndex == 3)
                        {
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

                    }
                    else
                    {

                        if (cmbBusqueda.SelectedIndex == 1)
                        {
                            NumeroDecimal = false;
                            txtBuscar.Text = borrarLetras(txtBuscar.Text);
                            tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                            this.Lista(tbusqueda);
                            cmbBusqSec.Enabled = false;



                        }
                        else
                        {
                            tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                            this.Lista(tbusqueda);
                            cmbBusqSec.Enabled = false;
                            //MessageBox.Show("----"+tbusqueda);
                        }

                    }


                }
                else
                {


                    this.Lista();


                }

            }
      }

    }
}