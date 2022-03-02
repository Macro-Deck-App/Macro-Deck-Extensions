
namespace SuchByte.TwitchPlugin.Views
{
    partial class SetSubscriberChatActionConfigView
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
            this.radioToggle = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioOff = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioOn = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.SuspendLayout();
            // 
            // radioToggle
            // 
            this.radioToggle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioToggle.Location = new System.Drawing.Point(467, 199);
            this.radioToggle.Name = "radioToggle";
            this.radioToggle.Size = new System.Drawing.Size(135, 27);
            this.radioToggle.TabIndex = 11;
            this.radioToggle.TabStop = true;
            this.radioToggle.Text = "Toggle";
            this.radioToggle.UseVisualStyleBackColor = true;
            // 
            // radioOff
            // 
            this.radioOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioOff.Location = new System.Drawing.Point(361, 199);
            this.radioOff.Name = "radioOff";
            this.radioOff.Size = new System.Drawing.Size(100, 27);
            this.radioOff.TabIndex = 10;
            this.radioOff.TabStop = true;
            this.radioOff.Text = "Off";
            this.radioOff.UseVisualStyleBackColor = true;
            // 
            // radioOn
            // 
            this.radioOn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioOn.Location = new System.Drawing.Point(255, 199);
            this.radioOn.Name = "radioOn";
            this.radioOn.Size = new System.Drawing.Size(100, 27);
            this.radioOn.TabIndex = 9;
            this.radioOn.TabStop = true;
            this.radioOn.Text = "On";
            this.radioOn.UseVisualStyleBackColor = true;
            // 
            // SetSubscriberChatActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioToggle);
            this.Controls.Add(this.radioOff);
            this.Controls.Add(this.radioOn);
            this.Name = "SetSubscriberChatActionConfigView";
            this.Load += new System.EventHandler(this.SetSubscriberChatActionConfigView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MacroDeck.GUI.CustomControls.TabRadioButton radioToggle;
        private MacroDeck.GUI.CustomControls.TabRadioButton radioOff;
        private MacroDeck.GUI.CustomControls.TabRadioButton radioOn;
    }
}
