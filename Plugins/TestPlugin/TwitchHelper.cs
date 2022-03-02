using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using SuchByte.TwitchPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Api.Helix.Models.Chat.ChatSettings;
using TwitchLib.Api.Services;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace SuchByte.TwitchPlugin
{
    public static class TwitchHelper
    {
        private static TwitchClient _client;

        private static string _channel;

        private static TwitchAPI _api;


        public static event EventHandler LoginSuccessful;

        public static event EventHandler LoginFailed;

        public static event EventHandler ConnectionStateChanged;

        private static string userId = "";
        private static string username = "";

        private static System.Timers.Timer updateTimer;

        public static bool SlowChat { get; set; } = false;

        public static bool FollowersOnlyChat { get; set; } = false;

        public static bool SubscibersOnlyChat { get; set; } = false;

        public static bool EmotesOnlyChat { get; set; } = false;


        public static void Connect(TwitchAccount account)
        {
            ConfigTwitchAPI(account.TwitchAccessToken);
            ConfigTwitchChat(account.TwitchAccessToken);
            if (updateTimer != null)
            {
                updateTimer.Enabled = false;
                updateTimer.Dispose();
            }
            updateTimer = new System.Timers.Timer
            {
                Interval = 1000*45,
                Enabled = true
            };
            updateTimer.Elapsed += UpdateTimer_Elapsed;
        }

        private static async void ConfigTwitchChat(string accesstoken)
        {
            try
            {
                char prefix = string.IsNullOrEmpty(PluginConfiguration.GetValue(PluginInstance.Main, "commandPrefix")) ? '!' : PluginConfiguration.GetValue(PluginInstance.Main, "commandPrefix")[0];
                var users = await _api.Helix.Users.GetUsersAsync();
                if (users == null || users.Users == null || users.Users.FirstOrDefault() == null) return;
                username = users.Users.FirstOrDefault().Login;
                MacroDeckLogger.Info(PluginInstance.Main, $"Using login: {username}");

                ConnectionCredentials credentials = new ConnectionCredentials(username, accesstoken);

                if (_client != null && _client.IsConnected)
                {
                    _client.Disconnect();
                }
                _client = new TwitchClient();
                _client.Initialize(credentials, username, prefix, prefix);

                _client.OnLog += Client_OnLog;
                _client.OnError += Client_OnError;
                _client.OnJoinedChannel += Client_OnJoinedChannel;
                _client.OnConnected += Client_OnConnected;
                _client.OnChannelStateChanged += Client_OnChannelStateChanged;
                _client.OnNewSubscriber += Client_OnNewSubscriber;
                _client.OnChatCommandReceived += Client_OnChatCommandReceived;

                _client.OnUserJoined += Client_OnUserJoined;
                _client.OnUserLeft += Client_OnUserLeft;

                _client.OnIncorrectLogin += Client_OnIncorrectLogin;
                _client.OnConnectionError += Client_OnConnectionError;
                _client.OnDisconnected += Client_OnDisconnected;

                _client.Connect();
                MacroDeckLogger.Info(PluginInstance.Main, "Connecting Twitch client...");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, "Failed to connect Twitch client: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private static void Client_OnChatCommandReceived(object sender, OnChatCommandReceivedArgs e)
        {
            if (e.Command.ChatMessage.IsModerator || e.Command.ChatMessage.IsBroadcaster)
            {
                MacroDeckLogger.Trace(PluginInstance.Main, "Command: [" + e.Command.CommandText + "] " + e.Command.ChatMessage.Username + " (Mod)");
                PluginInstance.Main.CommandIssued(e.Command.CommandText, e);
            }
        }

        private static void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_api == null) return;
            Task.Run(() => UpdateViewerCountAsync());
            Task.Run(() => UpdateFollowersAsync());
        }

        private static void ConfigTwitchAPI(string accessToken)
        {
            _api = new TwitchAPI();
            _api.Settings.ClientId = "m656oj5wocmg54tmjtkydhobl93ej4";
            _api.Settings.AccessToken = accessToken;
            Task.Run(() => {
                GetUserIdAsync();
                UpdateViewerCountAsync();
                UpdateFollowersAsync();
                UpdateSubscribersAsync();
                }
            );
        }


        private static async void SetTitleGameAsync(string title, string game)
        {
            try
            {
                string gameId = "";
                var games = await _api.Helix.Games.GetGamesAsync(gameNames: new List<string> { game });
                if (games != null && games.Games != null && games.Games.FirstOrDefault() != null)
                {
                    gameId = games.Games.FirstOrDefault().Id;
                }

                TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest modifyChannelInformationRequest = new TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation.ModifyChannelInformationRequest()
                {
                    Title = title,
                    GameId = gameId
                };
                await _api.Helix.Channels.ModifyChannelInformationAsync(userId, modifyChannelInformationRequest);
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, $"Error while setting title and game: {ex.Message + Environment.NewLine + ex.StackTrace}");
            }
        }

        private static async void UpdateFollowersAsync()
        {
            MacroDeckLogger.Trace(PluginInstance.Main, "Updating followers count");
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userId)) return;
            try
            {
                var followers = await _api.Helix.Users.GetUsersFollowsAsync(toId: userId);
                if (followers == null) return;
                var followersCount = followers.TotalFollows;
                VariableManager.SetValue(username + "_followers", followersCount, VariableType.Integer, PluginInstance.Main, true);
                MacroDeckLogger.Trace(PluginInstance.Main, $"Followers count: {followersCount}");
            }
            catch { }
        }

        private static async void UpdateSubscribersAsync()
        {
            MacroDeckLogger.Trace(PluginInstance.Main, "Updating subscribers count");
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userId)) return;
            try
            {
                var subscribers = await _api.Helix.Subscriptions.GetBroadcasterSubscriptionsAsync(userId);
                if (subscribers == null) return;
                var subscribersCount = subscribers.Total;
                VariableManager.SetValue(username + "_subscribers", subscribersCount, VariableType.Integer, PluginInstance.Main, true);
                MacroDeckLogger.Trace(PluginInstance.Main, $"Subscribers count: {subscribersCount}");
            }
            catch { }
        }

        private static async void GetUserIdAsync()
        {
            try
            {
                var users = await _api.Helix.Users.GetUsersAsync();
                if (users == null || users.Users == null || users.Users.FirstOrDefault() == null) return;
                userId = users.Users.FirstOrDefault().Id;
            } catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, $"Error while getting user id: {ex.Message + Environment.NewLine + ex.StackTrace}");
            }
        }

        private static async void UpdateChannelSettingsAsync()
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userId)) return;
            try
            {
                GetChatSettingsResponse channelSettings = await _api.Helix.Chat.GetChatSettingsAsync(userId, userId);
                if (channelSettings == null || channelSettings.Data == null || channelSettings.Data.FirstOrDefault() == null) return;
                SlowChat = channelSettings.Data.FirstOrDefault().SlowMode;
                FollowersOnlyChat = channelSettings.Data.FirstOrDefault().FollowerMode;
                SubscibersOnlyChat = channelSettings.Data.FirstOrDefault().SubscriberMode;
                EmotesOnlyChat = channelSettings.Data.FirstOrDefault().EmoteMode;

                MacroDeckLogger.Trace(PluginInstance.Main, $"Slow chat: {SlowChat}");
                MacroDeckLogger.Trace(PluginInstance.Main, $"Followers only: {FollowersOnlyChat}");
                MacroDeckLogger.Trace(PluginInstance.Main, $"Subs only: {SubscibersOnlyChat}");
                MacroDeckLogger.Trace(PluginInstance.Main, $"Emotes only: {EmotesOnlyChat}");

                VariableManager.SetValue(username + "_slow_chat", SlowChat, VariableType.Bool, PluginInstance.Main, true);
                VariableManager.SetValue(username + "_followers_only_chat", FollowersOnlyChat, VariableType.Bool, PluginInstance.Main, true);
                VariableManager.SetValue(username + "_subs_only_chat", SubscibersOnlyChat, VariableType.Bool, PluginInstance.Main, true);
                VariableManager.SetValue(username + "_emotes_only_chat", EmotesOnlyChat, VariableType.Bool, PluginInstance.Main, true);

            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, $"Error while updating channel settings: {ex.Message + Environment.NewLine + ex.StackTrace}");
            }
        }

        private static async void UpdateViewerCountAsync()
        {
            MacroDeckLogger.Trace(PluginInstance.Main, "Updating viewers count");
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userId)) return;
            try
            {
                var users = await _api.Helix.Users.GetUsersAsync();
                if (users == null) return;
                var stream = await _api.Helix.Streams.GetStreamsAsync(userIds: new List<string> { userId });
                if (stream == null || stream.Streams == null || stream.Streams.FirstOrDefault() == null) return;
                var viewersCount = stream.Streams.FirstOrDefault().ViewerCount;
                VariableManager.SetValue(username + "_viewers", viewersCount, VariableType.Integer, PluginInstance.Main, true);
                MacroDeckLogger.Trace(PluginInstance.Main, $"Viewer count: {viewersCount}");
            } catch { }
        }



        private static void Client_OnNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            Task.Run(() => UpdateSubscribersAsync());
        }

        private static void Client_OnError(object sender, TwitchLib.Communication.Events.OnErrorEventArgs e)
        {
            MacroDeckLogger.Error(PluginInstance.Main, $"Error in the protocol: { e.Exception.Message + Environment.NewLine + e.Exception.StackTrace }");
        }

        private static void Client_OnDisconnected(object sender, TwitchLib.Communication.Events.OnDisconnectedEventArgs e)
        {
            if (ConnectionStateChanged != null)
            {
                ConnectionStateChanged(null, EventArgs.Empty);
            }
        }

        private static void Client_OnConnectionError(object sender, OnConnectionErrorArgs e)
        {
            if (LoginFailed != null)
            {
                LoginFailed(null, EventArgs.Empty);
            }
            if (ConnectionStateChanged != null)
            {
                ConnectionStateChanged(null, EventArgs.Empty);
            }
        }

        private static void Client_OnIncorrectLogin(object sender, OnIncorrectLoginArgs e)
        {
            if (LoginFailed != null)
            {
                LoginFailed(null, EventArgs.Empty);
            }
        }


        private static void Client_OnUserLeft(object sender, OnUserLeftArgs e)
        {
            MacroDeckLogger.Trace(PluginInstance.Main, "User left");
        }

        private static void Client_OnUserJoined(object sender, OnUserJoinedArgs e)
        {
            MacroDeckLogger.Trace(PluginInstance.Main, "User joined");
        }

        private static void Client_OnChannelStateChanged(object sender, OnChannelStateChangedArgs e)
        {
            MacroDeckLogger.Trace(PluginInstance.Main, "Channel state changed");
            Task.Run(() => UpdateChannelSettingsAsync());
            
        }

        private static void Client_OnLog(object sender, OnLogArgs e)
        {
            MacroDeckLogger.Trace(PluginInstance.Main, e.Data);
        }

        private static void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            if (LoginSuccessful != null)
            {
                LoginSuccessful(null, EventArgs.Empty);
            }
            MacroDeckLogger.Info(PluginInstance.Main, $"Client connected to Twitch");
        }

        private static void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            _channel = e.Channel;
            MacroDeckLogger.Info(PluginInstance.Main, $"Joined channel { e.Channel }");
            if (ConnectionStateChanged != null)
            {
                ConnectionStateChanged(null, EventArgs.Empty);
            }
        }

        public static void ClearChat()
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            TwitchLib.Client.Extensions.ClearChatExt.ClearChat(_client, _channel);
            MacroDeckLogger.Info(PluginInstance.Main, "Cleared chat");
        }

        public static void SendChatMessage(string message)
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            _client.SendMessage(_channel, message);
            MacroDeckLogger.Info(PluginInstance.Main, $"Sent chat message: { message }");
        }

        public static void SetSlowChat(bool state, TimeSpan messageCooldown)
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            switch (state)
            {
                case true:
                    TwitchLib.Client.Extensions.SlowModeExt.SlowModeOn(_client, _channel, messageCooldown);
                    break;
                case false:
                    TwitchLib.Client.Extensions.SlowModeExt.SlowModeOff(_client, _channel);
                    break;
            }
            MacroDeckLogger.Info(PluginInstance.Main, $"Set slow chat: { state }");
        }

        public static void PlayAd(CommercialLength length)
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            TwitchLib.Client.Extensions.CommercialExt.StartCommercial(_client, _channel, length);
            MacroDeckLogger.Info(PluginInstance.Main, $"Play commercial: { length.ToString() }");
        }

        public static void SetEmoteChat(bool state)
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            switch (state)
            {
                case true:
                    TwitchLib.Client.Extensions.EmoteOnlyExt.EmoteOnlyOn(_client, _channel);
                    break;
                case false:
                    TwitchLib.Client.Extensions.EmoteOnlyExt.EmoteOnlyOff(_client, _channel);
                    break;
            }

            MacroDeckLogger.Info(PluginInstance.Main, $"Set emote chat: { state }");
        }

        public static void FollowerChat(bool state, TimeSpan requiredFollowTime)
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            switch (state)
            {
                case true:
                    TwitchLib.Client.Extensions.FollowersOnlyExt.FollowersOnlyOn(_client, _channel, requiredFollowTime);
                    break;
                case false:
                    TwitchLib.Client.Extensions.FollowersOnlyExt.FollowersOnlyOff(_client, _channel);
                    break;
            }

            MacroDeckLogger.Info(PluginInstance.Main, $"Set follower chat: { state }, required follow time: { requiredFollowTime.TotalDays } days");
        }

        public static void SetSubscriberChat(bool state)
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            switch (state)
            {
                case true:
                    TwitchLib.Client.Extensions.SubscribersOnly.SubscribersOnlyOn(_client, _channel);
                    break;
                case false:
                    TwitchLib.Client.Extensions.SubscribersOnly.SubscribersOnlyOn(_client, _channel);
                    break;
            }
            MacroDeckLogger.Info(PluginInstance.Main, $"Set subscriber chat: { state }");
        }


        public static void SetTitleGame(string title, string game)
        {
            if (_api == null) return;
            Task.Run(() => SetTitleGameAsync(title, game));
            MacroDeckLogger.Info(PluginInstance.Main, $"Set title to {title} and game to {game}");
        }

        public static void Marker()
        {
            if (_client == null || !_client.IsConnected || _channel == null) return;
            TwitchLib.Client.Extensions.MarkerExt.Marker(_client, _channel);
            MacroDeckLogger.Info(PluginInstance.Main, $"Placed stream marker");
        }

        public static void Disconnect()
        {
            if (!IsConnected) return;
            _client.Disconnect();
        }

        public static bool IsConnected
        {
            get => _client != null && _client.IsConnected && _channel != null;
        }


    }
}
