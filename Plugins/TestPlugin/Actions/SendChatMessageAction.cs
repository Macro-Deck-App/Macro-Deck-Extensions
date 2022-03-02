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
    public class SendChatMessageAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionSendChatMessage;

        public override string Description => PluginLanguageManager.PluginStrings.ActionSendChatMessageDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            var message = SendChatMessageActionConfigModel.Deserialize(this.Configuration).Message;
            foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.Variables)
            {
                if (message.ToLower().Contains("{" + variable.Name.ToLower() + "}"))
                {
                    message = message.Replace("{" + variable.Name + "}", variable.Value.ToString(), StringComparison.OrdinalIgnoreCase);
                }
            }

            TwitchHelper.SendChatMessage(message);   
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new SendChatMessageActionConfigView(this);
        }
    }
}
