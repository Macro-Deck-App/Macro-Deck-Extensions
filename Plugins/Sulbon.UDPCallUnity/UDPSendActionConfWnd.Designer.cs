
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.WindowsUtils.GUI
{
    partial class UDPSendActionConfWnd
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
            this.lblCommand = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextPort = new System.Windows.Forms.TextBox();
            this.TextCommand = new System.Windows.Forms.TextBox();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCommand
            // 
            this.lblCommand.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCommand.Location = new System.Drawing.Point(0, 60);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(169, 49);
            this.lblCommand.TabIndex = 6;
            this.lblCommand.Text = "Command:";
            this.lblCommand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "UDP port";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextPort
            // 
            this.TextPort.Location = new System.Drawing.Point(148, 15);
            this.TextPort.Name = "TextPort";
            this.TextPort.Size = new System.Drawing.Size(169, 30);
            this.TextPort.TabIndex = 8;
            this.TextPort.Text = "8193";
            // 
            // TextCommand
            // 
            this.TextCommand.Location = new System.Drawing.Point(339, 68);
            this.TextCommand.Name = "TextCommand";
            this.TextCommand.Size = new System.Drawing.Size(454, 30);
            this.TextCommand.TabIndex = 9;
            this.TextCommand.Text = "Assets/someMenuPath";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "Menu",
            "Layout"});
            this.comboType.Location = new System.Drawing.Point(148, 68);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(169, 31);
            this.comboType.TabIndex = 10;
            this.comboType.Text = "Menu";
            // 
            // UDPSendActionConfWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.TextCommand);
            this.Controls.Add(this.TextPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCommand);
            this.Name = "UDPSendActionConfWnd";
            this.Size = new System.Drawing.Size(818, 211);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextPort;
        private System.Windows.Forms.TextBox TextCommand;
        private System.Windows.Forms.ComboBox comboType;
    }
}
