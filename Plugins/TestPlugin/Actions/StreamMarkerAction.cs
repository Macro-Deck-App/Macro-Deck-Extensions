using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.TwitchPlugin.Actions
{
    public class StreamMarkerAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionStreamMarker;

        public override string Description => PluginLanguageManager.PluginStrings.ActionStreamMarkerDescription;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            TwitchHelper.Marker();
        }
    }
}
