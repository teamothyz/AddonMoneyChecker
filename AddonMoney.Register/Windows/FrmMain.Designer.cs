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
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            TotalCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            SuccessCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            FailedCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            ProcessedCountTextBox = new Krypton.Toolkit.KryptonTextBox();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            ThreadNumberUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            TimeoutUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            InputDataBtn = new Krypton.Toolkit.KryptonButton();
            StartBtn = new Krypton.Toolkit.KryptonButton();
            StopBtn = new Krypton.Toolkit.KryptonButton();
            StatusTextBox = new Krypton.Toolkit.KryptonTextBox();
            TopMostCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            ReferalTextBox = new Krypton.Toolkit.KryptonTextBox();
            OnlyRootLinkCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            SuspendLayout();
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new Point(12, 12);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(93, 20);
            kryptonLabel1.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 0;
            kryptonLabel1.Values.Text = "Tổng đầu vào:";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Location = new Point(12, 51);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(82, 20);
            kryptonLabel2.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel2.TabIndex = 1;
            kryptonLabel2.Values.Text = "Thành công:";
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Location = new Point(12, 89);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(61, 20);
            kryptonLabel3.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel3.TabIndex = 2;
            kryptonLabel3.Values.Text = "Thất bại:";
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Location = new Point(12, 128);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(60, 20);
            kryptonLabel4.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel4.TabIndex = 3;
            kryptonLabel4.Values.Text = "Đã chạy:";
            // 
            // TotalCountTextBox
            // 
            TotalCountTextBox.Location = new Point(111, 9);
            TotalCountTextBox.Name = "TotalCountTextBox";
            TotalCountTextBox.ReadOnly = true;
            TotalCountTextBox.Size = new Size(100, 23);
            TotalCountTextBox.StateCommon.Back.Color1 = Color.Yellow;
            TotalCountTextBox.StateCommon.Content.Color1 = Color.Black;
            TotalCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TotalCountTextBox.TabIndex = 4;
            TotalCountTextBox.Text = "0";
            TotalCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // SuccessCountTextBox
            // 
            SuccessCountTextBox.Location = new Point(111, 48);
            SuccessCountTextBox.Name = "SuccessCountTextBox";
            SuccessCountTextBox.ReadOnly = true;
            SuccessCountTextBox.Size = new Size(100, 23);
            SuccessCountTextBox.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 0);
            SuccessCountTextBox.StateCommon.Content.Color1 = Color.Black;
            SuccessCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            SuccessCountTextBox.TabIndex = 5;
            SuccessCountTextBox.Text = "0";
            SuccessCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // FailedCountTextBox
            // 
            FailedCountTextBox.Location = new Point(111, 86);
            FailedCountTextBox.Name = "FailedCountTextBox";
            FailedCountTextBox.ReadOnly = true;
            FailedCountTextBox.Size = new Size(100, 23);
            FailedCountTextBox.StateCommon.Back.Color1 = Color.Red;
            FailedCountTextBox.StateCommon.Content.Color1 = Color.Black;
            FailedCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FailedCountTextBox.TabIndex = 6;
            FailedCountTextBox.Text = "0";
            FailedCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // ProcessedCountTextBox
            // 
            ProcessedCountTextBox.Location = new Point(111, 125);
            ProcessedCountTextBox.Name = "ProcessedCountTextBox";
            ProcessedCountTextBox.ReadOnly = true;
            ProcessedCountTextBox.Size = new Size(100, 23);
            ProcessedCountTextBox.StateCommon.Back.Color1 = Color.Wheat;
            ProcessedCountTextBox.StateCommon.Content.Color1 = Color.Black;
            ProcessedCountTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ProcessedCountTextBox.TabIndex = 7;
            ProcessedCountTextBox.Text = "0";
            ProcessedCountTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Location = new Point(13, 166);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(65, 20);
            kryptonLabel5.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel5.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel5.TabIndex = 8;
            kryptonLabel5.Values.Text = "Số luồng:";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Location = new Point(13, 206);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(93, 20);
            kryptonLabel6.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel6.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel6.TabIndex = 9;
            kryptonLabel6.Values.Text = "Thời gian chờ:";
            // 
            // ThreadNumberUpDown
            // 
            ThreadNumberUpDown.Location = new Point(111, 164);
            ThreadNumberUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadNumberUpDown.Name = "ThreadNumberUpDown";
            ThreadNumberUpDown.Size = new Size(100, 22);
            ThreadNumberUpDown.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 192);
            ThreadNumberUpDown.StateCommon.Content.Color1 = Color.Black;
            ThreadNumberUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadNumberUpDown.TabIndex = 10;
            ThreadNumberUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TimeoutUpDown
            // 
            TimeoutUpDown.Location = new Point(111, 204);
            TimeoutUpDown.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            TimeoutUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            TimeoutUpDown.Name = "TimeoutUpDown";
            TimeoutUpDown.Size = new Size(100, 22);
            TimeoutUpDown.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 192);
            TimeoutUpDown.StateCommon.Content.Color1 = Color.Black;
            TimeoutUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TimeoutUpDown.TabIndex = 11;
            TimeoutUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            TimeoutUpDown.ValueChanged += TimeoutUpDown_ValueChanged;
            // 
            // InputDataBtn
            // 
            InputDataBtn.CornerRoundingRadius = -1F;
            InputDataBtn.Location = new Point(243, 7);
            InputDataBtn.Name = "InputDataBtn";
            InputDataBtn.Size = new Size(119, 25);
            InputDataBtn.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 192);
            InputDataBtn.StateCommon.Back.Color2 = Color.FromArgb(0, 192, 192);
            InputDataBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            InputDataBtn.StateCommon.Content.ShortText.Color2 = Color.Black;
            InputDataBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            InputDataBtn.TabIndex = 12;
            InputDataBtn.Values.Text = "Nhập data";
            InputDataBtn.Click += InputDataBtn_Click;
            // 
            // StartBtn
            // 
            StartBtn.CornerRoundingRadius = -1F;
            StartBtn.Location = new Point(243, 46);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(119, 25);
            StartBtn.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 0);
            StartBtn.StateCommon.Back.Color2 = Color.FromArgb(0, 192, 0);
            StartBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            StartBtn.StateCommon.Content.ShortText.Color2 = Color.Black;
            StartBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StartBtn.TabIndex = 13;
            StartBtn.Values.Text = "Bắt đầu";
            StartBtn.Click += StartBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.CornerRoundingRadius = -1F;
            StopBtn.Enabled = false;
            StopBtn.Location = new Point(243, 84);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(119, 25);
            StopBtn.StateCommon.Back.Color1 = Color.Red;
            StopBtn.StateCommon.Back.Color2 = Color.Red;
            StopBtn.StateCommon.Content.ShortText.Color1 = Color.Black;
            StopBtn.StateCommon.Content.ShortText.Color2 = Color.Black;
            StopBtn.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StopBtn.TabIndex = 14;
            StopBtn.Values.Text = "Dừng lại";
            StopBtn.Click += StopBtn_Click;
            // 
            // StatusTextBox
            // 
            StatusTextBox.Location = new Point(243, 125);
            StatusTextBox.Name = "StatusTextBox";
            StatusTextBox.ReadOnly = true;
            StatusTextBox.Size = new Size(119, 23);
            StatusTextBox.StateActive.Back.Color1 = Color.Yellow;
            StatusTextBox.StateCommon.Content.Color1 = Color.Black;
            StatusTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            StatusTextBox.TabIndex = 15;
            StatusTextBox.Text = "Chưa bắt đầu";
            StatusTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // TopMostCheckBox
            // 
            TopMostCheckBox.Checked = true;
            TopMostCheckBox.CheckState = CheckState.Checked;
            TopMostCheckBox.Location = new Point(244, 164);
            TopMostCheckBox.Name = "TopMostCheckBox";
            TopMostCheckBox.Size = new Size(82, 20);
            TopMostCheckBox.StateCommon.ShortText.Color1 = Color.Black;
            TopMostCheckBox.StateCommon.ShortText.Color2 = Color.Black;
            TopMostCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            TopMostCheckBox.TabIndex = 16;
            TopMostCheckBox.Values.Text = "Ghim APP";
            TopMostCheckBox.CheckedChanged += TopMostCheckBox_CheckedChanged;
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Location = new Point(13, 242);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(97, 20);
            kryptonLabel7.StateCommon.ShortText.Color1 = Color.Black;
            kryptonLabel7.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel7.TabIndex = 17;
            kryptonLabel7.Values.Text = "Link giới thiệu:";
            // 
            // ReferalTextBox
            // 
            ReferalTextBox.Location = new Point(111, 239);
            ReferalTextBox.Name = "ReferalTextBox";
            ReferalTextBox.Size = new Size(251, 23);
            ReferalTextBox.StateCommon.Content.Color1 = Color.Black;
            ReferalTextBox.StateCommon.Content.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            ReferalTextBox.TabIndex = 18;
            ReferalTextBox.TextChanged += ReferalTextBox_TextChanged;
            // 
            // OnlyRootLinkCheckBox
            // 
            OnlyRootLinkCheckBox.Location = new Point(244, 204);
            OnlyRootLinkCheckBox.Name = "OnlyRootLinkCheckBox";
            OnlyRootLinkCheckBox.Size = new Size(125, 20);
            OnlyRootLinkCheckBox.StateCommon.ShortText.Color1 = Color.Black;
            OnlyRootLinkCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            OnlyRootLinkCheckBox.TabIndex = 19;
            OnlyRootLinkCheckBox.Values.Text = "Chỉ dùng link gốc";
            OnlyRootLinkCheckBox.CheckedChanged += OnlyRootLinkCheckBox_CheckedChanged;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 271);
            Controls.Add(OnlyRootLinkCheckBox);
            Controls.Add(ReferalTextBox);
            Controls.Add(kryptonLabel7);
            Controls.Add(TopMostCheckBox);
            Controls.Add(StatusTextBox);
            Controls.Add(StopBtn);
            Controls.Add(StartBtn);
            Controls.Add(InputDataBtn);
            Controls.Add(TimeoutUpDown);
            Controls.Add(ThreadNumberUpDown);
            Controls.Add(kryptonLabel6);
            Controls.Add(kryptonLabel5);
            Controls.Add(ProcessedCountTextBox);
            Controls.Add(FailedCountTextBox);
            Controls.Add(SuccessCountTextBox);
            Controls.Add(TotalCountTextBox);
            Controls.Add(kryptonLabel4);
            Controls.Add(kryptonLabel3);
            Controls.Add(kryptonLabel2);
            Controls.Add(kryptonLabel1);
            MaximumSize = new Size(390, 310);
            MinimumSize = new Size(390, 310);
            Name = "FrmMain";
            Text = "Addonmoney Register - Tele: @lukaxsx";
            ResumeLayout(false);
            PerformLayout();
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
    }
}