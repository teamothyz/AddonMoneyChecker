namespace TelegramSessionChecking
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            SessionDataGridView = new Krypton.Toolkit.KryptonDataGridView();
            SessionName = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            Proxy = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            Status = new Krypton.Toolkit.KryptonDataGridViewTextBoxColumn();
            ThreadNumericUpDown = new Krypton.Toolkit.KryptonNumericUpDown();
            kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            StartButton = new Krypton.Toolkit.KryptonButton();
            StopButton = new Krypton.Toolkit.KryptonButton();
            LoadButton = new Krypton.Toolkit.KryptonButton();
            AddProxyButton = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)SessionDataGridView).BeginInit();
            SuspendLayout();
            // 
            // SessionDataGridView
            // 
            SessionDataGridView.AllowUserToAddRows = false;
            SessionDataGridView.AllowUserToDeleteRows = false;
            SessionDataGridView.AllowUserToOrderColumns = true;
            SessionDataGridView.AllowUserToResizeRows = false;
            SessionDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            SessionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SessionDataGridView.ColumnHeadersHeight = 30;
            SessionDataGridView.Columns.AddRange(new DataGridViewColumn[] { SessionName, Proxy, Status });
            SessionDataGridView.Location = new Point(12, 12);
            SessionDataGridView.Name = "SessionDataGridView";
            SessionDataGridView.RowHeadersWidth = 30;
            SessionDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            SessionDataGridView.RowTemplate.Height = 25;
            SessionDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            SessionDataGridView.Size = new Size(440, 337);
            SessionDataGridView.StateCommon.BackStyle = Krypton.Toolkit.PaletteBackStyle.GridBackgroundList;
            SessionDataGridView.StateCommon.HeaderColumn.Content.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            SessionDataGridView.TabIndex = 0;
            // 
            // SessionName
            // 
            SessionName.DataPropertyName = "Name";
            SessionName.DefaultCellStyle = dataGridViewCellStyle7;
            SessionName.HeaderText = "Tên file";
            SessionName.Name = "SessionName";
            SessionName.ReadOnly = true;
            SessionName.Width = 137;
            // 
            // Proxy
            // 
            Proxy.DataPropertyName = "Proxy";
            Proxy.DefaultCellStyle = dataGridViewCellStyle8;
            Proxy.HeaderText = "Proxy";
            Proxy.Name = "Proxy";
            Proxy.ReadOnly = true;
            Proxy.Width = 136;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.DefaultCellStyle = dataGridViewCellStyle9;
            Status.HeaderText = "Tình trạng";
            Status.Name = "Status";
            Status.ReadOnly = true;
            Status.Width = 137;
            // 
            // ThreadNumericUpDown
            // 
            ThreadNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ThreadNumericUpDown.Location = new Point(554, 162);
            ThreadNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            ThreadNumericUpDown.Name = "ThreadNumericUpDown";
            ThreadNumericUpDown.Size = new Size(98, 24);
            ThreadNumericUpDown.StateCommon.Content.Color1 = Color.Black;
            ThreadNumericUpDown.StateCommon.Content.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            ThreadNumericUpDown.TabIndex = 1;
            ThreadNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kryptonLabel1.Location = new Point(478, 163);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new Size(54, 21);
            kryptonLabel1.StateCommon.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            kryptonLabel1.TabIndex = 2;
            kryptonLabel1.Values.Text = "Luồng:";
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StartButton.CornerRoundingRadius = -1F;
            StartButton.Location = new Point(478, 12);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(174, 46);
            StartButton.StateCommon.Back.Color1 = Color.Lime;
            StartButton.StateCommon.Back.Color2 = Color.FromArgb(0, 64, 0);
            StartButton.StateCommon.Content.ShortText.Color1 = Color.Black;
            StartButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            StartButton.TabIndex = 3;
            StartButton.Values.Text = "Bắt đầu";
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            StopButton.CornerRoundingRadius = -1F;
            StopButton.Enabled = false;
            StopButton.Location = new Point(478, 91);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(174, 46);
            StopButton.StateCommon.Back.Color1 = Color.Red;
            StopButton.StateCommon.Back.Color2 = Color.FromArgb(64, 0, 0);
            StopButton.StateCommon.Content.ShortText.Color1 = Color.Black;
            StopButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            StopButton.TabIndex = 4;
            StopButton.Values.Text = "Dừng lại";
            StopButton.Click += StopButton_Click;
            // 
            // LoadButton
            // 
            LoadButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoadButton.CornerRoundingRadius = -1F;
            LoadButton.Location = new Point(478, 209);
            LoadButton.Name = "LoadButton";
            LoadButton.Size = new Size(174, 46);
            LoadButton.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 192);
            LoadButton.StateCommon.Back.Color2 = Color.FromArgb(0, 0, 64);
            LoadButton.StateCommon.Content.ShortText.Color1 = Color.Black;
            LoadButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            LoadButton.TabIndex = 5;
            LoadButton.Values.Text = "ReLoad Session";
            LoadButton.Click += LoadButton_Click;
            // 
            // AddProxyButton
            // 
            AddProxyButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AddProxyButton.CornerRoundingRadius = -1F;
            AddProxyButton.Location = new Point(478, 280);
            AddProxyButton.Name = "AddProxyButton";
            AddProxyButton.Size = new Size(174, 46);
            AddProxyButton.StateCommon.Back.Color1 = Color.FromArgb(0, 192, 192);
            AddProxyButton.StateCommon.Back.Color2 = Color.FromArgb(0, 0, 64);
            AddProxyButton.StateCommon.Content.ShortText.Color1 = Color.Black;
            AddProxyButton.StateCommon.Content.ShortText.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            AddProxyButton.TabIndex = 6;
            AddProxyButton.Values.Text = "Add Proxy";
            AddProxyButton.Click += AddProxyButton_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(664, 361);
            Controls.Add(AddProxyButton);
            Controls.Add(LoadButton);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Controls.Add(kryptonLabel1);
            Controls.Add(ThreadNumericUpDown);
            Controls.Add(SessionDataGridView);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(680, 400);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Telegram Session Checking - Tele: @lukaxsx";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)SessionDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Krypton.Toolkit.KryptonDataGridView SessionDataGridView;
        private Krypton.Toolkit.KryptonNumericUpDown ThreadNumericUpDown;
        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonButton StartButton;
        private Krypton.Toolkit.KryptonButton StopButton;
        private Krypton.Toolkit.KryptonButton LoadButton;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn SessionName;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Proxy;
        private Krypton.Toolkit.KryptonDataGridViewTextBoxColumn Status;
        private Krypton.Toolkit.KryptonButton AddProxyButton;
    }
}