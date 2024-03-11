using SuchByte.MacroDeck.GUI.CustomControls;

namespace MrVibes_RSA.StreamerbotPlugin.GUI
{
    partial class PluginConfig
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            textBox_IP = new RoundedTextBox();
            textBox_Port = new RoundedTextBox();
            btn_OK = new ButtonPrimary();
            btn_Test = new ButtonPrimary();
            label_ConnectionStatus = new System.Windows.Forms.Label();
            panel1 = new RoundedPanel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            label1.Font = new System.Drawing.Font("Tahoma", 15.75F);
            label1.Location = new System.Drawing.Point(147, 74);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(198, 25);
            label1.TabIndex = 2;
            label1.Text = "Connection Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            label2.Location = new System.Drawing.Point(126, 100);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(68, 16);
            label2.TabIndex = 4;
            label2.Text = "IP Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            label3.Location = new System.Drawing.Point(126, 145);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(30, 16);
            label3.TabIndex = 5;
            label3.Text = "Port";
            // 
            // textBox_IP
            // 
            textBox_IP.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            textBox_IP.Font = new System.Drawing.Font("Tahoma", 9F);
            textBox_IP.Icon = null;
            textBox_IP.Location = new System.Drawing.Point(126, 117);
            textBox_IP.MaxCharacters = 32767;
            textBox_IP.Multiline = false;
            textBox_IP.Name = "textBox_IP";
            textBox_IP.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            textBox_IP.PasswordChar = false;
            textBox_IP.PlaceHolderColor = System.Drawing.Color.Gray;
            textBox_IP.PlaceHolderText = "";
            textBox_IP.ReadOnly = false;
            textBox_IP.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_IP.SelectionStart = 0;
            textBox_IP.Size = new System.Drawing.Size(250, 25);
            textBox_IP.TabIndex = 6;
            textBox_IP.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // textBox_Port
            // 
            textBox_Port.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            textBox_Port.Font = new System.Drawing.Font("Tahoma", 9F);
            textBox_Port.Icon = null;
            textBox_Port.Location = new System.Drawing.Point(126, 161);
            textBox_Port.MaxCharacters = 32767;
            textBox_Port.Multiline = false;
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            textBox_Port.PasswordChar = false;
            textBox_Port.PlaceHolderColor = System.Drawing.Color.Gray;
            textBox_Port.PlaceHolderText = "";
            textBox_Port.ReadOnly = false;
            textBox_Port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_Port.SelectionStart = 0;
            textBox_Port.Size = new System.Drawing.Size(250, 25);
            textBox_Port.TabIndex = 7;
            textBox_Port.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btn_OK
            // 
            btn_OK.BorderRadius = 8;
            btn_OK.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_OK.Font = new System.Drawing.Font("Tahoma", 9.75F);
            btn_OK.ForeColor = System.Drawing.Color.White;
            btn_OK.HoverColor = System.Drawing.Color.Empty;
            btn_OK.Icon = null;
            btn_OK.Location = new System.Drawing.Point(254, 212);
            btn_OK.Name = "btn_OK";
            btn_OK.Progress = 0;
            btn_OK.ProgressColor = System.Drawing.Color.FromArgb(0, 103, 205);
            btn_OK.Size = new System.Drawing.Size(75, 23);
            btn_OK.TabIndex = 8;
            btn_OK.Text = "OK";
            btn_OK.UseVisualStyleBackColor = false;
            btn_OK.UseWindowsAccentColor = true;
            btn_OK.WriteProgress = true;
            btn_OK.Click += btn_OK_Click;
            // 
            // btn_Test
            // 
            btn_Test.BorderRadius = 8;
            btn_Test.FlatAppearance.BorderColor = System.Drawing.Color.Cyan;
            btn_Test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn_Test.Font = new System.Drawing.Font("Tahoma", 9.75F);
            btn_Test.ForeColor = System.Drawing.Color.White;
            btn_Test.HoverColor = System.Drawing.Color.Empty;
            btn_Test.Icon = null;
            btn_Test.Location = new System.Drawing.Point(173, 212);
            btn_Test.Name = "btn_Test";
            btn_Test.Progress = 0;
            btn_Test.ProgressColor = System.Drawing.Color.FromArgb(0, 103, 205);
            btn_Test.Size = new System.Drawing.Size(75, 23);
            btn_Test.TabIndex = 9;
            btn_Test.Text = "Test";
            btn_Test.UseVisualStyleBackColor = false;
            btn_Test.UseWindowsAccentColor = true;
            btn_Test.WriteProgress = true;
            btn_Test.Click += btn_Test_Click;
            // 
            // label_ConnectionStatus
            // 
            label_ConnectionStatus.Location = new System.Drawing.Point(79, 120);
            label_ConnectionStatus.Name = "label_ConnectionStatus";
            label_ConnectionStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label_ConnectionStatus.Size = new System.Drawing.Size(156, 16);
            label_ConnectionStatus.TabIndex = 10;
            label_ConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label_ConnectionStatus.UseMnemonic = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            panel1.Controls.Add(label_ConnectionStatus);
            panel1.Location = new System.Drawing.Point(94, 69);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(324, 140);
            panel1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = MrVibesRSA.StreamerbotPlugin.Properties.Resources.streamerbot_logo_text;
            pictureBox1.Location = new System.Drawing.Point(94, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(324, 59);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // PluginConfig
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(492, 244);
            Controls.Add(pictureBox1);
            Controls.Add(btn_Test);
            Controls.Add(btn_OK);
            Controls.Add(textBox_Port);
            Controls.Add(textBox_IP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            ForeColor = System.Drawing.Color.Gainsboro;
            Location = new System.Drawing.Point(0, 0);
            Name = "PluginConfig";
            Controls.SetChildIndex(panel1, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(textBox_IP, 0);
            Controls.SetChildIndex(textBox_Port, 0);
            Controls.SetChildIndex(btn_OK, 0);
            Controls.SetChildIndex(btn_Test, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private RoundedTextBox textBox_IP;
        private RoundedTextBox textBox_Port;
        private ButtonPrimary btn_OK;
        private ButtonPrimary btn_Test;
        private System.Windows.Forms.Label label_ConnectionStatus;
        private RoundedPanel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
