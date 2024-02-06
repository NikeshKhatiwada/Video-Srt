using Cocona;
using Video_Srt;

CoconaApp.Run((string? vn, char wm = 's') =>
{
    string currentDirectory = Environment.CurrentDirectory;
    string videoPath = Path.Combine(currentDirectory, vn);

    if (!File.Exists(videoPath))
    {
        throw new Exception("The video file doesn't exist.");
    }

    if (!IsVideoFile(videoPath))
    {
        throw new Exception("The file extension isn't recognised as video.");
    }

    FFMpegAudioExtractor audioExtractor = new FFMpegAudioExtractor();
    string audioName = audioExtractor.ExtractAudio(videoPath);

    AudioTranscriptionGenerator transcriptionGenerator = new AudioTranscriptionGenerator();
    transcriptionGenerator.GenerateTranscript(currentDirectory, audioName, wm);
});

static bool IsVideoFile(string videoPath)
{
    string[] videoExtensions =
        File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "video_extensions.txt"));

    try
    {
        string fileExtension = Path.GetExtension(videoPath);
        if (!videoExtensions.Any(e => e.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
        {
            return false;
        }
        return true;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        return false;
    }
}