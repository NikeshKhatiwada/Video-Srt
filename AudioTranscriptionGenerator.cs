using Microsoft.Extensions.Configuration;
using Python.Runtime;
using System.Globalization;

namespace Video_Srt
{
    public class AudioTranscriptionGenerator
    {
        private readonly IConfiguration _configuration;

        public AudioTranscriptionGenerator()
        {
            _configuration = LoadConfiguration();
            string pythonDll = _configuration["Python:PythonDll"];

            if (string.IsNullOrEmpty(pythonDll))
            {
                throw new Exception("Python DLL is not available in configuration.");
            }
            if (!File.Exists(pythonDll))
            {
                throw new Exception("The Python DLL file doesn't exist.");
            }

            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", pythonDll);

            PythonEngine.Initialize();
        }

        ~AudioTranscriptionGenerator()
        {
            PythonEngine.Shutdown();
        }

        public void GenerateTranscript(string currentDirectory, string audioName, char whisperModel)
        {
            using (Py.GIL())
            {
                dynamic sys = Py.Import("sys");
                sys.path.append(AppDomain.CurrentDomain.BaseDirectory);
                dynamic module = Py.Import("transcription");
                dynamic transcribeAudioFunction = module.GetAttr("transcribe_audio");
                PyTuple result = transcribeAudioFunction(audioName, whisperModel);
                string language = result[0].As<string>();
                string transcript = result[1].As<string>();

                Console.WriteLine("Detected Video Language: " + CultureInfo.GetCultureInfo(language));

                string subtitleName = Path.GetFileNameWithoutExtension(audioName) + ".srt";
                string subtitlePath = Path.Combine(currentDirectory, subtitleName);

                File.WriteAllText(subtitlePath, transcript);
                Console.WriteLine("Subtitle has been saved as: " + Path.Combine(currentDirectory, subtitleName));
            }
        }
        public IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddIniFile("transcription_config.ini")
                .Build();
        }
    }
}
