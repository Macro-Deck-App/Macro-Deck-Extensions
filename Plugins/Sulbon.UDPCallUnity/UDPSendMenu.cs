using SuchByte.MacroDeck.Plugins;
using System.Collections.Generic;
using System.Reflection;
using SuchByte.MacroDeck;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Variables;
using System.Diagnostics;
using System;
using SuchByte.WindowsUtils.GUI;
using Newtonsoft.Json.Linq;
using System.Net.Sockets;
using System.Net;
using SuchByte.MacroDeck.Logging;

namespace Sulbon.UDPCallUnity
{
    public class UDPSendMenu : PluginAction
    {
        // The name of the action
        public override string Name => "UDP Send Menu Action";

        // A short description what the action can do
        public override string Description => "UDP Send Menu Action";

        // Optional; Add if this action can be configured. This will make the ActionConfigurator calling GetActionConfigurator();
        public override bool CanConfigure => true;

        // Optional; Add if you added CanConfigure; Gets called when the action can be configured and the action got selected in the ActionSelector. You need to return a user control with the "ActionConfigControl" class as base class
        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new UDPSendActionConfWnd(this);
        }

        // Gets called when the action is triggered by a button press or an event
        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (String.IsNullOrWhiteSpace(this.Configuration))
            {
                MacroDeckLogger.Error(Main.Instance, "UDPSendMenu Trigger empty");
                return;
            }
            
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var command = configurationObject["command"].ToString();
                var port = configurationObject["port"].ToString();
                int nPort = 0;
                int.TryParse(port, out nPort);

                UdpClient udpcSend = new UdpClient();
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(command);
                IPEndPoint remoteIpep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), nPort);//发送到的端口号以及IP地址
                udpcSend.Send(byteArray, byteArray.Length, remoteIpep);//发送
                udpcSend.Close();
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(Main.Instance, ex.Message);
            }
            
        }

        // Optional; Gets called when the action button gets deleted
        public override void OnActionButtonDelete()
        {

        }

        // Optional; Gets called when the action button is loaded
        public override void OnActionButtonLoaded()
        {

        }
    }

}
