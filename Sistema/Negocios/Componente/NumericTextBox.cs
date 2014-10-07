using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Negocios.Componente
{
    public partial class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            InitializeComponent();
            this.Multiline = false;
            
           
            this.Size = new System.Drawing.Size(153, 25);
            this.TabIndex = 7;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Name = "txtnum";
            this.Text = "";

        }

        //Sobreescribir el metodo OnKeyPress de la clase TextBox
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            //solo permitir numeros y teclas de control
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false; //permitir el caracter
            }
            else
            {
                e.Handled = true; //rechazar el caracter
            }
        }
    }
}
