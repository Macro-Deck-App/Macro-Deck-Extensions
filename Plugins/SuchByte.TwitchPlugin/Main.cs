using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Events;
using SuchByte.MacroDeck.Folders;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Profiles;
using SuchByte.MacroDeck.Variables;
using SuchByte.TwitchPlugin.Actions;
using SuchByte.TwitchPlugin.Language;
using SuchByte.TwitchPlugin.Models;
using SuchByte.TwitchPlugin.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SuchByte.TwitchPlugin
{
    public static class PluginInstance {
        public static Main Main { get; set; }
    }


    public class Main : MacroDeckPlugin
    {
        private ContentSelectorButton statusButton = new ContentSelectorButton();

        private readonly ToolTip statusToolTip = new ToolTip();

        private MainWindow mainWindow;

        public override Image Icon => Properties.Resources.Twitch_Plugin;

        public override string Description => "Control Twitch using Macro Deck 2";
        private ChatCommandEvent chatCommandEvent = new ChatCommandEvent();

        public Main()
        {
            PluginInstance.Main ??= this;
        }

        public override bool CanConfigure => true;


        public override void Enable()
        {
            PluginLanguageManager.Initialize();
            this.Actions = new List<PluginAction>()
            {
                new SetTitleGameAction(),
                new ClearChatAction(),
                new PlayAdAction(),
                new SendChatMessageAction(),
                new SetFollowerChatAction(),
                new SetSlowChatAction(),
                new SetEmoteChatAction(),
                new SetSubscriberChatAction(),
                new StreamMarkerAction(),

            };
            EventManager.RegisterEvent(this.chatCommandEvent);

            MacroDeck.MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;
            TwitchHelper.ConnectionStateChanged += TwitchHelper_ConnectionStateChanged;

            if (MacroDeck.MacroDeck.MainWindow != null && !MacroDeck.MacroDeck.MainWindow.IsDisposed)
            {
                MacroDeck_OnMainWindowLoad(MacroDeck.MacroDeck.MainWindow, EventArgs.Empty);
            }

            Connect();
        }

        private void Connect()
        {
            TwitchAccount twitchAccount = CredentialsHelper.GetTwitchAccount();
            if (twitchAccount != null)
            {
                TwitchHelper.Connect(twitchAccount);
            }
        }

        private void TwitchHelper_ConnectionStateChanged(object sender, EventArgs e)
        {
            UpdateStautusIcon();
        }

        private void MacroDeck_OnMainWindowLoad(object sender, EventArgs e)
        {
            mainWindow = sender as MainWindow;

            this.statusButton = new ContentSelectorButton
            {
                BackgroundImageLayout = ImageLayout.Stretch,

            };
            statusButton.Click += StatusButton_Click;
            mainWindow.contentButtonPanel.Controls.Add(statusButton);
            UpdateStautusIcon();
        }

        private void UpdateStautusIcon()
        {

            if (this.mainWindow != null && !this.mainWindow.IsDisposed && this.statusButton != null && !this.statusButton.IsDisposed)
            {
                this.mainWindow.Invoke(new Action(() =>
                {
                    this.statusButton.BackgroundImage = TwitchHelper.IsConnected ? Properties.Resources.Twitch_Connected : Properties.Resources.Twitch_Disconnected;
                    this.statusToolTip.SetToolTip(this.statusButton, "Twitch " + (TwitchHelper.IsConnected ? " Connected" : "Disconnected"));
                }));
            }
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (CredentialsHelper.GetTwitchAccount() == null)
            {
                this.OpenConfigurator();
                return;
            }
            if (TwitchHelper.IsConnected)
            {
                TwitchHelper.Disconnect();
            } else
            {
                this.Connect();
            }
        }

        public override void OpenConfigurator()
        {
            using (var pluginConfig = new PluginConfigView())
            {
                pluginConfig.ShowDialog();
            }
        }

        public void CommandIssued(object sender, EventArgs e)
        {
            this.chatCommandEvent.Trigger(sender);
        }

        private class ChatCommandEvent : IMacroDeckEvent
        {
            public string Name => PluginLanguageManager.PluginStrings.EventName;

            public EventHandler<MacroDeckEventArgs> OnEvent { get; set; }
            public List<string> ParameterSuggestions
            {
                get
                {
                    List<string> commands = new List<string>();
                    var variable = PluginConfiguration.GetValue(PluginInstance.Main, "commandsList");
                    if (!string.IsNullOrWhiteSpace(variable))
                        commands.AddRange(variable.Split(';'));
                    return commands;
                }
                set { }
            }

            public void Trigger(object sender)
            {
                if (this.OnEvent != null)
                {
                    try
                    {
                        foreach (MacroDeckProfile macroDeckProfile in ProfileManager.Profiles)
                        {
                            foreach (MacroDeckFolder folder in macroDeckProfile.Folders)
                            {
                                if (folder.ActionButtons == null) continue;
                                foreach (ActionButton actionButton in folder.ActionButtons.FindAll(actionButton => actionButton.EventListeners != null && actionButton.EventListeners.Find(x => x.EventToListen != null && x.EventToListen.Equals(this.Name)) != null))
                                {
                                    MacroDeckEventArgs macroDeckEventArgs = new MacroDeckEventArgs
                                    {
                                        ActionButton = actionButton,
                                        Parameter = (string)sender,
                                    };
                                    this.OnEvent(this, macroDeckEventArgs);
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
