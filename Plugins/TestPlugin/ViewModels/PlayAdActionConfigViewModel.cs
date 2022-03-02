using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.ViewModels
{
    internal class PlayAdActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        public PlayAdActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public int Length
        {
            get => Configuration.Length;            
            set => Configuration.Length = value;            
        }

        public PlayAdActionConfigViewModel(PluginAction action)
        {
            this.Configuration = PlayAdActionConfigModel.Deserialize(action.Configuration);
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
            _action.ConfigurationSummary = $"{ Configuration.Length } seconds";
            _action.Configuration = Configuration.Serialize();
        }

    }
}
