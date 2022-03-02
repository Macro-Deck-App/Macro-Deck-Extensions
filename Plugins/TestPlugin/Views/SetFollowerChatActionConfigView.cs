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
    public partial class SetFollowerChatActionConfigView : ActionConfigControl
    {
        private readonly SetFollowerChatActionConfigViewModel _viewModel;

        public SetFollowerChatActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.radioOn.Text = PluginLanguageManager.PluginStrings.On;
            this.radioOff.Text = PluginLanguageManager.PluginStrings.Off;
            this.radioToggle.Text = PluginLanguageManager.PluginStrings.Toggle;
            this.lblRequiredFollowTime.Text = PluginLanguageManager.PluginStrings.RequiredFollowTime;
            this._viewModel = new SetFollowerChatActionConfigViewModel(action);
        }

        private void SetStateView_Load(object sender, EventArgs e)
        {
            switch (this._viewModel.Method)
            {
                case Models.SetFollowerChatActionMethod.On:
                    this.radioOn.Checked = true;
                    break;
                case Models.SetFollowerChatActionMethod.Off:
                    this.radioOff.Checked = true;
                    break;
                case Models.SetFollowerChatActionMethod.Toggle:
                    this.radioToggle.Checked = true;
                    break;
            }

            this.unit.Items.Add(PluginLanguageManager.PluginStrings.Minutes);
            this.unit.Items.Add(PluginLanguageManager.PluginStrings.Hours);
            this.unit.Items.Add(PluginLanguageManager.PluginStrings.Days);

            if (this._viewModel.RequiredFollowTime.TotalHours < 1)
            {
                this.requiredFollowTime.Value = (int)this._viewModel.RequiredFollowTime.TotalMinutes;
                this.unit.Text = PluginLanguageManager.PluginStrings.Minutes;
            }
            else if (this._viewModel.RequiredFollowTime.TotalHours < 24)
            {
                this.requiredFollowTime.Value = (int)this._viewModel.RequiredFollowTime.TotalHours;
                this.unit.Text = PluginLanguageManager.PluginStrings.Hours;
            } else
            {
                this.requiredFollowTime.Value = (int)this._viewModel.RequiredFollowTime.TotalDays;
                this.unit.Text = PluginLanguageManager.PluginStrings.Days;
            }
        }

        public override bool OnActionSave()
        {
            if (this.radioOn.Checked)
            {
                this._viewModel.Method = Models.SetFollowerChatActionMethod.On;
            } else if (this.radioOff.Checked)
            {
                this._viewModel.Method = Models.SetFollowerChatActionMethod.Off;
            } else if (this.radioToggle.Checked)
            {
                this._viewModel.Method = Models.SetFollowerChatActionMethod.Toggle;
            }

            if (this.unit.Text.Equals(PluginLanguageManager.PluginStrings.Minutes))
            {
                this._viewModel.RequiredFollowTime = TimeSpan.FromMinutes((double)this.requiredFollowTime.Value);
            }
            else if (this.unit.Text.Equals(PluginLanguageManager.PluginStrings.Hours))
            {
                this._viewModel.RequiredFollowTime = TimeSpan.FromHours((double)this.requiredFollowTime.Value);
            }
            else if (this.unit.Text.Equals(PluginLanguageManager.PluginStrings.Days))
            {
                this._viewModel.RequiredFollowTime = TimeSpan.FromDays((double)this.requiredFollowTime.Value);
            }

            return this._viewModel.SaveConfig();
        }
    }
}
