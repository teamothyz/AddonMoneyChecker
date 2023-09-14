namespace AddonMoney.Transfer.Windows
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
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            _2captchaTextBox = new Krypton.Toolkit.KryptonTextBox();
            ThreadUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            TimeoutUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            AccountsInputBtn = new Krypton.Toolkit.KryptonButton();
            StartBtn = new Krypton.Toolkit.KryptonButton();
            StopBtn = new Krypton.Toolkit.KryptonButton();
            StatusTextBox = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            SuccessTextBox = new Krypton.Toolkit.KryptonTextBox();
            FailedTextBox = new Krypton.Toolkit.KryptonTextBox();
            TopMostCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            AccCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            ProfileCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            ProxyCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            NoneProxyRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            HTTPProxyRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            Socks5ProxyRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel10 = new Krypton.Toolkit.KryptonLabel();
            MinNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            SuspendLayout();
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(12, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(65, 20);
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 1;
            kryptonLabel1.Values.Text = "Số luồng:";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(12, 48);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(62, 20);
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel2.TabIndex = 2;
            kryptonLabel2.Values.Text = "Timeout:";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(12, 192);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(90, 20);
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel3.TabIndex = 3;
            kryptonLabel3.Values.Text = "2captcha API:";
            // 
            // _2captchaTextBox
            // 
            _2captchaTextBox.Location = new Point(104, 189);
            _2captchaTextBox.Name = "_2captchaTextBox";
            _2captchaTextBox.Size = new Size(120, 23);
            _2captchaTextBox.TabIndex = 4;
            // 
            // ThreadUpDown
            // 
            ThreadUpDown.Location = new Point(104, 10);
            ThreadUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadUpDown.Name = "ThreadUpDown";
            ThreadUpDown.Size = new Size(120, 22);
            ThreadUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadUpDown.TabIndex = 5;
            ThreadUpDown.Value = new decimal(new int[] { 2, 0, 0, 0 });
            ThreadUpDown.ValueChanged += ThreadUpDown_ValueChanged;
            // 
            // TimeoutUpDown
            // 
            TimeoutUpDown.Location = new Point(104, 46);
            TimeoutUpDown.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            TimeoutUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            TimeoutUpDown.Name = "TimeoutUpDown";
            TimeoutUpDown.Size = new Size(120, 22);
            TimeoutUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TimeoutUpDown.TabIndex = 6;
            TimeoutUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            TimeoutUpDown.ValueChanged += TimeoutUpDown_ValueChanged;
            // 
            // AccountsInputBtn
            // 
            AccountsInputBtn.CornerRoundingRadius = -1F;
            AccountsInputBtn.Location = new Point(258, 10);
            AccountsInputBtn.Name = "AccountsInputBtn";
            AccountsInputBtn.Size = new Size(105, 30);
            AccountsInputBtn.StateCommon.Back.Color1 = Color.DeepSkyBlue;
            AccountsInputBtn.StateCommon.Back.Color2 = Color.DeepSkyBlue;
            AccountsInputBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AccountsInputBtn.TabIndex = 7;
            AccountsInputBtn.Values.Text = "Nhập Accounts";
            AccountsInputBtn.Click += AccountsInputBtn_Click;
            // 
            // StartBtn
            // 
            StartBtn.CornerRoundingRadius = -1F;
            StartBtn.Location = new Point(258, 173);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(91, 30);
            StartBtn.StateCommon.Back.Color1 = Color.FromArgb(128, 255, 128);
            StartBtn.StateCommon.Back.Color2 = Color.FromArgb(128, 255, 128);
            StartBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartBtn.TabIndex = 8;
            StartBtn.Values.Text = "Bắt đầu";
            StartBtn.Click += StartBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.CornerRoundingRadius = -1F;
            StopBtn.Enabled = false;
            StopBtn.Location = new Point(370, 173);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(91, 30);
            StopBtn.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StopBtn.TabIndex = 9;
            StopBtn.Values.Text = "Dừng lại";
            StopBtn.Click += StopBtn_Click;
            // 
            // StatusTextBox
            // 
            StatusTextBox.Location = new Point(258, 227);
            StatusTextBox.Name = "StatusTextBox";
            StatusTextBox.ReadOnly = true;
            StatusTextBox.Size = new Size(203, 23);
            StatusTextBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            StatusTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTextBox.TabIndex = 10;
            StatusTextBox.Text = "Chưa bắt đầu";
            StatusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(258, 264);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(82, 20);
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel4.TabIndex = 11;
            kryptonLabel4.Values.Text = "Thành công:";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(258, 290);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(61, 20);
            kryptonLabel5.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel5.TabIndex = 12;
            kryptonLabel5.Values.Text = "Thất bại:";
            // 
            // SuccessTextBox
            // 
            SuccessTextBox.Location = new Point(370, 258);
            SuccessTextBox.Name = "SuccessTextBox";
            SuccessTextBox.ReadOnly = true;
            SuccessTextBox.Size = new Size(91, 23);
            SuccessTextBox.StateCommon.Back.Color1 = Color.LimeGreen;
            SuccessTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SuccessTextBox.TabIndex = 13;
            SuccessTextBox.Text = "0";
            SuccessTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // FailedTextBox
            // 
            FailedTextBox.Location = new Point(370, 287);
            FailedTextBox.Name = "FailedTextBox";
            FailedTextBox.ReadOnly = true;
            FailedTextBox.Size = new Size(91, 23);
            FailedTextBox.StateCommon.Back.Color1 = Color.Tomato;
            FailedTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FailedTextBox.TabIndex = 14;
            FailedTextBox.Text = "0";
            FailedTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TopMostCheckBox
            // 
            TopMostCheckBox.Checked = true;
            TopMostCheckBox.CheckState = CheckState.Checked;
            TopMostCheckBox.Location = new Point(258, 325);
            TopMostCheckBox.Name = "TopMostCheckBox";
            TopMostCheckBox.Size = new Size(82, 20);
            TopMostCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TopMostCheckBox.TabIndex = 15;
            TopMostCheckBox.Values.Text = "Ghim App";
            TopMostCheckBox.CheckedChanged += TopMostCheckBox_CheckedChanged;
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(12, 154);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(67, 20);
            kryptonLabel6.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel6.TabIndex = 16;
            kryptonLabel6.Values.Text = "Accounts:";
            // 
            // AccCountTextBox
            // 
            AccCountTextBox.Location = new Point(104, 151);
            AccCountTextBox.Name = "AccCountTextBox";
            AccCountTextBox.ReadOnly = true;
            AccCountTextBox.Size = new Size(120, 23);
            AccCountTextBox.StateCommon.Back.Color1 = Color.FromArgb(128, 255, 255);
            AccCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AccCountTextBox.TabIndex = 17;
            AccCountTextBox.Text = "0";
            AccCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(12, 84);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(58, 20);
            kryptonLabel7.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel7.TabIndex = 18;
            kryptonLabel7.Values.Text = "Profiles:";
            // 
            // ProfileCountTextBox
            // 
            ProfileCountTextBox.Location = new Point(104, 81);
            ProfileCountTextBox.Name = "ProfileCountTextBox";
            ProfileCountTextBox.ReadOnly = true;
            ProfileCountTextBox.Size = new Size(120, 23);
            ProfileCountTextBox.StateCommon.Back.Color1 = Color.FromArgb(128, 255, 255);
            ProfileCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProfileCountTextBox.TabIndex = 19;
            ProfileCountTextBox.Text = "0";
            ProfileCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ProxyCountTextBox
            // 
            ProxyCountTextBox.Location = new Point(104, 117);
            ProxyCountTextBox.Name = "ProxyCountTextBox";
            ProxyCountTextBox.ReadOnly = true;
            ProxyCountTextBox.Size = new Size(120, 23);
            ProxyCountTextBox.StateCommon.Back.Color1 = Color.FromArgb(128, 255, 255);
            ProxyCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProxyCountTextBox.TabIndex = 22;
            ProxyCountTextBox.Text = "0";
            ProxyCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Location = new Point(12, 120);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(56, 20);
            kryptonLabel8.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel8.TabIndex = 21;
            kryptonLabel8.Values.Text = "Proxies:";
            // 
            // NoneProxyRadioBtn
            // 
            NoneProxyRadioBtn.Checked = true;
            NoneProxyRadioBtn.Location = new Point(260, 87);
            NoneProxyRadioBtn.Name = "NoneProxyRadioBtn";
            NoneProxyRadioBtn.Size = new Size(54, 20);
            NoneProxyRadioBtn.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            NoneProxyRadioBtn.TabIndex = 23;
            NoneProxyRadioBtn.Values.Text = "None";
            NoneProxyRadioBtn.CheckedChanged += NoneProxyRadioBtn_CheckedChanged;
            // 
            // HTTPProxyRadioBtn
            // 
            HTTPProxyRadioBtn.Location = new Point(260, 111);
            HTTPProxyRadioBtn.Name = "HTTPProxyRadioBtn";
            HTTPProxyRadioBtn.Size = new Size(54, 20);
            HTTPProxyRadioBtn.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            HTTPProxyRadioBtn.TabIndex = 24;
            HTTPProxyRadioBtn.Values.Text = "HTTP";
            HTTPProxyRadioBtn.CheckedChanged += HTTPProxyRadioBtn_CheckedChanged;
            // 
            // Socks5ProxyRadioBtn
            // 
            Socks5ProxyRadioBtn.Location = new Point(260, 134);
            Socks5ProxyRadioBtn.Name = "Socks5ProxyRadioBtn";
            Socks5ProxyRadioBtn.Size = new Size(62, 20);
            Socks5ProxyRadioBtn.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Socks5ProxyRadioBtn.TabIndex = 25;
            Socks5ProxyRadioBtn.Values.Text = "Socks5";
            Socks5ProxyRadioBtn.CheckedChanged += Socks5ProxyRadioBtn_CheckedChanged;
            // 
            // kryptonLabel9
            // 
            kryptonLabel9.Location = new Point(258, 61);
            kryptonLabel9.Name = "kryptonLabel9";
            kryptonLabel9.Size = new Size(56, 20);
            kryptonLabel9.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel9.TabIndex = 26;
            kryptonLabel9.Values.Text = "Proxies:";
            // 
            // kryptonLabel10
            // 
            kryptonLabel10.Location = new Point(12, 229);
            kryptonLabel10.Name = "kryptonLabel10";
            kryptonLabel10.Size = new Size(57, 20);
            kryptonLabel10.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel10.TabIndex = 27;
            kryptonLabel10.Values.Text = "Min rút:";
            // 
            // MinNumericUpDown
            // 
            MinNumericUpDown.Location = new Point(104, 227);
            MinNumericUpDown.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            MinNumericUpDown.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            MinNumericUpDown.Name = "MinNumericUpDown";
            MinNumericUpDown.Size = new Size(120, 22);
            MinNumericUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            MinNumericUpDown.TabIndex = 28;
            MinNumericUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 361);
            Controls.Add(MinNumericUpDown);
            Controls.Add(kryptonLabel10);
            Controls.Add(kryptonLabel9);
            Controls.Add(Socks5ProxyRadioBtn);
            Controls.Add(HTTPProxyRadioBtn);
            Controls.Add(NoneProxyRadioBtn);
            Controls.Add(ProxyCountTextBox);
            Controls.Add(kryptonLabel8);
            Controls.Add(ProfileCountTextBox);
            Controls.Add(kryptonLabel7);
            Controls.Add(AccCountTextBox);
            Controls.Add(kryptonLabel6);
            Controls.Add(TopMostCheckBox);
            Controls.Add(FailedTextBox);
            Controls.Add(SuccessTextBox);
            Controls.Add(kryptonLabel5);
            Controls.Add(kryptonLabel4);
            Controls.Add(StatusTextBox);
            Controls.Add(StopBtn);
            Controls.Add(StartBtn);
            Controls.Add(AccountsInputBtn);
            Controls.Add(TimeoutUpDown);
            Controls.Add(ThreadUpDown);
            Controls.Add(_2captchaTextBox);
            Controls.Add(kryptonLabel3);
            Controls.Add(kryptonLabel2);
            Controls.Add(kryptonLabel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(490, 400);
            MinimumSize = new Size(490, 400);
            Name = "FrmMain";
            Text = "AddonMoney Transfer - Telegram: @lukaxsx";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonTextBox _2captchaTextBox;
        private Krypton.Toolkit.KryptonNumericUpDown ThreadUpDown;
        private Krypton.Toolkit.KryptonNumericUpDown TimeoutUpDown;
        private Krypton.Toolkit.KryptonButton AccountsInputBtn;
        private Krypton.Toolkit.KryptonButton StartBtn;
        private Krypton.Toolkit.KryptonButton StopBtn;
        private Krypton.Toolkit.KryptonTextBox StatusTextBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonTextBox SuccessTextBox;
        private Krypton.Toolkit.KryptonTextBox FailedTextBox;
        private Krypton.Toolkit.KryptonCheckBox TopMostCheckBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonTextBox AccCountTextBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonTextBox ProfileCountTextBox;
        private Krypton.Toolkit.KryptonTextBox ProxyCountTextBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonRadioButton NoneProxyRadioBtn;
        private Krypton.Toolkit.KryptonRadioButton HTTPProxyRadioBtn;
        private Krypton.Toolkit.KryptonRadioButton Socks5ProxyRadioBtn;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonLabel kryptonLabel10;
        private Krypton.Toolkit.KryptonNumericUpDown MinNumericUpDown;
    }
}