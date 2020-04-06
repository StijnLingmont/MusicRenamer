using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
     * Description: All the functions for the Audiofiles that are selected
    */
    class AudioFileListSlin
    {

        public List<AudioFileSlin> audioFilesSlin { get; set; }

        public MainSlin mainFormSlin;

        //All Avalable Audio Extensions
        string[] avaiableFileExtensionsSlin = { ".wav",".aiff",".aif",".aifc",".m4a",".mogg",".caf",".pcm",".flac",".alac",".wma",".mp3",".ogg",".aac",".wma" };

        public AudioFileListSlin(MainSlin a_mainFormSlin)
        {
            audioFilesSlin = new List<AudioFileSlin>();
            mainFormSlin = a_mainFormSlin;
        }

        //Make a string with all the available extensions
        private string GetAvailableExtensionsAsTextSlin()
        {
            string m_availableExtensionsSlin = "";

            foreach (string m_extensionSlin in avaiableFileExtensionsSlin)
            {
                m_availableExtensionsSlin += "*" + m_extensionSlin + ";";
            }

            return m_availableExtensionsSlin;
        }

        public void AddFilesSlin(bool m_usingFolderOptionSlin)
        {
            try
            {
                //Check if the user wants to select files or a folder
                if (m_usingFolderOptionSlin)
                {
                    SelectFolderSlin();
                }
                else
                {
                    SelectFilesSlin();
                }
            }
            catch
            {
                MessageBox.Show("Oops! Something went wrong when selecting your songs! Please try another directory!");
            }
        }

        public void SelectFilesSlin()
        {
            string m_filterForAudioSlin = GetAvailableExtensionsAsTextSlin();

            using (OpenFileDialog m_musicFileDialogSlin = new OpenFileDialog())
            {
                m_musicFileDialogSlin.Filter = "All Audio Files|" + m_filterForAudioSlin;
                m_musicFileDialogSlin.RestoreDirectory = true;
                m_musicFileDialogSlin.Multiselect = true;

                if (m_musicFileDialogSlin.ShowDialog() == DialogResult.OK)
                {
                    mainFormSlin.pgbSelectingMusicProgresSlin.Maximum = m_musicFileDialogSlin.FileNames.Length * 10; //Set the maximum of the progressbar

                    mainFormSlin.LoggerSlin("Adding Files...");

                    // Go trough all the files that are selected
                    foreach (String m_singleSelectedFileSlin in m_musicFileDialogSlin.FileNames)
                    {
                        audioFilesSlin.Add(new AudioFileSlin(m_singleSelectedFileSlin));
                        mainFormSlin.pgbSelectingMusicProgresSlin.Value = mainFormSlin.pgbSelectingMusicProgresSlin.Value + 10; //Update the progressbar
                    }

                    mainFormSlin.LoggerSlin("Files added");
                }
            }
        }

        public void SelectFolderSlin()
        {
            using (FolderBrowserDialog m_musicFileDialogSlin = new FolderBrowserDialog())
            {
                if (m_musicFileDialogSlin.ShowDialog() == DialogResult.OK)
                {
                    var m_allFilesFromDirectory = System.IO.Directory.GetFiles(m_musicFileDialogSlin.SelectedPath); //Gives all the files from the directory

                    mainFormSlin.pgbSelectingMusicProgresSlin.Maximum = m_allFilesFromDirectory.Length * 10; //Set the maximum of the progressbar

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

                        mainFormSlin.pgbSelectingMusicProgresSlin.Value = mainFormSlin.pgbSelectingMusicProgresSlin.Value + 10; //Update progressbar
                    }

                    mainFormSlin.LoggerSlin("Files added");
                }
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

            //Go trough all the files
            foreach (var m_fileSlin in audioFilesSlin)
            {
                m_fileSlin.tagDataFromFilesSlin.Clear();

                //Check if the file still exists
                if(GetFilesFromDirectorySlin(m_fileSlin.GetNewAudioFileNameSlin()))
                {
                    bool m_statusOfId3RenameSlin = false; ; //Gives boolean back with if its succeeded or not
                    var thread = new Thread(() => { m_statusOfId3RenameSlin = Id3TagReaderSlin(m_fileSlin, a_orderListSlin); });
                    thread.Start();
                    thread.Join();


                    //Check if all the data is provided
                    if (!CheckRenameRequirementsSlin(m_fileSlin))
                    {
                        var thread1 = new Thread(() => MusicRecognisionSlin(m_fileSlin, a_orderListSlin));
                        thread1.Start();
                        thread1.Join();
                    }

                    //Check if the rename can be done
                    if(CheckRenameRequirementsSlin(m_fileSlin) && m_statusOfId3RenameSlin)
                    {
                        bool m_renameStatus = false;

                        //Rename files
                        var thread2 = new Thread(() => {m_renameStatus = m_fileSlin.RenameFileSlin(m_fileSlin.tagDataFromFilesSlin); });
                        thread2.Start();
                        thread2.Join();

                        if (m_renameStatus)
                        {
                            m_successRenamesSlin++;
                        } 
                        else
                        {
                            mainFormSlin.LoggerSlin(m_fileSlin.GetNewAudioFileNameSlin() + " Could not be renamed. Check if there is maybe a file with the same name in the folder.");
                        }
                    }
                }

                mainFormSlin.pgbRenameSlin.Value = mainFormSlin.pgbRenameSlin.Value + 10;
            }

            mainFormSlin.RenameEndStatusSlin(m_successRenamesSlin, audioFilesSlin.Count());
            audioFilesSlin.Clear();
        }

        private void MusicRecognisionSlin(AudioFileSlin a_musicFileSlin, List<string> a_orderListSlin)
        {
            string m_filePathSlin = a_musicFileSlin.GetNewAudioFileNameSlin();
            List<string> m_fileDataSlin = a_musicFileSlin.tagDataFromFilesSlin;

            //Create recognise instance of API
            var m_musicRecognisionSlin = new MusicRecognisionSlin();

            //Send file to API
            m_musicRecognisionSlin.SendFileToApi(m_filePathSlin);

            //If the song is found
            if(m_musicRecognisionSlin.GetStatusSlin())
            {
                for(int indexSlin = 0; indexSlin < m_fileDataSlin.Count(); indexSlin++)
                {
                    if(m_fileDataSlin[indexSlin] == null)
                    {
                        //Set the empty value to the value from the Music Recognision
                        m_fileDataSlin[indexSlin] = m_musicRecognisionSlin.GetSpeceficResultDataSlin(a_orderListSlin[indexSlin]);
                    }
                }
            }

            a_musicFileSlin.tagDataFromFilesSlin = m_fileDataSlin;
        }

        private bool Id3TagReaderSlin(AudioFileSlin a_audioFileSlin, List<string> a_orderListSlin)
        {
            try
            {
                string m_audioFilePathSlin = a_audioFileSlin.GetNewAudioFileNameSlin(); //get the audioFilePath
                var m_id3TagReaderSlin = new Id3TagReaderSlin(m_audioFilePathSlin, a_orderListSlin);

                a_audioFileSlin.tagDataFromFilesSlin = m_id3TagReaderSlin.GetDataForFile();

                return true;
            }
            catch
            {
                MessageBox.Show("Sorry! Something went wrong! Contact the company for more info.");
                return false;
            }

        }
    }
}
