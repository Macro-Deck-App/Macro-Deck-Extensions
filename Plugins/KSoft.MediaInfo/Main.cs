using System;
using KSoft.MediaInfo.Models;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using Windows.Media.Control;

namespace KSoft.MediaInfo
{
    public class Main : MacroDeckPlugin
    {
        private GlobalSystemMediaTransportControlsSessionManager _manager=null;
        private GlobalSystemMediaTransportControlsSession _session=null;
        public override bool CanConfigure => true;
        public Settings _settings;

        public override async void Enable()
        {
            _settings = Settings.GetSettings(this);

            _manager = await GlobalSystemMediaTransportControlsSessionManager.RequestAsync();
            if (_manager != null)
            {
                _manager.SessionsChanged += _manager_SessionsChanged;
            }
            _manager_SessionsChanged(null, null);
        }

        private void  _manager_SessionsChanged(GlobalSystemMediaTransportControlsSessionManager sender, SessionsChangedEventArgs args)
        {
            if (_manager != null)
            {
                _session = _manager.GetCurrentSession();
                if (_session != null)
                {
                    _session.MediaPropertiesChanged += _session_MediaPropertiesChanged;
                    _session.PlaybackInfoChanged += _session_PlaybackInfoChanged;
                }                
            }
            else
            {
                _session = null;
            }
            _session_MediaPropertiesChanged(null, null);
            _session_PlaybackInfoChanged(null, null);
        }

        private void _session_PlaybackInfoChanged(GlobalSystemMediaTransportControlsSession sender, PlaybackInfoChangedEventArgs args)
        {
            string state="";
            bool isPlaying = false;

            if (_session != null)
            {
                var info = _session.GetPlaybackInfo();
                if (info != null)
                {
                    switch (info.PlaybackStatus)
                    {
                        case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing:
                            state = "playing";
                            break;
                        case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Paused:
                            state = "paused";
                            break;
                        case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Closed:
                            state = "closed";
                            break;
                        case GlobalSystemMediaTransportControlsSessionPlaybackStatus.Stopped:
                            state = "stopped";
                            break;
                        default:
                            state = "other";
                            break;
                    }
                    isPlaying = (info.PlaybackStatus == GlobalSystemMediaTransportControlsSessionPlaybackStatus.Playing);
                }
            }
            if (_settings.IsIsPlayingEnabled)
                SuchByte.MacroDeck.Variables.VariableManager.SetValue(_settings.IsPlayingVariableName, isPlaying, VariableType.Bool, this, false);

            if (_settings.IsPlayingStatusEnabled)
                SuchByte.MacroDeck.Variables.VariableManager.SetValue(_settings.PlayingStatusVariableName, state, VariableType.String, this, false);
            
        }

        private async void _session_MediaPropertiesChanged(GlobalSystemMediaTransportControlsSession sender, MediaPropertiesChangedEventArgs args)
        {
            string title = "";
            string albumTitle = "";
            string artist = "";

            if (_session != null)
            {
                try
                {
                    var info = await _session.TryGetMediaPropertiesAsync();
                    if (info != null)
                    {

                        title = info.Title;
                        albumTitle = info.AlbumTitle;
                        artist = info.Artist;
                    }
                }
                catch(Exception ex)
                {

                }
            }

            if (_settings.IsTitleEnabled)
                SuchByte.MacroDeck.Variables.VariableManager.SetValue(_settings.TitleVariableName, title, VariableType.String, this, false);

            if (_settings.IsAlbumTitleEnabled)
                SuchByte.MacroDeck.Variables.VariableManager.SetValue(_settings.AlbumTitleVariableName, albumTitle, VariableType.String, this, false);
            
            if (_settings.IsArtistEnabled)
                SuchByte.MacroDeck.Variables.VariableManager.SetValue(_settings.ArtistVariableName, artist, VariableType.String, this, false);
        }

        public override void OpenConfigurator()
        {
            // Open your configuration form here            
            using (var configurator = new PluginConfiguration(_settings))
            {
                if (configurator.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                {
                    _settings.SaveSettings(this);
                    _session_MediaPropertiesChanged(null, null);
                    _session_PlaybackInfoChanged(null, null);
                }
            }
            
        }
    }
}
