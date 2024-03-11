using MrVibes_RSA.StreamerbotPlugin.Actions;
using MrVibes_RSA.StreamerbotPlugin.GUI;
using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;

namespace MrVibes_RSA.StreamerbotPlugin
{
    public static class PluginInstance
    {
        public static Main Main { get; set; }
    }

    public class Main : MacroDeckPlugin
    {
        public Main()
        {
            PluginInstance.Main ??= this;
        }

        // Optional; If your plugin can be configured, set to "true". It'll make the "Configure" button appear in the package manager.
        public override bool CanConfigure => true;

        // Gets called when the plugin is loaded
        public override void Enable()
        {
            this.Actions = new List<PluginAction>
            {
                // add the instances of your actions here
                new StreamerBotAction(),
            };
        }

        // Optional; Gets called when the user clicks on the "Configure" button in the package manager; If CanConfigure is not set to true, you don't need to add this
        public override void OpenConfigurator()
        {
            using var pluginConfig = new PluginConfig();
            pluginConfig.ShowDialog();
        }
    }
}
