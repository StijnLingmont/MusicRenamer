using System;
using System.Collections.Generic;
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

        public AudioFileSlin(string a_audioFilePathSlin)
        {
            this.audioFilePathSlin = a_audioFilePathSlin;
        }

        public void RenameFileSlin()
        {

        }

        public string GetNewAudioFileNameSlin()
        {
            return audioFilePathSlin;
        }
    }
}
