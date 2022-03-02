using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuchByte.TwitchPlugin
{
    internal static class CredentialsHelper
    {

        public static void UpdateCredentials(TwitchAccount twitchAccount)
        {
            Dictionary<string, string> credentials = new Dictionary<string, string>
            {
                ["token"] = twitchAccount.TwitchAccessToken
            };
            PluginCredentials.SetCredentials(PluginInstance.Main, credentials);
        }


        public static TwitchAccount GetTwitchAccount()
        {
            TwitchAccount account = null;
            try
            {
                List<Dictionary<string, string>> credentialsList = PluginCredentials.GetPluginCredentials(PluginInstance.Main);
                if (credentialsList == null || credentialsList.Count == 0) return null;
                Dictionary<string, string> credentials = credentialsList.FirstOrDefault();
                if (credentials == null) return null;
                account = new TwitchAccount()
                {
                    TwitchAccessToken = credentials["token"],
                };
            } catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, $"Error while getting credentials: { ex.Message + Environment.NewLine + ex.StackTrace }");
            }
            


            return account;
        }


    }
}
