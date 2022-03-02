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
    public class SetSubscriberChatAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionSetSubscriberChat;

        public override string Description => PluginLanguageManager.PluginStrings.ActionSetSubscriberChatDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            var configModel = SetSubscriberChatActionConfigModel.Deserialize(this.Configuration);
            if (configModel != null)
            {
                switch (configModel.Method)
                {
                    case SetSubscriberChatActionMethod.On:
                        TwitchHelper.SetSubscriberChat(true);
                        break;
                    case SetSubscriberChatActionMethod.Off:
                        TwitchHelper.SetSubscriberChat(false);
                        break;
                    case SetSubscriberChatActionMethod.Toggle:
                        TwitchHelper.SetSubscriberChat(!TwitchHelper.SubscibersOnlyChat);
                        break;
                }
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new SetSubscriberChatActionConfigView(this);
        }
    }
}
