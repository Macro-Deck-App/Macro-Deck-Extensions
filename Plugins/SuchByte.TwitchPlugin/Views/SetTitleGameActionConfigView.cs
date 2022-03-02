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
    public partial class SetTitleGameActionConfigView : ActionConfigControl
    {
        private readonly SetTitleGameActionConfigViewModel _viewModel;

        public SetTitleGameActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.lblStreamTitle.Text = PluginLanguageManager.PluginStrings.StreamTitle;
            this.lblGame.Text = PluginLanguageManager.PluginStrings.Game;
            this._viewModel = new SetTitleGameActionConfigViewModel(action);
        }

        private void SetTitleGameActionConfigView_Load(object sender, EventArgs e)
        {
            this.streamTitle.Text = this._viewModel.StreamTitle;
            this.game.Text = this._viewModel.Game;
        }

        public override bool OnActionSave()
        {
            if (string.IsNullOrWhiteSpace(this.streamTitle.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.game.Text))
            {
                return false;
            }
            this._viewModel.StreamTitle = this.streamTitle.Text;
            this._viewModel.Game = this.game.Text;
            return this._viewModel.SaveConfig();
        }

        private void BtnAddVariableTitle_Click(object sender, EventArgs e)
        {
            this.variablesContextMenu.Items.Clear();
            foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.Variables)
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    ForeColor = Color.White,
                    Text = variable.Name,
                };
                item.Click += AddVariableContextMenuItemTitleClick;
                this.variablesContextMenu.Items.Add(item);
            }
            this.variablesContextMenu.Show(PointToScreen(new Point(((ButtonPrimary)sender).Bounds.Left, ((ButtonPrimary)sender).Bounds.Bottom)));
        }

        private void btnAddVariableGame_Click(object sender, EventArgs e)
        {
            this.variablesContextMenu.Items.Clear();
            foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.Variables)
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    ForeColor = Color.White,
                    Text = variable.Name,
                };
                item.Click += AddVariableContextMenuItemGameClick;
                this.variablesContextMenu.Items.Add(item);
            }
            this.variablesContextMenu.Show(PointToScreen(new Point(((ButtonPrimary)sender).Bounds.Left, ((ButtonPrimary)sender).Bounds.Bottom)));
        }

        private void AddVariableContextMenuItemTitleClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            var selectionIndex = this.streamTitle.SelectionStart;
            this.streamTitle.Text = this.streamTitle.Text.Insert(selectionIndex, "{" + item.Text + "}");
            this.streamTitle.SelectionStart = selectionIndex + ("{" + item.Text + "}").Length;
        }
        private void AddVariableContextMenuItemGameClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            var selectionIndex = this.game.SelectionStart;
            this.game.Text = this.game.Text.Insert(selectionIndex, "{" + item.Text + "}");
            this.game.SelectionStart = selectionIndex + ("{" + item.Text + "}").Length;
        }
    }
}
