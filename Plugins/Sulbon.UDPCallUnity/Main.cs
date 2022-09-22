using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;
using System.Reflection;
using SuchByte.MacroDeck;


namespace Sulbon.UDPCallUnity
{
    public class Main : MacroDeckPlugin
    {
        // Optional; If your plugin can be configured, set to "true". It'll make the "Configure" button appear in the package manager.
        public override bool CanConfigure => false;

        static public Main Instance;

        // Gets called when the plugin is loaded
        public override void Enable()
        {
            Instance = this;
            this.Actions = new List<PluginAction>{
            // add the instances of your actions here
            new UDPSendMenu(),
        };
        }

        // Optional; Gets called when the user clicks on the "Configure" button in the package manager; If CanConfigure is not set to true, you don't need to add this
        public override void OpenConfigurator()
        {
            return;
        }


    }

}
