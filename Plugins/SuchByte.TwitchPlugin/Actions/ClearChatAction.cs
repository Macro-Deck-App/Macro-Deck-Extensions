using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.Actions
{
    public class ClearChatAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionClearChat;

        public override string Description => PluginLanguageManager.PluginStrings.ActionClearChatDescription;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            TwitchHelper.ClearChat();
        }
    }
}
