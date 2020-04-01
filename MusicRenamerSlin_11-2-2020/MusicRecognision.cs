using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRenamerSlin_11_2_2020
{
    class MusicRecognision
    {
        private Dictionary<string, object> recogniserApiConfigSlin = new Dictionary<string, object>();
        private ACRCloudRecognizer musicRecogniserSlin;
        private JObject decodedJsonResultsSlin;

        public MusicRecognision()
        {
            recogniserApiConfigSlin.Add("host", "identify-eu-west-1.acrcloud.com");
            recogniserApiConfigSlin.Add("access_key", "ffeea9eb549bf53ae78d55a77523a76a");
            recogniserApiConfigSlin.Add("access_secret", "DmWkeTmEURSD6EseTsTOXTUzTaov2IuTtDzR9DqS");
            recogniserApiConfigSlin.Add("timeout", 10); // seconds
            recogniserApiConfigSlin.Add("rec_type", ACRCloudRecognizer.RECOGNIZER_TYPE.acr_rec_type_audio);

            musicRecogniserSlin = new ACRCloudRecognizer(recogniserApiConfigSlin);
        }

        public void SendFileToApi(string a_fileForRecognisionSlin)
        {
            string m_jsonResultsSlin = musicRecogniserSlin.RecognizeByFile(a_fileForRecognisionSlin, 0);

            decodedJsonResultsSlin = JObject.Parse(m_jsonResultsSlin);
        }

        public string GetSpeceficResultDataSlin(string a_dataTypeSlin)
        {
            var m_fileDataSlin = decodedJsonResultsSlin["metadata"]["music"][0];

            if (a_dataTypeSlin == "Title" && m_fileDataSlin["title"] != null)
            {
                return m_fileDataSlin["title"].ToString();
            }
            else if(a_dataTypeSlin == "Artists" && m_fileDataSlin["artists"] != null)
            {
                string m_mergedArtistsSlin = "";
                foreach (var m_oneArtistSlin in m_fileDataSlin["artists"])
                {
                    if (m_mergedArtistsSlin.Length > 0)
                    {
                        m_mergedArtistsSlin += m_oneArtistSlin["name"].ToString() + ";";
                    }
                    else
                    {
                        m_mergedArtistsSlin = m_oneArtistSlin["name"].ToString();
                    }
                }

                return m_mergedArtistsSlin;
            }
            else if(a_dataTypeSlin == "Year" && m_fileDataSlin["release_date"] != null)
            {
                string m_yearSlin = m_fileDataSlin["release_date"].ToString().Substring(0, 4);
                return m_yearSlin;
            }
            else if(a_dataTypeSlin == "Genres" && m_fileDataSlin["genres"] != null)
            {
                string m_mergedGenresSlin = "";
                foreach (var m_oneArtistSlin in m_fileDataSlin["genres"])
                {
                    if (m_mergedGenresSlin.Length > 0)
                    {
                        m_mergedGenresSlin += m_oneArtistSlin["name"].ToString() + ";";
                    }
                    else
                    {
                        m_mergedGenresSlin = m_oneArtistSlin["name"].ToString();
                    }
                }

                return m_mergedGenresSlin;
            }
            else if(a_dataTypeSlin == "Duration" && m_fileDataSlin["duration_ms"] != null)
            {
                int m_timeinMiliSecondsSlin = Convert.ToInt32(m_fileDataSlin["duration_ms"]);
                int m_timeinSecondsSlin = m_timeinMiliSecondsSlin / 1000;

                string m_timeInString = m_timeinSecondsSlin + "Sec";

                return m_timeInString;
            }

            return null;
        }

        public bool GetStatusSlin()
        {
            if (decodedJsonResultsSlin["status"]["msg"].ToString() == "Success")
            {
                return true;
            }

            return false;
        }

    }
}
