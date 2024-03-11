using MrVibes_RSA.StreamerbotPlugin.GUI;
using Newtonsoft.Json;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Net.Http;
using System.Text;

namespace MrVibes_RSA.StreamerbotPlugin.Actions
{
    public class StreamerBotAction : PluginAction
    {
        // The name of the action
        public override string Name => "Run Action";

        // A short description what the action can do
        public override string Description => "Select which Streamer.bot action to run.";

        // Optional; Add if this action can be configured. This will make the ActionConfigurator calling GetActionConfigurator();
        public override bool CanConfigure => true;

        // Optional; Add if you added CanConfigure; Gets called when the action can be configured and the action got selected in the ActionSelector. You need to return a user control with the "ActionConfigControl" class as base class
        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new StreamerBotActionConfigurator(this, actionConfigurator);
        }

        // Gets called when the action is triggered by a button press or an event
        public override void Trigger(string clientId, ActionButton actionButton)
        {
            DoStreamerbotAction(Configuration);
        }

        // Optional; Gets called when the action button gets deleted
        public override void OnActionButtonDelete()
        {

        }

        // Optional; Gets called when the action button is loaded
        public override void OnActionButtonLoaded()
        {

        }

        private async void DoStreamerbotAction(string configuration)
        {
            var ip = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(PluginInstance.Main, "IPAddress");
            var port = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(PluginInstance.Main, "PortNumber");

            // Define the base URL of the API
            string baseUrl = $"http://{ip}:{port}";

            // Define the endpoint
            string endpoint = "/DoAction";

            try
            {
                // Parse the configuration string into a JObject
                var configObject = JsonConvert.DeserializeObject<dynamic>(configuration);

                // Define the action data
                var actionData = new
                {
                    action = new
                    {
                        id = (string)configObject.actionId,
                        name = (string)configObject.actionName
                    },
                    args = new
                    {
                        key = (string)configObject.actionArgument
                    }
                };

                // Serialize the action data to JSON
                string jsonData = JsonConvert.SerializeObject(actionData);

                // Create a HttpClient
                using (var httpClient = new HttpClient())
                {
                    // Create a StringContent with JSON data
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Send the POST request to the API
                    var response = await httpClient.PostAsync(baseUrl + endpoint, content);

                    // Check if the response is successful (204 No Content)
                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        MacroDeckLogger.Info(PluginInstance.Main, "Action executed successfully.");
                    }
                    else
                    {
                        MacroDeckLogger.Trace(PluginInstance.Main, $"Failed to execute action. Status Code: {response.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                MacroDeckLogger.Trace(PluginInstance.Main, $"Failed to execute action. Message: {ex.Message}");
            }
        }
    }
}
