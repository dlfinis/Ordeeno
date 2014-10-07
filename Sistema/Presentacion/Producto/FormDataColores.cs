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
    public partial class FormDataColores : Base.FormData
    {
        #region conexion
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataColores.dtSeleccion; }
            set { FormDataColores.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataColores.gridSeleccion; }
            set { FormDataColores.gridSeleccion = value; }
        }
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (GridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono la Colore: " + dtLista.Rows[e.RowIndex].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {
                    DtSeleccion = dtLista.Rows[e.RowIndex];

                   // Producto.FormProducto.Prod_principal.cmbColor.SelectedValue = Convert.ToInt32(DtSeleccion.Cells[0].Value);
                    GridSeleccion = false; this.Hide();

                }
                else
                {
                    txtBuscar.Text = "";


                }


            }

        }
        #endregion 
        
        public FormDataColores()
        {
            InitializeComponent();
        }

        NColor addColor = new NColor();
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
                

                this.dtLista.DataSource = this.addColor.Listar(this.txtBuscar.Text);


                this.dtLista.Columns[0].HeaderText = "Codigo";
                this.dtLista.Columns[0].Width = 100;
                this.dtLista.Columns[1].HeaderText = "Nombre";
               
             

                // segundo asignarle que se centre el texto de la columna


            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar los Datos \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDataColores_Load(object sender, EventArgs e)
        {
            this.Lista();
            this.dtLista.CellContentClick +=
              new System.Windows.Forms.DataGridViewCellEventHandler(this.dtLista_CellContentClick);
            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormColor frm = new FormColor();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormColor frm = new FormColor();
                var t = this.addColor.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text ="0000"+ t.col_codigo.ToString();
                frm.txtNombre.Text = t.col_nombre;
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
                    this.addColor.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
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

        private void FormDataColores_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void FormDataColores_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSeleccion = false;
            this.Hide();
        }

        
    }
}
