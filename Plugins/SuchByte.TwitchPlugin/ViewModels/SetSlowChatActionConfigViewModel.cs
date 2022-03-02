using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.ViewModels
{
    internal class SetSlowChatActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        public SetSlowChatActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public SetSlowChatActionMethod Method
        {
            get => Configuration.Method;            
            set => Configuration.Method = value;            
        }

        public TimeSpan MessageCooldown
        {
            get => TimeSpan.FromSeconds(Configuration.MessageCooldown);
            set => Configuration.MessageCooldown = value.TotalSeconds;            
        }

        public SetSlowChatActionConfigViewModel(PluginAction action)
        {
            this.Configuration = SetSlowChatActionConfigModel.Deserialize(action.Configuration);
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
            _action.ConfigurationSummary = Configuration.Method.ToString();
            _action.Configuration = Configuration.Serialize();
        }

    }
}
