using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocios;
using Negocios.Entidades;

namespace Presentacion
{
    public partial class FormProveedor : Presentacion.Base.FormMain

    {

        /// A?adir una variable para indicar al formulario
        /// si se quiere editar o eliminar
        public bool nuevo = false;
        public bool editar = false;
        public bool eliminar = false;
        /// instanciamos una clase
        EProveedor c = new EProveedor();
        /// instanciamos otra clase
        NProveedor addProveedor = new NProveedor();

        public static AutoCompleteStringCollection LoadAutoCompleteCiudad()
        {
            NCiudad getLista = new NCiudad();



            AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();

            foreach (Datos.TCiudad row in getLista.Listar(""))
            {

                stringCol.Add(Convert.ToString(row.ciu_nombre));

            }
            return stringCol;
        }
        public FormProveedor()
        {
            InitializeComponent();
            txtCiudad.AutoCompleteCustomSource = FormProveedor.LoadAutoCompleteCiudad();
            txtCiudad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCiudad.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
        }

       
        private void btnSalir_Click(object sender, EventArgs e)
        {
                    this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.c.Prov_codigo = int.Parse(this.txtCodigo.Text);
                this.c.Prov_nombre = this.txtNombre.Text;
       
                this.c.Prov_direccion = this.txtDireccion.Text;
                this.c.Ciu_nombre = this.txtCiudad.Text;

                this.c.Prov_telefono = this.txtTelefono.Text;
                this.c.Prov_celular = this.txtCelular.Text;
                this.c.Prov_email = this.txtEmail.Text;
                this.c.Prov_identificacion = this.txtIdentificacion.Text;


                //preguntamos si fue pulsado
                #region Nuevo
                if (nuevo && !editar)
                {
                    if (this.btnNuevo.Text == "Grabar")
                    {
                        //insertar
                        this.txtCodigo.Text = this.addProveedor.Insertar(this.c).ToString("000000");

                        MessageBox.Show("Registro insertado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.btnNuevo.Text = "Limpiar";
                        this.btnNuevo.Focus();
                    }
                    else
                    {
                        this.txtCodigo.Text = "00000";
                        this.txtNombre.Text = "";
                        this.txtDireccion.Text = "";
                        this.txtCiudad.Text="";
                        this.txtTelefono.Text = "";
                        this.txtCelular.Text = "";
                        this.txtEmail.Text = "";
                        this.txtIdentificacion.Text = "";
                        this.btnNuevo.Text = "Grabar";
                        this.txtNombre.Focus();
                        this.nuevo = true;

                    }
                }
                #endregion
                #region Editar
                if (this.editar && btnNuevo.Text == "Editar")
                {
                    //edicion

                    this.addProveedor.Editar(this.c);
                    MessageBox.Show("Registro actualizado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNombre.Focus();



                }



                #endregion



            }
            catch (Exception ex)
            {
                Datos.Excepciones.Gestionar(ex);
                MessageBox.Show("No se puede Editar \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
