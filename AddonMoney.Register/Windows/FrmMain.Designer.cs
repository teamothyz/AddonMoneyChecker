namespace AddonMoney.Register.Windows
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
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.TotalCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.SuccessCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.FailedCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.ProcessedCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            this.ThreadNumberUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.TimeoutUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            this.InputDataBtn = new Krypton.Toolkit.KryptonButton();
            this.StartBtn = new Krypton.Toolkit.KryptonButton();
            this.StopBtn = new Krypton.Toolkit.KryptonButton();
            this.StatusTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.TopMostCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.ReferalTextBox = new Krypton.Toolkit.KryptonTextBox();
            this.OnlyRootLinkCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.ProxyComboBox = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.ProxyComboBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel1.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Tổng đầu vào:";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 51);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel2.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Thành công:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 89);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel3.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel3.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel3.TabIndex = 2;
            this.kryptonLabel3.Values.Text = "Thất bại:";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(12, 128);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel4.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel4.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel4.TabIndex = 3;
            this.kryptonLabel4.Values.Text = "Đã chạy:";
            // 
            // TotalCountTextBox
            // 
            this.TotalCountTextBox.Location = new System.Drawing.Point(111, 9);
            this.TotalCountTextBox.Name = "TotalCountTextBox";
            this.TotalCountTextBox.ReadOnly = true;
            this.TotalCountTextBox.Size = new System.Drawing.Size(100, 23);
            this.TotalCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.Yellow;
            this.TotalCountTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.TotalCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TotalCountTextBox.TabIndex = 4;
            this.TotalCountTextBox.Text = "0";
            this.TotalCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SuccessCountTextBox
            // 
            this.SuccessCountTextBox.Location = new System.Drawing.Point(111, 48);
            this.SuccessCountTextBox.Name = "SuccessCountTextBox";
            this.SuccessCountTextBox.ReadOnly = true;
            this.SuccessCountTextBox.Size = new System.Drawing.Size(100, 23);
            this.SuccessCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SuccessCountTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.SuccessCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SuccessCountTextBox.TabIndex = 5;
            this.SuccessCountTextBox.Text = "0";
            this.SuccessCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FailedCountTextBox
            // 
            this.FailedCountTextBox.Location = new System.Drawing.Point(111, 86);
            this.FailedCountTextBox.Name = "FailedCountTextBox";
            this.FailedCountTextBox.ReadOnly = true;
            this.FailedCountTextBox.Size = new System.Drawing.Size(100, 23);
            this.FailedCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.FailedCountTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.FailedCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FailedCountTextBox.TabIndex = 6;
            this.FailedCountTextBox.Text = "0";
            this.FailedCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProcessedCountTextBox
            // 
            this.ProcessedCountTextBox.Location = new System.Drawing.Point(111, 125);
            this.ProcessedCountTextBox.Name = "ProcessedCountTextBox";
            this.ProcessedCountTextBox.ReadOnly = true;
            this.ProcessedCountTextBox.Size = new System.Drawing.Size(100, 23);
            this.ProcessedCountTextBox.StateCommon.Back.Color1 = System.Drawing.Color.Wheat;
            this.ProcessedCountTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.ProcessedCountTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ProcessedCountTextBox.TabIndex = 7;
            this.ProcessedCountTextBox.Text = "0";
            this.ProcessedCountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(13, 166);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel5.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel5.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel5.TabIndex = 8;
            this.kryptonLabel5.Values.Text = "Số luồng:";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.Location = new System.Drawing.Point(13, 206);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(93, 20);
            this.kryptonLabel6.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel6.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel6.TabIndex = 9;
            this.kryptonLabel6.Values.Text = "Thời gian chờ:";
            // 
            // ThreadNumberUpDown
            // 
            this.ThreadNumberUpDown.Location = new System.Drawing.Point(111, 164);
            this.ThreadNumberUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ThreadNumberUpDown.Name = "ThreadNumberUpDown";
            this.ThreadNumberUpDown.Size = new System.Drawing.Size(100, 22);
            this.ThreadNumberUpDown.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ThreadNumberUpDown.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.ThreadNumberUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ThreadNumberUpDown.TabIndex = 10;
            this.ThreadNumberUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TimeoutUpDown
            // 
            this.TimeoutUpDown.Location = new System.Drawing.Point(111, 204);
            this.TimeoutUpDown.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.TimeoutUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.TimeoutUpDown.Name = "TimeoutUpDown";
            this.TimeoutUpDown.Size = new System.Drawing.Size(100, 22);
            this.TimeoutUpDown.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.TimeoutUpDown.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.TimeoutUpDown.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TimeoutUpDown.TabIndex = 11;
            this.TimeoutUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.TimeoutUpDown.ValueChanged += new System.EventHandler(this.TimeoutUpDown_ValueChanged);
            // 
            // InputDataBtn
            // 
            this.InputDataBtn.CornerRoundingRadius = -1F;
            this.InputDataBtn.Location = new System.Drawing.Point(243, 7);
            this.InputDataBtn.Name = "InputDataBtn";
            this.InputDataBtn.Size = new System.Drawing.Size(119, 25);
            this.InputDataBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.InputDataBtn.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.InputDataBtn.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.InputDataBtn.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.InputDataBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.InputDataBtn.TabIndex = 12;
            this.InputDataBtn.Values.Text = "Nhập data";
            this.InputDataBtn.Click += new System.EventHandler(this.InputDataBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.CornerRoundingRadius = -1F;
            this.StartBtn.Location = new System.Drawing.Point(243, 46);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(119, 25);
            this.StartBtn.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartBtn.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartBtn.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.StartBtn.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.StartBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StartBtn.TabIndex = 13;
            this.StartBtn.Values.Text = "Bắt đầu";
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.CornerRoundingRadius = -1F;
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(243, 84);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(119, 25);
            this.StopBtn.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.StopBtn.StateCommon.Back.Color2 = System.Drawing.Color.Red;
            this.StopBtn.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.StopBtn.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.StopBtn.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StopBtn.TabIndex = 14;
            this.StopBtn.Values.Text = "Dừng lại";
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Location = new System.Drawing.Point(243, 125);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.Size = new System.Drawing.Size(119, 23);
            this.StatusTextBox.StateActive.Back.Color1 = System.Drawing.Color.Yellow;
            this.StatusTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.StatusTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StatusTextBox.TabIndex = 15;
            this.StatusTextBox.Text = "Chưa bắt đầu";
            this.StatusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TopMostCheckBox
            // 
            this.TopMostCheckBox.Checked = true;
            this.TopMostCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TopMostCheckBox.Location = new System.Drawing.Point(244, 164);
            this.TopMostCheckBox.Name = "TopMostCheckBox";
            this.TopMostCheckBox.Size = new System.Drawing.Size(82, 20);
            this.TopMostCheckBox.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.TopMostCheckBox.StateCommon.ShortText.Color2 = System.Drawing.Color.Black;
            this.TopMostCheckBox.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.TopMostCheckBox.TabIndex = 16;
            this.TopMostCheckBox.Values.Text = "Ghim APP";
            this.TopMostCheckBox.Click += new System.EventHandler(this.TopMostCheckBox_CheckedChanged);
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(13, 290);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(97, 20);
            this.kryptonLabel7.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel7.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel7.TabIndex = 17;
            this.kryptonLabel7.Values.Text = "Link giới thiệu:";
            // 
            // ReferalTextBox
            // 
            this.ReferalTextBox.Location = new System.Drawing.Point(111, 287);
            this.ReferalTextBox.Name = "ReferalTextBox";
            this.ReferalTextBox.Size = new System.Drawing.Size(251, 23);
            this.ReferalTextBox.StateCommon.Content.Color1 = System.Drawing.Color.Black;
            this.ReferalTextBox.StateCommon.Content.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReferalTextBox.TabIndex = 18;
            this.ReferalTextBox.TextChanged += new System.EventHandler(this.ReferalTextBox_TextChanged);
            // 
            // OnlyRootLinkCheckBox
            // 
            this.OnlyRootLinkCheckBox.Location = new System.Drawing.Point(244, 204);
            this.OnlyRootLinkCheckBox.Name = "OnlyRootLinkCheckBox";
            this.OnlyRootLinkCheckBox.Size = new System.Drawing.Size(125, 20);
            this.OnlyRootLinkCheckBox.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.OnlyRootLinkCheckBox.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.OnlyRootLinkCheckBox.TabIndex = 19;
            this.OnlyRootLinkCheckBox.Values.Text = "Chỉ dùng link gốc";
            this.OnlyRootLinkCheckBox.Click += new System.EventHandler(this.OnlyRootLinkCheckBox_CheckedChanged);
            // 
            // ProxyComboBox
            // 
            this.ProxyComboBox.CornerRoundingRadius = -1F;
            this.ProxyComboBox.DropDownWidth = 100;
            this.ProxyComboBox.IntegralHeight = false;
            this.ProxyComboBox.Items.AddRange(new object[] {
            "HTTP",
            "Socks5"});
            this.ProxyComboBox.Location = new System.Drawing.Point(111, 247);
            this.ProxyComboBox.Name = "ProxyComboBox";
            this.ProxyComboBox.Size = new System.Drawing.Size(100, 21);
            this.ProxyComboBox.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.ProxyComboBox.TabIndex = 20;
            this.ProxyComboBox.SelectedIndexChanged += new System.EventHandler(this.ProxyComboBox_SelectedIndexChanged);
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(13, 248);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(75, 20);
            this.kryptonLabel8.StateCommon.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonLabel8.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kryptonLabel8.TabIndex = 21;
            this.kryptonLabel8.Values.Text = "Loại Proxy:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 321);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.ProxyComboBox);
            this.Controls.Add(this.OnlyRootLinkCheckBox);
            this.Controls.Add(this.ReferalTextBox);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.TopMostCheckBox);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.InputDataBtn);
            this.Controls.Add(this.TimeoutUpDown);
            this.Controls.Add(this.ThreadNumberUpDown);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.ProcessedCountTextBox);
            this.Controls.Add(this.FailedCountTextBox);
            this.Controls.Add(this.SuccessCountTextBox);
            this.Controls.Add(this.TotalCountTextBox);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.kryptonLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 360);
            this.MinimumSize = new System.Drawing.Size(390, 360);
            this.Name = "FrmMain";
            this.Text = "Addonmoney Register - Tele: @lukaxsx";
            ((System.ComponentModel.ISupportInitialize)(this.ProxyComboBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonTextBox TotalCountTextBox;
        private Krypton.Toolkit.KryptonTextBox SuccessCountTextBox;
        private Krypton.Toolkit.KryptonTextBox FailedCountTextBox;
        private Krypton.Toolkit.KryptonTextBox ProcessedCountTextBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonNumericUpDown ThreadNumberUpDown;
        private Krypton.Toolkit.KryptonNumericUpDown TimeoutUpDown;
        private Krypton.Toolkit.KryptonButton InputDataBtn;
        private Krypton.Toolkit.KryptonButton StartBtn;
        private Krypton.Toolkit.KryptonButton StopBtn;
        private Krypton.Toolkit.KryptonTextBox StatusTextBox;
        private Krypton.Toolkit.KryptonCheckBox TopMostCheckBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonTextBox ReferalTextBox;
        private Krypton.Toolkit.KryptonCheckBox OnlyRootLinkCheckBox;
        private Krypton.Toolkit.KryptonComboBox ProxyComboBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
    }
}