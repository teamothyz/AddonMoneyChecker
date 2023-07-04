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
            ProfilesTextBox = new Krypton.Toolkit.KryptonTextBox();
            TimeoutUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            TopMostCheckBtn = new Krypton.Toolkit.KryptonCheckBox();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            StartBtn = new Krypton.Toolkit.KryptonButton();
            StopBtn = new Krypton.Toolkit.KryptonButton();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            RunStatusTextBox = new Krypton.Toolkit.KryptonTextBox();
            ProfileCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            SleepTimeUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            VPSNameTextBox = new Krypton.Toolkit.KryptonTextBox();
            SuspendLayout();
            // 
            // ProfilesTextBox
            // 
            ProfilesTextBox.Location = new Point(12, 12);
            ProfilesTextBox.Multiline = true;
            ProfilesTextBox.Name = "ProfilesTextBox";
            ProfilesTextBox.Size = new Size(452, 180);
            ProfilesTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ProfilesTextBox.TabIndex = 1;
            ProfilesTextBox.TextChanged += ProfilesTextBox_TextChanged;
            // 
            // TimeoutUpDown
            // 
            TimeoutUpDown.Location = new Point(84, 247);
            TimeoutUpDown.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            TimeoutUpDown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            TimeoutUpDown.Name = "TimeoutUpDown";
            TimeoutUpDown.Size = new Size(128, 22);
            TimeoutUpDown.StateCommon.Content.Color1 = Color.Black;
            TimeoutUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TimeoutUpDown.TabIndex = 2;
            TimeoutUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            TimeoutUpDown.ValueChanged += TimeoutUpDown_ValueChanged;
            // 
            // TopMostCheckBtn
            // 
            TopMostCheckBtn.Checked = true;
            TopMostCheckBtn.CheckState = CheckState.Checked;
            TopMostCheckBtn.Location = new Point(245, 209);
            TopMostCheckBtn.Name = "TopMostCheckBtn";
            TopMostCheckBtn.Size = new Size(82, 20);
            TopMostCheckBtn.StateCommon.ShortText.Color1 = Color.Black;
            TopMostCheckBtn.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TopMostCheckBtn.TabIndex = 7;
            TopMostCheckBtn.Values.Text = "Ghim App";
            TopMostCheckBtn.CheckedChanged += TopMostCheckBtn_CheckedChanged;
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(12, 247);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(66, 20);
            kryptonLabel5.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel5.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel5.TabIndex = 16;
            kryptonLabel5.Values.Text = "Time out:";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(12, 26);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(6, 2);
            kryptonLabel6.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel6.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel6.TabIndex = 17;
            kryptonLabel6.Values.Text = "";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(12, 209);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(87, 20);
            kryptonLabel7.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel7.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel7.TabIndex = 18;
            kryptonLabel7.Values.Text = "User Profiles:";
            // 
            // StartBtn
            // 
            StartBtn.CornerRoundingRadius = -1F;
            StartBtn.Location = new Point(12, 326);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(90, 25);
            StartBtn.StateCommon.Back.Color1 = Color.GreenYellow;
            StartBtn.StateCommon.Back.Color2 = Color.GreenYellow;
            StartBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartBtn.TabIndex = 19;
            StartBtn.Values.Text = "Bắt đầu";
            StartBtn.Click += StartBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.CornerRoundingRadius = -1F;
            StopBtn.Enabled = false;
            StopBtn.Location = new Point(122, 326);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(90, 25);
            StopBtn.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StopBtn.TabIndex = 20;
            StopBtn.Values.Text = "Dừng lại";
            StopBtn.Click += StopBtn_Click;
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(245, 247);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(82, 20);
            kryptonLabel8.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel8.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel8.TabIndex = 21;
            kryptonLabel8.Values.Text = "Quãng nghỉ:";
            // 
            // RunStatusTextBox
            // 
            RunStatusTextBox.Location = new Point(245, 326);
            RunStatusTextBox.Name = "RunStatusTextBox";
            RunStatusTextBox.ReadOnly = true;
            RunStatusTextBox.Size = new Size(93, 23);
            RunStatusTextBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            RunStatusTextBox.StateCommon.Content.Color1 = Color.Black;
            RunStatusTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RunStatusTextBox.TabIndex = 22;
            RunStatusTextBox.Text = "Chưa bắt đầu";
            RunStatusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ProfileCountTextBox
            // 
            ProfileCountTextBox.Location = new Point(105, 209);
            ProfileCountTextBox.Name = "ProfileCountTextBox";
            ProfileCountTextBox.ReadOnly = true;
            ProfileCountTextBox.Size = new Size(107, 23);
            ProfileCountTextBox.StateCommon.Content.Color1 = Color.Black;
            ProfileCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProfileCountTextBox.TabIndex = 23;
            ProfileCountTextBox.Text = "0";
            ProfileCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SleepTimeUpDown
            // 
            SleepTimeUpDown.Location = new Point(336, 247);
            SleepTimeUpDown.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            SleepTimeUpDown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            SleepTimeUpDown.Name = "SleepTimeUpDown";
            SleepTimeUpDown.Size = new Size(128, 22);
            SleepTimeUpDown.StateCommon.Content.Color1 = Color.Black;
            SleepTimeUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SleepTimeUpDown.TabIndex = 24;
            SleepTimeUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            SleepTimeUpDown.ValueChanged += SleepTimeUpDown_ValueChanged;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(12, 287);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(74, 20);
            kryptonLabel1.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 25;
            kryptonLabel1.Values.Text = "VPS Name:";
            // 
            // VPSNameTextBox
            // 
            VPSNameTextBox.Location = new Point(84, 284);
            VPSNameTextBox.Name = "VPSNameTextBox";
            VPSNameTextBox.Size = new Size(380, 23);
            VPSNameTextBox.StateCommon.Back.Color1 = Color.White;
            VPSNameTextBox.StateCommon.Content.Color1 = Color.Black;
            VPSNameTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            VPSNameTextBox.TabIndex = 26;
            VPSNameTextBox.TextAlign = HorizontalAlignment.Center;
            VPSNameTextBox.TextChanged += VPSNameTextBox_TextChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 361);
            Controls.Add(VPSNameTextBox);
            Controls.Add(kryptonLabel1);
            Controls.Add(SleepTimeUpDown);
            Controls.Add(ProfileCountTextBox);
            Controls.Add(RunStatusTextBox);
            Controls.Add(kryptonLabel8);
            Controls.Add(StopBtn);
            Controls.Add(StartBtn);
            Controls.Add(kryptonLabel7);
            Controls.Add(kryptonLabel6);
            Controls.Add(kryptonLabel5);
            Controls.Add(TopMostCheckBtn);
            Controls.Add(TimeoutUpDown);
            Controls.Add(ProfilesTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(494, 400);
            MinimumSize = new Size(494, 400);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddonMoneyChecker Client - Tele: @lukaxsx";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
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
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox VPSNameTextBox;
    }
}