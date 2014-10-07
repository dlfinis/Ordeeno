using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormUsuario : Negocios.Base.FormBase
    {

        public bool editar=false;
        public string usuario="";
        public FormUsuario()
        {
            InitializeComponent();
        }

        public static AutoCompleteStringCollection LoadAutoCompleteUsuario()
        {



            AutoCompleteStringCollection accl = new AutoCompleteStringCollection();

            var foos = new List<String>(ConfigurationManager.AppSettings.AllKeys);
            

            foreach (string row in foos)
            {
                if (!row.Equals("SISTEMA"))
                {
                    accl.Add(row);
                }
            }
            return accl;
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {


            txtNombre.AutoCompleteCustomSource = FormUsuario.LoadAutoCompleteUsuario();
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNombre.AutoCompleteMode = AutoCompleteMode.SuggestAppend; //Es el mas bonito
           
        }

        private bool ConsultarClave(string usuario,string clave)
        {

            string tmp = ConfigurationManager.AppSettings[usuario];

            if (!clave.Equals(tmp))
            {
                return false;
            }
            else
            {

                return true;
            }
        }

        private void EditarClave(string usuario, string clave)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[usuario].Value = clave;

            ConfigurationManager.RefreshSection("appSettings");
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
         
            
                FormMDI.Usuario = clave;
            
        }

        private void ActualizarUsuario(string usuario,string usuario2,string clave)
        {

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove(usuario);
            config.AppSettings.Settings.Add(usuario2,clave);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

        }
        bool edicion = false;
        
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            
                if (!edicion)
                {
                    
                    
                
                    if (ConsultarClave(txtNombre.Text, txtClave.Text))
                    {

                        if (!btnEditar.Visible)
                        {
                            FormMDI.Principal.Text = "ORDEENO " + " (" + txtNombre.Text + ")";
                            MessageBox.Show("Ingreso Correcto", txtNombre.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);



                            usuario = txtNombre.Text;
                            EditarClave("SISTEMA", usuario);
                            btnEditar.Visible = true;
                        }
                        else
                        {
                            this.Hide();
                            this.Close();
                        }
                        
                        
                        //txtNombre.Enabled = usuario.Equals("ADMIN") ? false : true;
                        
                    }
                    else
                    {
                        MessageBox.Show("Ha ingresado el Usuario o la Clave Incorrecta", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormMDI.Principal.Text = "ORDEENO";
                        usuario = "";
                        btnEditar.Visible = false;
                      
                    }

                
                }
             


                if (edicion)
                {

                        if ( !String.IsNullOrEmpty(txtClave1.Text)&&txtClave1.Text.Equals(txtClave2.Text) &&  ConsultarClave(txtNombre.Text,txtClave.Text))
                        {

                            EditarClave(txtNombre.Text, txtClave1.Text);
                            FormMDI.Principal.Text = "ORDEENO" + " (" + txtNombre.Text + ")";
                            MessageBox.Show("Clave Actualizado", txtNombre.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EditarClave("SISTEMA", txtNombre.Text);
                           
                            this.Height = 166;
                            edicion = false;

                        }
                        else
                        {
                            MessageBox.Show("Ha ingresado la Clave Incorrecta", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormMDI.Principal.Text = "ORDEENO";
                            
                        }

                    
                    
                }
            

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
            txtClave1.Text = "";
            txtClave2.Text = "";
            this.Height = 262;
            edicion = true;
            btnEditar.Visible = false;
           
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            { 
            btnAceptar_Click(sender, new EventArgs());
            
            }
        }

    }
}
