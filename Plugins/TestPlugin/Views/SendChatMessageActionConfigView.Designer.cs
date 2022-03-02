
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.TwitchPlugin.Views
{
    partial class SendChatMessageActionConfigView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.message = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.variablesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddVariable = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.message.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.message.Cursor = System.Windows.Forms.Cursors.Hand;
            this.message.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.message.Icon = null;
            this.message.Location = new System.Drawing.Point(96, 80);
            this.message.MaxCharacters = 32767;
            this.message.Multiline = true;
            this.message.Name = "message";
            this.message.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.message.PasswordChar = false;
            this.message.PlaceHolderColor = System.Drawing.Color.Gray;
            this.message.PlaceHolderText = "Message";
            this.message.ReadOnly = false;
            this.message.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.message.SelectionStart = 0;
            this.message.Size = new System.Drawing.Size(665, 242);
            this.message.TabIndex = 1;
            this.message.TabStop = false;
            this.message.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // variablesContextMenu
            // 
            this.variablesContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.variablesContextMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.variablesContextMenu.Name = "variablesContextMenu";
            this.variablesContextMenu.ShowImageMargin = false;
            this.variablesContextMenu.Size = new System.Drawing.Size(36, 4);
            // 
            // btnAddVariable
            // 
            this.btnAddVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVariable.BorderRadius = 8;
            this.btnAddVariable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVariable.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddVariable.ForeColor = System.Drawing.Color.White;
            this.btnAddVariable.HoverColor = System.Drawing.Color.Empty;
            this.btnAddVariable.Icon = null;
            this.btnAddVariable.Location = new System.Drawing.Point(621, 328);
            this.btnAddVariable.Name = "btnAddVariable";
            this.btnAddVariable.Progress = 0;
            this.btnAddVariable.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(225)))));
            this.btnAddVariable.Size = new System.Drawing.Size(140, 30);
            this.btnAddVariable.TabIndex = 0;
            this.btnAddVariable.TabStop = false;
            this.btnAddVariable.Text = "Add variable";
            this.btnAddVariable.UseVisualStyleBackColor = true;
            this.btnAddVariable.UseWindowsAccentColor = true;
            this.btnAddVariable.Click += new System.EventHandler(this.BtnAddVariable_Click);
            // 
            // SendChatMessageActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddVariable);
            this.Controls.Add(this.message);
            this.Name = "SendChatMessageActionConfigView";
            this.Load += new System.EventHandler(this.SendChatMessageActionConfigView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedTextBox message;
        private System.Windows.Forms.ContextMenuStrip variablesContextMenu;
        private ButtonPrimary btnAddVariable;
    }
}
