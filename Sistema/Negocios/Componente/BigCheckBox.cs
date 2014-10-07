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
    public class BigCheckBox : DevComponents.DotNetBar.Controls.CheckBoxX
    {
        public BigCheckBox()
        {
            
            this.Text = "";
            this.Name = "BigChkBox";
          
           this.Checked = true;
           this.CheckValue = "S";
           this.CheckValueChecked = "S";
           
            //this.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            
        }
        public override bool AutoSize
        {
            set { base.AutoSize = false; }
            get { return base.AutoSize; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.Height = 25;
            this.Width = 25;
            int squareSide = 25;
           
           


            Rectangle rect = new Rectangle(new Point(0, 1), new Size(squareSide, squareSide));

            ControlPaint.DrawCheckBox(e.Graphics, rect, this.Checked ? ButtonState.Checked : ButtonState.Normal);
        }
    }
}
