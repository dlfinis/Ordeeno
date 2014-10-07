using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Producto
{
    public partial class FormDataUnidades : Base.FormData
    {


        #region conexion
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataUnidades.dtSeleccion; }
            set { FormDataUnidades.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataUnidades.gridSeleccion; }
            set { FormDataUnidades.gridSeleccion = value; }
        }
        private void dtLista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && dtLista.Rows.Count > 0)
            {
                #region seleccion
                if (gridSeleccion)
                {
                    DialogResult dresult = (MessageBox.Show("Selecciono la Unidad : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value,
                                                          "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                    if (dresult == DialogResult.OK)
                    {




                        DtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index];

                        GridSeleccion = false;

                        Producto.FormProducto.Prod_principal.Enabled = true;

                        Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[4].Value = DtSeleccion.Cells[1].Value.ToString();


                        Producto.FormProducto.Prod_principal.dtNombre.Focus();

                        Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[4];
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
                DialogResult dresult = (MessageBox.Show("Selecciono la Unidad : " + dtLista.Rows[dtLista.CurrentRow.Index].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {




                    DtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index];
                  
                    GridSeleccion = false;

                    Producto.FormProducto.Prod_principal.Enabled = true;

                        Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[4].Value = DtSeleccion.Cells[1].Value.ToString();


                        Producto.FormProducto.Prod_principal.dtNombre.Focus();

                        Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtNombre.Rows[0].Cells[4];
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
        public FormDataUnidades()
        {
            InitializeComponent();
        }

        NUnidad addUnidad = new NUnidad();
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
                

                this.dtLista.DataSource = this.addUnidad.Listar(this.txtBuscar.Text);

                this.dtLista.Columns[0].HeaderText = "Codigo";

                this.dtLista.Columns[0].Width = 90;
                this.dtLista.Columns[1].HeaderText = "Nombre"; 
             
                this.dtLista.Columns[2].HeaderText = "Prefijo";
                this.dtLista.Columns[2].Width = 70;
            

                // segundo asignarle que se centre el texto de la columna


            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDataUnidades_Load(object sender, EventArgs e)
        {
            this.Lista();
            this.dtLista.CellContentClick +=
              new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);
            this.dtLista.KeyDown += new System.Windows.Forms.KeyEventHandler(dtLista_KeyDown);
            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormUnidad frm = new FormUnidad();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormUnidad frm = new FormUnidad();
                var t = this.addUnidad.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text ="00000"+ t.uni_codigo.ToString();
                frm.txtNombre.Text = t.uni_nombre;
                frm.txtPrefijo.Text = t.uni_prefijo;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.addUnidad.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    this.Lista();

                }

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Eliminar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            GridSeleccion = false;
            this.Hide();
        }

        private void FormDataUnidades_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void FormDataUnidades_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSeleccion = false;
        }


    }
}
