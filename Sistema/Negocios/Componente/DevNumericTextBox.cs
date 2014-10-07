using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Linq;
using System.Text;


namespace Negocios.Componente
{
    public partial class DevNumericTextBox : DevComponents.DotNetBar.Controls.TextBoxX
    {
        public DevNumericTextBox()
        {
            InitializeComponent();

            this.Border.Class = "TextBoxBorder";
            this.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Location = new System.Drawing.Point(90, 226);
            this.MaxLength = 15;
            this.Name = "txtNum";
            this.Size = new System.Drawing.Size(191, 22);
            this.TabIndex = 13;
            this.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WatermarkText = "Ingrese";



        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {

            if (numeroDecimal)
            {
                if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if (e.KeyChar == '.'
                    && this.Text.IndexOf('.') > -1)
                {
                    //System.Windows.Forms.MessageBox.Show("" + this.Text.IndexOf('.')+"--"+this.Text.Length);
                    e.Handled = true;

                }
                Boolean dot = false;


                foreach (char value in this.Text)
                {
                    if (value == '.')
                    { dot = true; }
                }




                if (dot && char.IsDigit(e.KeyChar)
                   && this.Text.IndexOf('.') + CantidadDecimal+1 == this.TextLength)
                {
                    // System.Windows.Forms.MessageBox.Show("" + this.Text.IndexOf('.') + "--" + this.Text.Length);
                    e.Handled = true;

                }
            }
            else 
            {
                if (!char.IsControl(e.KeyChar)
                     && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            
            }
           

        }

        private bool numeroDecimal = false;
        public bool NumeroDecimal
        {
            set
            {
                this.numeroDecimal = value;
            }

            get
            {
                return this.numeroDecimal;
            }
        }

        private int cantidadDecimal = 4;
        public int CantidadDecimal
        {
            set
            {
                this.cantidadDecimal = value;
            }

            get
            {
                return this.cantidadDecimal;
            }
        }

        //protected override void OnTextChanged(EventArgs e)
        //{
        //    if (System.Text.RegularExpressions.Regex.IsMatch("[^0-9]",this.Text))
        //    {
        //        //MessageBox.Show("Please enter only numbers.");
        //       this.Text= this.Text.Remove(this.Text.Length - 1);
        //    }
        //}
       
        ////Sobreescribir el metodo OnKeyPress de la clase TextBox

        //bool allowSpace = false;


        //// Restricts the entry of characters to digits (including hex), the negative sign, 
        //// the decimal point, and editing keystrokes (backspace). 
        //protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    base.OnKeyPress(e);

        //    NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
        //    string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
        //    string groupSeparator = numberFormatInfo.NumberGroupSeparator;
        //    string negativeSign = numberFormatInfo.NegativeSign;

        //    // Workaround for groupSeparator equal to non-breaking space 
        //    if (groupSeparator == ((char)160).ToString())
        //    {
        //        groupSeparator = " ";
        //    }

        //    string keyInput = e.KeyChar.ToString();

        //    if (Char.IsDigit(e.KeyChar))
        //    {
        //        // Digits are OK
        //    }
        //    else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
        //     keyInput.Equals(negativeSign))
        //    {
        //        // Decimal separator is OK
        //    }
        //    else if (e.KeyChar == '\b')
        //    {
        //        // Backspace key is OK
        //    }
        //    //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0) 
        //    //    { 
        //    //     // Let the edit control handle control and alt key combinations 
        //    //    } 
        //    else if (this.allowSpace && e.KeyChar == ' ')
        //    {

        //    }
        //    else
        //    {
        //        // Consume this invalid key and beep
        //        e.Handled = true;
        //        //    MessageBeep();
        //    }
        //}

        //public int IntValue
        //{
        //    get
        //    {
        //        return Int32.Parse(this.Text);
        //    }
        //}

        //public decimal DecimalValue
        //{
        //    get
        //    {
        //        return Decimal.Parse(this.Text);
        //    }
        //}
       
    }
}
