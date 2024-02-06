using FFMpegCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Srt
{
    public class FFMpegAudioExtractor
    {
        string tempAudioDirectory = Path.Combine(Path.GetTempPath(), "Video-Srt-Audios");

        public string ExtractAudio(string videoPath)
        {
            if (!Directory.Exists(tempAudioDirectory))
            {
                Directory.CreateDirectory(tempAudioDirectory);
            }

            // Console.WriteLine("Temporary Directory: " + tempAudioDirectory);

            string audioName = Path.GetFileNameWithoutExtension(videoPath) + ".mp3";
            string audioPath = Path.Combine(tempAudioDirectory, audioName);

            FFMpeg.ExtractAudio(videoPath, audioPath);

            return Path.GetFileName(audioPath);
        }
    }
}
