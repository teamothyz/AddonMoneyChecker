namespace AddonMoney.Client
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ProfilesTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.TimeoutUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.TopMostCheckBtn = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.StartBtn = new Krypton.Toolkit.KryptonButton();
            this.StopBtn = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.RunStatusTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.ProfileCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.SleepTimeUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.SuspendLayout();
            // 
            // ProfilesTextBox
            // 
            this.ProfilesTextBox.Location = new System.Drawing.Point(12, 12);
            this.ProfilesTextBox.Multiline = true;
            this.ProfilesTextBox.Name = "ProfilesTextBox";
            this.ProfilesTextBox.Size = new System.Drawing.Size(452, 180);
            this.ProfilesTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ProfilesTextBox.TabIndex = 1;
            this.ProfilesTextBox.TextChanged += new System.EventHandler(this.ProfilesTextBox_TextChanged);
            // 
            // TimeoutUpDown
            // 
            this.TimeoutUpDown.Location = new System.Drawing.Point(84, 247);
            this.TimeoutUpDown.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.TimeoutUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TimeoutUpDown.Name = "TimeoutUpDown";
            this.TimeoutUpDown.Size = new System.Drawing.Size(128, 22);
            this.TimeoutUpDown.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.TimeoutUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeoutUpDown.TabIndex = 2;
            this.TimeoutUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.TimeoutUpDown.ValueChanged += new System.EventHandler(this.TimeoutUpDown_ValueChanged);
            // 
            // TopMostCheckBtn
            // 
            this.TopMostCheckBtn.Checked = true;
            this.TopMostCheckBtn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopMostCheckBtn.Location = new System.Drawing.Point(245, 209);
            this.TopMostCheckBtn.Name = "TopMostCheckBtn";
            this.TopMostCheckBtn.Size = new System.Drawing.Size(82, 20);
            this.TopMostCheckBtn.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.TopMostCheckBtn.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TopMostCheckBtn.TabIndex = 7;
            this.TopMostCheckBtn.Values.Text = "Ghim App";
            this.TopMostCheckBtn.CheckedChanged += new System.EventHandler(this.TopMostCheckBtn_CheckedChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(12, 247);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(66, 20);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel5.TabIndex = 16;
            this.kryptonLabel5.Values.Text = "Time out:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(12, 26);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(6, 2);
            this.kryptonLabel6.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel6.TabIndex = 17;
            this.kryptonLabel6.Values.Text = "";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(12, 209);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(87, 20);
            this.kryptonLabel7.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel7.TabIndex = 18;
            this.kryptonLabel7.Values.Text = "User Profiles:";
            // 
            // StartBtn
            // 
            this.StartBtn.CornerRoundingRadius = -1F;
            this.StartBtn.Location = new System.Drawing.Point(12, 290);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(90, 25);
            this.StartBtn.StateCommon.Back.Color1 = System.Drawing.Color.GreenYellow;
            this.StartBtn.StateCommon.Back.Color2 = System.Drawing.Color.GreenYellow;
            this.StartBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartBtn.TabIndex = 19;
            this.StartBtn.Values.Text = "Bắt đầu";
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.CornerRoundingRadius = -1F;
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(122, 290);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(90, 25);
            this.StopBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StopBtn.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StopBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StopBtn.TabIndex = 20;
            this.StopBtn.Values.Text = "Dừng lại";
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(245, 247);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel8.TabIndex = 21;
            this.kryptonLabel8.Values.Text = "Quãng nghỉ:";
            // 
            // RunStatusTextBox
            // 
            this.RunStatusTextBox.Location = new System.Drawing.Point(245, 290);
            this.RunStatusTextBox.Name = "RunStatusTextBox";
            this.RunStatusTextBox.ReadOnly = true;
            this.RunStatusTextBox.Size = new System.Drawing.Size(93, 23);
            this.RunStatusTextBox.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.RunStatusTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.RunStatusTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RunStatusTextBox.TabIndex = 22;
            this.RunStatusTextBox.Text = "Chưa bắt đầu";
            this.RunStatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProfileCountTextBox
            // 
            this.ProfileCountTextBox.Location = new System.Drawing.Point(105, 209);
            this.ProfileCountTextBox.Name = "ProfileCountTextBox";
            this.ProfileCountTextBox.ReadOnly = true;
            this.ProfileCountTextBox.Size = new System.Drawing.Size(107, 23);
            this.ProfileCountTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.ProfileCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProfileCountTextBox.TabIndex = 23;
            this.ProfileCountTextBox.Text = "0";
            this.ProfileCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SleepTimeUpDown
            // 
            this.SleepTimeUpDown.Location = new System.Drawing.Point(336, 247);
            this.SleepTimeUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.SleepTimeUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SleepTimeUpDown.Name = "SleepTimeUpDown";
            this.SleepTimeUpDown.Size = new System.Drawing.Size(128, 22);
            this.SleepTimeUpDown.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.SleepTimeUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SleepTimeUpDown.TabIndex = 24;
            this.SleepTimeUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.SleepTimeUpDown.ValueChanged += new System.EventHandler(this.SleepTimeUpDown_ValueChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 327);
            this.Controls.Add(this.SleepTimeUpDown);
            this.Controls.Add(this.ProfileCountTextBox);
            this.Controls.Add(this.RunStatusTextBox);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.TopMostCheckBtn);
            this.Controls.Add(this.TimeoutUpDown);
            this.Controls.Add(this.ProfilesTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(494, 366);
            this.MinimumSize = new System.Drawing.Size(494, 366);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddonMoneyChecker Client - Tele: @lukaxsx";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonTextBox ProfilesTextBox;
        private Krypton.Toolkit.KryptonNumericUpDown TimeoutUpDown;
        private Krypton.Toolkit.KryptonCheckBox TopMostCheckBtn;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonButton StartBtn;
        private Krypton.Toolkit.KryptonButton StopBtn;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonTextBox RunStatusTextBox;
        private Krypton.Toolkit.KryptonTextBox ProfileCountTextBox;
        private Krypton.Toolkit.KryptonNumericUpDown SleepTimeUpDown;
    }
}