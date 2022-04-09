using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSoft.MediaInfo.Models
{
    public class Settings
    {
        public bool IsTitleEnabled;
        public bool IsAlbumTitleEnabled;
        public bool IsArtistEnabled;
        public bool IsIsPlayingEnabled;
        public bool IsPlayingStatusEnabled;

        public string TitleVariableName;
        public string AlbumTitleVariableName;
        public string ArtistVariableName;
        public string IsPlayingVariableName;
        public string PlayingStatusVariableName;

        public Settings()
        {

        }


        public void SaveSettings(MacroDeckPlugin plugin)
        {
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "IsTitleEnabled", IsTitleEnabled.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "TitleVariableName", TitleVariableName.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "IsAlbumTitleEnabled", IsAlbumTitleEnabled.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "AlbumTitleVariableName", AlbumTitleVariableName.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "IsArtistEnabled", IsArtistEnabled.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "ArtistVariableName", ArtistVariableName.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "IsIsPlayingEnabled", IsIsPlayingEnabled.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "IsPlayingVariableName", IsPlayingVariableName.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "IsPlayingStatusEnabled", IsPlayingStatusEnabled.ToString());
            SuchByte.MacroDeck.Plugins.PluginConfiguration.SetValue(plugin, "PlayingStatusVariableName", PlayingStatusVariableName.ToString());
        }

        static public Settings GetSettings(MacroDeckPlugin plugin)
        {
            Settings result = new Settings();
        
            bool.TryParse(SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "IsTitleEnabled"), out result.IsTitleEnabled);
            result.TitleVariableName = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "TitleVariableName");
            bool.TryParse(SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "IsAlbumTitleEnabled"),out result.IsAlbumTitleEnabled);
            result.AlbumTitleVariableName = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "AlbumTitleVariableName");
            bool.TryParse(SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "IsArtistEnabled"),out result.IsArtistEnabled);
            result.ArtistVariableName = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "ArtistVariableName");
            bool.TryParse(SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "IsIsPlayingEnabled"),out result.IsIsPlayingEnabled);
            result.IsPlayingVariableName = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "IsPlayingVariableName");
            bool.TryParse(SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "IsPlayingStatusEnabled"),out result.IsPlayingStatusEnabled);
            result.PlayingStatusVariableName = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(plugin, "PlayingStatusVariableName");

            if (result.TitleVariableName == "")
                result.TitleVariableName = "media_info_title";

            if (result.AlbumTitleVariableName == "")
                result.AlbumTitleVariableName = "media_info_album_title";

            if (result.ArtistVariableName == "")
                result.ArtistVariableName = "media_info_artist";

            if (result.IsPlayingVariableName == "")
                result.IsPlayingVariableName = "media_info_is_playing";

            if (result.PlayingStatusVariableName == "")
                result.PlayingStatusVariableName = "media_info_playing_status";

            return result;
        }

    }
}
