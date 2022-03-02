using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Language;
using SuchByte.TwitchPlugin.Models;
using SuchByte.TwitchPlugin.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.Actions
{
    public class SetFollowerChatAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionSetFollowerChat;

        public override string Description => PluginLanguageManager.PluginStrings.ActionSetFollowerChatDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            var configModel = SetFollowerChatActionConfigModel.Deserialize(this.Configuration);
            if (configModel != null)
            {
                switch (configModel.Method)
                {
                    case SetFollowerChatActionMethod.On:
                        TwitchHelper.FollowerChat(true, TimeSpan.FromSeconds(configModel.RequiredFollowTime));
                        break;
                    case SetFollowerChatActionMethod.Off:
                        TwitchHelper.FollowerChat(false, TimeSpan.Zero);
                        break;
                    case SetFollowerChatActionMethod.Toggle:
                        TwitchHelper.FollowerChat(!TwitchHelper.FollowersOnlyChat, TimeSpan.FromSeconds(configModel.RequiredFollowTime));
                        break;
                }
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new SetFollowerChatActionConfigView(this);
        }
    }
}
