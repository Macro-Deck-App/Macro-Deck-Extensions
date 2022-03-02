using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.TwitchPlugin.Language;
using SuchByte.TwitchPlugin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.TwitchPlugin.Views
{
    public partial class SetSlowChatActionConfigView : ActionConfigControl
    {

        private readonly SetSlowChatActionConfigViewModel _viewModel;


        public SetSlowChatActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.radioOn.Text = PluginLanguageManager.PluginStrings.On;
            this.radioOff.Text = PluginLanguageManager.PluginStrings.Off;
            this.radioToggle.Text = PluginLanguageManager.PluginStrings.Toggle;
            this.lblMessageCooldown.Text = PluginLanguageManager.PluginStrings.MessageCooldown;
            this.lblSeconds.Text = PluginLanguageManager.PluginStrings.Seconds;

            this._viewModel = new SetSlowChatActionConfigViewModel(action);
        }

        private void SetSlowChatActionConfigView_Load(object sender, EventArgs e)
        {
            switch (this._viewModel.Method)
            {
                case Models.SetSlowChatActionMethod.On:
                    this.radioOn.Checked = true;
                    break;
                case Models.SetSlowChatActionMethod.Off:
                    this.radioOff.Checked = true;
                    break;
                case Models.SetSlowChatActionMethod.Toggle:
                    this.radioToggle.Checked = true;
                    break;
            }

            this.cooldown.Value = (decimal)this._viewModel.MessageCooldown.TotalSeconds;
        }

        public override bool OnActionSave()
        {
            if (this.radioOn.Checked)
            {
                this._viewModel.Method = Models.SetSlowChatActionMethod.On;
            }
            else if (this.radioOff.Checked)
            {
                this._viewModel.Method = Models.SetSlowChatActionMethod.Off;
            }
            else if (this.radioToggle.Checked)
            {
                this._viewModel.Method = Models.SetSlowChatActionMethod.Toggle;
            }

            this._viewModel.MessageCooldown = TimeSpan.FromSeconds((double)this.cooldown.Value);

            return this._viewModel.SaveConfig();
        }
    }
}
