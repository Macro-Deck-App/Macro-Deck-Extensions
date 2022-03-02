using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.ViewModels
{
    internal class SendChatMessageActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        public SendChatMessageActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public string Message
        {
            get => Configuration.Message;            
            set => Configuration.Message = value;            
        }

        public SendChatMessageActionConfigViewModel(PluginAction action)
        {
            this.Configuration = SendChatMessageActionConfigModel.Deserialize(action.Configuration);
            this._action = action;
        }

        public bool SaveConfig()
        {
            if (string.IsNullOrWhiteSpace(this.Message))
            {
                return false;
            }
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
            _action.ConfigurationSummary = Configuration.Message;
            _action.Configuration = Configuration.Serialize();
        }

    }
}
