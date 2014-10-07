using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;

namespace Presentacion.Producto
{
    public partial class FormDataCaracteristicas : Base.FormData
    {
         #region conexion
        private static DataGridViewRow dtSeleccion;


        public static DataGridViewRow DtSeleccion
        {
            get { return FormDataCaracteristicas.dtSeleccion; }
            set { FormDataCaracteristicas.dtSeleccion = value; }
        }

        private static bool gridSeleccion;

        public static bool GridSeleccion
        {
            get { return FormDataCaracteristicas.gridSeleccion; }
            set { FormDataCaracteristicas.gridSeleccion = value; }
        }
        private void dtLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (GridSeleccion)
            {
                DialogResult dresult = (MessageBox.Show("Selecciono la Caracteristicas: " + dtLista.Rows[e.RowIndex].Cells[1].Value,
                                                      "Seleccion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1));
                if (dresult == DialogResult.OK)
                {
                    DtSeleccion = dtLista.Rows[dtLista.CurrentRow.Index];

                    GridSeleccion = false;

                    Producto.FormProducto.Prod_principal.Enabled = true;


                    Producto.FormProducto.Prod_principal.dtCaracteristicaR.CurrentRow.Cells[1].Value = DtSeleccion.Cells[1].Value.ToString();
                    Producto.FormProducto.Prod_principal.dtCaracteristicaR.CurrentRow.Cells[2].Value = DtSeleccion.Cells[2].Value.ToString();

                    Producto.FormProducto.Prod_principal.dtNombre.Focus();

                    Producto.FormProducto.Prod_principal.dtNombre.CurrentCell = Producto.FormProducto.Prod_principal.dtCaracteristicaR.CurrentRow.Cells[1];


                    this.Hide();
                    System.Threading.Thread.Sleep(50);

                }
                else
                {
                    txtBuscar.Text = "";
                    txtBuscar.Focus();


                }


            }

        }
        #endregion 
        
        public FormDataCaracteristicas()
        {
            InitializeComponent();

        }

        NCaracteristica addCaracteristica = new NCaracteristica();
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {
               this.dtLista.DataSource = this.addCaracteristica.Listar(this.txtBuscar.Text);

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

        private void FormDataCaracteristicas_Load(object sender, EventArgs e)
        {
            this.Lista();
            this.dtLista.CellContentClick += dtLista_CellContentClick;
            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormCaracteristica frm = new FormCaracteristica();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormCaracteristica frm = new FormCaracteristica();
                var t = this.addCaracteristica.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text ="0000"+ t.car_codigo.ToString();
                frm.txtNombre.Text = t.car_tipo;
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
                    this.addCaracteristica.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    this.Lista();

                }

            }
            catch (Exception ex)
            {

                Datos.Excepciones.Gestionar(ex);
                Datos.Excepciones.Mostrar("Information","Caracteristicas");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (FormDataCaracteristicas.GridSeleccion)
            {
                FormDataCaracteristicas.GridSeleccion = false;
                Producto.FormProducto.Prod_principal.Enabled = true;
            }
                this.Hide();
        }

        private void FormDataCaracteristicas_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

        private void FormDataCaracteristicas_FormClosing(object sender, FormClosingEventArgs e)
        {
            GridSeleccion = false;
            Producto.FormProducto.Prod_principal.Enabled = true;
            this.Hide();
        }

        
    }
}
