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
using TwitchLib.Api.Core.Enums;

namespace SuchByte.TwitchPlugin.Views
{
    public partial class PlayAdActionConfigView : ActionConfigControl
    {

        private readonly PlayAdActionConfigViewModel _viewModel;

        public PlayAdActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.lblLength.Text = PluginLanguageManager.PluginStrings.GeneralLength;

            this._viewModel = new PlayAdActionConfigViewModel(action);
        }

        private void PlayAdActionConfigView_Load(object sender, EventArgs e)
        {
            foreach (CommercialLength length in (CommercialLength[])Enum.GetValues(typeof(CommercialLength)))
            {
                this.commercialLenght.Items.Add((int)length);
            }
            this.commercialLenght.Text = this._viewModel.Configuration.Length.ToString();
        }

        public override bool OnActionSave()
        {
            if (Int32.TryParse(this.commercialLenght.Text, out int length))
            {
                this._viewModel.Length = length;
            }
            return this._viewModel.SaveConfig();
        }
    }
}
