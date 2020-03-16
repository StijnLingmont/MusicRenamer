using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public void RemoveFileSlin(ListBox a_musicListBoxSlin)
        {
            audioFilesSlin.RemoveAt(a_musicListBoxSlin.SelectedIndex);
        }

        private void CheckFileExtensionSlin()
        {

        }

        private void GetFilesFromDirectorySlin()
        {

        }

        public void RenameFilesSlin()
        {
            foreach(AudioFileSlin m_fileSlin in audioFilesSlin)
            {
                Id3TagReaderSlin(m_fileSlin.GetNewAudioFileNameSlin());
            }

        }

        private bool CheckRenameRequirementsSlin()
        {
            return true;
        }

        private void MusicRecognisionSlin()
        {

        }

        private void Id3TagReaderSlin(String a_filePathSlin)
        {
            var tfile = TagLib.File.Create(a_filePathSlin);
            string title = tfile.Tag.Title;

            foreach(string Test in OrderList.GetSelectedItemsSlin())
            {
                Console.WriteLine(Test);
            }
        }
    }
}
