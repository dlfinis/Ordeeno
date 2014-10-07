using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormCorreoUsuario : Negocios.Base.FormBase
    {
        public FormCorreoUsuario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if((DialogResult)MessageBox.Show("Desea limpiar los Datos ..? ","Atencion..!",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                txtEmail.Text = "";
                txtClave.Text = "";
                txtMensaje.Text = "";

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtClave.Text))
            {
                try
                {
                    //MessageBox.Show(txtEmail.Text+"\n"+txtClave.Text);
                    Cursor.Current = Cursors.WaitCursor;
                    Datos.Excepciones.WriteToEmail(txtEmail.Text, txtClave.Text,txtMensaje.Text);
                    Cursor.Current = Cursors.Arrow;
                    this.Hide();
                MessageBox.Show("Se Envio con exito el Correo", "Email", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                 
               }
                catch (Exception ex)
                {
                    Datos.Excepciones.Gestionar(ex);
                    MessageBox.Show(ex.Message,"Error en el Envio",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Son necesarios Correo y Clave", "Datos Email", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                 

            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSymbol(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsLetterOrDigit(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsControl(e.KeyChar))
            { e.Handled = false; }
            else if (Char.IsPunctuation(e.KeyChar))
            { e.Handled = false; }
            else
            {
                e.Handled = true;
            }
            

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!isEmail(txtEmail.Text))
            {
                MessageBox.Show("No es un email Valido","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
           
        }
        public static bool isEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
    }
}
