using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.ViewModels
{
    internal class SetFollowerChatActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        public SetFollowerChatActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public SetFollowerChatActionMethod Method
        {
            get => Configuration.Method;
            set => Configuration.Method = value;
        }

        public TimeSpan RequiredFollowTime
        {
            get => TimeSpan.FromSeconds(Configuration.RequiredFollowTime);            
            set => Configuration.RequiredFollowTime = value.TotalSeconds;            
        }

        public SetFollowerChatActionConfigViewModel(PluginAction action)
        {
            this.Configuration = SetFollowerChatActionConfigModel.Deserialize(action.Configuration);
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
