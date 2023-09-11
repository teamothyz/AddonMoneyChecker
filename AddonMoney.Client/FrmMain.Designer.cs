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
            TimeScanUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            VPSNameTextBox = new Krypton.Toolkit.KryptonTextBox();
            ProxyTypeComboBox = new Krypton.Toolkit.KryptonComboBox();
            DataInputBtn = new Krypton.Toolkit.KryptonButton();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            Group1TimeUpdown = new Krypton.Toolkit.KryptonNumericUpDown();
            Group2TimeUpdown = new Krypton.Toolkit.KryptonNumericUpDown();
            ThreadNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)ProxyTypeComboBox).BeginInit();
            SuspendLayout();
            // 
            // TimeoutUpDown
            // 
            TimeoutUpDown.Location = new Point(105, 45);
            TimeoutUpDown.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            TimeoutUpDown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            TimeoutUpDown.Name = "TimeoutUpDown";
            TimeoutUpDown.Size = new Size(107, 22);
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
            TopMostCheckBtn.Location = new Point(241, 158);
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
            kryptonLabel5.Location = new Point(12, 47);
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
            kryptonLabel7.Location = new Point(12, 12);
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
            StartBtn.Location = new Point(241, 45);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(90, 25);
            StartBtn.StateCommon.Back.Color1 = Color.GreenYellow;
            StartBtn.StateCommon.Back.Color2 = Color.GreenYellow;
            StartBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            StartBtn.StateCommon.Content.ShortText.Color2 = Color.Black;
            StartBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartBtn.TabIndex = 19;
            StartBtn.Values.Text = "Bắt đầu";
            StartBtn.Click += StartBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.CornerRoundingRadius = -1F;
            StopBtn.Enabled = false;
            StopBtn.Location = new Point(241, 80);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(90, 25);
            StopBtn.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            StopBtn.StateCommon.Content.ShortText.Color2 = Color.Black;
            StopBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StopBtn.TabIndex = 20;
            StopBtn.Values.Text = "Dừng lại";
            StopBtn.Click += StopBtn_Click;
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(12, 121);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(113, 20);
            kryptonLabel8.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel8.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel8.TabIndex = 21;
            kryptonLabel8.Values.Text = "Time quét (phút):";
            // 
            // RunStatusTextBox
            // 
            RunStatusTextBox.Location = new Point(241, 119);
            RunStatusTextBox.Name = "RunStatusTextBox";
            RunStatusTextBox.ReadOnly = true;
            RunStatusTextBox.Size = new Size(90, 23);
            RunStatusTextBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            RunStatusTextBox.StateCommon.Content.Color1 = Color.Black;
            RunStatusTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            RunStatusTextBox.TabIndex = 22;
            RunStatusTextBox.Text = "Chưa bắt đầu";
            RunStatusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ProfileCountTextBox
            // 
            ProfileCountTextBox.Location = new Point(105, 9);
            ProfileCountTextBox.Name = "ProfileCountTextBox";
            ProfileCountTextBox.ReadOnly = true;
            ProfileCountTextBox.Size = new Size(107, 23);
            ProfileCountTextBox.StateCommon.Content.Color1 = Color.Black;
            ProfileCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProfileCountTextBox.TabIndex = 23;
            ProfileCountTextBox.Text = "0";
            ProfileCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TimeScanUpDown
            // 
            TimeScanUpDown.Location = new Point(121, 119);
            TimeScanUpDown.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            TimeScanUpDown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            TimeScanUpDown.Name = "TimeScanUpDown";
            TimeScanUpDown.Size = new Size(91, 22);
            TimeScanUpDown.StateCommon.Content.Color1 = Color.Black;
            TimeScanUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TimeScanUpDown.TabIndex = 24;
            TimeScanUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            TimeScanUpDown.ValueChanged += SleepTimeUpDown_ValueChanged;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(12, 83);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(74, 20);
            kryptonLabel1.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 25;
            kryptonLabel1.Values.Text = "VPS Name:";
            // 
            // VPSNameTextBox
            // 
            VPSNameTextBox.Location = new Point(105, 80);
            VPSNameTextBox.Name = "VPSNameTextBox";
            VPSNameTextBox.Size = new Size(107, 23);
            VPSNameTextBox.StateCommon.Back.Color1 = Color.White;
            VPSNameTextBox.StateCommon.Content.Color1 = Color.Black;
            VPSNameTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            VPSNameTextBox.TabIndex = 26;
            VPSNameTextBox.TextAlign = HorizontalAlignment.Center;
            VPSNameTextBox.TextChanged += VPSNameTextBox_TextChanged;
            // 
            // ProxyTypeComboBox
            // 
            ProxyTypeComboBox.CornerRoundingRadius = -1F;
            ProxyTypeComboBox.DropDownWidth = 130;
            ProxyTypeComboBox.IntegralHeight = false;
            ProxyTypeComboBox.Items.AddRange(new object[] { "HTTP", "Socks5" });
            ProxyTypeComboBox.Location = new Point(105, 226);
            ProxyTypeComboBox.Name = "ProxyTypeComboBox";
            ProxyTypeComboBox.Size = new Size(106, 21);
            ProxyTypeComboBox.StateCommon.ComboBox.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProxyTypeComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            ProxyTypeComboBox.TabIndex = 27;
            ProxyTypeComboBox.Text = "Proxy Type";
            ProxyTypeComboBox.SelectedIndexChanged += ProxyTypeComboBox_SelectedIndexChanged;
            // 
            // DataInputBtn
            // 
            DataInputBtn.CornerRoundingRadius = -1F;
            DataInputBtn.Location = new Point(241, 7);
            DataInputBtn.Name = "DataInputBtn";
            DataInputBtn.Size = new Size(90, 25);
            DataInputBtn.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 192);
            DataInputBtn.StateCommon.Back.Color2 = Color.FromArgb(0, 192, 192);
            DataInputBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            DataInputBtn.StateCommon.Content.ShortText.Color2 = Color.Black;
            DataInputBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            DataInputBtn.TabIndex = 32;
            DataInputBtn.Values.Text = "Nhập dữ liệu";
            DataInputBtn.Click += DataInputBtn_Click;
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(12, 227);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(75, 20);
            kryptonLabel2.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel2.TabIndex = 33;
            kryptonLabel2.Values.Text = "Loại proxy:";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(12, 158);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(81, 20);
            kryptonLabel3.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel3.TabIndex = 34;
            kryptonLabel3.Values.Text = "Time lượt 1:";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(12, 194);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(81, 20);
            kryptonLabel4.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel4.TabIndex = 35;
            kryptonLabel4.Values.Text = "Time lượt 2:";
            // 
            // Group1TimeUpdown
            // 
            Group1TimeUpdown.Location = new Point(105, 156);
            Group1TimeUpdown.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            Group1TimeUpdown.Name = "Group1TimeUpdown";
            Group1TimeUpdown.Size = new Size(107, 22);
            Group1TimeUpdown.StateCommon.Content.Color1 = Color.Black;
            Group1TimeUpdown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Group1TimeUpdown.TabIndex = 36;
            Group1TimeUpdown.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // Group2TimeUpdown
            // 
            Group2TimeUpdown.Location = new Point(104, 192);
            Group2TimeUpdown.Maximum = new decimal(new int[] { 23, 0, 0, 0 });
            Group2TimeUpdown.Name = "Group2TimeUpdown";
            Group2TimeUpdown.Size = new Size(107, 22);
            Group2TimeUpdown.StateCommon.Content.Color1 = Color.Black;
            Group2TimeUpdown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Group2TimeUpdown.TabIndex = 37;
            Group2TimeUpdown.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // ThreadNumericUpDown
            // 
            ThreadNumericUpDown.Location = new Point(105, 258);
            ThreadNumericUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            ThreadNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadNumericUpDown.Name = "ThreadNumericUpDown";
            ThreadNumericUpDown.Size = new Size(107, 22);
            ThreadNumericUpDown.StateCommon.Content.Color1 = Color.Black;
            ThreadNumericUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadNumericUpDown.TabIndex = 39;
            ThreadNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(12, 260);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(65, 20);
            kryptonLabel9.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel9.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel9.TabIndex = 38;
            kryptonLabel9.Values.Text = "Số luồng:";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 290);
            Controls.Add(ThreadNumericUpDown);
            Controls.Add(kryptonLabel9);
            Controls.Add(Group2TimeUpdown);
            Controls.Add(Group1TimeUpdown);
            Controls.Add(kryptonLabel4);
            Controls.Add(kryptonLabel3);
            Controls.Add(kryptonLabel2);
            Controls.Add(DataInputBtn);
            Controls.Add(ProxyTypeComboBox);
            Controls.Add(VPSNameTextBox);
            Controls.Add(kryptonLabel1);
            Controls.Add(TimeScanUpDown);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(374, 329);
            MinimumSize = new Size(374, 329);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddonMoneyChecker Client - Tele: @lukaxsx";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)ProxyTypeComboBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
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
        private Krypton.Toolkit.KryptonNumericUpDown TimeScanUpDown;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox VPSNameTextBox;
        private Krypton.Toolkit.KryptonComboBox ProxyTypeComboBox;
        private Krypton.Toolkit.KryptonButton DataInputBtn;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonNumericUpDown Group1TimeUpdown;
        private Krypton.Toolkit.KryptonNumericUpDown Group2TimeUpdown;
        private Krypton.Toolkit.KryptonNumericUpDown ThreadNumericUpDown;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
    }
}