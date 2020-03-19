using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    /*
     * Auteur: Stijn Lingmont
     * Date: 13-03-2020
     * Description: All the functions for the Audiofiles that are selected
    */
    class AudioFileListSlin
    {
        public List<AudioFileSlin> audioFilesSlin { get; set; }

        public Main mainFormSlin;

        //All Avalable Audio Extensions
        string[] avaiableFileExtensionsSlin = { ".wav",".aiff",".aif",".aifc",".m4a",".mogg",".caf",".pcm",".flac",".alac",".wma",".mp3",".ogg",".aac",".wma" };

        public AudioFileListSlin(Main a_mainFormSlin)
        {
            audioFilesSlin = new List<AudioFileSlin>();
            mainFormSlin = a_mainFormSlin;
        }

        private string GetAvailableExtensionsAsTextSlin()
        {
            string m_availableExtensionsSlin = "";

            foreach (string m_extensionSlin in avaiableFileExtensionsSlin)
            {
                m_availableExtensionsSlin += "*" + m_extensionSlin + ";";
            }

            return m_availableExtensionsSlin;
        }

        public void SelectFilesSlin(bool m_usingFolderOptionSlin)
        {
            try
            {
                //Check if the user wants to select files or a folder
                if (m_usingFolderOptionSlin)
                {
                    using (FolderBrowserDialog m_musicFileDialogSlin = new FolderBrowserDialog())
                    {
                        if (m_musicFileDialogSlin.ShowDialog() == DialogResult.OK)
                        {
                            var m_allFilesFromDirectory = System.IO.Directory.GetFiles(m_musicFileDialogSlin.SelectedPath); //Gives all the files from the directory

                            mainFormSlin.pgbSelectingMusicProgresSlin.Maximum = m_allFilesFromDirectory.Length * 10;

                            mainFormSlin.LoggerSlin("Searching for Audio Files...");

                            //Go trough all the files of the folder
                            foreach (string m_singleSelectedFileSlin in m_allFilesFromDirectory)
                            {
                                string m_fileExtensionSlin = Path.GetExtension(m_singleSelectedFileSlin);

                                //Is the file an audio file
                                if (avaiableFileExtensionsSlin.Contains(m_fileExtensionSlin))
                                {
                                    audioFilesSlin.Add(new AudioFileSlin(m_singleSelectedFileSlin));
                                }

                                mainFormSlin.pgbSelectingMusicProgresSlin.Value = mainFormSlin.pgbSelectingMusicProgresSlin.Value + 10;
                            }

                            mainFormSlin.LoggerSlin("Files added");
                        }
                    }
                }
                else
                {
                    string m_filterForAudioSlin = GetAvailableExtensionsAsTextSlin();

                    using (OpenFileDialog m_musicFileDialogSlin = new OpenFileDialog())
                    {
                        m_musicFileDialogSlin.Filter = "All Audio Files|" + m_filterForAudioSlin;
                        m_musicFileDialogSlin.RestoreDirectory = true;
                        m_musicFileDialogSlin.Multiselect = true;

                        if (m_musicFileDialogSlin.ShowDialog() == DialogResult.OK)
                        {
                            mainFormSlin.pgbSelectingMusicProgresSlin.Maximum = m_musicFileDialogSlin.FileNames.Length * 10;

                            mainFormSlin.LoggerSlin("Adding Files...");

                            // Go trough all the files that are selected
                            foreach (String m_singleSelectedFileSlin in m_musicFileDialogSlin.FileNames)
                            {
                                audioFilesSlin.Add(new AudioFileSlin(m_singleSelectedFileSlin));
                                mainFormSlin.pgbSelectingMusicProgresSlin.Value = mainFormSlin.pgbSelectingMusicProgresSlin.Value + 10;
                            }

                            mainFormSlin.LoggerSlin("Files added");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Oops! Something went wrong when selecting your songs! Please try another directory!");
            }
        }

        public void RemoveFileSlin(int a_selectedIndexSlin)
        {
            audioFilesSlin.RemoveAt(a_selectedIndexSlin);
        }

        private bool GetFilesFromDirectorySlin(string a_audioFilePathSlin)
        {
            bool m_valueExists = File.Exists(a_audioFilePathSlin);

            return m_valueExists;
        }

        private bool CheckRenameRequirementsSlin(AudioFileSlin a_audioFileSlin)
        {
            // Check if all the data is filled in. If not then a Music Recognision API is required.
            if (a_audioFileSlin.tagDataFromFilesSlin.Contains(null))
            {
                return false;
            }

            return true;
        }

        public void RenameFilesSlin(List<string> a_orderListSlin)
        {
            int m_successRenamesSlin = 0;

            mainFormSlin.pgbRenameSlin.Maximum = audioFilesSlin.Count() * 10;
            mainFormSlin.pgbRenameSlin.Value = 0;

            mainFormSlin.LoggerSlin("Start renaming...");

            foreach (var m_fileSlin in audioFilesSlin)
            {
                m_fileSlin.tagDataFromFilesSlin.Clear();

                //Check if the file still exists
                if(GetFilesFromDirectorySlin(m_fileSlin.GetNewAudioFileNameSlin()))
                {
                    bool m_statusOfId3RenameSlin = Id3TagReaderSlin(m_fileSlin, a_orderListSlin); //Gives boolean back with if its succeeded or not

                    //Check if all the data is provided
                    if (!CheckRenameRequirementsSlin(m_fileSlin))
                    {
                        MusicRecognisionSlin();
                    }

                    //Check if the rename can be done
                    if(CheckRenameRequirementsSlin(m_fileSlin) && m_statusOfId3RenameSlin)
                    {
                        //Rename files
                        m_fileSlin.newNameSlin = RenameStringSlin(m_fileSlin.tagDataFromFilesSlin);
                        bool m_renameStatus = m_fileSlin.RenameFileSlin();

                        if (m_renameStatus)
                        {
                            m_successRenamesSlin++;
                        }
                    }
                }

                mainFormSlin.pgbRenameSlin.Value = mainFormSlin.pgbRenameSlin.Value + 10;
            }

            mainFormSlin.RenameEndStatusSlin(m_successRenamesSlin, audioFilesSlin.Count());
            audioFilesSlin.Clear();
        }

        private void MusicRecognisionSlin()
        {
            Console.WriteLine("Music Recognision will work!");
        }

        private bool Id3TagReaderSlin(AudioFileSlin a_audioFileSlin, List<string> a_orderListSlin)
        {
            try
            {
                string m_audioFilePathSlin = a_audioFileSlin.GetNewAudioFileNameSlin(); //get the audioFilePath

                var tfile = TagLib.File.Create(m_audioFilePathSlin); //Create a File Reading Instance

                foreach (string m_orderItemSlin in a_orderListSlin)
                {
                    var m_dataRetrievedSlin = tfile.Tag.GetType().GetProperty(m_orderItemSlin).GetValue(tfile.Tag, null);

                    // Check which data is given and execute the right commans for thats data
                    if (m_dataRetrievedSlin == null)
                    {
                        a_audioFileSlin.tagDataFromFilesSlin.Add(null);
                    }
                    else if (m_dataRetrievedSlin.GetType().ToString() == "System.String" || m_dataRetrievedSlin.GetType().ToString() == "System.UInt32")
                    {
                        a_audioFileSlin.tagDataFromFilesSlin.Add(m_dataRetrievedSlin.ToString());
                    }
                    else if (m_dataRetrievedSlin.GetType().ToString() == "System.String[]")
                    {
                        string[] m_dataRetrievedFromArraySlin = (string[])m_dataRetrievedSlin; //Get the retrieved data

                        //Check if the array is filled
                        if (m_dataRetrievedFromArraySlin.Length > 0)
                        {
                            m_dataRetrievedFromArraySlin[0] = m_dataRetrievedFromArraySlin[0].Replace("/", ";");
                            a_audioFileSlin.tagDataFromFilesSlin.Add(m_dataRetrievedFromArraySlin[0]);
                        }
                        else
                        {
                            a_audioFileSlin.tagDataFromFilesSlin.Add(null);
                        }
                    }
                    else
                    {
                        MessageBox.Show("The data from the file is unvalid");
                    }
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Sorry! Something went wrong! Contact the company for more info.");
                return false;
            }

        }

        private string RenameStringSlin(List<string> a_tagDataFromFileSlin)
        {
            string m_fileNameSlin = "";

            foreach (string m_singleTagDataFromFile in a_tagDataFromFileSlin)
            {
                //Check if the data is valid
                if(m_singleTagDataFromFile != null)
                {
                    if (m_fileNameSlin.Length > 0)
                    {
                        m_fileNameSlin = m_fileNameSlin + " - " + m_singleTagDataFromFile;
                    }
                    else
                    {
                        m_fileNameSlin = m_singleTagDataFromFile;
                    }
                }
            }

            return m_fileNameSlin;
        }
    }
}
