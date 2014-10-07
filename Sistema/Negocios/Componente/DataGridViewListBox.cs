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
    public partial class DataGridViewListBox : DataGridView
    {
        ListBoxDgv[] listBoxCollection;

        int currentRowIndex;
        int scorallValue;
        public DataGridViewListBox()
        {
            InitializeComponent();
        }

         public DataGridViewListBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        

        /// <summary>
        /// Add and retrive collection of ListBoxDgves to the DataGridView.
        /// </summary>
        [Browsable(true), Category("ListBox Details"), Description("To add List Box")]
        public ListBoxDgv[] ListBoxCollection
        {
            get
            {
                return listBoxCollection;
            }
            set
            {
                try
                {
                    if (value.Length <= this.Columns.Count)
                    {
                        listBoxCollection = value;
                    }
                }
                catch { 
                
                }
            }
        }

        /// <summary>
        /// Calculate height of rows that visible in DataGridView component.
        /// </summary>
        /// <returns></returns>
        private int CalculateRowsHeight()
        {
            int rowsHeight = 0;

            DataGridViewRow row;
            for (int i = scorallValue; i < this.Rows.Count; i++)
            {
                row = this.Rows[i];

                if (row.Visible)
                    rowsHeight += row.Height;

                if (currentRowIndex == i)
                    break;
            }
            return rowsHeight;
        }

        /// <summary>
        /// This method is used to assign default drawing points to each
        /// ListBox that added to the DataGridView.
        /// </summary>
        private void SetDefaultLocationOfListBoxes()
        {
            Point defaultPoint;

            for (int lbIndex = 0; lbIndex < listBoxCollection.Length; lbIndex++)
            {
                defaultPoint = new Point();
                defaultPoint.Y = this.Location.Y;
                defaultPoint.X = 40;

                if (this.Columns.Count > 0)
                {
                    for (int ind = 0; ind < listBoxCollection[lbIndex].ColumnIndex; ind++)
                    {
                        defaultPoint.X += this.Columns[ind].Width;
                    }
                    listBoxCollection[lbIndex].Width =
                    this.Columns[listBoxCollection[lbIndex].ColumnIndex].Width;
                }
                
                listBoxCollection[lbIndex].Location = defaultPoint;
                this.Controls.Add(listBoxCollection[lbIndex]);
                listBoxCollection[lbIndex].Visible = false;
            }
        }

        private void DataGridViewListBox_Scroll(object sender, ScrollEventArgs e)
        {
            scorallValue = e.NewValue;
            SetDefaultLocationOfListBoxes();
        }

        /// <summary>
        /// When enter to a particular cell of the DataGridView, check there is
        /// a ListBox added to particular cell's column, if it is ok, then display
        /// that ListBox according to the proper position of a cell that display
        /// on a DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewListBox_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int y;
            SetDefaultLocationOfListBoxes();

            if (e.RowIndex == -1)
                return;

            currentRowIndex = e.RowIndex;

            foreach (ListBoxDgv lb in listBoxCollection)
            {
                if (lb.ColumnIndex == e.ColumnIndex)
                {
                    lb.Visible = true;

                    y = CalculateRowsHeight() + this.Rows[e.RowIndex].Height;

                    if (this.Height - (this.Rows[e.RowIndex].Height) < y)
                        y = y - lb.Height - this.Rows[e.RowIndex].Height;

                    lb.Location =
                        new System.Drawing.Point(lb.Location.X, y);
                }
            }
        }

        /// <summary>
        /// if column width is changed while displaying ListBox, ListBox width also
        /// changed according to the column width.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewListBox_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridViewColumn col = e.Column;

            foreach (ListBoxDgv lb in listBoxCollection)
            {
                if (lb.ColumnIndex == col.Index)
                {
                    lb.Width = col.Width;
                    this.Refresh();
                }
            }
        }

        private void DataGridViewListBox_Leave(object sender, EventArgs e)
        {
            SetDefaultLocationOfListBoxes();
        }
    }
}
