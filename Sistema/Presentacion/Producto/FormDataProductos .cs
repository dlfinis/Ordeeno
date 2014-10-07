using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;
using System.Threading;
using System.Threading.Tasks;
namespace Presentacion.Producto
{
    public partial class FormDataProductos : Base.FormDataBusq
    {
        #region conexion

        private static String origen;

        public static String Origen
        {
            get { return FormDataProductos.origen; }
            set { FormDataProductos.origen = value; }
        }
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataProductos.dtSeleccion; }
            set { FormDataProductos.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataProductos.gridSeleccion; }
            set { FormDataProductos.gridSeleccion = value; }
        }
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (GridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono el Producto : " + dtLista.Rows[e.RowIndex].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {
                    DtSeleccion = dtLista.Rows[e.RowIndex];

                    if (Origen=="Consulta")
                    {

                        Venta.FormConsulta.Consulta.fillDatos( Convert.ToInt32(DtSeleccion.Cells[0].Value));
                
                    }
                    if (Origen == "Venta")
                    {
                        

                        //Venta.FormVenta.VentaP
                        //Venta.FormVenta.VentaP.fillDatosProductos(Convert.ToInt32(DtSeleccion.Cells[0].Value));
                    }
                   // Producto.FormProducto.Prod_principal.cmbTamanio.SelectedValue = Convert.ToInt32(DtSeleccion.Cells[0].Value);
                    GridSeleccion = false; this.Hide();

                }
                else
                {
                    txtBuscar.Text = "";


                }


            }

        }

        private void dtLista_CellFormatting(object sender,
      System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            if (dtLista.Rows.Count > 0)
            {
                
                if (e.ColumnIndex > 11)
                {

                    dtLista.Columns[e.ColumnIndex].Visible = false;

                }

                if (dtLista.Columns[e.ColumnIndex].Name.Equals("Compra") ||
                    dtLista.Columns[e.ColumnIndex].Name.Equals("Venta")||
                    dtLista.Columns[e.ColumnIndex].Name.Equals("VentaConIVA"))
                {
                 //   dtLista.Columns["Compra"].Width = 110;
                  //  dtLista.Columns["Venta"].Width = 110;
                    System.Windows.Forms.DataGridViewCellStyle dataCurrency = new System.Windows.Forms.DataGridViewCellStyle();

                    dataCurrency.Format = "C4";
                    dataCurrency.NullValue = "0.0";
                    dtLista.Columns["Compra"].DefaultCellStyle = dataCurrency;
                    dtLista.Columns["Venta"].DefaultCellStyle = dataCurrency;
                    dtLista.Columns["VentaConIVA"].DefaultCellStyle = dataCurrency;
                }

                // Set the background to red for negative values in the Balance column. 
                if (dtLista.Columns[e.ColumnIndex].Name.Equals("Stock"))
                {
                   // dtLista.Columns[e.ColumnIndex].Width = 70;
                    if (Convert.ToInt32(e.Value) <= addProducto.getCantidadMinima())
                    {
                        e.CellStyle.BackColor = Color.DarkOrange;
                        e.CellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
                        e.CellStyle.BackColor = Color.DarkOrange;
                        e.CellStyle.ForeColor = Color.Red;
                    }
                }

                //if (this.dtLista.Columns[e.ColumnIndex].Name.Equals("Codigo"))
                //{

                //    dtLista.Columns[e.ColumnIndex].Width = -1;
                   
                //}

            }

        }
       
        #endregion 
        NProducto addProducto = new NProducto();
        ENBusqueda tbusqueda;
        ENBusquedaOpcion topcion;
        NProveedor getProveedor = new NProveedor();


        List<Datos.TProducto_Caracteristica_Foreign> lista = new List<Datos.TProducto_Caracteristica_Foreign>();

        DataTable TLista = new DataTable();

        DataRow fila;

        int filasPagina = 14; // Definimos el numero de filas que deseamos ver por pagina, tambien puede leerse desde un archivo de configuracion.
        int nroPagina = 1;//Esto define el numero de pagina actual en al que  nos encontramos
        int ini = 0; //inicio del paginado
        int fin = 0;//fin del paginado

        int numeroRegistro;

        enum ENBusqueda
        {

            Seleccione = 0,
            Nombre = 1,
            Descripcion = 2,
            Tamanio = 3,
            Color = 4,
            Categoria = 5,
            Unidad = 6,
            Stock = 7,
            StockMinimo = 8,
            Compra = 9,
            Venta = 10,
            IVA = 11,
            Marca = 12
        }

        enum ENBusquedaOpcion
        {

            Seleccione = 0,
            Mayor = 1,
            Menor = 2,
            Si = 3,
            No = 4
        }



        #region Hilo

       
        
        BackgroundWorker bgw = new BackgroundWorker();

        void bgw_DoWork(ENBusqueda nprov)
        {
            Cursor.Current = Cursors.WaitCursor;
            Lista(nprov);

        }

        void bgw_DoWork(ENBusqueda nprov,ENBusquedaOpcion nopc)
        {
            rbbMain.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            Lista(nprov,nopc);

        }
    
        
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Lista();
            
            
           
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            rbbMain.Enabled = true;
            panelPreview.Visible = false;
            Cursor.Current = Cursors.AppStarting;
            if (lista.Count > 0)
            {
                bndPagActual.Text = "1";
                paginar();
            }
            dtLista.Select();
        }
       

        public void LoadData()
        {   bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            //bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            //bgw.WorkerReportsProgress = true;
            bgw.RunWorkerAsync();

            
        }
      
          void LoadData(ENBusqueda nprov)
        {  

            bgw.DoWork += (obj, e) => bgw_DoWork(nprov);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
          
             bgw.RunWorkerAsync();
        }

          void LoadData(ENBusqueda nprov, ENBusquedaOpcion nopc)
         {

             bgw.DoWork += (obj, e) => bgw_DoWork(nprov);
             bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);

             bgw.RunWorkerAsync();
         }
        #endregion


        public FormDataProductos()
        {
            //rbbMain.Enabled = false;
            InitializeComponent();
           
           // cmbBusqueda.DataBindings.Add("SelectedItem",Enum.GetValues(typeof(Negocios.ETProducto)),"SelectedItem");

            //string alfa=Enum.GetName(cmbBusqueda.SelectedValue,alfa);
           // this.dtLista.CellContentClick +=
             //   new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);

          // dtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;


            loadColumn();

            //dtLista.VirtualMode = true;
          // dtLista.Visible = false;
           
          //Thread t = new Thread(new ThreadStart(LoadData));
          //t.IsBackground = true;
            //t.Start();
           //t.Join();
                //rbbMain.Enabled = true;

            //CancellationTokenSource cts = new CancellationTokenSource();
            //Task t = Task.Factory.StartNew(() => LoadData());
            //Task t2 = Task.Factory.ContinueWhenAll(LoadData(t));
            LoadData();

            //Lista();
           // rbbMain.Enabled = true;
            //panelPreview.Visible = false;
          
        }


       
     
       
        private void FormDataProductos_Load(object sender, EventArgs e)
        {


            try
            {

                cmbBusqueda.DataSource = Enum.GetValues(typeof(ENBusqueda));
                cmbBusqSec.Visible = true;
                cmbBusqSec.Items.Add("Seleccione");
                cmbBusqSec.Items.Add("Mayor");
                cmbBusqSec.Items.Add("Menor");
                cmbBusqSec.Items.Add("Si");
                cmbBusqSec.Items.Add("No");

                //Thread t = new Thread(new ThreadStart(LoadData));
                //t.Start();
                //t.Join();
                //Task t = Task.Factory.StartNew(() =>LoadData());
                // dtLista.Visible = false;


                this.dtLista.CellFormatting += this.dtLista_CellFormatting;
                this.dtLista.CellContentClick += dtLista_CellContentClick;
                //ThreadPool.QueueUserWorkItem(new WaitCallback(o => LoadData()));

                // dtLista.VirtualMode = true;



                this.bndUltimo.Click += new System.EventHandler(this.bindingNavigatorMoveLastItem_Click);
                this.bndSiguiente.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
                this.bndPrimero.Click += new System.EventHandler(this.bindingNavigatorMoveFirstItem_Click);
                this.bndAtras.Click += new System.EventHandler(this.bindingNavigatorMovePreviousItem_Click);

                this.bndPagActual.TextChanged += new System.EventHandler(this.bndPagActual_TextChanged);
                // dtLista.AllowUserToResizeColumns = false;


                //this.LoadData();

                FormMDI.usuarioValido(btnEditar);
                FormMDI.usuarioValido(btnEliminar);
            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message);
            
            
            }
           
        }

        public void loadColumn()
        {
            List<String> col = new List<string>();
            col.Add("Codigo");
            col.Add("CodProd");
            col.Add("Nombre");
            col.Add("IVA");
            col.Add("Categoria");
            col.Add("StockMin");
            col.Add("Stock");
            col.Add("Compra");
            
            col.Add("Venta");
            col.Add("VentaConIVA");
            col.Add("Unidad");
            col.Add("Marca");


            col.Add("Descripcion");
            col.Add("CodDcar");

            foreach (String mn in col)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.Name = mn;
                column.HeaderText = mn;
                if (mn.Equals("Nombre"))
                {
                    column.Width = 200;
                }
                column.CellTemplate = cell;
                dtLista.Columns.Add(column);

            }

            foreach (DataGridViewColumn mn in dtLista.Columns)
            {
                if (mn.HeaderText.Equals("Codigo"))
                {
                    mn.Visible = false;

                }
                if (mn.HeaderText.Equals("CodProd"))
                {
                    mn.Width = 80;

                }
                if (mn.HeaderText.Equals("Nombre"))
                {
                    mn.Width = 200;

                }
                if (mn.HeaderText.Equals("IVA"))
                {
                    mn.Width = 50;

                }
                if (mn.HeaderText.Equals("Compra"))
                {
                    mn.Width = 80;

                }
                
                if (mn.HeaderText.Equals("Venta"))
                {
                    mn.Width = 85;

                }
                if (mn.HeaderText.Equals("VentaConIVA"))
                {
                    mn.Width = 85;
                    dtLista.Columns["VentaConIVA"].HeaderText = "Venta+IVA";

                }
                if (mn.HeaderText.Equals("Stock"))
                {
                    mn.Width = 75;

                }
                if (mn.HeaderText.Equals("StockMin"))
                {
                    mn.Visible = false;

                }
                if (mn.HeaderText.Equals("Unidad"))
                {
                    mn.Visible = false;

                }
                if (mn.HeaderText.Equals("Marca"))
                {
                    mn.Width = 120;

                }
                if (mn.HeaderText.Equals("Categoria"))
                {
                    mn.Width = 100;

                }
                if (mn.HeaderText.Equals("Descripcion"))
                {
                    mn.Width = 100;

                }
                

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

                   if(dtLista.Rows.Count>0)
                       dtLista.Rows.Clear();
            //int indiceInsertar;//
            numeroRegistro = this.ini;
            for (int i = ini; i < fin; i++)
            {

                dtLista.Rows.Add(1);
 
                fila = TLista.Rows[i];


               

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
                    dtLista.Rows[indiceInsertar].Cells[8].Value = fila[8];
                    dtLista.Rows[indiceInsertar].Cells[9].Value = fila[9];
                    dtLista.Rows[indiceInsertar].Cells[10].Value = fila[10];
                    dtLista.Rows[indiceInsertar].Cells[11].Value = fila[11];
                    dtLista.Rows[indiceInsertar].Cells[12].Value = fila[12];
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


       

        private void Lista()
        {
            
            //MessageBox.Show("Lista");
            try
            {

                //this.bndSource.DataSource =this.addProducto.Listar(txtBuscar.Text);
                //this.dtLista.DataSource = this.addProducto.Listar(txtBuscar.Text);



                lista = this.addProducto.Listar(txtBuscar.Text);
                TLista = addProducto.LINQToDataTable(lista.AsEnumerable());
                if (lista.Count > 0)
                {
                    this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista

                    lblCantidad.Text = "Productos: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                    paginar();//empezamos con la paginacion
                    dtLista.Focus();
                }
                else
                {
                    dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                    lblCantidad.Text = "Productos: 0 ";//Cantidad totoal de registros encontrados
                    bndPagActual.Text = "1";
                }

                //  MessageBox.Show(this.addProducto.Listar("").Count + "--");




            }

            catch (Exception ex)
            {

                if (!ex.Message.Contains("subproceso"))
                {
                    MessageBox.Show(ex.Message);
                    Datos.Excepciones.Gestionar(ex);
                }
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

                    //this.bndSource.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().Trim());
                    //this.dtLista.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().Trim());
                    lista = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().Trim());
                    TLista = addProducto.LINQToDataTable(lista.AsEnumerable());
                    if (lista.Count > 0)
                    {
                        this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                        this.paginar();//empezamos con la paginacion
                        lblCantidad.Text = "Productos: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                        dtLista.Focus();
                    }
                    else
                    {
                        dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                        lblCantidad.Text = "Productos: 0 ";//Cantidad totoal de registros encontrados
                        bndPagActual.Text = "1";
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
                if (nprov.ToString().TrimEnd().Equals("IVA"))
                {


                    //this.bndSource.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());

                    //this.dtLista.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());

                    lista = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());
                    TLista = addProducto.LINQToDataTable(lista.AsEnumerable());
                    if (lista.Count > 0)
                    {
                        this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                        this.paginar();//empezamos con la paginacion
                        lblCantidad.Text = "Productos: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                        dtLista.Focus();
                    }
                    else
                    {
                        dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                        lblCantidad.Text = "Productos: 0 ";//Cantidad totoal de registros encontrados
                        bndPagActual.Text = "1";
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


                       //this.bndSource.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());

                        //this.dtLista.DataSource = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd());
                        lista = this.addProducto.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd(), nopc.ToString().TrimEnd()); 
                   TLista = addProducto.LINQToDataTable(lista.AsEnumerable());
                    if (lista.Count > 0)
                    {
                        this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                        this.paginar();//empezamos con la paginacion
                        lblCantidad.Text = "Productos: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                        dtLista.Focus();
                    }
                    else
                    {
                        dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                        lblCantidad.Text = "Productos: 0 ";//Cantidad totoal de registros encontrados
                        bndPagActual.Text = "1";
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

            

            if (cmbBusqueda.SelectedIndex == 0 && txtBuscar.Text.Length>0)
            {
                //txtBuscar.Text = "";
                this.Lista();
                cmbBusqSec.Enabled = false;
            }

            if (cmbBusqueda.SelectedIndex != 0 && !(cmbBusqueda.SelectedIndex >=7 &&cmbBusqueda.SelectedIndex <=10))
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
                txtBuscar.MaxLength = 270;
                cmbBusqSec.Enabled = false;
                cmbBusqSec.SelectedItem = "Seleccione";
              
                 //cmbBusqSec.SelectedItem = "Seleccione";
               // this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
              
            }
            if (cmbBusqueda.SelectedIndex==11)
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
                this.Lista(tbusqueda,topcion);
               

            
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            GridSeleccion = false;
           // panelPreview.Visible = true;
            this.Hide();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            
          
            }

        private void FormDataProductos_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dtLista.Focus();
            try
            {
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int dc1=(int)this.dtLista.CurrentRow.Cells[12].Value;
                     int dc2= 
                        new NProducto_Caracteristica().getDatos(Convert.ToInt32(this.dtLista.CurrentRow.Cells[0].Value)).dcar_codigo;
                     if (dc1 > 0 && dc1 == dc2)
                     {
                         new NDetalleCaracteristica().EliminarDetalle(dc1);
                         new NProducto_Caracteristica().Eliminar(dc1);

                     }
                     else
                     {
                         if (dc2 > 0 )
                         {
                             new NDetalleCaracteristica().EliminarDetalle(dc2);
                             new NProducto_Caracteristica().Eliminar(dc2);

                         }
                     
                     }
                    
                    this.addProducto.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    
                    this.Lista();

                }

            }
            catch  (System.Data.SqlClient.SqlException ex)
            {

                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(Datos.Excepciones.MensajePersonalizado,"Error.. Atencion..!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {

                FormProducto frm = new FormProducto();
                frm.nuevo = true;

                frm.editar = false;
                frm.inicioIngresoR();
                frm.dtNombre.Focus();
                frm.dtNombre.CurrentCell = frm.dtNombre.Rows[0].Cells[0];
                frm.dtNombre.EndEdit();
                frm.ShowDialog();


                this.Lista();
            }
            catch (Exception ex){
                Datos.Excepciones.Gestionar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                FormProducto frm = new FormProducto();
                dtLista.Focus();
                var t = this.addProducto.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

               

                frm.editar = true;
               
                frm.txtCodigo.Text = "0000" + t.Codigo.ToString();
             
                frm.fillProducto((int)t.Codigo);
                

               
               
                

                frm.btnNuevo.Text = "Editar";
                frm.dtNombre.Focus();
                frm.ShowDialog();

               // System.Threading.Thread.Sleep(10);
                this.Lista();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDataProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (GridSeleccion)
            //{
            //    Producto.FormProducto.Prod_principal.Show();
            //    GridSeleccion = false;
            //}
            GridSeleccion = false;
          //  panelPreview.Visible = true;
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


     

        private void btnVer_Click(object sender, EventArgs e)
        {
            try
            {
                FormProducto frm = new FormProducto();
               

                var t = this.addProducto.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                

                frm.ver = true;
                frm.editar = true;

                frm.txtCodigo.Text = "0000" + t.Codigo.ToString();
                frm.tciVer.Visible = true;
                frm.fillVista((int)t.Codigo);
                frm.fillProducto((int)t.Codigo);


               // frm.txtCodigo.Text = "0000" + t.Codigo.ToString();
               // frm.txtNombre.Text = t.Nombre;
               // frm.txtCategoria.Text = t.Categoria;
               // //frm.cmbColor.SelectedText = t.Color;
               //// frm.cmbTamanio.SelectedText = t.Tamanio;
               // frm.txtUnidad.Text = t.Unidad;

               // frm.txtStock.Text = "" + t.Stock;
               // frm.txtStockMin.Text = "" + t.StockMin;
               // frm.txtVenta.Text = "" + t.Venta;
               // frm.txtCompra.Text = "" + t.Compra;
               // frm.txtDescripcion.Text = t.Descripcion;
               // frm.chkIva.CheckState = t.IVA == 'S' ? CheckState.Checked : CheckState.Unchecked;
               // frm.chkPrecioVenta.CheckState = CheckState.Unchecked;
               // frm.txtMarca.Text = t.Marca;


                frm.btnNuevo.Text = "Habilitar Edicion";
                frm.btnNuevo.Visible = true;


                frm.pnlTab1.Enabled = false;
                frm.pnlTab2.Enabled = false;
                frm.pnlTab3.Enabled = false;
                //frm.chkPrecioVenta.Visible = false;
                //frm.label14.Visible = false;
               
               
                   
                   frm.ShowDialog();
                //this.LoadData();
                  
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (Convert.ToInt32(bndPagTotal.Text) > 1)
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
             if (!String.IsNullOrEmpty(txtBuscar.Text))
            {
                if (e.KeyCode == Keys.Enter)
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
                            txtBuscar.Focus();


                        }


                    }
                    else
                    {


                        tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                        this.Lista(tbusqueda);
                        cmbBusqSec.Enabled = false;
                        txtBuscar.Focus();
                        //MessageBox.Show("----"+tbusqueda);
                    }
                }

            }
            else
            {
               // tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), "Seleccione");
                this.Lista();
                txtBuscar.Focus();
            }
        }
       

       

     

    }
}