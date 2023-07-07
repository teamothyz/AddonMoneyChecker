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
            ProfilesTextBox = new Krypton.Toolkit.KryptonTextBox();
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
            ProCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            SuspendLayout();
            // 
            // ProfilesTextBox
            // 
            ProfilesTextBox.Location = new Point(12, 12);
            ProfilesTextBox.Multiline = true;
            ProfilesTextBox.Name = "ProfilesTextBox";
            ProfilesTextBox.Size = new Size(558, 390);
            ProfilesTextBox.TabIndex = 0;
            ProfilesTextBox.TextChanged += ProfilesTextBox_TextChanged;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(592, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(65, 20);
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 1;
            kryptonLabel1.Values.Text = "Số luồng:";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(592, 54);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(62, 20);
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel2.TabIndex = 2;
            kryptonLabel2.Values.Text = "Timeout:";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(12, 418);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(90, 20);
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel3.TabIndex = 3;
            kryptonLabel3.Values.Text = "2captcha API:";
            // 
            // _2captchaTextBox
            // 
            _2captchaTextBox.Location = new Point(108, 415);
            _2captchaTextBox.Name = "_2captchaTextBox";
            _2captchaTextBox.Size = new Size(370, 23);
            _2captchaTextBox.TabIndex = 4;
            // 
            // ThreadUpDown
            // 
            ThreadUpDown.Location = new Point(668, 12);
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
            TimeoutUpDown.Location = new Point(668, 54);
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
            AccountsInputBtn.Location = new Point(632, 138);
            AccountsInputBtn.Name = "AccountsInputBtn";
            AccountsInputBtn.Size = new Size(123, 30);
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
            StartBtn.Location = new Point(632, 188);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(123, 30);
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
            StopBtn.Location = new Point(632, 237);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(123, 30);
            StopBtn.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 128);
            StopBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StopBtn.TabIndex = 9;
            StopBtn.Values.Text = "Dừng lại";
            StopBtn.Click += StopBtn_Click;
            // 
            // StatusTextBox
            // 
            StatusTextBox.Location = new Point(592, 415);
            StatusTextBox.Name = "StatusTextBox";
            StatusTextBox.ReadOnly = true;
            StatusTextBox.Size = new Size(196, 23);
            StatusTextBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
            StatusTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTextBox.TabIndex = 10;
            StatusTextBox.Text = "Chưa bắt đầu";
            StatusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(592, 330);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(82, 20);
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel4.TabIndex = 11;
            kryptonLabel4.Values.Text = "Thành công:";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(592, 368);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(61, 20);
            kryptonLabel5.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel5.TabIndex = 12;
            kryptonLabel5.Values.Text = "Thất bại:";
            // 
            // SuccessTextBox
            // 
            SuccessTextBox.Location = new Point(680, 327);
            SuccessTextBox.Name = "SuccessTextBox";
            SuccessTextBox.ReadOnly = true;
            SuccessTextBox.Size = new Size(108, 23);
            SuccessTextBox.StateCommon.Back.Color1 = Color.LimeGreen;
            SuccessTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SuccessTextBox.TabIndex = 13;
            SuccessTextBox.Text = "0";
            SuccessTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // FailedTextBox
            // 
            FailedTextBox.Location = new Point(680, 368);
            FailedTextBox.Name = "FailedTextBox";
            FailedTextBox.ReadOnly = true;
            FailedTextBox.Size = new Size(108, 23);
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
            TopMostCheckBox.Location = new Point(488, 415);
            TopMostCheckBox.Name = "TopMostCheckBox";
            TopMostCheckBox.Size = new Size(82, 20);
            TopMostCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TopMostCheckBox.TabIndex = 15;
            TopMostCheckBox.Values.Text = "Ghim App";
            TopMostCheckBox.CheckedChanged += TopMostCheckBox_CheckedChanged;
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(592, 294);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(67, 20);
            kryptonLabel6.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel6.TabIndex = 16;
            kryptonLabel6.Values.Text = "Accounts:";
            // 
            // AccCountTextBox
            // 
            AccCountTextBox.Location = new Point(680, 291);
            AccCountTextBox.Name = "AccCountTextBox";
            AccCountTextBox.ReadOnly = true;
            AccCountTextBox.Size = new Size(108, 23);
            AccCountTextBox.StateCommon.Back.Color1 = Color.FromArgb(128, 255, 255);
            AccCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AccCountTextBox.TabIndex = 17;
            AccCountTextBox.Text = "0";
            AccCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(592, 95);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(58, 20);
            kryptonLabel7.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel7.TabIndex = 18;
            kryptonLabel7.Values.Text = "Profiles:";
            // 
            // ProCountTextBox
            // 
            ProCountTextBox.Location = new Point(668, 92);
            ProCountTextBox.Name = "ProCountTextBox";
            ProCountTextBox.ReadOnly = true;
            ProCountTextBox.Size = new Size(120, 23);
            ProCountTextBox.StateCommon.Back.Color1 = Color.FromArgb(128, 255, 255);
            ProCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProCountTextBox.TabIndex = 19;
            ProCountTextBox.Text = "0";
            ProCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ProCountTextBox);
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
            Controls.Add(ProfilesTextBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(816, 489);
            MinimumSize = new Size(816, 489);
            Name = "FrmMain";
            Text = "AddonMoney Transfer - Telegram: @lukaxsx";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox ProfilesTextBox;
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
        private Krypton.Toolkit.KryptonTextBox ProCountTextBox;
    }
}