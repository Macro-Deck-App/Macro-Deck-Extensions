

using SuchByte.MacroDeck.GUI.CustomControls;
using System.Windows.Forms;

namespace MrVibes_RSA.StreamerbotPlugin.GUI
{
    partial class StreamerBotActionConfigurator
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
            comboBox_ActionList = new RoundedComboBox();
            label1 = new Label();
            label2 = new Label();
            textBox_Arguments = new RoundedTextBox();
            btn_Refresh = new ButtonPrimary();
            panel1 = new RoundedPanel();
            label_ConnectionStatus = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox_ActionList
            // 
            comboBox_ActionList.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            comboBox_ActionList.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox_ActionList.Font = new System.Drawing.Font("Tahoma", 9F);
            comboBox_ActionList.Icon = null;
            comboBox_ActionList.Location = new System.Drawing.Point(199, 166);
            comboBox_ActionList.Name = "comboBox_ActionList";
            comboBox_ActionList.Padding = new Padding(8, 2, 8, 2);
            comboBox_ActionList.SelectedIndex = -1;
            comboBox_ActionList.SelectedItem = null;
            comboBox_ActionList.Size = new System.Drawing.Size(421, 26);
            comboBox_ActionList.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            label1.Location = new System.Drawing.Point(199, 140);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(117, 23);
            label1.TabIndex = 2;
            label1.Text = "Select Action";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            label2.Location = new System.Drawing.Point(199, 204);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(56, 23);
            label2.TabIndex = 4;
            label2.Text = "Value";
            // 
            // textBox_Arguments
            // 
            textBox_Arguments.BackColor = System.Drawing.Color.FromArgb(65, 65, 65);
            textBox_Arguments.Font = new System.Drawing.Font("Tahoma", 9F);
            textBox_Arguments.Icon = null;
            textBox_Arguments.Location = new System.Drawing.Point(200, 230);
            textBox_Arguments.MaxCharacters = 32767;
            textBox_Arguments.Multiline = false;
            textBox_Arguments.Name = "textBox_Arguments";
            textBox_Arguments.Padding = new Padding(8, 5, 8, 5);
            textBox_Arguments.PasswordChar = false;
            textBox_Arguments.PlaceHolderColor = System.Drawing.Color.Gray;
            textBox_Arguments.PlaceHolderText = "";
            textBox_Arguments.ReadOnly = false;
            textBox_Arguments.ScrollBars = ScrollBars.None;
            textBox_Arguments.SelectionStart = 0;
            textBox_Arguments.Size = new System.Drawing.Size(420, 25);
            textBox_Arguments.TabIndex = 7;
            textBox_Arguments.TextAlignment = HorizontalAlignment.Left;
            // 
            // btn_Refresh
            // 
            btn_Refresh.BorderRadius = 8;
            btn_Refresh.FlatStyle = FlatStyle.Flat;
            btn_Refresh.Font = new System.Drawing.Font("Tahoma", 9.75F);
            btn_Refresh.ForeColor = System.Drawing.Color.White;
            btn_Refresh.HoverColor = System.Drawing.Color.Empty;
            btn_Refresh.Icon = null;
            btn_Refresh.Location = new System.Drawing.Point(628, 167);
            btn_Refresh.Name = "btn_Refresh";
            btn_Refresh.Progress = 0;
            btn_Refresh.ProgressColor = System.Drawing.Color.FromArgb(0, 103, 205);
            btn_Refresh.Size = new System.Drawing.Size(75, 23);
            btn_Refresh.TabIndex = 8;
            btn_Refresh.Text = "Refresh";
            btn_Refresh.UseVisualStyleBackColor = true;
            btn_Refresh.UseWindowsAccentColor = true;
            btn_Refresh.WriteProgress = true;
            btn_Refresh.Click += btn_Refresh_Click;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(36, 36, 36);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label_ConnectionStatus);
            panel1.Location = new System.Drawing.Point(98, 102);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(649, 199);
            panel1.TabIndex = 12;
            // 
            // label_ConnectionStatus
            // 
            label_ConnectionStatus.Location = new System.Drawing.Point(79, 120);
            label_ConnectionStatus.Name = "label_ConnectionStatus";
            label_ConnectionStatus.RightToLeft = RightToLeft.No;
            label_ConnectionStatus.Size = new System.Drawing.Size(156, 16);
            label_ConnectionStatus.TabIndex = 10;
            label_ConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label_ConnectionStatus.UseMnemonic = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label3.Location = new System.Drawing.Point(153, 108);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 16);
            label3.TabIndex = 11;
            label3.Text = "(Optional)";
            // 
            // StreamerBotActionConfigurator
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Refresh);
            Controls.Add(textBox_Arguments);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox_ActionList);
            Controls.Add(panel1);
            Name = "StreamerBotActionConfigurator";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RoundedComboBox comboBox_ActionList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RoundedTextBox textBox_Arguments;
        private ButtonPrimary btn_Refresh;
        private RoundedPanel panel1;
        private Label label_ConnectionStatus;
        private Label label3;
    }
}
