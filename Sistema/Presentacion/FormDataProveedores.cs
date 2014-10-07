using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;


namespace Presentacion
{
    public partial class FormDataProveedores : Base.FormDataBusq
    {

        

        private static DataGridViewRow dtSeleccion;

       
        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataProveedores.dtSeleccion; }
            set { FormDataProveedores.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataProveedores.gridSeleccion; }
            set { FormDataProveedores.gridSeleccion = value; }
        }


       

       NProveedor addProveedor= new NProveedor();
        ENBusqueda tbusqueda;
        NCiudad getCiudad = new NCiudad();
        enum ENBusqueda
        {

            Seleccione = 0,
            Nombre = 1,
            
            Ciudad = 2,
            Telefono = 3,
            Celular = 4,
            Email = 5,
            Identificacion = -1
        }

        public FormDataProveedores()
        {
            InitializeComponent();
            //cmbBusqueda.DataBindings.Add("SelectedItem",Enum.GetValues(typeof(Negocios.ETProveedor)),"SelectedItem");
            cmbBusqueda.DataSource = Enum.GetValues(typeof(ENBusqueda));



            bndNavegador.Visible = false;
            lblCantidad.Visible = false;
            dtLista.Dock = DockStyle.Fill;
            cmbBusqSec.Visible = false;
            
            //string alfa=Enum.GetName(cmbBusqueda.SelectedValue,alfa);
          

           
           
           
        }
        private void FormDataProveedors_Load(object sender, EventArgs e)
        {
           
            this.Lista();
            this.dtLista.CellContentClick +=
              new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);
            cmbBusqSec.Visible = false;

            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
           

        }
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (gridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono el Proveedor : " + dtLista.Rows[e.RowIndex].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {

                    DtSeleccion = dtLista.Rows[e.RowIndex];

                   

                        // Venta.FormConsulta.Consulta.fillDatos(Convert.ToInt32(DtSeleccion.Cells[0].Value));
                       Pedido.FormPedido.PedidoP.fillDatos(Convert.ToInt32(DtSeleccion.Cells[0].Value));
                    
                    // Producto.FormProducto.Prod_principal.cmbDimension.SelectedValue = Convert.ToInt32(DtSeleccion.Cells[0].Value);
                    GridSeleccion = false;
                    this.Hide();
                    this.Close();

               
                  
              

                }
                else
                {
                    txtBuscar.Text = "";


                }

             
            }

        }
       
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
              

                this.dtLista.DataSource = this.addProveedor.Listar(this.txtBuscar.Text);

               
                this.dtLista.Columns[0].Visible = false;
            

            

            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    cmbBusqueda.SelectedIndex = 0;

                }
                else {
                    
                 this.dtLista.DataSource = this.addProveedor.Listar(this.txtBuscar.Text, nprov.ToString().TrimEnd());
                
                }



                this.dtLista.Columns[0].Visible = false;

                if (dtLista.RowCount < 0)
                {
                    cmbBusqueda.SelectedIndex = 0;
                }



            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBusqueda.SelectedIndex == 0)
            {
                txtBuscar.Text = "";
            }

            if (cmbBusqueda.SelectedIndex != 0)
            {
                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                this.Lista(tbusqueda);
              
                //MessageBox.Show("----"+tbusqueda);
            }

            if (cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Identificacion"))
            {
                txtBuscar.MaxLength = 15;

            }
            else
            {
                if (cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Telefono") || cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString().Equals("Celular"))
                {
                    txtBuscar.MaxLength = 10;

                }
                else
                {
                    txtBuscar.MaxLength = 300;
                }
            }
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {


            GridSeleccion = false;
                this.Hide();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cmbBusqueda.SelectedIndex == 0)
                this.Lista();
            else
            {
                this.Lista(tbusqueda);
            
            }
        }

        private void FormDataProveedors_Resize(object sender, EventArgs e)
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
                dtLista.Focus();
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.addProveedor.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    this.Lista();

                }

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Eliminar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            FormProveedor frm = new FormProveedor();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                dtLista.Focus();
                FormProveedor frm = new FormProveedor();
                var t = this.addProveedor.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text ="0000"+ t.Codigo.ToString();
                frm.txtNombre.Text = t.Nombre;
                
                frm.txtDireccion.Text = t.Direccion;
                frm.txtCiudad.Text = t.Ciudad;
                //MessageBox.Show(t.Ciudad);

                

                frm.txtTelefono.Text = t.Telefono;
                frm.txtCelular.Text = t.Celular;
                frm.txtEmail.Text =t.Email;
                frm.txtIdentificacion.Text=t.Identificacion;


                frm.btnNuevo.Text = "Editar";
                frm.ShowDialog();
                this.Lista();
            }
            catch (Exception)
            {

                MessageBox.Show("No se puede Editar\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
        }

        private void FormDataProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {

            GridSeleccion = false;
         
                this.Hide();
        }


       
    
    }
}
