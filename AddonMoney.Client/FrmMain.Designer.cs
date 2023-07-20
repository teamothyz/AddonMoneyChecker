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
            this.TimeScanUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.VPSNameTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.ProxyTypeComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.ReferLinkTxtBox = new Krypton.Toolkit.KryptonTextBox();
            this.ReferLinkLabel = new Krypton.Toolkit.KryptonLabel();
            this.TimeResetUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.OnlyRootLinkCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyTypeComboBox)).BeginInit();
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
            this.TimeoutUpDown.Location = new System.Drawing.Point(105, 247);
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
            this.TimeoutUpDown.Size = new System.Drawing.Size(107, 22);
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
            this.StartBtn.Location = new System.Drawing.Point(12, 326);
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
            this.StopBtn.Location = new System.Drawing.Point(122, 326);
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
            this.kryptonLabel8.Size = new System.Drawing.Size(113, 20);
            this.kryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel8.TabIndex = 21;
            this.kryptonLabel8.Values.Text = "Time quét (phút):";
            // 
            // RunStatusTextBox
            // 
            this.RunStatusTextBox.Location = new System.Drawing.Point(12, 366);
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
            // TimeScanUpDown
            // 
            this.TimeScanUpDown.Location = new System.Drawing.Point(357, 247);
            this.TimeScanUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TimeScanUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.TimeScanUpDown.Name = "TimeScanUpDown";
            this.TimeScanUpDown.Size = new System.Drawing.Size(107, 22);
            this.TimeScanUpDown.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.TimeScanUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeScanUpDown.TabIndex = 24;
            this.TimeScanUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.TimeScanUpDown.ValueChanged += new System.EventHandler(this.SleepTimeUpDown_ValueChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 287);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(74, 20);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel1.TabIndex = 25;
            this.kryptonLabel1.Values.Text = "VPS Name:";
            // 
            // VPSNameTextBox
            // 
            this.VPSNameTextBox.Location = new System.Drawing.Point(105, 284);
            this.VPSNameTextBox.Name = "VPSNameTextBox";
            this.VPSNameTextBox.Size = new System.Drawing.Size(107, 23);
            this.VPSNameTextBox.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.VPSNameTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.VPSNameTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.VPSNameTextBox.TabIndex = 26;
            this.VPSNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VPSNameTextBox.TextChanged += new System.EventHandler(this.VPSNameTextBox_TextChanged);
            // 
            // ProxyTypeComboBox
            // 
            this.ProxyTypeComboBox.CornerRoundingRadius = -1F;
            this.ProxyTypeComboBox.DropDownWidth = 130;
            this.ProxyTypeComboBox.IntegralHeight = false;
            this.ProxyTypeComboBox.Items.AddRange(new object[] {
            "HTTP",
            "Socks5"});
            this.ProxyTypeComboBox.Location = new System.Drawing.Point(340, 211);
            this.ProxyTypeComboBox.Name = "ProxyTypeComboBox";
            this.ProxyTypeComboBox.Size = new System.Drawing.Size(126, 21);
            this.ProxyTypeComboBox.StateCommon.ComboBox.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProxyTypeComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.ProxyTypeComboBox.TabIndex = 27;
            this.ProxyTypeComboBox.Text = "Proxy Type";
            this.ProxyTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ProxyTypeComboBox_SelectedIndexChanged);
            // 
            // ReferLinkTxtBox
            // 
            this.ReferLinkTxtBox.Location = new System.Drawing.Point(324, 326);
            this.ReferLinkTxtBox.Name = "ReferLinkTxtBox";
            this.ReferLinkTxtBox.Size = new System.Drawing.Size(140, 23);
            this.ReferLinkTxtBox.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.ReferLinkTxtBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.ReferLinkTxtBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReferLinkTxtBox.TabIndex = 29;
            this.ReferLinkTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReferLinkTxtBox.TextChanged += new System.EventHandler(this.ReferLinkTxtBox_TextChanged);
            // 
            // ReferLinkLabel
            // 
            this.ReferLinkLabel.Location = new System.Drawing.Point(245, 329);
            this.ReferLinkLabel.Name = "ReferLinkLabel";
            this.ReferLinkLabel.Size = new System.Drawing.Size(73, 20);
            this.ReferLinkLabel.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.ReferLinkLabel.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReferLinkLabel.TabIndex = 28;
            this.ReferLinkLabel.Values.Text = "Refer Link:";
            // 
            // TimeResetUpDown
            // 
            this.TimeResetUpDown.Location = new System.Drawing.Point(357, 285);
            this.TimeResetUpDown.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.TimeResetUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeResetUpDown.Name = "TimeResetUpDown";
            this.TimeResetUpDown.Size = new System.Drawing.Size(107, 22);
            this.TimeResetUpDown.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.TimeResetUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeResetUpDown.TabIndex = 31;
            this.TimeResetUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(245, 287);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(106, 20);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel2.TabIndex = 30;
            this.kryptonLabel2.Values.Text = "Time reset (giờ):";
            // 
            // OnlyRootLinkCheckBox
            // 
            this.OnlyRootLinkCheckBox.Location = new System.Drawing.Point(245, 369);
            this.OnlyRootLinkCheckBox.Name = "OnlyRootLinkCheckBox";
            this.OnlyRootLinkCheckBox.Size = new System.Drawing.Size(142, 20);
            this.OnlyRootLinkCheckBox.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.OnlyRootLinkCheckBox.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.OnlyRootLinkCheckBox.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OnlyRootLinkCheckBox.TabIndex = 32;
            this.OnlyRootLinkCheckBox.Values.Text = "Chỉ sử dụng link gốc";
            this.OnlyRootLinkCheckBox.CheckedChanged += new System.EventHandler(this.OnlyRootLinkCheckBox_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 408);
            this.Controls.Add(this.OnlyRootLinkCheckBox);
            this.Controls.Add(this.TimeResetUpDown);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.ReferLinkTxtBox);
            this.Controls.Add(this.ReferLinkLabel);
            this.Controls.Add(this.ProxyTypeComboBox);
            this.Controls.Add(this.VPSNameTextBox);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.TimeScanUpDown);
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
            this.MaximumSize = new System.Drawing.Size(494, 447);
            this.MinimumSize = new System.Drawing.Size(494, 447);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddonMoneyChecker Client - Tele: @lukaxsx";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ProxyTypeComboBox)).EndInit();
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
        private Krypton.Toolkit.KryptonNumericUpDown TimeScanUpDown;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonTextBox VPSNameTextBox;
        private Krypton.Toolkit.KryptonComboBox ProxyTypeComboBox;
        private Krypton.Toolkit.KryptonTextBox ReferLinkTxtBox;
        private Krypton.Toolkit.KryptonLabel ReferLinkLabel;
        private Krypton.Toolkit.KryptonNumericUpDown TimeResetUpDown;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonCheckBox OnlyRootLinkCheckBox;
    }
}