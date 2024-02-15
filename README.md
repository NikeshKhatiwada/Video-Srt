# नेपाली

## Video-Srt

Video-Srt C# र Python प्रयोग गरेर लेखिएको कन्सोल प्रोग्राम हो, जुन भिडियोहरूको लागि उपशीर्षकहरू उत्पन्न गर्न प्रयोग गर्न सकिन्छ।

## आवश्यकताहरु

प्रोग्राम प्रयोग गर्न, तपाईँले निम्न स्थापना गर्न आवश्यक छ:

- Python
- FFMPEG
- OpenAI Whisper

तपाईँको Python स्थापनालाई सङ्केत गर्न transcription_config.ini सम्पादन गर्न निश्चित गर्नुहोस्।

## प्रोग्राम कसरी प्रयोग गर्ने

१. तपाईंले माथि उल्लेख गरिएका सबै आवश्यकताहरू पूरा गर्नुभएको छ भनी सुनिश्चित गर्नुहोस्।
२. आफ्नो कम्प्युटरमा 'Releases' बाट प्रोग्राम डाउनलोड गर्नुहोस्।
३. टर्मिनल वा कमाण्ड प्रम्प्ट खोल्नुहोस्।
४. भिडियो भण्डारण गरिएको डाइरेक्टरीमा नेभिगेट गर्नुहोस् ।
५. कमाण्ड कार्यान्वयन गरेर प्रोग्राम चलाउनुहोस्:
```
"[Video_Srtको_मार्ग]" --vn "[भिडियो_फाइलको_नाम]" --wm [Whisper_मोडल]
```
[Video_Srtको_मार्ग] Video-Srt कार्यान्वयन योग्यको पूरा मार्गसँग, [भिडियो_फाइलको_नाम] भिडियो फाइलको पूरा नामसँग, र [Whisper_मोडल] इच्छित Whisper मोडेल प्रकारसँग बदल्नुहोस्।

उपलब्ध Whisper मोडेल प्रकारहरू हुन्:

- `t`: अत्यन्त सानो मोडेल
- `b`: आधार मोडेल
- `s`: सानो मोडेल (निर्दिष्ट नगरिएमा पूर्वनिर्धारित)
- `m`: मध्यम मोडेल
- `l`: ठूलो मोडेल

# English

## Video-Srt

Video-Srt is a console program written using C# and Python, that can be used to generate subtitles for videos.

## Requirements

To run the program, you need to have the following installed:

- Python
- FFMPEG
- OpenAI Whisper

Make sure to modify transcription_config.ini to point to your Python installation.

## How to use program

1. Ensure you have met all the requirements mentioned above.
2. Download the program from 'Releases' to your computer.
3. Open a terminal or command prompt.
4. Navigate to the directory where the video is stored.
5. Run the program by executing the command:
```
"[path_to_video_srt]" --vn "[video_file_name]" --wm [whisper_model]
```
Replace [path_to_video_srt] with the full path to the Video-Srt executable, [video_file_name] with the full name of video file, and [whisper_model] with the desired Whisper model type.

The available Whisper model types are:

- `t`: Tiny model
- `b`: Base model
- `s`: Small model (default if not specified)
- `m`: Medium model
- `l`: Large model
