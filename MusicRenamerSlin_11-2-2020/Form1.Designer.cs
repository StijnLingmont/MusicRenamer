namespace MusicRenamerSlin_11_2_2020
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.grbOptionsSlin = new System.Windows.Forms.GroupBox();
            this.pgbRenameSlin = new System.Windows.Forms.ProgressBar();
            this.lnlSelectedListSlin = new System.Windows.Forms.Label();
            this.lblUnselectedListSlin = new System.Windows.Forms.Label();
            this.lblUnsuccesRenamedSlin = new System.Windows.Forms.Label();
            this.lblSuccesRenamedSlin = new System.Windows.Forms.Label();
            this.lblSelectRenameOrderSlin = new System.Windows.Forms.Label();
            this.lsbSelectedOrderSlin = new System.Windows.Forms.ListBox();
            this.lsbUnselectedOrderSlin = new System.Windows.Forms.ListBox();
            this.btnRenameSongsSlin = new System.Windows.Forms.Button();
            this.grbSelectMusicSlin = new System.Windows.Forms.GroupBox();
            this.btnSelectMusicByFolderSlin = new System.Windows.Forms.Button();
            this.pgbSelectingMusicProgresSlin = new System.Windows.Forms.ProgressBar();
            this.btnRemoveSongSlin = new System.Windows.Forms.Button();
            this.lsbSelectedMusicSlin = new System.Windows.Forms.ListBox();
            this.lblMusicSelectedSlin = new System.Windows.Forms.Label();
            this.btnSelectMusicByFilesSlin = new System.Windows.Forms.Button();
            this.grbLogSlin = new System.Windows.Forms.GroupBox();
            this.rtbLogSlin = new System.Windows.Forms.RichTextBox();
            this.grbOptionsSlin.SuspendLayout();
            this.grbSelectMusicSlin.SuspendLayout();
            this.grbLogSlin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbOptionsSlin
            // 
            this.grbOptionsSlin.Controls.Add(this.pgbRenameSlin);
            this.grbOptionsSlin.Controls.Add(this.lnlSelectedListSlin);
            this.grbOptionsSlin.Controls.Add(this.lblUnselectedListSlin);
            this.grbOptionsSlin.Controls.Add(this.lblUnsuccesRenamedSlin);
            this.grbOptionsSlin.Controls.Add(this.lblSuccesRenamedSlin);
            this.grbOptionsSlin.Controls.Add(this.lblSelectRenameOrderSlin);
            this.grbOptionsSlin.Controls.Add(this.lsbSelectedOrderSlin);
            this.grbOptionsSlin.Controls.Add(this.lsbUnselectedOrderSlin);
            this.grbOptionsSlin.Controls.Add(this.btnRenameSongsSlin);
            this.grbOptionsSlin.Location = new System.Drawing.Point(305, 12);
            this.grbOptionsSlin.Name = "grbOptionsSlin";
            this.grbOptionsSlin.Size = new System.Drawing.Size(244, 468);
            this.grbOptionsSlin.TabIndex = 0;
            this.grbOptionsSlin.TabStop = false;
            this.grbOptionsSlin.Text = "Options";
            // 
            // pgbRenameSlin
            // 
            this.pgbRenameSlin.Location = new System.Drawing.Point(6, 439);
            this.pgbRenameSlin.Name = "pgbRenameSlin";
            this.pgbRenameSlin.Size = new System.Drawing.Size(232, 23);
            this.pgbRenameSlin.TabIndex = 6;
            // 
            // lnlSelectedListSlin
            // 
            this.lnlSelectedListSlin.AutoSize = true;
            this.lnlSelectedListSlin.Location = new System.Drawing.Point(125, 103);
            this.lnlSelectedListSlin.Name = "lnlSelectedListSlin";
            this.lnlSelectedListSlin.Size = new System.Drawing.Size(76, 13);
            this.lnlSelectedListSlin.TabIndex = 9;
            this.lnlSelectedListSlin.Text = "Selected items";
            // 
            // lblUnselectedListSlin
            // 
            this.lblUnselectedListSlin.AutoSize = true;
            this.lblUnselectedListSlin.Location = new System.Drawing.Point(6, 103);
            this.lblUnselectedListSlin.Name = "lblUnselectedListSlin";
            this.lblUnselectedListSlin.Size = new System.Drawing.Size(88, 13);
            this.lblUnselectedListSlin.TabIndex = 8;
            this.lblUnselectedListSlin.Text = "Unselected items";
            // 
            // lblUnsuccesRenamedSlin
            // 
            this.lblUnsuccesRenamedSlin.AutoSize = true;
            this.lblUnsuccesRenamedSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnsuccesRenamedSlin.Location = new System.Drawing.Point(7, 398);
            this.lblUnsuccesRenamedSlin.Name = "lblUnsuccesRenamedSlin";
            this.lblUnsuccesRenamedSlin.Size = new System.Drawing.Size(185, 16);
            this.lblUnsuccesRenamedSlin.TabIndex = 7;
            this.lblUnsuccesRenamedSlin.Text = "0 songs have not be renamed";
            // 
            // lblSuccesRenamedSlin
            // 
            this.lblSuccesRenamedSlin.AutoSize = true;
            this.lblSuccesRenamedSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccesRenamedSlin.Location = new System.Drawing.Point(6, 376);
            this.lblSuccesRenamedSlin.Name = "lblSuccesRenamedSlin";
            this.lblSuccesRenamedSlin.Size = new System.Drawing.Size(233, 16);
            this.lblSuccesRenamedSlin.TabIndex = 4;
            this.lblSuccesRenamedSlin.Text = "0 songs have succesfully be renamed";
            // 
            // lblSelectRenameOrderSlin
            // 
            this.lblSelectRenameOrderSlin.AutoSize = true;
            this.lblSelectRenameOrderSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectRenameOrderSlin.Location = new System.Drawing.Point(6, 75);
            this.lblSelectRenameOrderSlin.Name = "lblSelectRenameOrderSlin";
            this.lblSelectRenameOrderSlin.Size = new System.Drawing.Size(157, 20);
            this.lblSelectRenameOrderSlin.TabIndex = 6;
            this.lblSelectRenameOrderSlin.Text = "Select rename order:";
            // 
            // lsbSelectedOrderSlin
            // 
            this.lsbSelectedOrderSlin.FormattingEnabled = true;
            this.lsbSelectedOrderSlin.Location = new System.Drawing.Point(128, 119);
            this.lsbSelectedOrderSlin.Name = "lsbSelectedOrderSlin";
            this.lsbSelectedOrderSlin.Size = new System.Drawing.Size(110, 251);
            this.lsbSelectedOrderSlin.TabIndex = 5;
            this.lsbSelectedOrderSlin.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectedListBoxSlin_DragDrop);
            this.lsbSelectedOrderSlin.DragOver += new System.Windows.Forms.DragEventHandler(this.selectedListBoxSli_DragOver);
            this.lsbSelectedOrderSlin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectedListBoxSlin_MouseDown);
            // 
            // lsbUnselectedOrderSlin
            // 
            this.lsbUnselectedOrderSlin.FormattingEnabled = true;
            this.lsbUnselectedOrderSlin.Items.AddRange(new object[] {
            "Title",
            "Artists",
            "Year",
            "Genres",
            "Durartion"});
            this.lsbUnselectedOrderSlin.Location = new System.Drawing.Point(6, 119);
            this.lsbUnselectedOrderSlin.Name = "lsbUnselectedOrderSlin";
            this.lsbUnselectedOrderSlin.Size = new System.Drawing.Size(110, 251);
            this.lsbUnselectedOrderSlin.TabIndex = 4;
            this.lsbUnselectedOrderSlin.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectedListBoxSlin_DragDrop);
            this.lsbUnselectedOrderSlin.DragOver += new System.Windows.Forms.DragEventHandler(this.selectedListBoxSli_DragOver);
            this.lsbUnselectedOrderSlin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.selectedListBoxSlin_MouseDown);
            // 
            // btnRenameSongsSlin
            // 
            this.btnRenameSongsSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenameSongsSlin.Location = new System.Drawing.Point(6, 19);
            this.btnRenameSongsSlin.Name = "btnRenameSongsSlin";
            this.btnRenameSongsSlin.Size = new System.Drawing.Size(232, 50);
            this.btnRenameSongsSlin.TabIndex = 0;
            this.btnRenameSongsSlin.Text = "Rename List";
            this.btnRenameSongsSlin.UseVisualStyleBackColor = true;
            this.btnRenameSongsSlin.Click += new System.EventHandler(this.btnRenameSongsSlin_Click);
            // 
            // grbSelectMusicSlin
            // 
            this.grbSelectMusicSlin.Controls.Add(this.btnSelectMusicByFolderSlin);
            this.grbSelectMusicSlin.Controls.Add(this.pgbSelectingMusicProgresSlin);
            this.grbSelectMusicSlin.Controls.Add(this.btnRemoveSongSlin);
            this.grbSelectMusicSlin.Controls.Add(this.lsbSelectedMusicSlin);
            this.grbSelectMusicSlin.Controls.Add(this.lblMusicSelectedSlin);
            this.grbSelectMusicSlin.Controls.Add(this.btnSelectMusicByFilesSlin);
            this.grbSelectMusicSlin.Location = new System.Drawing.Point(12, 12);
            this.grbSelectMusicSlin.Name = "grbSelectMusicSlin";
            this.grbSelectMusicSlin.Size = new System.Drawing.Size(287, 468);
            this.grbSelectMusicSlin.TabIndex = 1;
            this.grbSelectMusicSlin.TabStop = false;
            this.grbSelectMusicSlin.Text = "Selected Music";
            // 
            // btnSelectMusicByFolderSlin
            // 
            this.btnSelectMusicByFolderSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectMusicByFolderSlin.Location = new System.Drawing.Point(7, 75);
            this.btnSelectMusicByFolderSlin.Name = "btnSelectMusicByFolderSlin";
            this.btnSelectMusicByFolderSlin.Size = new System.Drawing.Size(274, 50);
            this.btnSelectMusicByFolderSlin.TabIndex = 5;
            this.btnSelectMusicByFolderSlin.Text = "Select Music by Folder";
            this.btnSelectMusicByFolderSlin.UseVisualStyleBackColor = true;
            this.btnSelectMusicByFolderSlin.Click += new System.EventHandler(this.btnSelectMusicByFolderSlin_Click);
            // 
            // pgbSelectingMusicProgresSlin
            // 
            this.pgbSelectingMusicProgresSlin.Location = new System.Drawing.Point(9, 398);
            this.pgbSelectingMusicProgresSlin.Name = "pgbSelectingMusicProgresSlin";
            this.pgbSelectingMusicProgresSlin.Size = new System.Drawing.Size(272, 23);
            this.pgbSelectingMusicProgresSlin.TabIndex = 4;
            // 
            // btnRemoveSongSlin
            // 
            this.btnRemoveSongSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSongSlin.Location = new System.Drawing.Point(9, 427);
            this.btnRemoveSongSlin.Name = "btnRemoveSongSlin";
            this.btnRemoveSongSlin.Size = new System.Drawing.Size(272, 35);
            this.btnRemoveSongSlin.TabIndex = 3;
            this.btnRemoveSongSlin.Text = "Remove Selected Song";
            this.btnRemoveSongSlin.UseVisualStyleBackColor = true;
            this.btnRemoveSongSlin.Click += new System.EventHandler(this.btnRemoveSongSlin_Click);
            // 
            // lsbSelectedMusicSlin
            // 
            this.lsbSelectedMusicSlin.FormattingEnabled = true;
            this.lsbSelectedMusicSlin.HorizontalScrollbar = true;
            this.lsbSelectedMusicSlin.Location = new System.Drawing.Point(9, 154);
            this.lsbSelectedMusicSlin.Name = "lsbSelectedMusicSlin";
            this.lsbSelectedMusicSlin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lsbSelectedMusicSlin.Size = new System.Drawing.Size(272, 238);
            this.lsbSelectedMusicSlin.TabIndex = 2;
            // 
            // lblMusicSelectedSlin
            // 
            this.lblMusicSelectedSlin.AutoSize = true;
            this.lblMusicSelectedSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMusicSelectedSlin.Location = new System.Drawing.Point(6, 133);
            this.lblMusicSelectedSlin.Name = "lblMusicSelectedSlin";
            this.lblMusicSelectedSlin.Size = new System.Drawing.Size(140, 16);
            this.lblMusicSelectedSlin.TabIndex = 1;
            this.lblMusicSelectedSlin.Text = " You selected 0 songs";
            // 
            // btnSelectMusicByFilesSlin
            // 
            this.btnSelectMusicByFilesSlin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectMusicByFilesSlin.Location = new System.Drawing.Point(7, 19);
            this.btnSelectMusicByFilesSlin.Name = "btnSelectMusicByFilesSlin";
            this.btnSelectMusicByFilesSlin.Size = new System.Drawing.Size(274, 50);
            this.btnSelectMusicByFilesSlin.TabIndex = 0;
            this.btnSelectMusicByFilesSlin.Text = "Select Music by Files";
            this.btnSelectMusicByFilesSlin.UseVisualStyleBackColor = true;
            this.btnSelectMusicByFilesSlin.Click += new System.EventHandler(this.btnSelectMusicByFilesSlin_Click);
            // 
            // grbLogSlin
            // 
            this.grbLogSlin.Controls.Add(this.rtbLogSlin);
            this.grbLogSlin.Location = new System.Drawing.Point(555, 12);
            this.grbLogSlin.Name = "grbLogSlin";
            this.grbLogSlin.Size = new System.Drawing.Size(354, 468);
            this.grbLogSlin.TabIndex = 3;
            this.grbLogSlin.TabStop = false;
            this.grbLogSlin.Text = "Log";
            // 
            // rtbLogSlin
            // 
            this.rtbLogSlin.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbLogSlin.ForeColor = System.Drawing.SystemColors.Window;
            this.rtbLogSlin.Location = new System.Drawing.Point(6, 19);
            this.rtbLogSlin.Name = "rtbLogSlin";
            this.rtbLogSlin.ReadOnly = true;
            this.rtbLogSlin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtbLogSlin.Size = new System.Drawing.Size(342, 443);
            this.rtbLogSlin.TabIndex = 0;
            this.rtbLogSlin.Text = "";
            this.rtbLogSlin.WordWrap = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 492);
            this.Controls.Add(this.grbLogSlin);
            this.Controls.Add(this.grbSelectMusicSlin);
            this.Controls.Add(this.grbOptionsSlin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "Music Renamer";
            this.grbOptionsSlin.ResumeLayout(false);
            this.grbOptionsSlin.PerformLayout();
            this.grbSelectMusicSlin.ResumeLayout(false);
            this.grbSelectMusicSlin.PerformLayout();
            this.grbLogSlin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOptionsSlin;
        private System.Windows.Forms.GroupBox grbSelectMusicSlin;
        private System.Windows.Forms.Label lblMusicSelectedSlin;
        private System.Windows.Forms.Button btnSelectMusicByFilesSlin;
        private System.Windows.Forms.ListBox lsbSelectedMusicSlin;
        private System.Windows.Forms.Button btnRenameSongsSlin;
        private System.Windows.Forms.Button btnRemoveSongSlin;
        private System.Windows.Forms.ListBox lsbUnselectedOrderSlin;
        private System.Windows.Forms.Label lblSelectRenameOrderSlin;
        private System.Windows.Forms.Label lblUnsuccesRenamedSlin;
        private System.Windows.Forms.Label lblSuccesRenamedSlin;
        private System.Windows.Forms.GroupBox grbLogSlin;
        private System.Windows.Forms.RichTextBox rtbLogSlin;
        private System.Windows.Forms.Label lnlSelectedListSlin;
        private System.Windows.Forms.Label lblUnselectedListSlin;
        public System.Windows.Forms.ListBox lsbSelectedOrderSlin;
        public System.Windows.Forms.ProgressBar pgbSelectingMusicProgresSlin;
        private System.Windows.Forms.Button btnSelectMusicByFolderSlin;
        public System.Windows.Forms.ProgressBar pgbRenameSlin;
    }
}

