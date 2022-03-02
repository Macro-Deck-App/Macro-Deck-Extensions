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
    public partial class SetSubscriberChatActionConfigView : ActionConfigControl
    {


        private readonly SetSubscriberChatActionConfigViewModel _viewModel;
        public SetSubscriberChatActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.radioOn.Text = PluginLanguageManager.PluginStrings.On;
            this.radioOff.Text = PluginLanguageManager.PluginStrings.Off;
            this.radioToggle.Text = PluginLanguageManager.PluginStrings.Toggle;

            this._viewModel = new SetSubscriberChatActionConfigViewModel(action);
        }

        private void SetSubscriberChatActionConfigView_Load(object sender, EventArgs e)
        {
            switch (this._viewModel.Method)
            {
                case Models.SetSubscriberChatActionMethod.On:
                    this.radioOn.Checked = true;
                    break;
                case Models.SetSubscriberChatActionMethod.Off:
                    this.radioOff.Checked = true;
                    break;
                case Models.SetSubscriberChatActionMethod.Toggle:
                    this.radioToggle.Checked = true;
                    break;
            }
        }

        public override bool OnActionSave()
        {
            if (this.radioOn.Checked)
            {
                this._viewModel.Method = Models.SetSubscriberChatActionMethod.On;
            }
            else if (this.radioOff.Checked)
            {
                this._viewModel.Method = Models.SetSubscriberChatActionMethod.Off;
            }
            else if (this.radioToggle.Checked)
            {
                this._viewModel.Method = Models.SetSubscriberChatActionMethod.Toggle;
            }

            return this._viewModel.SaveConfig();
        }
    }
}
