using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.ViewModels
{
    internal class SetTitleGameActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        public SetTitleGameActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public string StreamTitle
        {
            get => Configuration.StreamTitle;
            set => Configuration.StreamTitle = value;
        }

        public string Game
        {
            get => Configuration.Game;
            set => Configuration.Game = value;
        }

        public SetTitleGameActionConfigViewModel(PluginAction action)
        {
            this.Configuration = SetTitleGameActionConfigModel.Deserialize(action.Configuration);
            this._action = action;
        }

        public bool SaveConfig()
        {
            try
            {
                SetConfig();
                MacroDeckLogger.Info(PluginInstance.Main, $"{GetType().Name}: config saved");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, $"{GetType().Name}: Error while saving config: { ex.Message + Environment.NewLine + ex.StackTrace }");
            }
            return true;
        }

        public void SetConfig()
        {
            _action.ConfigurationSummary = "Stream title: " + this.StreamTitle + " | " + "Game: " + this.Game;
            _action.Configuration = Configuration.Serialize();
        }

    }
}
