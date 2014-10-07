using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Negocios;

namespace Presentacion.Producto
{
    public partial class FormSeleccionProducto : Presentacion.Base.FormBusqSeleccion
    {


        #region conexion
       

      

        private static string origen;

        public static string Origen
        {
            get { return FormSeleccionProducto.origen; }
            set { FormSeleccionProducto.origen = value; }
        }

        private static int fila=0;

        public static int Fila
        {
            get { return FormSeleccionProducto.fila; }
            set { FormSeleccionProducto.fila = value; }
        }


        private void dtLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dtLista.Rows.Count > 0)
            {
                #region seleccion
               

                    #region PRoducto
                    if (Origen.Equals("Producto"))
                    {
                        DialogResult dresult = (MessageBox.Show("Selecciono de Producto : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value,
                                                             "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                        if (dresult == DialogResult.OK)
                        {


                            
                            DataGridViewRow dtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index>-1?dtLista.CurrentRow.Index:0];


                            Producto.FormProducto.Prod_principal.Enabled = true;

                            Producto.FormProducto.Prod_principal.fillProductoSeleccion(Convert.ToInt32(dtSeleccion.Cells[0].Value));

                            Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[0];

                            Producto.FormProducto.Prod_principal.dtNombre.EndEdit();
                           

                            this.Hide();
                            this.Close();







                        }
                        if (dresult == DialogResult.Cancel)
                        {
                            txtBuscar.Text = "";
                            txtBuscar.Focus();

                        }
                    }
                    #endregion

                    #region Venta
                    if (Origen.Equals("Venta"))
                    {
                        DialogResult dresult = (MessageBox.Show("Selecciono de Producto : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value + "\n" + dtLista.Rows[dtLista.CurrentRow.Index].Cells[2].Value,
                                                             "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                        if (dresult == DialogResult.OK)
                        {


                            if (Fila > -1)
                            {
                                if (!Venta.FormVenta.VentaP.findProductoListByCodigo((dtLista.CurrentRow.Cells["CodProd"].Value + "")))
                                    Venta.FormVenta.VentaP.fillDatosProducto(dtLista.CurrentRow, Fila);
                                else
                                {
                                    MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                if (!Venta.FormVenta.VentaP.findProductoList(Convert.ToInt32(dtLista.Rows[0].Cells[0].Value)))
                                    Venta.FormVenta.VentaP.fillDatosProducto(dtLista.Rows[0]);
                                else
                                {
                                    MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            Venta.FormVenta.VentaP.Enabled = true;
                            
                            this.Hide();
                            this.Close();







                        }
                        if (dresult == DialogResult.Cancel)
                        {
                            txtBuscar.Text = "";
                            txtBuscar.Focus();

                        }
                    }
                    #endregion
                    #region Pedido
                    if (Origen.Equals("Pedido"))
                    {
                        DialogResult dresult = (MessageBox.Show("Selecciono de Producto : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value + "\n" + dtLista.Rows[dtLista.CurrentRow.Index].Cells[2].Value,
                                                             "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                        if (dresult == DialogResult.OK)
                        {


                            if (Fila > -1)
                            {
                                if (!Pedido.FormPedido.PedidoP.findProductoListByCodigo((dtLista.CurrentRow.Cells["CodProd"].Value + "")))
                                    Pedido.FormPedido.PedidoP.fillDatosProducto(dtLista.CurrentRow, Fila);
                                else
                                {
                                    MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            else
                            {
                                if (!Pedido.FormPedido.PedidoP.findProductoList(Convert.ToInt32(dtLista.Rows[0].Cells[0].Value)))
                                    Pedido.FormPedido.PedidoP.fillDatosProducto(dtLista.Rows[0]);
                                else
                                {
                                    MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            Pedido.FormPedido.PedidoP.Enabled = true;

                            this.Hide();
                            this.Close();

                        }
                        if (dresult == DialogResult.Cancel)
                        {
                            txtBuscar.Text = "";
                            txtBuscar.Focus();

                        }
                    }
                    #endregion


                #endregion

                

            }


        }
        
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            if ( dtLista.Rows.Count > 0)
            {
                #region seleccion


                #region PRoducto
                if (Origen.Equals("Producto"))
                {
                    DialogResult dresult = (MessageBox.Show("Selecciono de Producto : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value,
                                                         "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                    if (dresult == DialogResult.OK)
                    {



                        DataGridViewRow dtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index > -1 ? dtLista.CurrentRow.Index : 0];


                        Producto.FormProducto.Prod_principal.Enabled = true;

                        Producto.FormProducto.Prod_principal.fillProductoSeleccion(Convert.ToInt32(dtSeleccion.Cells[0].Value));

                        Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[0];

                        Producto.FormProducto.Prod_principal.dtNombre.EndEdit();


                        this.Hide();
                        this.Close();







                    }
                    if (dresult == DialogResult.Cancel)
                    {
                        txtBuscar.Text = "";
                        txtBuscar.Focus();

                    }
                }
                #endregion

                #region Venta
                if (Origen.Equals("Venta"))
                {
                    DialogResult dresult = (MessageBox.Show("Selecciono de Producto : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value + "\n" + dtLista.Rows[dtLista.CurrentRow.Index].Cells[2].Value,
                                                         "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                    if (dresult == DialogResult.OK)
                    {


                        if (Fila > -1)
                        {
                            if (!Venta.FormVenta.VentaP.findProductoListByCodigo((dtLista.CurrentRow.Cells["CodProd"].Value + "")))
                            {
                                Venta.FormVenta.VentaP.fillDatosProducto(dtLista.CurrentRow, Fila);
                               
                            }
                            else
                            {
                                MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            if (!Venta.FormVenta.VentaP.findProductoList(Convert.ToInt32(dtLista.Rows[0].Cells[0].Value)))
                            {
                                Venta.FormVenta.VentaP.fillDatosProducto(dtLista.Rows[0]);
                               
                              
                            }
                            else
                            {
                                MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        Venta.FormVenta.VentaP.Enabled = true;

                        this.Hide();
                        this.Close();







                    }
                    if (dresult == DialogResult.Cancel)
                    {
                        txtBuscar.Text = "";
                        txtBuscar.Focus();

                    }
                }
                #endregion
                #region Pedido
                if (Origen.Equals("Pedido"))
                {
                    DialogResult dresult = (MessageBox.Show("Selecciono de Producto : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value + "\n" + dtLista.Rows[dtLista.CurrentRow.Index].Cells[2].Value,
                                                         "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                    if (dresult == DialogResult.OK)
                    {


                        if (Fila > -1)
                        {
                            if (!Pedido.FormPedido.PedidoP.findProductoListByCodigo((dtLista.CurrentRow.Cells["CodProd"].Value + "")))
                                Pedido.FormPedido.PedidoP.fillDatosProducto(dtLista.CurrentRow, Fila);
                            else
                            {
                                MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            if (!Pedido.FormPedido.PedidoP.findProductoList(Convert.ToInt32(dtLista.Rows[0].Cells[0].Value)))
                                Pedido.FormPedido.PedidoP.fillDatosProducto(dtLista.Rows[0]);
                            else
                            {
                                MessageBox.Show("No se puede LLenar los Datos \n Ese producto ya existe ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        Pedido.FormPedido.PedidoP.Enabled = true;

                        this.Hide();
                        this.Close();

                    }
                    if (dresult == DialogResult.Cancel)
                    {
                        txtBuscar.Text = "";
                        txtBuscar.Focus();

                    }
                }
                #endregion


                #endregion




            }
        }


        #endregion
        NProducto getProducto = new NProducto();
        DataGridViewCellStyle styMarca;
        public void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {


                 this.dtLista.DataSource = this.getProducto.ListarSeleccion(txtBuscar.Text); 
                //  MessageBox.Show(this.addProducto.Listar("").Count + "--");

                if (dtLista.RowCount > 0)
                {
                    dtLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.dtLista.Columns["Codigo"].Visible = false;
                    this.dtLista.Columns["CodProd"].FillWeight = 50;
                    this.dtLista.Columns["Nombre"].FillWeight = 130;
                    this.dtLista.Columns["Stock"].FillWeight = 30;
                    this.dtLista.Columns["IVA"].FillWeight = 25;

                    this.dtLista.Columns["Unidad"].Visible = true;
                    this.dtLista.Columns["Marca"].Visible = true;
                    this.dtLista.Columns["Categoria"].Visible = false;
                    this.dtLista.Columns["Stock"].Visible = true;
                    this.dtLista.Columns["StockMin"].Visible = false;
                    this.dtLista.Columns["Descripcion"].Visible = false;
                    this.dtLista.Columns[13].Visible = false;

                   
                    System.Windows.Forms.DataGridViewCellStyle dataCurrency = new System.Windows.Forms.DataGridViewCellStyle();

                    dataCurrency.Format = "C2";
                    dataCurrency.NullValue = "0.0";
                    dtLista.Columns["Compra"].DefaultCellStyle = dataCurrency;
                    dtLista.Columns["Compra"].Width = 40;
                    dtLista.Columns["Venta"].DefaultCellStyle = dataCurrency;
                    dtLista.Columns["Venta"].Width = 45;
                    dtLista.Columns["VentaConIVA"].DefaultCellStyle = dataCurrency;
                    dtLista.Columns["VentaConIVA"].Width = 55;
                
                    dtLista.Columns["VentaConIVA"].HeaderText = "Venta+IVA";
                    dtLista.Columns["Unidad"].Width = 40;
                    dtLista.Columns["Marca"].Width = 80;
                         
                }


            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message);
            }
        }

        private void dtLista_CellFormatting(object sender,System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            NProducto getProducto = new NProducto();
            if (dtLista.Columns[e.ColumnIndex].Name.Equals("Stock"))
            {
                // dtLista.Columns[e.ColumnIndex].Width = 70;
                if (Convert.ToInt32(e.Value) <= getProducto.getCantidadMinima())
                {
                    e.CellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
                    e.CellStyle.BackColor = Color.DarkOrange;
                    e.CellStyle.ForeColor = Color.Red;

                }

            }
            if (dtLista.Columns[e.ColumnIndex].Name.Equals("Marca"))
            {
                e.CellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif",7F,System.Drawing.FontStyle.Bold);
                e.CellStyle.ForeColor = Color.Black;
            }
        
        }

        public FormSeleccionProducto()
        {
            InitializeComponent();
        }

        private void FormSeleccionProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Origen =="Producto")
            {
                Producto.FormProducto.Prod_principal.Enabled = true;
            }
            if (Origen =="Venta")
            {
                Venta.FormVenta.VentaP.Enabled = true;
            }
            if (Origen == "Pedido")
            {
                Pedido.FormPedido.PedidoP.Enabled = true;
            }
            this.Hide();
            this.Close();
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //this.Lista();
        }

        private void FormSeleccionProducto_Load(object sender, EventArgs e)
        {
            this.Lista();
            this.dtLista.CellContentClick +=
           new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);
            this.dtLista.KeyDown += new System.Windows.Forms.KeyEventHandler(dtLista_KeyDown);
            this.dtLista.CellFormatting += this.dtLista_CellFormatting;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (Origen =="Producto")
            {
                Producto.FormProducto.Prod_principal.Enabled = true;
            }
            if (Origen =="Venta")
            {
                Venta.FormVenta.VentaP.Enabled = true;
            }
            if (Origen == "Pedido")
            {
                Pedido.FormPedido.PedidoP.Enabled = true;
            }
            this.Hide();
            this.Close();
        }

       public void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                  this.Lista();
            
            }

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                this.Lista();

            }
        }
    }
}
