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
    public class SetEmoteChatAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionSetEmoteChat;

        public override string Description => PluginLanguageManager.PluginStrings.ActionSetEmoteChatDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            var configModel = SetSlowChatActionConfigModel.Deserialize(this.Configuration);
            if (configModel != null)
            {
                switch (configModel.Method)
                {
                    case SetSlowChatActionMethod.On:
                        TwitchHelper.SetEmoteChat(true);
                        break;
                    case SetSlowChatActionMethod.Off:
                        TwitchHelper.SetEmoteChat(false);
                        break;
                    case SetSlowChatActionMethod.Toggle:
                        TwitchHelper.SetEmoteChat(!TwitchHelper.EmotesOnlyChat);
                        break;
                }
            }
        }
        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new SetEmoteChatActionConfigView(this);
        }
    }
}

