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
            this.ProfilesTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this._2captchaTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.ThreadUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.TimeoutUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.AccountsInputBtn = new Krypton.Toolkit.KryptonButton();
            this.StartBtn = new Krypton.Toolkit.KryptonButton();
            this.StopBtn = new Krypton.Toolkit.KryptonButton();
            this.StatusTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.SuccessTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.FailedTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.TopMostCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.AccCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.ProCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.ProxyInputBtn = new Krypton.Toolkit.KryptonButton();
            this.ProxyCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            this.NoneProxyRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            this.HTTPProxyRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            this.Socks5ProxyRadioBtn = new Krypton.Toolkit.KryptonRadioButton();
            this.SuspendLayout();
            // 
            // ProfilesTextBox
            // 
            this.ProfilesTextBox.Location = new System.Drawing.Point(12, 12);
            this.ProfilesTextBox.Multiline = true;
            this.ProfilesTextBox.Name = "ProfilesTextBox";
            this.ProfilesTextBox.Size = new System.Drawing.Size(558, 390);
            this.ProfilesTextBox.TabIndex = 0;
            this.ProfilesTextBox.TextChanged += new System.EventHandler(this.ProfilesTextBox_TextChanged);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(576, 14);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Số luồng:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(576, 50);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Timeout:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 418);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(90, 20);
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel3.TabIndex = 3;
            this.kryptonLabel3.Values.Text = "2captcha API:";
            // 
            // _2captchaTextBox
            // 
            this._2captchaTextBox.Location = new System.Drawing.Point(108, 415);
            this._2captchaTextBox.Name = "_2captchaTextBox";
            this._2captchaTextBox.Size = new System.Drawing.Size(370, 23);
            this._2captchaTextBox.TabIndex = 4;
            // 
            // ThreadUpDown
            // 
            this.ThreadUpDown.Location = new System.Drawing.Point(668, 12);
            this.ThreadUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadUpDown.Name = "ThreadUpDown";
            this.ThreadUpDown.Size = new System.Drawing.Size(120, 22);
            this.ThreadUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ThreadUpDown.TabIndex = 5;
            this.ThreadUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ThreadUpDown.ValueChanged += new System.EventHandler(this.ThreadUpDown_ValueChanged);
            // 
            // TimeoutUpDown
            // 
            this.TimeoutUpDown.Location = new System.Drawing.Point(668, 48);
            this.TimeoutUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.TimeoutUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TimeoutUpDown.Name = "TimeoutUpDown";
            this.TimeoutUpDown.Size = new System.Drawing.Size(120, 22);
            this.TimeoutUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeoutUpDown.TabIndex = 6;
            this.TimeoutUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.TimeoutUpDown.ValueChanged += new System.EventHandler(this.TimeoutUpDown_ValueChanged);
            // 
            // AccountsInputBtn
            // 
            this.AccountsInputBtn.CornerRoundingRadius = -1F;
            this.AccountsInputBtn.Location = new System.Drawing.Point(576, 194);
            this.AccountsInputBtn.Name = "AccountsInputBtn";
            this.AccountsInputBtn.Size = new System.Drawing.Size(100, 30);
            this.AccountsInputBtn.StateCommon.Back.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.AccountsInputBtn.StateCommon.Back.Color2 = System.Drawing.Color.DeepSkyBlue;
            this.AccountsInputBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AccountsInputBtn.TabIndex = 7;
            this.AccountsInputBtn.Values.Text = "Nhập Accounts";
            this.AccountsInputBtn.Click += new System.EventHandler(this.AccountsInputBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.CornerRoundingRadius = -1F;
            this.StartBtn.Location = new System.Drawing.Point(576, 310);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(100, 30);
            this.StartBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.StartBtn.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.StartBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartBtn.TabIndex = 8;
            this.StartBtn.Values.Text = "Bắt đầu";
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.CornerRoundingRadius = -1F;
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(688, 310);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(100, 30);
            this.StopBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StopBtn.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.StopBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StopBtn.TabIndex = 9;
            this.StopBtn.Values.Text = "Dừng lại";
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Location = new System.Drawing.Point(576, 415);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.Size = new System.Drawing.Size(212, 23);
            this.StatusTextBox.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.StatusTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusTextBox.TabIndex = 10;
            this.StatusTextBox.Text = "Chưa bắt đầu";
            this.StatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(576, 356);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel4.TabIndex = 11;
            this.kryptonLabel4.Values.Text = "Thành công:";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(576, 382);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel5.TabIndex = 12;
            this.kryptonLabel5.Values.Text = "Thất bại:";
            // 
            // SuccessTextBox
            // 
            this.SuccessTextBox.Location = new System.Drawing.Point(688, 350);
            this.SuccessTextBox.Name = "SuccessTextBox";
            this.SuccessTextBox.ReadOnly = true;
            this.SuccessTextBox.Size = new System.Drawing.Size(100, 23);
            this.SuccessTextBox.StateCommon.Back.Color1 = System.Drawing.Color.LimeGreen;
            this.SuccessTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SuccessTextBox.TabIndex = 13;
            this.SuccessTextBox.Text = "0";
            this.SuccessTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FailedTextBox
            // 
            this.FailedTextBox.Location = new System.Drawing.Point(688, 379);
            this.FailedTextBox.Name = "FailedTextBox";
            this.FailedTextBox.ReadOnly = true;
            this.FailedTextBox.Size = new System.Drawing.Size(100, 23);
            this.FailedTextBox.StateCommon.Back.Color1 = System.Drawing.Color.Tomato;
            this.FailedTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FailedTextBox.TabIndex = 14;
            this.FailedTextBox.Text = "0";
            this.FailedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TopMostCheckBox
            // 
            this.TopMostCheckBox.Checked = true;
            this.TopMostCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopMostCheckBox.Location = new System.Drawing.Point(488, 417);
            this.TopMostCheckBox.Name = "TopMostCheckBox";
            this.TopMostCheckBox.Size = new System.Drawing.Size(82, 20);
            this.TopMostCheckBox.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TopMostCheckBox.TabIndex = 15;
            this.TopMostCheckBox.Values.Text = "Ghim App";
            this.TopMostCheckBox.CheckedChanged += new System.EventHandler(this.TopMostCheckBox_CheckedChanged);
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(576, 156);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(67, 20);
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel6.TabIndex = 16;
            this.kryptonLabel6.Values.Text = "Accounts:";
            // 
            // AccCountTextBox
            // 
            this.AccCountTextBox.Location = new System.Drawing.Point(668, 153);
            this.AccCountTextBox.Name = "AccCountTextBox";
            this.AccCountTextBox.ReadOnly = true;
            this.AccCountTextBox.Size = new System.Drawing.Size(120, 23);
            this.AccCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AccCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AccCountTextBox.TabIndex = 17;
            this.AccCountTextBox.Text = "0";
            this.AccCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(576, 86);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(58, 20);
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel7.TabIndex = 18;
            this.kryptonLabel7.Values.Text = "Profiles:";
            // 
            // ProCountTextBox
            // 
            this.ProCountTextBox.Location = new System.Drawing.Point(668, 83);
            this.ProCountTextBox.Name = "ProCountTextBox";
            this.ProCountTextBox.ReadOnly = true;
            this.ProCountTextBox.Size = new System.Drawing.Size(120, 23);
            this.ProCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProCountTextBox.TabIndex = 19;
            this.ProCountTextBox.Text = "0";
            this.ProCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProxyInputBtn
            // 
            this.ProxyInputBtn.CornerRoundingRadius = -1F;
            this.ProxyInputBtn.Location = new System.Drawing.Point(688, 194);
            this.ProxyInputBtn.Name = "ProxyInputBtn";
            this.ProxyInputBtn.Size = new System.Drawing.Size(100, 30);
            this.ProxyInputBtn.StateCommon.Back.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.ProxyInputBtn.StateCommon.Back.Color2 = System.Drawing.Color.DeepSkyBlue;
            this.ProxyInputBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProxyInputBtn.TabIndex = 20;
            this.ProxyInputBtn.Values.Text = "Nhập Proxies";
            this.ProxyInputBtn.Click += new System.EventHandler(this.ProxyInputBtn_Click);
            // 
            // ProxyCountTextBox
            // 
            this.ProxyCountTextBox.Location = new System.Drawing.Point(668, 119);
            this.ProxyCountTextBox.Name = "ProxyCountTextBox";
            this.ProxyCountTextBox.ReadOnly = true;
            this.ProxyCountTextBox.Size = new System.Drawing.Size(120, 23);
            this.ProxyCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ProxyCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProxyCountTextBox.TabIndex = 22;
            this.ProxyCountTextBox.Text = "0";
            this.ProxyCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(576, 122);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel8.TabIndex = 21;
            this.kryptonLabel8.Values.Text = "Proxies:";
            // 
            // NoneProxyRadioBtn
            // 
            this.NoneProxyRadioBtn.Checked = true;
            this.NoneProxyRadioBtn.Location = new System.Drawing.Point(688, 230);
            this.NoneProxyRadioBtn.Name = "NoneProxyRadioBtn";
            this.NoneProxyRadioBtn.Size = new System.Drawing.Size(54, 20);
            this.NoneProxyRadioBtn.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NoneProxyRadioBtn.TabIndex = 23;
            this.NoneProxyRadioBtn.Values.Text = "None";
            this.NoneProxyRadioBtn.CheckedChanged += new System.EventHandler(this.NoneProxyRadioBtn_CheckedChanged);
            // 
            // HTTPProxyRadioBtn
            // 
            this.HTTPProxyRadioBtn.Location = new System.Drawing.Point(688, 254);
            this.HTTPProxyRadioBtn.Name = "HTTPProxyRadioBtn";
            this.HTTPProxyRadioBtn.Size = new System.Drawing.Size(54, 20);
            this.HTTPProxyRadioBtn.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.HTTPProxyRadioBtn.TabIndex = 24;
            this.HTTPProxyRadioBtn.Values.Text = "HTTP";
            this.HTTPProxyRadioBtn.CheckedChanged += new System.EventHandler(this.HTTPProxyRadioBtn_CheckedChanged);
            // 
            // Socks5ProxyRadioBtn
            // 
            this.Socks5ProxyRadioBtn.Location = new System.Drawing.Point(688, 277);
            this.Socks5ProxyRadioBtn.Name = "Socks5ProxyRadioBtn";
            this.Socks5ProxyRadioBtn.Size = new System.Drawing.Size(62, 20);
            this.Socks5ProxyRadioBtn.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Socks5ProxyRadioBtn.TabIndex = 25;
            this.Socks5ProxyRadioBtn.Values.Text = "Socks5";
            this.Socks5ProxyRadioBtn.CheckedChanged += new System.EventHandler(this.Socks5ProxyRadioBtn_CheckedChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Socks5ProxyRadioBtn);
            this.Controls.Add(this.HTTPProxyRadioBtn);
            this.Controls.Add(this.NoneProxyRadioBtn);
            this.Controls.Add(this.ProxyCountTextBox);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.ProxyInputBtn);
            this.Controls.Add(this.ProCountTextBox);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.AccCountTextBox);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.TopMostCheckBox);
            this.Controls.Add(this.FailedTextBox);
            this.Controls.Add(this.SuccessTextBox);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.AccountsInputBtn);
            this.Controls.Add(this.TimeoutUpDown);
            this.Controls.Add(this.ThreadUpDown);
            this.Controls.Add(this._2captchaTextBox);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.ProfilesTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "FrmMain";
            this.Text = "AddonMoney Transfer - Telegram: @lukaxsx";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Krypton.Toolkit.KryptonButton ProxyInputBtn;
        private Krypton.Toolkit.KryptonTextBox ProxyCountTextBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonRadioButton NoneProxyRadioBtn;
        private Krypton.Toolkit.KryptonRadioButton HTTPProxyRadioBtn;
        private Krypton.Toolkit.KryptonRadioButton Socks5ProxyRadioBtn;
    }
}