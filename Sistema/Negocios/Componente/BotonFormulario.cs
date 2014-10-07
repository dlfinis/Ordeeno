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
    public partial class BotonFormulario : Button
    {
        public BotonFormulario()
        {
            InitializeComponent();


            this.FlatAppearance.BorderColor = Color.CadetBlue;
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            
          
            this.Size = new System.Drawing.Size(71, 33);
            this.TabIndex = 1;
            this.Text = "Text";
            this.UseVisualStyleBackColor = true;
         
            this.Name = "btn";
            this.Size = new System.Drawing.Size(76,30);
          

        }
    }
}
