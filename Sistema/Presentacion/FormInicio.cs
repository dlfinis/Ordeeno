using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }


        private void EditarClave(string usuario, string clave)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["sistemaConnectionString2"].ConnectionString = "Data Source=(localhost);Initial Catalog=sistema;User="+usuario+";Password="+clave;

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");

           

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            EditarClave(txtNombre.Text,txtClave.Text);
            MessageBox.Show(ConfigurationManager.ConnectionStrings["sistemaConnectionString2"].ConnectionString);

            //SqlConnection conexion = new SqlConnection();
             
        }

    }
}
