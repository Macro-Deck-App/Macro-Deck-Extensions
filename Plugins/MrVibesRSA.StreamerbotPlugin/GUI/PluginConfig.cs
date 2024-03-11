using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Data;
using System.Drawing;
using System.Net.Http;

namespace MrVibes_RSA.StreamerbotPlugin.GUI
{
    public partial class PluginConfig : DialogForm
    {
        public PluginConfig()
        {
            InitializeComponent();

            var ip = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(PluginInstance.Main, "IPAddress") ?? "127.0.0.1";
            var port = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(PluginInstance.Main, "PortNumber") ?? "7474";

            if (String.IsNullOrEmpty(ip))
            { 
                ip = "127.0.0.1";
            }

            if (String.IsNullOrEmpty(port))
            {
                port = "7474";
            }
            textBox_IP.Text = ip;
            textBox_Port.Text = port;
        }

        private async void btn_Test_Click(object sender, EventArgs e)
        {
            var ip = textBox_IP.Text;
            var port = textBox_Port.Text;

            /// do HTTP get to ip:port/GetActions
            // Construct the URL
            var url = $"http://{ip}:{port}/GetActions";

            try
            {
                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    // Send the GET request and wait for the response
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // If the response is successful, display an success message
                        label_ConnectionStatus.Text = "Connection Successful";
                        label_ConnectionStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        // If the response is not successful, display an error message
                        label_ConnectionStatus.Text = "Connection Failed";
                        label_ConnectionStatus.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the request
                // If the response is not successful, display an error message
                label_ConnectionStatus.Text = "Connection Failed";
                label_ConnectionStatus.ForeColor = Color.Red;
                MacroDeckLogger.Error(PluginInstance.Main, ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            PluginConfiguration.SetValue(PluginInstance.Main, "IPAddress", textBox_IP.Text);
            PluginConfiguration.SetValue(PluginInstance.Main, "PortNumber", textBox_Port.Text);

            this.Close();
        }
    }
}
