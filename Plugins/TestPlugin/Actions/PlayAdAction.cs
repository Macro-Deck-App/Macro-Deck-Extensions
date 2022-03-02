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
using TwitchLib.Client.Enums;

namespace SuchByte.TwitchPlugin.Actions
{
    public class PlayAdAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionPlayAd;

        public override string Description => PluginLanguageManager.PluginStrings.ActionPlayAdDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            object commercialLength;
            Enum.TryParse(typeof(CommercialLength), PlayAdActionConfigModel.Deserialize(this.Configuration).Length.ToString(), out commercialLength);
            TwitchHelper.PlayAd((CommercialLength)commercialLength);
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new PlayAdActionConfigView(this);
        }
    }
}
