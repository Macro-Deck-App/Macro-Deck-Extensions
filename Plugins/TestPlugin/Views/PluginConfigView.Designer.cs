
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.TwitchPlugin.Views
{
    partial class PluginConfigView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            TwitchHelper.LoginFailed -= TwitchHelper_LoginFailed;
            TwitchHelper.LoginSuccessful -= TwitchHelper_LoginSuccessful;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.oAuthToken = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.btnGetToken = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.btnOk = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lblAuthToken = new System.Windows.Forms.Label();
            this.lblCommandPrefix = new System.Windows.Forms.Label();
            this.commandPrefix = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.commandsList = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.lblCommandsList = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oAuthToken
            // 
            this.oAuthToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.oAuthToken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.oAuthToken.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.oAuthToken.Icon = null;
            this.oAuthToken.Location = new System.Drawing.Point(176, 69);
            this.oAuthToken.MaxCharacters = 32767;
            this.oAuthToken.Multiline = false;
            this.oAuthToken.Name = "oAuthToken";
            this.oAuthToken.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.oAuthToken.PasswordChar = true;
            this.oAuthToken.PlaceHolderColor = System.Drawing.Color.Gray;
            this.oAuthToken.PlaceHolderText = "";
            this.oAuthToken.ReadOnly = false;
            this.oAuthToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.oAuthToken.SelectionStart = 0;
            this.oAuthToken.Size = new System.Drawing.Size(293, 25);
            this.oAuthToken.TabIndex = 3;
            this.oAuthToken.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnGetToken
            // 
            this.btnGetToken.BorderRadius = 8;
            this.btnGetToken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetToken.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGetToken.ForeColor = System.Drawing.Color.White;
            this.btnGetToken.HoverColor = System.Drawing.Color.Empty;
            this.btnGetToken.Icon = null;
            this.btnGetToken.Location = new System.Drawing.Point(475, 71);
            this.btnGetToken.Name = "btnGetToken";
            this.btnGetToken.Progress = 0;
            this.btnGetToken.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(225)))));
            this.btnGetToken.Size = new System.Drawing.Size(109, 23);
            this.btnGetToken.TabIndex = 4;
            this.btnGetToken.TabStop = false;
            this.btnGetToken.Text = "Get token";
            this.btnGetToken.UseWindowsAccentColor = true;
            this.btnGetToken.Click += new System.EventHandler(this.BtnGetToken_Click);
            // 
            // btnOk
            // 
            this.btnOk.BorderRadius = 8;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.HoverColor = System.Drawing.Color.Empty;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(511, 164);
            this.btnOk.Name = "btnOk";
            this.btnOk.Progress = 0;
            this.btnOk.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(225)))));
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 5;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "Ok";
            this.btnOk.UseWindowsAccentColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // lblAuthToken
            // 
            this.lblAuthToken.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAuthToken.Location = new System.Drawing.Point(18, 69);
            this.lblAuthToken.Name = "lblAuthToken";
            this.lblAuthToken.Size = new System.Drawing.Size(152, 25);
            this.lblAuthToken.TabIndex = 7;
            this.lblAuthToken.Text = "Auth token";
            this.lblAuthToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCommandPrefix
            // 
            this.lblCommandPrefix.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCommandPrefix.Location = new System.Drawing.Point(18, 100);
            this.lblCommandPrefix.Name = "lblCommandPrefix";
            this.lblCommandPrefix.Size = new System.Drawing.Size(152, 25);
            this.lblCommandPrefix.TabIndex = 8;
            this.lblCommandPrefix.Text = "Command prefix";
            this.lblCommandPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // commandPrefix
            // 
            this.commandPrefix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.commandPrefix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commandPrefix.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commandPrefix.Icon = null;
            this.commandPrefix.Location = new System.Drawing.Point(176, 100);
            this.commandPrefix.MaxCharacters = 1;
            this.commandPrefix.Multiline = false;
            this.commandPrefix.Name = "commandPrefix";
            this.commandPrefix.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.commandPrefix.PasswordChar = false;
            this.commandPrefix.PlaceHolderColor = System.Drawing.Color.Gray;
            this.commandPrefix.PlaceHolderText = "";
            this.commandPrefix.ReadOnly = false;
            this.commandPrefix.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.commandPrefix.SelectionStart = 0;
            this.commandPrefix.Size = new System.Drawing.Size(293, 25);
            this.commandPrefix.TabIndex = 9;
            this.commandPrefix.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // commandsList
            // 
            this.commandsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.commandsList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.commandsList.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.commandsList.Icon = null;
            this.commandsList.Location = new System.Drawing.Point(176, 131);
            this.commandsList.MaxCharacters = 32767;
            this.commandsList.Multiline = false;
            this.commandsList.Name = "commandsList";
            this.commandsList.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.commandsList.PasswordChar = false;
            this.commandsList.PlaceHolderColor = System.Drawing.Color.Gray;
            this.commandsList.PlaceHolderText = "";
            this.commandsList.ReadOnly = false;
            this.commandsList.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.commandsList.SelectionStart = 0;
            this.commandsList.Size = new System.Drawing.Size(293, 25);
            this.commandsList.TabIndex = 11;
            this.commandsList.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblCommandsList
            // 
            this.lblCommandsList.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCommandsList.Location = new System.Drawing.Point(18, 131);
            this.lblCommandsList.Name = "lblCommandsList";
            this.lblCommandsList.Size = new System.Drawing.Size(152, 25);
            this.lblCommandsList.TabIndex = 10;
            this.lblCommandsList.Text = "Command list";
            this.lblCommandsList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 198);
            this.Controls.Add(this.commandsList);
            this.Controls.Add(this.lblCommandsList);
            this.Controls.Add(this.commandPrefix);
            this.Controls.Add(this.lblCommandPrefix);
            this.Controls.Add(this.lblAuthToken);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnGetToken);
            this.Controls.Add(this.oAuthToken);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PluginConfigView";
            this.Text = "PluginConfigView";
            this.Load += new System.EventHandler(this.PluginConfigView_Load);
            this.Controls.SetChildIndex(this.oAuthToken, 0);
            this.Controls.SetChildIndex(this.btnGetToken, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.lblAuthToken, 0);
            this.Controls.SetChildIndex(this.lblCommandPrefix, 0);
            this.Controls.SetChildIndex(this.commandPrefix, 0);
            this.Controls.SetChildIndex(this.lblCommandsList, 0);
            this.Controls.SetChildIndex(this.commandsList, 0);
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedTextBox oAuthToken;
        private ButtonPrimary btnGetToken;
        private ButtonPrimary btnOk;
        private System.Windows.Forms.Label lblAuthToken;
        private System.Windows.Forms.Label lblCommandPrefix;
        private RoundedTextBox commandPrefix;
        private RoundedTextBox commandsList;
        private System.Windows.Forms.Label lblCommandsList;
    }
}