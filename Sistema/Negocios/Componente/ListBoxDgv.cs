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
    public partial class ListBoxDgv : ListBox
    {
        int columnIndex = -1;
        public ListBoxDgv()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ColumnIndex of DataGridView that is going to assign ListBox.
        /// </summary>
        [
         Browsable(true), Category("Binding Column"),
         Description("To assign this ListBox to paticular column of DataGridView")
        ]
        public int ColumnIndex
        {
            get
            { return columnIndex; }

            set
            { columnIndex = value; }
        }
    }
}
