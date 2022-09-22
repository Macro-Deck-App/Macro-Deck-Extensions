
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using SuchByte.MacroDeck.Logging;
using Sulbon.UDPCallUnity;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class UDPSendActionConfWnd : ActionConfigControl
    {
        PluginAction pluginAction;

        public UDPSendActionConfWnd(PluginAction pluginAction)
        {
            this.pluginAction = pluginAction;

            InitializeComponent();
            this.TextPort.Text = "8193";
            this.LoadConfig();
        }

        public override bool OnActionSave()
        {
            if (String.IsNullOrWhiteSpace(this.TextCommand.Text))
            {
                MacroDeckLogger.Error(Main.Instance, "command is empty: create action failed");
                return false;
            }

            
            JObject configurationObject = JObject.FromObject(new
            {
                port = this.TextPort.Text,
                command = this.TextCommand.Text,
            });
            this.pluginAction.Configuration = configurationObject.ToString();
            this.pluginAction.ConfigurationSummary = this.TextCommand.Text;


            MacroDeckLogger.Info(Main.Instance, $"UDPSendActionConfWnd OnActionSave {this.pluginAction.Configuration}");

            return true;
        }



        private void LoadConfig()
        {
            if (string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
            {
             //   MacroDeckLogger.Error(Main.Instance, $"UDPSendActionConfWnd LoadConfig empty");
                return;
            }
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.TextPort.Text = configurationObject["port"].ToString();
                this.TextCommand.Text = configurationObject["command"].ToString();
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(Main.Instance, $"UDPSendActionConfWnd LoadConfig {ex.Message}");
            }
            
        }

    }
}
