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

        public AudioFileListSlin()
        {
            audioFilesSlin = new List<AudioFileSlin>();
        }

        public void SelectFilesSlin()
        {
            using (OpenFileDialog m_musicFileDialogSlin = new OpenFileDialog())
            {
                m_musicFileDialogSlin.Filter = "All Audio Files|*.wav;*.aiff;*.aif;*.aifc;*.m4a;*.mogg;*.caf;*.pcm;*.flac;*.alac;*.wma;*.mp3;*.ogg;*.aac;*.wma;";
                m_musicFileDialogSlin.RestoreDirectory = true;
                m_musicFileDialogSlin.Multiselect = true;

                if (m_musicFileDialogSlin.ShowDialog() == DialogResult.OK)
                {
                    // Read the files
                    foreach (String m_singleSelectedFileSlin in m_musicFileDialogSlin.FileNames)
                    {
                        audioFilesSlin.Add(new AudioFileSlin(m_singleSelectedFileSlin));
                    }
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

        public void RenameFilesSlin(List<string> a_orderListSlin)
        {
            foreach(var m_fileSlin in audioFilesSlin)
            {
                m_fileSlin.tagDataFromFilesSlin.Clear();

                //Check if the file still exists
                if(GetFilesFromDirectorySlin(m_fileSlin.GetNewAudioFileNameSlin()))
                {
                    Id3TagReaderSlin(m_fileSlin, a_orderListSlin);

                    //Check if all the data is provided
                    if (!CheckRenameRequirementsSlin(m_fileSlin))
                    {
                        MusicRecognisionSlin();
                    }

                    //Rename files
                    m_fileSlin.newNameSlin = RenameStringSlin(m_fileSlin.tagDataFromFilesSlin);
                    m_fileSlin.RenameFileSlin();
                }
            }
        }

        private bool CheckRenameRequirementsSlin(AudioFileSlin a_audioFileSlin)
        {
            //TODO: Check if File still exists

            //TODO: Check if all the data is filled in. If not then a Music Recognision API is required.
            if(a_audioFileSlin.tagDataFromFilesSlin.Contains(null))
            {
                return false;
            }

            return true;
        }

        private void MusicRecognisionSlin()
        {
            MessageBox.Show("Music Recognision will work!");
        }

        private void Id3TagReaderSlin(AudioFileSlin a_audioFileSlin, List<string> a_orderListSlin)
        {
            string m_audioFilePathSlin = a_audioFileSlin.GetNewAudioFileNameSlin(); //get the audioFilePath

            var tfile = TagLib.File.Create(m_audioFilePathSlin);

            foreach (string m_orderItemSlin in a_orderListSlin)
            {
                var m_dataRetrievedSlin = tfile.Tag.GetType().GetProperty(m_orderItemSlin).GetValue(tfile.Tag, null);

                if(m_dataRetrievedSlin == null)
                {
                    a_audioFileSlin.tagDataFromFilesSlin.Add(null);
                } 
                else if(m_dataRetrievedSlin.GetType().ToString() == "System.String")
                {
                    a_audioFileSlin.tagDataFromFilesSlin.Add(m_dataRetrievedSlin.ToString());
                }
                else if(m_dataRetrievedSlin.GetType().ToString() == "System.String[]")
                {
                    string[] m_dataRetrievedFromArraySlin = (string[])m_dataRetrievedSlin;

                    if(m_dataRetrievedFromArraySlin.Length > 0)
                    {
                        a_audioFileSlin.tagDataFromFilesSlin.Add(m_dataRetrievedFromArraySlin[0]);
                    } else
                    {
                        a_audioFileSlin.tagDataFromFilesSlin.Add(null);
                    }
                }
                else
                {
                    MessageBox.Show("The data from the file is unvalid");
                }
            }
        }

        private string RenameStringSlin(List<string> a_tagDataFromFileSlin)
        {
            string m_fileNameSlin = "";

            foreach (string m_singleTagDataFromFile in a_tagDataFromFileSlin)
            {
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
