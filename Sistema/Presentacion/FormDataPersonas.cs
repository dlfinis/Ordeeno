using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Negocios;

namespace Presentacion
{
    public partial class FormDataPersonas : Base.FormDataBusq
    {

        #region conexion

        private static String origen;

        public static String Origen
        {
            get { return FormDataPersonas.origen; }
            set { FormDataPersonas.origen = value; }
        }
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataPersonas.dtSeleccion; }
            set { FormDataPersonas.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataPersonas.gridSeleccion; }
            set { FormDataPersonas.gridSeleccion = value; }
        }
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (GridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono a la Persona : " + dtLista.Rows[e.RowIndex].Cells[1].Value + " " + dtLista.Rows[e.RowIndex].Cells[2].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {
                    DtSeleccion = dtLista.Rows[e.RowIndex];

                    if (Origen == "Venta")
                    {

                       // Venta.FormConsulta.Consulta.fillDatos(Convert.ToInt32(DtSeleccion.Cells[0].Value));
                        Venta.FormVenta.VentaP.fillDatos(Convert.ToInt32(DtSeleccion.Cells[0].Value));
                    }
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

        

        #endregion 
        
        NPersona addPersona = new NPersona();
        ENBusqueda tbusqueda;
        NCiudad getCiudad = new NCiudad();
        enum ENBusqueda
        {

            Seleccione = 0,
            Nombre = 1,
            Apellido = 2,
            Ciudad = 3,
            Telefono = 4,
            Celular = 5,

            Identificacion = -1
        }
        public FormDataPersonas()
        {
            InitializeComponent();
            //cmbBusqueda.DataBindings.Add("SelectedItem",Enum.GetValues(typeof(Negocios.ETPersona)),"SelectedItem");

            bndNavegador.Visible = false;
            lblCantidad.Visible = false;
            dtLista.Dock = DockStyle.Fill;
            cmbBusqSec.Visible = false;
          
         
            
            //string alfa=Enum.GetName(cmbBusqueda.SelectedValue,alfa);
        }

       
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
               
                this.dtLista.DataSource = this.addPersona.Listar(this.txtBuscar.Text);

               
                this.dtLista.Columns[0].Visible = false;
               
               

            

            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Lista(ENBusqueda nper)
        {
            //MessageBox.Show("Lista");
            try
            {
               


                if (String.IsNullOrEmpty(this.txtBuscar.Text.Trim()))
                {
                    Lista();
                    cmbBusqueda.SelectedItem = 0;

                }
                else {
                    
                 this.dtLista.DataSource = this.addPersona.Listar(this.txtBuscar.Text, nper.ToString().TrimEnd());
                
                }



                this.dtLista.Columns[0].Visible = false;
            
                //if (dtLista.RowCount <= 0)
                //{
                //    cmbBusqueda.SelectedIndex = 0;
                //}



            }

           catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (dtLista.RowCount <= 0)
                {
                    cmbBusqueda.SelectedIndex = 0;
                }
            }

              
            
        }

        private void FormDataPersonas_Load(object sender, EventArgs e)
        {
           
            this.Lista();


            cmbBusqueda.DataSource = Enum.GetValues(typeof(ENBusqueda));
            this.dtLista.CellContentClick += dtLista_CellContentClick;
                  
            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbBusqueda.SelectedIndex != 0)
            {
                tbusqueda = (ENBusqueda)Enum.Parse(typeof(ENBusqueda), cmbBusqueda.Items[cmbBusqueda.SelectedIndex].ToString());
                this.Lista(tbusqueda);
              
                //MessageBox.Show("----"+tbusqueda);
            }
           
            if (cmbBusqueda.SelectedText.Equals("Identificacion") )
            {
                txtBuscar.MaxLength = 15;

            }
            else
            {
                if (cmbBusqueda.SelectedText.Equals("Telefono") || cmbBusqueda.SelectedText.Equals("Celular"))
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

        private void FormDataPersonas_Resize(object sender, EventArgs e)
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
                    this.addPersona.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
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

            FormPersona frm = new FormPersona();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormPersona frm = new FormPersona();
                var t = this.addPersona.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text ="0000"+ t.Codigo.ToString();
                frm.txtNombre.Text = t.Nombre;
                frm.txtApellido.Text = t.Apellido;
                frm.txtDireccion.Text = t.Direccion;
                frm.txtCiudad.Text = t.Ciudad;
                //MessageBox.Show(t.Ciudad);

                

                frm.txtTelefono.Text = t.Telefono;
                frm.txtCelular.Text = t.Celular;
                frm.txtIdentificacion.Text = t.Identificacion;


                frm.btnNuevo.Text = "Editar";
                frm.ShowDialog();
                this.Lista();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDataPersonas_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }
    }
}
