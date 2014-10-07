using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Presentacion
{
    public partial class FormLogin : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormLogin()
        {
            InitializeComponent();
            this.Load += new EventHandler(FormMain_Load);
        }

        void FormMain_Load(object sender, EventArgs e)
        {
            showSplashScreen();
        }

        private void showSplashScreen()
        {
            using (FormSplashScreen fsplash = new FormSplashScreen())
            {
                if (fsplash.ShowDialog() == System.Windows.Forms.DialogResult.Cancel) this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

              
                
                //creando la conexion
                SqlConnection miConecion = new SqlConnection(Datos.BaseDatos.Cadena);
                //abriendo conexion
                miConecion.Open();


                SqlCommand comando = new SqlCommand("select usu_nombre, usu_password from usuario where usu_nombre = '" + txtusuario.Text + "'And usu_password = '" + txtpassword.Text + "' ", miConecion);

                //ejecuta una instruccion de sql devolviendo el numero de las filas afectadas
                comando.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comando);
               
                //Llenando el dataAdapter
                da.Fill(ds,"usuario");
                //utilizado para representar una fila de la tabla q necesitas en este caso usuario
                DataRow DR;
                DR = ds.Tables[0].Rows[0];

                //evaluando que la contraseña y usuario sean correctos
                if ((txtusuario.Text == DR[0].ToString()) || (txtpassword.Text == DR[1].ToString()))
                {
                    //instanciando el formulario principal
                    FormMDI frmPrincipal = new FormMDI();
                    frmPrincipal.Show();//abriendo el formulario principal
                    this.Hide();//esto sirve para ocultar el formulario de login
                }

            }
            catch
            {
                //en caso que la contraseña sea erronea mostrara un mensaje
                //dentro de los parentesis va: "Mensaje a mostrar","Titulo de la ventana",botones a mostrar en ste caso OK, icono a mostrar en este caso uno de error
                MessageBox.Show("Error! Su contraseña y/o usuario son invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {
            //aca se activa el boton INICIAR
            btnAceptar.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //Salir de la aplicacion
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
