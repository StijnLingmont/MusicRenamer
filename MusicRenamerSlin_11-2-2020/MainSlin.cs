﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    /*
     * Auteur: Stijn Lingmont
     * Date: 13-03-2020
     * Description: The main form when the program is opened
    */

    public partial class MainSlin : Form
    {
        private OrderListSlin orderListSlin;
        private AudioFileListSlin audioListSlin;

        public MainSlin()
        {
            //Initialise
            InitializeComponent();

            orderListSlin = new OrderListSlin(this);
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

        private void btnSelectMusicByFolderSlin_Click(object sender, EventArgs e)
        {
            LoggerSlin("Selecting files by Folder");

            SelectMusicSlin(true);
        }

        private void btnSelectMusicByFilesSlin_Click(object sender, EventArgs e)
        {
            LoggerSlin("Selecting files by Files");

            SelectMusicSlin(false);
        }

        private void SelectMusicSlin(bool a_isFolderSlin)
        {
            pgbSelectingMusicProgresSlin.Value = 0;

            LoggerSlin("Selecting Music by Files...");

            audioListSlin.AddFilesSlin(a_isFolderSlin);

            RenewSelectedListSlin();

            LoggerSlin(audioListSlin.audioFilesSlin.Count + " Selected music");
        }

        private void btnRemoveSongSlin_Click(object sender, EventArgs e)
        {
            if (lsbSelectedMusicSlin.SelectedIndex >= 0)
            {
                audioListSlin.RemoveFileSlin(lsbSelectedMusicSlin.SelectedIndex);

                RenewSelectedListSlin();
            } 
            else
            {
                MessageBox.Show("Please select the file you want to remove!");
            }
        }

        private void btnRenameSongsSlin_Click(object sender, EventArgs e)
        {
            List<string> m_orderListItemsSlin = orderListSlin.GetSelectedItemsSlin(); //Get all the selected order items
            audioListSlin.RenameFilesSlin(m_orderListItemsSlin);

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

            ProgramFeaturesCheckSlin();
        }

        private void ProgramFeaturesCheckSlin()
        {

            if (audioListSlin.audioFilesSlin.Count > 0)
            {
                btnRenameSongsSlin.Enabled = true;
                btnRemoveSongSlin.Enabled = true;
            } else
            {
                btnRenameSongsSlin.Enabled = false;
                btnRemoveSongSlin.Enabled = false;
            }
        }

        public void LoggerSlin(String a_loggingStringSlin)
        {
            rtbLogSlin.AppendText(a_loggingStringSlin + "\n");
        }

        public void RenameEndStatusSlin(int a_completedRenames, int a_amountRenamingSlin)
        {
            int m_uncompletedRenamesSlin = a_amountRenamingSlin - a_completedRenames; //Calculate failed

            //Get the update messages
            string m_completedTextSlin = a_completedRenames + " songs have succesfully be renamed";
            string m_uncompletedTextSlin = m_uncompletedRenamesSlin + " songs have not be renamed";

            //Update the labels and the Log for the end status of the rename process
            lblSuccesRenamedSlin.Text = m_completedTextSlin;
            lblUnsuccesRenamedSlin.Text = m_uncompletedTextSlin;

            LoggerSlin(m_completedTextSlin);
            LoggerSlin(m_uncompletedTextSlin);
        }
    }
}
