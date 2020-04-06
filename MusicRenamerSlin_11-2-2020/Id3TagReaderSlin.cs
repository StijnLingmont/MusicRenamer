using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicRenamerSlin_11_2_2020
{
    class Id3TagReaderSlin
    {
        private string audioFilePathSlin;
        private List<string> orderListSlin;
        private TagLib.File tfileSlin;

        public Id3TagReaderSlin(string a_audioFilePathSlin, List<string> a_orderListSlin)
        {
            audioFilePathSlin = a_audioFilePathSlin;
            orderListSlin = a_orderListSlin;

            tfileSlin = TagLib.File.Create(audioFilePathSlin); //Create a TagLib reader instance
        }

        public List<string> GetDataForFile()
        {
            List<string> m_dataForFileSlin = new List<string>();

            foreach (string m_orderItemSlin in orderListSlin)
            {
                var m_dataRetrievedSlin = GetSpeceficDataSlin(m_orderItemSlin);
                m_dataForFileSlin.Add(m_dataRetrievedSlin);
            }

            return m_dataForFileSlin;
        }
        private string GetSpeceficDataSlin(string a_orderItemSlin)
        {
            string m_dataFromFileSlin = null;

            if (a_orderItemSlin == "Title")
            {
                m_dataFromFileSlin = tfileSlin.Tag.Title;
            } 
            else if(a_orderItemSlin == "Artists")
            {
                var m_dataRetrievedFromArraySlin = tfileSlin.Tag.Artists; //Get the retrieved data

                //Check if the array is filled
                if (m_dataRetrievedFromArraySlin.Length > 0)
                {
                    m_dataFromFileSlin = m_dataRetrievedFromArraySlin[0].Replace("/", ";");
                }
                else
                {
                    m_dataFromFileSlin = null;
                }
            }
            else if(a_orderItemSlin == "Year")
            {
                m_dataFromFileSlin = tfileSlin.Tag.Year.ToString();

                //Check if year is unvalid
                if(m_dataFromFileSlin == "0")
                {
                    m_dataFromFileSlin = null;
                }

            }
            else if(a_orderItemSlin == "Genres")
            {
                var m_dataRetrievedFromArraySlin = tfileSlin.Tag.Genres; //Get the retrieved data

                //Check if the array is filled
                if (m_dataRetrievedFromArraySlin.Length > 0)
                {
                    m_dataFromFileSlin = m_dataRetrievedFromArraySlin[0];
                }
                else
                {
                    m_dataFromFileSlin = null;
                }
            }   
            else if(a_orderItemSlin == "Duration")
            {
                int m_timeHoursSlin = 0;
                int m_timeMinutesSlin = 0;
                int m_timeSecondsSlin = 0;

                m_timeHoursSlin = tfileSlin.Properties.Duration.Hours;
                m_timeMinutesSlin = tfileSlin.Properties.Duration.Minutes;
                m_timeMinutesSlin = tfileSlin.Properties.Duration.Seconds;

                if(m_timeHoursSlin < 10)
                {
                    m_dataFromFileSlin += "0";
                }
                m_dataFromFileSlin += m_timeHoursSlin + ";";

                if(m_timeMinutesSlin < 10)
                {
                    m_dataFromFileSlin += "0";
                }
                m_dataFromFileSlin += m_timeMinutesSlin + ";";

                if (m_timeSecondsSlin < 10)
                {
                    m_dataFromFileSlin += "0";
                }
                m_dataFromFileSlin += m_timeSecondsSlin + ";";
            }

            return m_dataFromFileSlin;
        }
    }
}
