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
    public partial class FormDataCategorias : Base.FormData
    {
        #region conexion
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataCategorias.dtSeleccion; }
            set { FormDataCategorias.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataCategorias.gridSeleccion; }
            set { FormDataCategorias.gridSeleccion = value; }
        }
        private void dtLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter&& dtLista.Rows.Count > 0)
            {
                #region seleccion
                if (gridSeleccion)
                {
                    DialogResult dresult = (MessageBox.Show("Selecciono la Categoria : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value,
                                                          "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                    if (dresult == DialogResult.OK)
                    {




                        DtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index];
                      

                        GridSeleccion = false;

                        Producto.FormProducto.Prod_principal.Enabled = true;

                      
                            Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[3].Value = DtSeleccion.Cells[1].Value.ToString();


                            Producto.FormProducto.Prod_principal.dtNombre.Focus();

                            Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[3];
                            Producto.FormProducto.Prod_principal.dtNombre.EndEdit();

                        this.Hide();
                        System.Threading.Thread.Sleep(50);







                    }
                    else
                    {
                        txtBuscar.Text = "";
                        txtBuscar.Focus();

                    }

                #endregion

                }

            }
            if (e.KeyData.ToString().Equals("Delete") && dtLista.Rows.Count > 0)
            {

                btnEliminar_Click(sender, e);


            }

        }

        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            #region seleccion
            if (gridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono la Categoria : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {



                    DtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index];
                  

                    GridSeleccion = false;

                    Producto.FormProducto.Prod_principal.Enabled = true;

                        Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[3].Value = DtSeleccion.Cells[1].Value.ToString();


                        Producto.FormProducto.Prod_principal.dtNombre.Focus();

                        Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[3];
                        Producto.FormProducto.Prod_principal.dtNombre.EndEdit();
                    

                    this.Hide();
                    System.Threading.Thread.Sleep(50);






                   





                }
                else
                {
                    txtBuscar.Text = "";
                    txtBuscar.Focus();

                }

            #endregion
            }

        }
        
        
        
        #endregion 
        public FormDataCategorias()
        {
            InitializeComponent();
           
           
        }

        NCategoria addCategoria = new NCategoria();
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
                
                this.dtLista.DataSource = this.addCategoria.Listar(this.txtBuscar.Text);

                this.dtLista.Columns[0].HeaderText = "Codigo";

                this.dtLista.Columns[0].Width = 100;
                this.dtLista.Columns[1].HeaderText = "Nombre";
                
             


            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormCategoria frm = new FormCategoria();
            frm.nuevo = true;
           
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormCategoria frm = new FormCategoria();
              
                var t = this.addCategoria.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text ="0000"+ t.cat_codigo.ToString();
                frm.txtNombre.Text = t.cat_nombre;
                frm.btnNuevo.Text = "Editar";
                frm.ShowDialog();
                this.Lista();
            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Editar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.addCategoria.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    this.Lista();

                }

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Eliminar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          
                
            }
        }

       

        private void FormDataCategoria_Load(object sender, EventArgs e)
        {
            this.Lista();
             this.dtLista.CellContentClick +=
               new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);
            this.dtLista.KeyDown+=  new System.Windows.Forms.KeyEventHandler(dtLista_KeyDown);

            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            if (GridSeleccion)
            {
                GridSeleccion = false;
                Producto.FormProducto.Prod_principal.Enabled = true;

            }
                this.Hide();
        
        
        }

        private void FormDataCategoria_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void FormDataCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSeleccion = false;
            this.Hide();
            Producto.FormProducto.Prod_principal.Enabled = true;
        }
    }
}