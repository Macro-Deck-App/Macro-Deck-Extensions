
namespace SuchByte.TwitchPlugin.Views
{
    partial class SetSlowChatActionConfigView
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
            this.lblMessageCooldown = new System.Windows.Forms.Label();
            this.cooldown = new System.Windows.Forms.NumericUpDown();
            this.radioToggle = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioOff = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioOn = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.lblSeconds = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cooldown)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessageCooldown
            // 
            this.lblMessageCooldown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMessageCooldown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMessageCooldown.Location = new System.Drawing.Point(243, 215);
            this.lblMessageCooldown.Name = "lblMessageCooldown";
            this.lblMessageCooldown.Size = new System.Drawing.Size(182, 26);
            this.lblMessageCooldown.TabIndex = 10;
            this.lblMessageCooldown.Text = "Message cooldown";
            this.lblMessageCooldown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cooldown
            // 
            this.cooldown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.cooldown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cooldown.ForeColor = System.Drawing.Color.White;
            this.cooldown.Location = new System.Drawing.Point(431, 216);
            this.cooldown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.cooldown.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.cooldown.Name = "cooldown";
            this.cooldown.Size = new System.Drawing.Size(75, 26);
            this.cooldown.TabIndex = 9;
            this.cooldown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // radioToggle
            // 
            this.radioToggle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioToggle.Location = new System.Drawing.Point(467, 183);
            this.radioToggle.Name = "radioToggle";
            this.radioToggle.Size = new System.Drawing.Size(135, 27);
            this.radioToggle.TabIndex = 8;
            this.radioToggle.TabStop = true;
            this.radioToggle.Text = "Toggle";
            this.radioToggle.UseVisualStyleBackColor = true;
            // 
            // radioOff
            // 
            this.radioOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioOff.Location = new System.Drawing.Point(361, 183);
            this.radioOff.Name = "radioOff";
            this.radioOff.Size = new System.Drawing.Size(100, 27);
            this.radioOff.TabIndex = 7;
            this.radioOff.TabStop = true;
            this.radioOff.Text = "Off";
            this.radioOff.UseVisualStyleBackColor = true;
            // 
            // radioOn
            // 
            this.radioOn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioOn.Location = new System.Drawing.Point(255, 183);
            this.radioOn.Name = "radioOn";
            this.radioOn.Size = new System.Drawing.Size(100, 27);
            this.radioOn.TabIndex = 6;
            this.radioOn.TabStop = true;
            this.radioOn.Text = "On";
            this.radioOn.UseVisualStyleBackColor = true;
            // 
            // lblSeconds
            // 
            this.lblSeconds.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSeconds.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeconds.Location = new System.Drawing.Point(512, 216);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(125, 26);
            this.lblSeconds.TabIndex = 11;
            this.lblSeconds.Text = "seconds";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SetSlowChatActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSeconds);
            this.Controls.Add(this.lblMessageCooldown);
            this.Controls.Add(this.cooldown);
            this.Controls.Add(this.radioToggle);
            this.Controls.Add(this.radioOff);
            this.Controls.Add(this.radioOn);
            this.Name = "SetSlowChatActionConfigView";
            this.Load += new System.EventHandler(this.SetSlowChatActionConfigView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cooldown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessageCooldown;
        private System.Windows.Forms.NumericUpDown cooldown;
        private MacroDeck.GUI.CustomControls.TabRadioButton radioToggle;
        private MacroDeck.GUI.CustomControls.TabRadioButton radioOff;
        private MacroDeck.GUI.CustomControls.TabRadioButton radioOn;
        private System.Windows.Forms.Label lblSeconds;
    }
}
