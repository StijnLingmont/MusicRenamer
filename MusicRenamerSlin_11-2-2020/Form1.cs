using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    public partial class Main : Form
    {
        OrderList orderListSlin = new OrderList();
        public Main()
        {
            InitializeComponent();
            lsbUnselectedOrderSlin.AllowDrop = true;
            lsbSelectedOrderSlin.AllowDrop = true;
        }

        #region Name Order List
        private void selectedListBoxSlin_MouseDown(object sender, MouseEventArgs e)
        {
            orderListSlin.MoveFromListBoxSlin((ListBox)sender);
        }

        private void selectedListBoxSli_DragOver(object sender, DragEventArgs e)
        {
            orderListSlin.EnterDropRegionSlin((ListBox)sender, e);
        }

        private void selectedListBoxSlin_DragDrop(object sender, DragEventArgs e)
        {
            orderListSlin.DropInBoxSlin(e);
        }
        #endregion
    }
}
