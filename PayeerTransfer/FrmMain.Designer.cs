namespace PayeerTransfer
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            AccountDataGridView = new Krypton.Toolkit.KryptonDataGridView();
            STT = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            Username = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            Password = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            Status = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            Progress = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            InputButton = new Krypton.Toolkit.KryptonButton();
            StartButton = new Krypton.Toolkit.KryptonButton();
            StopButton = new Krypton.Toolkit.KryptonButton();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            ReceiverTextBox = new Krypton.Toolkit.KryptonTextBox();
            ProtectCodeTextBox = new Krypton.Toolkit.KryptonTextBox();
            TopMostCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            ThreadNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            TimeOutNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel6 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            kryptonLabel8 = new Krypton.Toolkit.KryptonLabel();
            TotalLabel = new Krypton.Toolkit.KryptonLabel();
            SuccessLabel = new Krypton.Toolkit.KryptonLabel();
            FailedLabel = new Krypton.Toolkit.KryptonLabel();
            ProcessedLabel = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)AccountDataGridView).BeginInit();
            SuspendLayout();
            // 
            // AccountDataGridView
            // 
            AccountDataGridView.AllowUserToAddRows = false;
            AccountDataGridView.AllowUserToDeleteRows = false;
            AccountDataGridView.AllowUserToOrderColumns = true;
            AccountDataGridView.AllowUserToResizeRows = false;
            AccountDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AccountDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AccountDataGridView.ColumnHeadersHeight = 28;
            AccountDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            AccountDataGridView.Columns.AddRange(new DataGridViewColumn[] { STT, Username, Password, Status, Progress });
            AccountDataGridView.Location = new Point(12, 12);
            AccountDataGridView.Name = "AccountDataGridView";
            AccountDataGridView.RowTemplate.Height = 25;
            AccountDataGridView.Size = new Size(655, 411);
            AccountDataGridView.TabIndex = 0;
            // 
            // STT
            // 
            STT.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            STT.DataPropertyName = "Index";
            STT.DefaultCellStyle = dataGridViewCellStyle1;
            STT.FillWeight = 50F;
            STT.HeaderText = "STT";
            STT.MinimumWidth = 50;
            STT.Name = "STT";
            STT.ReadOnly = true;
            STT.Width = 50;
            // 
            // Username
            // 
            Username.DataPropertyName = "Username";
            Username.DefaultCellStyle = dataGridViewCellStyle2;
            Username.HeaderText = "Username";
            Username.Name = "Username";
            Username.ReadOnly = true;
            Username.Width = 141;
            // 
            // Password
            // 
            Password.DataPropertyName = "Password";
            Password.DefaultCellStyle = dataGridViewCellStyle3;
            Password.HeaderText = "Password";
            Password.Name = "Password";
            Password.ReadOnly = true;
            Password.Width = 141;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.DefaultCellStyle = dataGridViewCellStyle4;
            Status.HeaderText = "Status";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 141;
            // 
            // Progress
            // 
            Progress.DataPropertyName = "Progress";
            Progress.DefaultCellStyle = dataGridViewCellStyle5;
            Progress.HeaderText = "Progress";
            Progress.Name = "Progress";
            Progress.ReadOnly = true;
            Progress.Width = 141;
            // 
            // InputButton
            // 
            InputButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            InputButton.CornerRoundingRadius = -1F;
            InputButton.Location = new Point(712, 12);
            InputButton.Name = "InputButton";
            InputButton.Size = new Size(136, 44);
            InputButton.StateCommon.Back.Color1 = Color.SpringGreen;
            InputButton.StateCommon.Back.Color2 = Color.SpringGreen;
            InputButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            InputButton.TabIndex = 1;
            InputButton.Values.Text = "Nhập data";
            InputButton.Click += InputButton_Click;
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartButton.CornerRoundingRadius = -1F;
            StartButton.Location = new Point(712, 94);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(136, 44);
            StartButton.StateCommon.Back.Color1 = Color.Lime;
            StartButton.StateCommon.Back.Color2 = Color.Lime;
            StartButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            StartButton.TabIndex = 2;
            StartButton.Values.Text = "Bắt đầu chuyển";
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StopButton.CornerRoundingRadius = -1F;
            StopButton.Enabled = false;
            StopButton.Location = new Point(712, 182);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(136, 44);
            StopButton.StateCommon.Back.Color1 = Color.FromArgb(255, 128, 128);
            StopButton.StateCommon.Back.Color2 = Color.FromArgb(255, 128, 128);
            StopButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            StopButton.TabIndex = 3;
            StopButton.Values.Text = "Dừng lại";
            StopButton.Click += StopButton_Click;
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            kryptonLabel1.Location = new Point(12, 441);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(71, 19);
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 4;
            kryptonLabel1.Values.Text = "Chuyển tới:";
            // 
            // kryptonLabel2
            // 
            kryptonLabel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            kryptonLabel2.Location = new Point(390, 441);
            kryptonLabel2.Name = "kryptonLabel2";
            kryptonLabel2.Size = new Size(69, 19);
            kryptonLabel2.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel2.TabIndex = 5;
            kryptonLabel2.Values.Text = "Mã bảo vệ:";
            // 
            // ReceiverTextBox
            // 
            ReceiverTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ReceiverTextBox.Location = new Point(90, 438);
            ReceiverTextBox.Name = "ReceiverTextBox";
            ReceiverTextBox.Size = new Size(217, 23);
            ReceiverTextBox.TabIndex = 6;
            // 
            // ProtectCodeTextBox
            // 
            ProtectCodeTextBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProtectCodeTextBox.Location = new Point(467, 438);
            ProtectCodeTextBox.Name = "ProtectCodeTextBox";
            ProtectCodeTextBox.Size = new Size(200, 23);
            ProtectCodeTextBox.TabIndex = 7;
            // 
            // TopMostCheckBox
            // 
            TopMostCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TopMostCheckBox.Location = new Point(712, 369);
            TopMostCheckBox.Name = "TopMostCheckBox";
            TopMostCheckBox.Size = new Size(85, 21);
            TopMostCheckBox.StateCommon.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            TopMostCheckBox.TabIndex = 8;
            TopMostCheckBox.Values.Text = "Ghim app";
            TopMostCheckBox.CheckedChanged += TopMostCheckBox_CheckedChanged;
            // 
            // kryptonLabel3
            // 
            kryptonLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kryptonLabel3.Location = new Point(712, 253);
            kryptonLabel3.Name = "kryptonLabel3";
            kryptonLabel3.Size = new Size(61, 19);
            kryptonLabel3.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel3.TabIndex = 9;
            kryptonLabel3.Values.Text = "Số luồng:";
            // 
            // ThreadNumericUpDown
            // 
            ThreadNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ThreadNumericUpDown.Location = new Point(712, 278);
            ThreadNumericUpDown.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            ThreadNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadNumericUpDown.Name = "ThreadNumericUpDown";
            ThreadNumericUpDown.Size = new Size(120, 22);
            ThreadNumericUpDown.TabIndex = 10;
            ThreadNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // TimeOutNumericUpDown
            // 
            TimeOutNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TimeOutNumericUpDown.Location = new Point(712, 331);
            TimeOutNumericUpDown.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            TimeOutNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            TimeOutNumericUpDown.Name = "TimeOutNumericUpDown";
            TimeOutNumericUpDown.Size = new Size(120, 22);
            TimeOutNumericUpDown.TabIndex = 12;
            TimeOutNumericUpDown.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // kryptonLabel4
            // 
            kryptonLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kryptonLabel4.Location = new Point(712, 306);
            kryptonLabel4.Name = "kryptonLabel4";
            kryptonLabel4.Size = new Size(58, 19);
            kryptonLabel4.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel4.TabIndex = 11;
            kryptonLabel4.Values.Text = "Timeout:";
            // 
            // kryptonLabel5
            // 
            kryptonLabel5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            kryptonLabel5.Location = new Point(12, 481);
            kryptonLabel5.Name = "kryptonLabel5";
            kryptonLabel5.Size = new Size(91, 19);
            kryptonLabel5.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel5.TabIndex = 13;
            kryptonLabel5.Values.Text = "Tổng accounts:";
            // 
            // kryptonLabel6
            // 
            kryptonLabel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            kryptonLabel6.Location = new Point(206, 481);
            kryptonLabel6.Name = "kryptonLabel6";
            kryptonLabel6.Size = new Size(76, 19);
            kryptonLabel6.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel6.TabIndex = 14;
            kryptonLabel6.Values.Text = "Thành công:";
            // 
            // kryptonLabel7
            // 
            kryptonLabel7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            kryptonLabel7.Location = new Point(357, 481);
            kryptonLabel7.Name = "kryptonLabel7";
            kryptonLabel7.Size = new Size(57, 19);
            kryptonLabel7.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel7.TabIndex = 15;
            kryptonLabel7.Values.Text = "Thất bại:";
            // 
            // kryptonLabel8
            // 
            kryptonLabel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            kryptonLabel8.Location = new Point(522, 481);
            kryptonLabel8.Name = "kryptonLabel8";
            kryptonLabel8.Size = new Size(55, 19);
            kryptonLabel8.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel8.TabIndex = 16;
            kryptonLabel8.Values.Text = "Đã chạy:";
            // 
            // TotalLabel
            // 
            TotalLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            TotalLabel.Location = new Point(109, 481);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(17, 19);
            TotalLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            TotalLabel.TabIndex = 17;
            TotalLabel.Values.Text = "0";
            // 
            // SuccessLabel
            // 
            SuccessLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            SuccessLabel.Location = new Point(288, 481);
            SuccessLabel.Name = "SuccessLabel";
            SuccessLabel.Size = new Size(17, 19);
            SuccessLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            SuccessLabel.TabIndex = 18;
            SuccessLabel.Values.Text = "0";
            // 
            // FailedLabel
            // 
            FailedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FailedLabel.Location = new Point(420, 481);
            FailedLabel.Name = "FailedLabel";
            FailedLabel.Size = new Size(17, 19);
            FailedLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            FailedLabel.TabIndex = 19;
            FailedLabel.Values.Text = "0";
            // 
            // ProcessedLabel
            // 
            ProcessedLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ProcessedLabel.Location = new Point(583, 481);
            ProcessedLabel.Name = "ProcessedLabel";
            ProcessedLabel.Size = new Size(17, 19);
            ProcessedLabel.StateCommon.ShortText.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            ProcessedLabel.TabIndex = 20;
            ProcessedLabel.Values.Text = "0";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 512);
            Controls.Add(ProcessedLabel);
            Controls.Add(FailedLabel);
            Controls.Add(SuccessLabel);
            Controls.Add(TotalLabel);
            Controls.Add(kryptonLabel8);
            Controls.Add(kryptonLabel7);
            Controls.Add(kryptonLabel6);
            Controls.Add(kryptonLabel5);
            Controls.Add(TimeOutNumericUpDown);
            Controls.Add(kryptonLabel4);
            Controls.Add(ThreadNumericUpDown);
            Controls.Add(kryptonLabel3);
            Controls.Add(TopMostCheckBox);
            Controls.Add(ProtectCodeTextBox);
            Controls.Add(ReceiverTextBox);
            Controls.Add(kryptonLabel2);
            Controls.Add(kryptonLabel1);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Controls.Add(InputButton);
            Controls.Add(AccountDataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "Payeer Transfer Tool - Tele: @lukaxsx";
            ((System.ComponentModel.ISupportInitialize)AccountDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView AccountDataGridView;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn STT;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Username;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Password;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Status;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Progress;
        private Krypton.Toolkit.KryptonButton InputButton;
        private Krypton.Toolkit.KryptonButton StartButton;
        private Krypton.Toolkit.KryptonButton StopButton;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonTextBox ReceiverTextBox;
        private Krypton.Toolkit.KryptonTextBox ProtectCodeTextBox;
        private Krypton.Toolkit.KryptonCheckBox TopMostCheckBox;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonNumericUpDown ThreadNumericUpDown;
        private Krypton.Toolkit.KryptonNumericUpDown TimeOutNumericUpDown;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonLabel kryptonLabel6;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonLabel kryptonLabel8;
        private Krypton.Toolkit.KryptonLabel TotalLabel;
        private Krypton.Toolkit.KryptonLabel SuccessLabel;
        private Krypton.Toolkit.KryptonLabel FailedLabel;
        private Krypton.Toolkit.KryptonLabel ProcessedLabel;
    }
}