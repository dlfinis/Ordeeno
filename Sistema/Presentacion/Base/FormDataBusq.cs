using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Base
{
    public partial class FormDataBusq : Negocios.Base.FormBase

    {
        public FormDataBusq()
        {
            InitializeComponent();
        }

        private void bndPagActual_KeyPress(object sender, KeyPressEventArgs e)
        {
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
