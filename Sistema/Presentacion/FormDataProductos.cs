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

namespace Presentacion.Producto
{
    public partial class FormDataProductos :Base.FormDataBusq
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
                   // Producto.FormProducto.Prod_principal.cmbDimension.SelectedValue = Convert.ToInt32(DtSeleccion.Cells[0].Value);
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
          
            if (this.dtLista.Columns[e.ColumnIndex].Name.Equals("IVA"))
            {

                dtLista.Columns[e.ColumnIndex].Width = 35;
            }

            
                if (e.ColumnIndex==0)
                {

                    dtLista.Columns[e.ColumnIndex].Visible = false;
                }


                if (e.ColumnIndex == 1)
                {

                    dtLista.Columns[e.ColumnIndex].Width = 75;
                }
         


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
        NProducto addProducto = new NProducto();
        ENBusqueda tbusqueda;
        ENBusquedaOpcion topcion;
        NProveedor getProveedor = new NProveedor();


        List<Datos.TProducto_Caracteristica_Foreign> lista = new List<Datos.TProducto_Caracteristica_Foreign>();

        DataTable TLista = new DataTable();

        DataRow fila;

        int filasPagina = 15; // Definimos el numero de filas que deseamos ver por pagina, tambien puede leerse desde un archivo de configuracion.
        int nroPagina = 1;//Esto define el numero de pagina actual en al que  nos encontramos
        int ini = 0; //inicio del paginado
        int fin = 0;//fin del paginado

        int numeroRegistro;

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


        void LoadUI()
        {


            if (this.ribbonBar1.InvokeRequired)
            {

                Thread.SpinWait(5);
                ribbonBar1.Invoke(new MethodInvoker(this.LoadUIComplete));

            }

        }

        void LoadData()
        {


            if (this.dtLista.InvokeRequired)
            {
                Thread.SpinWait(10);
                dtLista.Invoke(new MethodInvoker(this.LoadDataComplete));

            }

        }

        void LoadUIComplete()
        {


            //this.Lista();
            // Thread.Sleep(10);
            this.ribbonBar1.Visible = true;

        }

        void LoadDataComplete()
        {

            this.Lista();
            dtLista.Visible = true;
        }
        #endregion


        public FormDataProductos()
        {
           
            InitializeComponent();
         
            //cmbBusqueda.DataBindings.Add("SelectedItem",Enum.GetValues(typeof(Negocios.ETProducto)),"SelectedItem");

            //string alfa=Enum.GetName(cmbBusqueda.SelectedValue,alfa);
           // this.dtLista.CellContentClick +=
               // new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);

           // dtLista.ScrollBars = System.Windows.Forms.ScrollBars.None;


            loadColumn();
           

               
            
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
            col.Add("Unidad");
            col.Add("Marca");

           
            col.Add("Descripcion");
            col.Add("CodDcar");
           
            foreach(String mn in col)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                column.Name = mn;
                column.HeaderText = mn;

                column.CellTemplate = cell;
                dtLista.Columns.Add(column);
                
            }
           

        }
     
       
        private void FormDataProductos_Load(object sender, EventArgs e)
        {
   

           
            cmbBusqueda.DataSource = Enum.GetValues(typeof(ENBusqueda));
            cmbBusqSec.Visible = true;
            cmbBusqSec.Items.Add("Seleccione");
            cmbBusqSec.Items.Add("Mayor");
            cmbBusqSec.Items.Add("Menor");
            cmbBusqSec.Items.Add("Si");
            cmbBusqSec.Items.Add("No");

           // dtLista.Visible = false;
           
           
            ThreadPool.QueueUserWorkItem(new WaitCallback(o => LoadUI()));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(o => LoadData()));
            //this.dtLista.CellFormatting += this.dtLista_CellFormatting;
            //this.dtLista.CellContentClick += dtLista_CellContentClick;
            //ThreadPool.QueueUserWorkItem(new WaitCallback(o => LoadData()));
          
           // dtLista.VirtualMode = true;
            Thread.SpinWait(15);
            panelPreview.Visible = false;

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
                    this.paginar();//empezamos con la paginacion
                    lblCantidad.Text = "Productos: " + lista.Count.ToString();//Cantidad totoal de registros encontrados
                    dtLista.Select();
                }
                else
                {
                    dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                    lblCantidad.Text = "Productos: 0 ";//Cantidad totoal de registros encontrados

                }

                //  MessageBox.Show(this.addProducto.Listar("").Count + "--");

                  if (dtLista.RowCount > 0)
                  {
                      this.dtLista.Columns[0].Visible = false;
                      this.dtLista.Columns[5].Visible = false;
                      this.dtLista.Columns[9].Visible = false;

                      this.dtLista.Columns[11].Visible = false;
                      this.dtLista.Columns[12].Visible = false;
                   
                      
                      System.Windows.Forms.DataGridViewCellStyle dataCurrency = new System.Windows.Forms.DataGridViewCellStyle();

                      dataCurrency.Format = "C4";
                      dataCurrency.NullValue = "0.0";
                      dtLista.Columns["Compra"].DefaultCellStyle = dataCurrency;
                      dtLista.Columns["Venta"].DefaultCellStyle = dataCurrency;


                  }
                 

            }

            catch (Exception ex)
            {

                MessageBox.Show( ex.Message);
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
                        dtLista.Select();
                    }
                    else
                    {
                        dtLista.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview
                        lblCantidad.Text = "Productos: 0 ";//Cantidad totoal de registros encontrados

                    }

                }
               
                if (dtLista.RowCount > 0)
                {
                    this.dtLista.Columns[0].Visible = false;
                    this.dtLista.Columns[5].Visible = false;
                    this.dtLista.Columns[9].Visible = false;

                    this.dtLista.Columns[11].Visible = false;
                    this.dtLista.Columns[12].Visible = false;
                   
                      
                }

            }

            catch (Exception ex)
            {

                //if (dtLista.RowCount <= 0)
                //{
                //    cmbBusqueda.SelectedIndex = 0;
                //}
                throw new Exception(ex.Message);

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
                
                    }
                }


                if (dtLista.RowCount > 0)
                {

                    this.dtLista.Columns[0].Visible = false;
                    this.dtLista.Columns[5].Visible = false;
                    this.dtLista.Columns[9].Visible = false;

                    this.dtLista.Columns[11].Visible = false;
                    this.dtLista.Columns[12].Visible = false;
                    this.dtLista.Columns[1].Width = 85;
                    this.dtLista.Columns[2].Width = 270;
                    
                }


                


            }

            catch (Exception)
            {

                throw new Exception();
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
                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), "Seleccione");
                this.Lista(tbusqueda);
            }
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
                MessageBox.Show(Datos.Excepciones.MensajePersonalizado);
            }
            
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormProducto frm = new FormProducto();
            frm.nuevo = true;
           

            frm.inicioIngresoR();
            frm.dtNombre.Focus();
            frm.dtNombre.CurrentCell= frm.dtNombre.Rows[0].Cells[0];
            frm.dtNombre.EndEdit();
            frm.ShowDialog();
            
            
            System.Threading.Thread.Sleep(10);
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
             
                frm.fillProducto((int)t.Codigo);
                

               
               
                

                frm.btnNuevo.Text = "Editar";
                frm.dtNombre.Focus();
                frm.ShowDialog();

                System.Threading.Thread.Sleep(10);
                this.Lista();
            }
            catch (Exception ex)
            {

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
               //// frm.cmbDimension.SelectedText = t.Dimension;
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
                //this.Lista();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bndPagTotal.Text) > 1)
            {
                this.nroPagina = 1;
                bndPagActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt32(bndPagActual.Text) > 1)
            {
                this.nroPagina -= 1;
                bndPagActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bndPagActual.Text) < Convert.ToInt32(bndPagTotal.Text))
            {
                this.nroPagina += 1;
                bndPagActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(bndPagTotal.Text) > 1)
            {
                this.nroPagina = Convert.ToInt32(bndPagTotal.Text);
                bndPagActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }
       

       

     

    }
}