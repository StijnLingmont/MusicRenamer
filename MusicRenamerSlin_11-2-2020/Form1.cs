using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    public partial class Main : Form
    {
        OrderList orderListSlin;
        AudioFileListSlin audioListSlin;
        public Main()
        {
            InitializeComponent();

            orderListSlin = new OrderList(this);
            audioListSlin = new AudioFileListSlin(this);

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

        private void btnSelectMusicSlin_Click(object sender, EventArgs e)
        {
            LoggerSlin("Selecting Music...");

            audioListSlin.SelectFilesSlin();
            RenewSelectedListSlin();
        }

        private void btnRemoveSongSlin_Click(object sender, EventArgs e)
        {
            audioListSlin.RemoveFileSlin(lsbSelectedMusicSlin.SelectedIndex);
            RenewSelectedListSlin();
        }

        private void RenewSelectedListSlin()
        {
            LoggerSlin("Updating Music List...");

            lsbSelectedMusicSlin.Items.Clear();

            //Add all the items from the begin of the list to the listbox
            foreach (AudioFileSlin audioFile in audioListSlin.audioFilesSlin)
            {
                lsbSelectedMusicSlin.Items.Add(Path.GetFileNameWithoutExtension(audioFile.GetNewAudioFileNameSlin()));
            }

            //Give the amount of selected Items
            lblMusicSelectedSlin.Text = "You selected " + audioListSlin.audioFilesSlin.Count + " songs";
            LoggerSlin(audioListSlin.audioFilesSlin.Count + " Selected music");
        }

        private void LoggerSlin(String a_loggingStringSlin)
        {
            rtbLogSlin.AppendText(a_loggingStringSlin + "\n");
        }

        private void btnRenameSongsSlin_Click(object sender, EventArgs e)
        {
            List<string> m_orderListItemsSlin = orderListSlin.GetSelectedItemsSlin();
            audioListSlin.RenameFilesSlin(m_orderListItemsSlin);
        }
    }
}
