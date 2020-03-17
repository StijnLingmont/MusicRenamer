using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRenamerSlin_11_2_2020
{
    /*
     * Auteur: Stijn Lingmont
     * Date: 12-02-2020
     * Description: All the functions and data for one specefic file.
    */
    class AudioFileSlin
    {
        private string audioFilePathSlin = "";

        public List<string> tagDataFromFilesSlin { get; set; }

        public string newNameSlin { get; set; }

        public AudioFileSlin(string a_audioFilePathSlin)
        {
            this.audioFilePathSlin = a_audioFilePathSlin;
            this.tagDataFromFilesSlin = new List<string>();
        }

        public void RenameFileSlin()
        {
            string m_getFileExtension = Path.GetExtension(audioFilePathSlin);
            string m_directoySlin = Path.GetDirectoryName(audioFilePathSlin);
            string m_newFilePathSlin = m_directoySlin + "\\" + newNameSlin + m_getFileExtension;

            File.Move(audioFilePathSlin, m_newFilePathSlin);
        }

        public string GetNewAudioFileNameSlin()
        {
            return audioFilePathSlin;
        }
    }
}
