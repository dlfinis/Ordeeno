using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormDataCiudades : Base.FormData
    {
        public FormDataCiudades()
        {
            InitializeComponent();
        }
        NCiudad addCiudad = new NCiudad();
        private void Lista()
        {
            //MessageBox.Show("Lista");
            try
            {

                this.dtLista.DataSource = this.addCiudad.Listar(this.txtBuscar.Text);

                this.dtLista.Columns[0].HeaderText = "Codigo";

                this.dtLista.Columns[0].Width = 100;
                this.dtLista.Columns[1].HeaderText = "Nombre";
             

                //this.dtLista.ColumnHeadersVisible = false;

                // segundo asignarle que se centre el texto de la columna


            }

            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Listar\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void FormDataCiudades_Load(object sender, EventArgs e)
        {

            FormMDI.usuarioValido(btnEditar);
            FormMDI.usuarioValido(btnEliminar);
            this.Lista();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.Lista();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormCiudad frm = new FormCiudad();
            frm.nuevo = true;
            frm.ShowDialog();
            this.Lista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                FormCiudad frm = new FormCiudad();
                var t = this.addCiudad.getDatos(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));

                frm.editar = true;

                frm.txtCodigo.Text = "0000" + t.ciu_codigo.ToString();
                frm.txtNombre.Text = t.ciu_nombre;
                frm.btnNuevo.Text = "Editar";
                frm.ShowDialog();
                this.Lista();
            }
            catch (Exception)
            {

                MessageBox.Show("No se puede Editar\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult res = MessageBox.Show("Desea eliminar el registro", "Atencion!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    this.addCiudad.Eliminar(int.Parse(this.dtLista.CurrentRow.Cells[0].Value.ToString()));
                    this.Lista();

                }

            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Eliminar\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
