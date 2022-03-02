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
    public partial class SetEmoteChatActionConfigView : ActionConfigControl
    {


        private readonly SetEmoteChatActionConfigViewModel _viewModel;

        public SetEmoteChatActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.radioOn.Text = PluginLanguageManager.PluginStrings.On;
            this.radioOff.Text = PluginLanguageManager.PluginStrings.Off;
            this.radioToggle.Text = PluginLanguageManager.PluginStrings.Toggle;
            this._viewModel = new SetEmoteChatActionConfigViewModel(action);
        }

        private void SetEmoteChatActionConfigView_Load(object sender, EventArgs e)
        {
            switch (this._viewModel.Method)
            {
                case Models.SetEmoteChatActionMethod.On:
                    this.radioOn.Checked = true;
                    break;
                case Models.SetEmoteChatActionMethod.Off:
                    this.radioOff.Checked = true;
                    break;
                case Models.SetEmoteChatActionMethod.Toggle:
                    this.radioToggle.Checked = true;
                    break;
            }
        }

        public override bool OnActionSave()
        {
            if (this.radioOn.Checked)
            {
                this._viewModel.Method = Models.SetEmoteChatActionMethod.On;
            }
            else if (this.radioOff.Checked)
            {
                this._viewModel.Method = Models.SetEmoteChatActionMethod.Off;
            }
            else if (this.radioToggle.Checked)
            {
                this._viewModel.Method = Models.SetEmoteChatActionMethod.Toggle;
            }

            return this._viewModel.SaveConfig();
        }
    }
}
