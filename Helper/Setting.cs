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

        private float _soundRate = 0.5f;

        public float SoundRate
        {
            get => _soundRate;
            set
            {
                _soundRate = value;
                _soundRate = Math.Max(_soundRate, 0);
                _soundRate = Math.Min(_soundRate, 1);
            }
        }

        private bool _showingSetting = false;
        private bool _speedSetting = false;
        private bool _qualitySetting = false;

        public bool ShowingSetting
        {
            get => _showingSetting;
            set
            {
                _showingSetting = value;
                if (_showingSetting == false)
                {
                    _speedSetting = _qualitySetting = false;
                }
            }
        }

        public bool SpeedSetting
        {
            get => _speedSetting;
            set
            {
                _speedSetting = value;
                if (_speedSetting == true)
                {
                    _qualitySetting = false;
                }
            }
        }

        public bool QualitySetting
        {
            get => _qualitySetting;
            set
            {
                _qualitySetting = value;
                if (_qualitySetting == true)
                {
                    _speedSetting = false;
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

