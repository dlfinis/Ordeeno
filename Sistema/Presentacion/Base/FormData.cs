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
    public partial class FormData : Negocios.Base.FormBase


    {
        public FormData()
        {
            InitializeComponent();
       
        }

        private void FormData_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void FormData_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height < 50)
                this.MaximizeBox = true;
            else
                this.MaximizeBox = false;
        }

       


       
    }
}
