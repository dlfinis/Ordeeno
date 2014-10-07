using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Negocios.Componente
{
    public partial class DevStringTextBox : DevComponents.DotNetBar.Controls.TextBoxX 
    {
        public DevStringTextBox()
        {
            InitializeComponent();
            this.Border.Class = "TextBoxBorder";
            this.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Location = new System.Drawing.Point(89, 143);
            this.MaxLength = 300;
            this.Name = "txtString";
            this.Size = new System.Drawing.Size(191, 22);
            this.TabIndex = 11;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WatermarkText = "Ingrese";
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
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

        public DevStringTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
