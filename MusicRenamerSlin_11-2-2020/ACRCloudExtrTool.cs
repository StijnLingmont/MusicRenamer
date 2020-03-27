using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicRenamerSlin_11_2_2020
{
    class ACRCloudExtrTool
    {
        private int filter_energy_min_ = 0;
        private int silence_energy_threshold_ = 500;
        private float silence_rate_threshold_ = 0.9f;

        public ACRCloudExtrTool()
        {
            acr_init();
        }

        public ACRCloudExtrTool(int filter_energy_min, int silence_energy_threshold, float silence_rate_threshold)
        {
            this.filter_energy_min_ = filter_energy_min;
            this.silence_energy_threshold_ = silence_energy_threshold;
            this.silence_rate_threshold_ = silence_rate_threshold;

            acr_init();
        }

        /**
          *
          *  create "ACRCloud Fingerprint" by wav audio buffer(RIFF (little-endian) data, WAVE audio, Microsoft PCM, 16 bit, mono 8000 Hz) 
          *
          *  @param pcmBuffer query audio buffer
          *  @param pcmBufferLen the length of wavAudioBuffer
          *  @param isDB   If it is True, it will create db frigerprint; 
          *  
          *  @return result "ACRCloud Fingerprint"
          *
          **/
        public byte[] CreateFingerprint(byte[] pcmBuffer, int pcmBufferLen, bool isDB)
        {
            byte[] fpBuffer = null;
            if (pcmBuffer == null || pcmBufferLen <= 0)
            {
                return fpBuffer;
            }
            if (pcmBufferLen > pcmBuffer.Length)
            {
                pcmBufferLen = pcmBuffer.Length;
            }
            byte tIsDB = (isDB) ? (byte)1 : (byte)0;
            IntPtr pFpBuffer = IntPtr.Zero;
            int fpBufferLen = create_fingerprint(pcmBuffer, pcmBufferLen, tIsDB, this.filter_energy_min_, this.silence_energy_threshold_, this.silence_rate_threshold_, ref pFpBuffer);
            if (fpBufferLen <= 0)
            {
                return fpBuffer;
            }

            fpBuffer = new byte[fpBufferLen];
            Marshal.Copy(pFpBuffer, fpBuffer, 0, fpBufferLen);
            acr_free(pFpBuffer);

            return fpBuffer;
        }

        /**
          *
          *  create "ACRCloud Humming Fingerprint" by wav audio buffer(RIFF (little-endian) data, WAVE audio, Microsoft PCM, 16 bit, mono 8000 Hz) 
          *
          *  @param pcmBuffer query audio buffer
          *  @param pcmBufferLen the length of wavAudioBuffer
          *  
          *  @return result "ACRCloud Fingerprint"
          *
          **/
        public byte[] CreateHummingFingerprint(byte[] pcmBuffer, int pcmBufferLen)
        {
            byte[] fpBuffer = null;
            if (pcmBuffer == null || pcmBufferLen <= 0)
            {
                return fpBuffer;
            }
            if (pcmBufferLen > pcmBuffer.Length)
            {
                pcmBufferLen = pcmBuffer.Length;
            }

            IntPtr pFpBuffer = IntPtr.Zero;
            int fpBufferLen = create_humming_fingerprint(pcmBuffer, pcmBufferLen, ref pFpBuffer);
            if (fpBufferLen <= 0)
            {
                return fpBuffer;
            }

            fpBuffer = new byte[fpBufferLen];
            Marshal.Copy(pFpBuffer, fpBuffer, 0, fpBufferLen);
            acr_free(pFpBuffer);

            return fpBuffer;
        }

        /**
          *
          *  create "ACRCloud Fingerprint" by file path of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param filePath query file path
          *  @param startTimeSeconds skip (startSeconds) seconds from from the beginning of (filePath)
          *  @param audioLenSeconds Length of audio data you need. if you create recogize frigerprint, default is 12 seconds, if you create db frigerprint, it is not usefully; 
          *  @param isDB   If it is True, it will create db frigerprint; 
          *  
          *  @return result "ACRCloud Fingerprint"
          *
          **/
        public byte[] CreateFingerprintByFile(string filePath, int startTimeSeconds, int audioLenSeconds, bool isDB)
        {
            byte[] fpBuffer = null;

            byte tIsDB = (isDB) ? (byte)1 : (byte)0;
            IntPtr pFpBuffer = IntPtr.Zero;
            int fpBufferLen = create_fingerprint_by_file(filePath, startTimeSeconds, audioLenSeconds, tIsDB, this.filter_energy_min_, this.silence_energy_threshold_, this.silence_rate_threshold_, ref pFpBuffer);
            switch (fpBufferLen)
            {
                case -1:
                    throw new Exception(filePath + " is not readable!");
                case -2:
                    throw new Exception(filePath + " can not be decoded audio data!");
            }
            if (fpBufferLen == 0)
            {
                return fpBuffer;
            }

            fpBuffer = new byte[fpBufferLen];
            Marshal.Copy(pFpBuffer, fpBuffer, 0, fpBufferLen);
            acr_free(pFpBuffer);

            return fpBuffer;
        }

        /**
          *
          *  create "ACRCloud Humming Fingerprint" by file path of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param filePath query file path
          *  @param startTimeSeconds skip (startSeconds) seconds from from the beginning of (filePath)
          *  @param audioLenSeconds Length of audio data you need. if you create recogize frigerprint, default is 12 seconds, if you create db frigerprint, it is not usefully; 
          *  
          *  @return result "ACRCloud Humming Fingerprint"
          *
          **/
        public byte[] CreateHummingFingerprintByFile(string filePath, int startTimeSeconds, int audioLenSeconds)
        {
            byte[] fpBuffer = null;

            IntPtr pFpBuffer = IntPtr.Zero;
            int fpBufferLen = create_humming_fingerprint_by_file(filePath, startTimeSeconds, audioLenSeconds, ref pFpBuffer);
            switch (fpBufferLen)
            {
                case -1:
                    throw new Exception(filePath + " is not readable!");
                case -2:
                    throw new Exception(filePath + " can not be decoded audio data!");
            }
            if (fpBufferLen == 0)
            {
                return fpBuffer;
            }

            fpBuffer = new byte[fpBufferLen];
            Marshal.Copy(pFpBuffer, fpBuffer, 0, fpBufferLen);
            acr_free(pFpBuffer);

            return fpBuffer;
        }

        /**
          *
          *  create "ACRCloud Fingerprint" by file buffer of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param fileBuffer data buffer of input file
          *  @param fileBufferLen  length of fileBuffer
          *  @param startTimeSeconds skip (startSeconds) seconds from from the beginning of (filePath)
          *  @param audioLenSeconds Length of audio data you need. if you create recogize frigerprint, default is 12 seconds, if you create db frigerprint, it is not usefully; 
          *  @param isDB   If it is True, it will create db frigerprint; 
          *  
          *  @return result "ACRCloud Fingerprint"
          *
          **/
        public byte[] CreateFingerprintByFileBuffer(byte[] fileBuffer, int fileBufferLen, int startTimeSeconds, int audioLenSeconds, bool isDB)
        {
            byte[] fpBuffer = null;
            if (fileBufferLen > fileBuffer.Length)
            {
                fileBufferLen = fileBuffer.Length;
            }

            byte tIsDB = (isDB) ? (byte)1 : (byte)0;
            IntPtr pFpBuffer = IntPtr.Zero;
            int fpBufferLen = create_fingerprint_by_filebuffer(fileBuffer, fileBufferLen, startTimeSeconds, audioLenSeconds, tIsDB, this.filter_energy_min_, this.silence_energy_threshold_, this.silence_rate_threshold_, ref pFpBuffer);
            switch (fpBufferLen)
            {
                case -1:
                    throw new Exception("fileBuffer is not audio/video data!");
                case -2:
                    throw new Exception("fileBuffer can not be decoded audio data!");
            }
            if (fpBufferLen == 0)
            {
                return fpBuffer;
            }

            fpBuffer = new byte[fpBufferLen];
            Marshal.Copy(pFpBuffer, fpBuffer, 0, fpBufferLen);
            acr_free(pFpBuffer);
            return fpBuffer;
        }

        /**
          *
          *  create "ACRCloud Humming Fingerprint" by file buffer of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param fileBuffer data buffer of input file
          *  @param fileBufferLen  length of fileBuffer
          *  @param startTimeSeconds skip (startSeconds) seconds from from the beginning of (filePath)
          *  @param audioLenSeconds Length of audio data you need. if you create recogize frigerprint, default is 12 seconds, if you create db frigerprint, it is not usefully; 
          *  
          *  @return result "ACRCloud Humming Fingerprint"
          *
          **/
        public byte[] CreateHummingFingerprintByFileBuffer(byte[] fileBuffer, int fileBufferLen, int startTimeSeconds, int audioLenSeconds)
        {
            byte[] fpBuffer = null;
            if (fileBufferLen > fileBuffer.Length)
            {
                fileBufferLen = fileBuffer.Length;
            }

            IntPtr pFpBuffer = IntPtr.Zero;
            int fpBufferLen = create_humming_fingerprint_by_filebuffer(fileBuffer, fileBufferLen, startTimeSeconds, audioLenSeconds, ref pFpBuffer);
            switch (fpBufferLen)
            {
                case -1:
                    throw new Exception("fileBuffer is not audio/video data!");
                case -2:
                    throw new Exception("fileBuffer can not be decoded audio data!");
            }
            if (fpBufferLen == 0)
            {
                return fpBuffer;
            }

            fpBuffer = new byte[fpBufferLen];
            Marshal.Copy(pFpBuffer, fpBuffer, 0, fpBufferLen);
            acr_free(pFpBuffer);
            return fpBuffer;
        }

        /**
          *
          *  decode audio from file path of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param filePath query file path
          *  @param startTimeSeconds skip (startSeconds) seconds from from the beginning of (filePath)
          *  @param audioLenSeconds Length of audio data you need, if it is 0, will decode all the audio;  
          *  
          *  @return result audio data(formatter:RIFF (little-endian) data, WAVE audio, Microsoft PCM, 16 bit, mono 8000 Hz)
          *
          **/
        public byte[] DecodeAudioByFile(string filePath, int startTimeSeconds, int audioLenSeconds)
        {
            byte aa = 1;
            acr_set_debug(aa);
            byte[] audioBuffer = null;

            IntPtr pAudioBuffer = IntPtr.Zero;
            int fpBufferLen = decode_audio_by_file(filePath, startTimeSeconds, audioLenSeconds, ref pAudioBuffer);
            switch (fpBufferLen)
            {
                case -1:
                    throw new Exception(filePath + " is not readable!");
                case -2:
                    throw new Exception(filePath + " can not be decoded audio data!");
            }
            if (fpBufferLen == 0)
            {
                return audioBuffer;
            }

            audioBuffer = new byte[fpBufferLen];
            Marshal.Copy(pAudioBuffer, audioBuffer, 0, fpBufferLen);
            acr_free(pAudioBuffer);

            return audioBuffer;
        }

        /**
          *
          *  decode audio from file buffer of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param fileBuffer data buffer of input file
          *  @param fileBufferLen  length of fileBuffer
          *  @param startTimeSeconds skip (startSeconds) seconds from from the beginning of (filePath)
          *  @param audioLenSeconds Length of audio data you need, if it is 0, will decode all the audio;  
          *  
          *  @return result audio data(formatter:RIFF (little-endian) data, WAVE audio, Microsoft PCM, 16 bit, mono 8000 Hz)
          *
          **/
        public byte[] DecodeAudioByFileBuffer(byte[] fileBuffer, int fileBufferLen, int startTimeSeconds, int audioLenSeconds)
        {
            byte[] audioBuffer = null;

            if (fileBufferLen > fileBuffer.Length)
            {
                fileBufferLen = fileBuffer.Length;
            }
            IntPtr pAudioBuffer = IntPtr.Zero;
            int fpBufferLen = decode_audio_by_filebuffer(fileBuffer, fileBufferLen, startTimeSeconds, audioLenSeconds, ref pAudioBuffer);
            switch (fpBufferLen)
            {
                case -1:
                    throw new Exception("fileBuffer is not audio/video data!");
                case -2:
                    throw new Exception("fileBuffer can not be decoded audio data!");
            }
            if (fpBufferLen == 0)
            {
                return audioBuffer;
            }

            audioBuffer = new byte[fpBufferLen];
            Marshal.Copy(pAudioBuffer, audioBuffer, 0, fpBufferLen);
            acr_free(pAudioBuffer);
            return audioBuffer;
        }

        /**
          *
          *  get duration from file buffer of (Audio/Video file)
          *          Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...
          *          Video: mp4, mkv, wmv, flv, ts, avi ...
          *
          *  @param filePath query file path 
          *  
          *  @return duration ms
          *
          **/
        public int GetDurationMillisecondByFile(string filePath)
        {
            return get_duration_ms_by_file(filePath);
        }

        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int create_fingerprint(byte[] pcm_buffer, int pcm_buffer_len, byte is_db_fingerprint, int filter_energy_min, int silence_energy_threshold, float silence_rate_threshold, ref IntPtr fps_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int create_humming_fingerprint(byte[] pcm_buffer, int pcm_buffer_len, ref IntPtr fps_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int create_fingerprint_by_file(string file_path, int start_time_seconds, int audio_len_seconds, byte is_db_fingerprint, int filter_energy_min, int silence_energy_threshold, float silence_rate_threshold, ref IntPtr fps_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int create_humming_fingerprint_by_file(string file_path, int start_time_seconds, int audio_len_seconds, ref IntPtr fps_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int create_fingerprint_by_filebuffer(byte[] file_buffer, int file_buffer_len, int start_time_seconds, int audio_len_seconds, byte is_db_fingerprint, int filter_energy_min, int silence_energy_threshold, float silence_rate_threshold, ref IntPtr fps_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int create_humming_fingerprint_by_filebuffer(byte[] file_buffer, int file_buffer_len, int start_time_seconds, int audio_len_seconds, ref IntPtr fps_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int decode_audio_by_file(string file_path, int start_time_seconds, int audio_len_seconds, ref IntPtr audio_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int decode_audio_by_filebuffer(byte[] file_buffer, int file_buffer_len, int start_time_seconds, int audio_len_seconds, ref IntPtr audio_buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern void acr_free(IntPtr buffer);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern int get_duration_ms_by_file(string file_path);
        [DllImport("libacrcloud_extr_tool.dll")]
        public static extern void acr_set_debug(byte is_debug);
        [DllImport("libacrcloud_extr_tool.dll")]
        private static extern void acr_init();
    }
}
