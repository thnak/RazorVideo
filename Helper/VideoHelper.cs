using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorVideo.Helper
{
    internal class VideoHelper
    {
    }

    public class VideoDimension
    {
        public VideoDimension()
        {
        }

        public VideoDimension(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Media
    {
        public Media()
        {
        }

        public Media(string[] sources, VideoDimension videoDimension, string poster)
        {
            Sources = sources;
            Dimension = videoDimension;
            Poster = poster;
        }

        public double Duration { get; set; }

        public TimeSpan DurationTimeSpan
        {
            get => TimeSpan.FromSeconds(Duration);
        }

        public double CurrentTime { get; set; }

        public TimeSpan CurrentTimeTimeSpan
        {
            get => TimeSpan.FromSeconds(CurrentTime);
        }

        public double BufferedStart { get; set; }
        public double BufferedEnd { get; set; }
        public double BufferedLength { get; set; }
        public bool Muted { get; set; }
        public float Volumn { get; set; }
        public bool Loop { get; set; }
        public float DefaultPlaybackRate { get; set; }
        public bool Paused { get; set; }
        public float PlaybackRate { get; set; }

        public string TimeSpanString
        {
            get { return $"{timeInSecToTimeString(CurrentTime)} / {timeInSecToTimeString(Duration)}"; }
        }

        private string[] _sources;

        public string[] Sources
        {
            get => _sources;

            set
            {
                if (value is not null)
                {
                    IEnumerable<string>? srcs = from src in value where !string.IsNullOrEmpty(src) select src;
                    if(srcs.Any()) _sources = srcs.ToArray();
                }
            }
        }

        public VideoDimension Dimension { get; set; }
        public string Poster { get; set; }

        public string[] types
        {
            get
            {
                List<string> type = new List<string>();
                foreach (var source in Sources)
                {
                    string mediatype = source.Split(".").Last().ToLower();
                    switch (mediatype)
                    {
                        case "mp4":
                        {
                            type.Add("video/mp4");
                            break;
                        }
                        case "ogg":
                        {
                            type.Add("video/ogg");
                            break;
                        }
                        case "webm":
                        {
                            type.Add("video/webm");
                            break;
                        }
                        case "mp3":
                        {
                            type.Add("audio/mpeg");
                            break;
                        }
                        default:
                        {
                            type.Add("");
                            break;
                        }
                    }
                }

                return type.ToArray();
            }
        }

        private string timeInSecToTimeString(double time_)
        {
            var sec = time_ % (24 * 3600);
            var hours = Math.Floor(sec / 3600);
            sec %= 3600;
            var minus = Math.Floor(sec / 60);
            sec %= 60;
            return $"{hours}:{minus}:{Math.Floor(sec)}";
        }
    }
}