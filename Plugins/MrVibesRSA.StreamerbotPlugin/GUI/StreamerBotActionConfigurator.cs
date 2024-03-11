/*
 * File: StreamerBotActionConfigurator.cs
 * Author: MrVibes_RSA
 * Created: 09/03/2024
 * Description: Configurator for Streamer Bot actions in MacroDeck.
 */
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MrVibes_RSA.StreamerbotPlugin.GUI
{
    public partial class StreamerBotActionConfigurator : ActionConfigControl
    {
        // Add a variable for the instance of your action to get access to the Configuration etc.
        private PluginAction _macroDeckAction;

        public StreamerBotActionConfigurator(PluginAction macroDeckAction, ActionConfigurator actionConfigurator)
        {
            this._macroDeckAction = macroDeckAction;
            InitializeComponent();
            Task task = GetActionList();
        }

        public async Task GetActionList()
        {
            var ip = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(PluginInstance.Main, "IPAddress");
            var port = SuchByte.MacroDeck.Plugins.PluginConfiguration.GetValue(PluginInstance.Main, "PortNumber");

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
                        // Deserialize the JSON response
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                        comboBox_ActionList.Items.Clear();

                        // Now you can access the list of actions in apiResponse.actions
                        foreach (var action in apiResponse.actions)
                        {
                            // Process each action
                            //MacroDeckLogger.Error(PluginInstance.Main, $"Action Name: {action.name}, Group: {action.group}, Enabled: {action.enabled}, Subactions Count: {action.subactions_count}");
                            comboBox_ActionList.Items.Add(action);
                        }



                        if (_macroDeckAction.Configuration != null)
                        {
                            // Assuming _macroDeckAction.Configuration is a valid JSON string
                            JObject configurationObject = JObject.Parse(_macroDeckAction.Configuration);
                            // Further processing with configurationObject...
                            var selected = configurationObject["actionName"]?.ToString();

                            if (selected == string.Empty)
                            {
                                // Handle the case where selected is null or empty
                                if (comboBox_ActionList.Items.Count > 0)
                                {
                                    comboBox_ActionList.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                comboBox_ActionList.Text = selected;
                            }

                            textBox_Arguments.Text = configurationObject["actionArgument"]?.ToString();

                        }
                        else
                        {
                            // Handle the case where _macroDeckAction.Configuration is null
                            // For example, you could provide default values or log a message.
                            MacroDeckLogger.Info(PluginInstance.Main, "_macroDeckAction.Configuration is null.");
                        }
                    }
                    else
                    {
                        // If the response is not successful, display an error message
                        MacroDeckLogger.Error(PluginInstance.Main, "Failed to retrieve actions from the server. Status Code: " + response.StatusCode);
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "HTTP request failed, Please check Logs");
                MacroDeckLogger.Trace(PluginInstance.Main, "HTTP request failed: " + ex.Message);
            }
            catch (JsonException ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "JSON deserialization error, Please check Logs");
                MacroDeckLogger.Trace(PluginInstance.Main, "JSON deserialization error: " + ex.Message);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "An unexpected error occurred, Please check Logs");
                MacroDeckLogger.Trace(PluginInstance.Main, "An unexpected error occurred: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        public override bool OnActionSave()
        {
            if (comboBox_ActionList.SelectedItem == null)
            {
                return false; // Return false if no action is selected
            }

            try
            {
                string summary = "";
                // Retrieve the selected Action object
                Action selectedAction = (Action)comboBox_ActionList.SelectedItem;

                JObject configuration = new JObject();
                configuration["actionId"] = selectedAction.id; // Save the ID of the selected action
                configuration["actionName"] = selectedAction.name; // Save the name of the selected action
                configuration["actionArgument"] = textBox_Arguments.Text;

                if(configuration["actionArgument"].ToString() == string.Empty)
                {
                    summary = $"Name - '{configuration["actionName"]}'";
                }
                else
                {
                    summary = $"Name - '{configuration["actionName"]}', Value - '{configuration["actionArgument"]}'";
                }

                this._macroDeckAction.ConfigurationSummary = summary; // Set a summary of the configuration that gets displayed in the ButtonConfigurator item
                this._macroDeckAction.Configuration = configuration.ToString();
            }
            catch { }
            return true; // Return true if the action was configured successfully; This closes the ActionConfigurator
        }

        private async void btn_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                await GetActionList();
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Trace(PluginInstance.Main, "Failed to refresh actions: " + ex.Message);
            }
        }
    }

    // Define classes to match the JSON structure
    public class Action
    {
        public string id { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public bool enabled { get; set; }
        public int subactions_count { get; set; }

        // Override the ToString() method to return the action's name
        public override string ToString()
        {
            return name;
        }
    }

    public class ApiResponse
    {
        public int count { get; set; }
        public Action[] actions { get; set; }
    }
}
