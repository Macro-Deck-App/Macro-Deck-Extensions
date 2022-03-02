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
    public partial class SendChatMessageActionConfigView : ActionConfigControl
    {

        private readonly SendChatMessageActionConfigViewModel _viewModel;

        public SendChatMessageActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.btnAddVariable.Text = PluginLanguageManager.PluginStrings.AddVariable;
            this._viewModel = new SendChatMessageActionConfigViewModel(action);
        }

        private void SendChatMessageActionConfigView_Load(object sender, EventArgs e)
        {
            this.message.Text = this._viewModel.Message;
        }

        public override bool OnActionSave()
        {
            this._viewModel.Message = this.message.Text;
            return this._viewModel.SaveConfig();
        }

        private void BtnAddVariable_Click(object sender, EventArgs e)
        {
            this.variablesContextMenu.Items.Clear();
            foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.Variables)
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    ForeColor = Color.White,
                    Text = variable.Name,
                };
                item.Click += AddVariableContextMenuItemClick;
                this.variablesContextMenu.Items.Add(item);
            }
            this.variablesContextMenu.Show(PointToScreen(new Point(((ButtonPrimary)sender).Bounds.Left, ((ButtonPrimary)sender).Bounds.Bottom)));
        }

        private void AddVariableContextMenuItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            var selectionIndex = this.message.SelectionStart;
            this.message.Text = this.message.Text.Insert(selectionIndex, "{" + item.Text + "}");
            this.message.SelectionStart = selectionIndex + ("{" + item.Text + "}").Length;
        }
    }
}
