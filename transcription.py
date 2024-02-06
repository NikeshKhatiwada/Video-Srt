import os
import tempfile
import whisper

def convert_time_format(input_time):
    seconds = int(input_time)
    milliseconds = int((input_time - seconds) * 1000)

    minutes, seconds = divmod(seconds, 60)
    hours, minutes = divmod(minutes, 60)

    time_string = f"{hours:02}:{minutes:02}:{seconds:02},{milliseconds:03}"
    return time_string

def transcribe_audio(audio_file_name, model_type):
    if model_type == 't':
        model = whisper.load_model("tiny")
    elif model_type == 'b':
        model = whisper.load_model("base")
    elif model_type == 's':
        model = whisper.load_model("small")
    elif model_type == 'm':
        model = whisper.load_model("medium")
    elif model_type == 'l':
        model = whisper.load_model("large")
    else:
        model = whisper.load_model("small")

    current_directory = os.getcwd()
    current_directory = os.path.join(tempfile.gettempdir())
    audio_file_path = os.path.join(current_directory, "Video-Srt-Audios", audio_file_name)

    result = model.transcribe(audio_file_path)

    language = result["language"]
    sorted_segments = sorted(result["segments"], key=lambda x: x["start"])
    transcript = ""

    i = 1;
    for segment in sorted_segments:
        start_time = segment["start"]
        end_time = segment["end"]
        text = segment["text"]
        text = text.strip()

        transcript += f"{i}\n"
        i += 1
        transcript += f"{convert_time_format(start_time)} --> {convert_time_format(end_time)}\n"
        transcript += f"{text}\n"
        transcript += "\n"

    return language, transcript