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
    public partial class StringTextBox : TextBox
    {
        public StringTextBox()
        {
            InitializeComponent();
           
            this.Multiline = true;
           
            this.Size = new System.Drawing.Size(153, 25);
            this.TabIndex = 7;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            this.Name = "txt";
            this.Text = "";

           
        }


        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        

    }
}
