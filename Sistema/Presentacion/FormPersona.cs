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
    public partial class FormPersona : Presentacion.Base.FormMain
    {

       

        /// A?adir una variable para indicar al formulario
        /// si se quiere editar o eliminar
        public bool nuevo = false;
        public bool editar = false;
        public bool eliminar = false;
        /// instanciamos una clase
        EPersona c = new EPersona();
        /// instanciamos otra clase
        NPersona addPersona = new NPersona();

        
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
        public FormPersona()
        {
            InitializeComponent();
            txtCiudad.AutoCompleteCustomSource = FormPersona.LoadAutoCompleteCiudad();
            txtCiudad.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtCiudad.AutoCompleteSource = AutoCompleteSource.CustomSource;
            
        }

      


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.c.Per_codigo = int.Parse(this.txtCodigo.Text);
                this.c.Per_nombre = this.txtNombre.Text;
                this.c.Per_apellido = this.txtApellido.Text;
                this.c.Per_direccion = this.txtDireccion.Text;
                this.c.Ciu_nombre = this.txtCiudad.Text;
               
                this.c.Per_telefono = this.txtTelefono.Text;
                this.c.Per_celular = this.txtCelular.Text;
                this.c.Per_identificacion = this.txtIdentificacion.Text;

              
                //preguntamos si fue pulsado
                #region Nuevo
                if (nuevo && !editar)
                {
                    if (this.btnNuevo.Text == "Grabar")
                    {
                        //insertar
                        this.txtCodigo.Text = this.addPersona.Insertar(this.c).ToString("000000");
                        
                        MessageBox.Show("Registro insertado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.btnNuevo.Text = "Limpiar";
                        this.btnNuevo.Focus();
                    }
                    else
                    {
                        this.txtCodigo.Text = "00000";
                        this.txtNombre.Text = "";
                        this.txtDireccion.Text = "";
                        this.txtCiudad.Text = "";
                        this.txtTelefono.Text = "";
                        this.txtCelular.Text = "";
                        this.txtApellido.Text = "";
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

                    this.addPersona.Editar(this.c);
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
       
      
    }
}
