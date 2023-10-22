using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorVideo.Helper
{
    public class Setting
    {
        public Setting()
        {
        }

        public int VideoIdx { get; set; } = 0;

        public readonly float[] VideoSpeedRates = new[] { 0.25f, 0.5f, 0.75f, 1f, 1.25f, 1.5f, 1.75f, 2.0f };
        public float VideoSpeedRate { get; set; } = 1.0f;

        private bool _playstate = false;

        public bool IsPlaying
        {
            get => _playstate;
            set { _playstate = value; }
        }

        public bool IsPaused
        {
            get => _playstate ? false : true;
            set { _playstate = !value; }
        }

        private float _SoundRate = 0.5f;

        public float SoundRate
        {
            get => _SoundRate;
            set
            {
                _SoundRate = value;
                _SoundRate = Math.Max(_SoundRate, 0);
                _SoundRate = Math.Min(_SoundRate, 1);
            }
        }

        private bool _ShowingSetting = false;
        public bool _SpeedSetting = false;
        private bool _QualitySetting = false;

        public bool ShowingSetting
        {
            get => _ShowingSetting;
            set
            {
                _ShowingSetting = value;
                if (_ShowingSetting == false)
                {
                    _SpeedSetting = _QualitySetting = false;
                }
            }
        }

        public bool SpeedSetting
        {
            get => _SpeedSetting;
            set
            {
                _SpeedSetting = value;
                if (_SpeedSetting == true)
                {
                    _QualitySetting = false;
                }
            }
        }

        public bool QualitySetting
        {
            get => _QualitySetting;
            set
            {
                _QualitySetting = value;
                if (_QualitySetting == true)
                {
                    _SpeedSetting = false;
                }
            }
        }

        public bool Mute { get; set; } = false;
        public bool Subtitle { get; set; }

        private bool _fullScreen = false;
        private bool _pip = false;
        private bool _cinema = false;

        public bool FullScreen
        {
            get => _fullScreen;
            set
            {
                _fullScreen = value;
                if (_fullScreen) _pip = _cinema = false;
            }
        }

        public bool PiP
        {
            get => _pip;
            set
            {
                _pip = value;
                if (_pip)
                {
                    _fullScreen = _cinema = false;
                }
            }
        }

        public bool Cinema
        {
            get => _cinema;
            set
            {
                _cinema = value;
                if (_cinema)
                {
                    _fullScreen = _pip = false;
                }
            }
        }
    }
}
}
