﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicRenamerSlin_11_2_2020
{
    public class ACRCloudStatusCode
    {
        public static string HTTP_ERROR = "{\"status\":{\"msg\":\"Http Error\", \"code\":3000}}";
        public static string NO_RESULT = "{\"status\":{\"msg\":\"No Result\", \"code\":1001}}";
        public static string GEN_FP_ERROR = "{\"status\":{\"msg\":\"Gen Fingerprint Error\", \"code\":2004}}";
        public static string DECODE_AUDIO_ERROR = "{\"status\":{\"msg\":\"Can not decode audio data\", \"code\":2004}}";
        public static string RECORD_ERROR = "{\"status\":{\"msg\":\"Record Error\", \"code\":2000}}";
        public static string JSON_ERROR = "{\"status\":{\"msg\":\"json error\", \"code\":2002}}";
        public static string MUTE_ERROR = "{\"status\":{\"msg\":\"May Be Mute\", \"code\":2006}}";
    }
}
