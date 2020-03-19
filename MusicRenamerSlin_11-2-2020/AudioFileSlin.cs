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

        public List<string> tagDataFromFilesSlin { get; set; } //List of all the information

        public string newNameSlin { get; set; } //New name that the file needs to be renamed to

        public AudioFileSlin(string a_audioFilePathSlin)
        {
            this.audioFilePathSlin = a_audioFilePathSlin;
            this.tagDataFromFilesSlin = new List<string>();
        }

        public bool RenameFileSlin()
        {
            try
            {
                //Get need informaiton for renaming
                string m_getFileExtension = Path.GetExtension(audioFilePathSlin);
                string m_directoySlin = Path.GetDirectoryName(audioFilePathSlin);

                //Create the new Path for the renamed file
                string m_newFilePathSlin = m_directoySlin + "\\" + newNameSlin + m_getFileExtension;

                File.Move(audioFilePathSlin, m_newFilePathSlin); //Rename the file

                return true;
            } 
            catch
            {
                return false;
            }
        }

        public string GetNewAudioFileNameSlin()
        {
            return audioFilePathSlin;
        }
    }
}
