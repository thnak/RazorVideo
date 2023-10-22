﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VideoNet.Helper
{
    internal class VideoHelper
    {
    }

    public class VideoDimention
    {
        public VideoDimention()
        {
        }

        public VideoDimention(int height, int width)
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

        public Media(string[] sources, VideoDimention videoDimention, string poster)
        {
            Sources = sources;
            Dimention = videoDimention;
            Poster = poster;
        }

        private string[] _sources;
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

        public string[] Sources
        {
            get => _sources;

            set
            {
                var srcs = from src in _sources where !string.IsNullOrEmpty(src) select src;
                _sources = srcs.ToArray();
            }
        }

        public VideoDimention Dimention { get; set; }
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