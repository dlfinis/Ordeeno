using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Negocios.Componente
{
    public partial class DevStringWTextBox : DevComponents.DotNetBar.Controls.TextBoxX 
    {
        public DevStringWTextBox()
        {
            InitializeComponent();
            this.Border.Class = "TextBoxBorder";
            this.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Location = new System.Drawing.Point(89, 143);
            this.MaxLength = 300;
            this.Name = "txtStringW";
            this.Size = new System.Drawing.Size(191, 22);
            this.TabIndex = 11;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WatermarkText = "Ingrese";
        }


       
        public DevStringWTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
