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

namespace Presentacion.Producto
{
    public partial class FormCaracteristica : Base.FormMain
    {
        public FormCaracteristica()
        {
            InitializeComponent();
        }

        /// A?adir una variable para indicar al formulario
        /// si se quiere editar o eliminar
        public bool nuevo = false;
        public bool editar = false;
        public bool eliminar = false;
        /// instanciamos una clase
        ECaracteristica c = new ECaracteristica();
        /// instanciamos otra clase
        NCaracteristica addCaracteristica = new NCaracteristica();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {


            try
            {
                this.c.Car_codigo = int.Parse(this.txtCodigo.Text);
                this.c.Car_tipo= this.txtNombre.Text;




                //preguntamos si fue pulsado
                #region Nuevo
                if (nuevo && !editar)
                {
                    if (this.btnNuevo.Text == "Grabar")
                    {
                        //insertar
                        this.txtCodigo.Text = this.addCaracteristica.Insertar(this.c).ToString("000000");
                        MessageBox.Show("Registro insertado completo", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.btnNuevo.Text = "Limpiar";
                        this.btnNuevo.Focus();
                    }

                    else
                    {
                        this.txtCodigo.Text = "00000";
                        this.txtNombre.Text = "";
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

                    this.addCaracteristica.Editar(this.c);
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
