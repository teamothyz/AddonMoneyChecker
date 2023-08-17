using AddonMoney.Register.Models;
using AddonMoney.Register.Services;
using ChromeDriverLibrary;
using Serilog;

namespace AddonMoney.Register.Windows
{
    public partial class FrmMain : Form
    {
        public static string ReferLinkRoot { get; private set; } = string.Empty;
        public static string ReferLinkFirst { get; set; } = string.Empty;
        public static string ReferLinkSecond { get; set; } = string.Empty;
        public static bool OnlyRootLink { get; private set; } = false;

        private CancellationTokenSource _cancelSource = new();
        private readonly DataCountModel _dataCount = new();

        public FrmMain()
        {
            InitializeComponent();
            ProxyComboBox.SelectedIndex = 0;
            TotalCountTextBox.DataBindings.Add("Text", _dataCount, "Total");
            SuccessCountTextBox.DataBindings.Add("Text", _dataCount, "Success");
            FailedCountTextBox.DataBindings.Add("Text", _dataCount, "Failed");
            ProcessedCountTextBox.DataBindings.Add("Text", _dataCount, "Processed");
            ActiveControl = kryptonLabel1;
        }

        private void TimeoutUpDown_ValueChanged(object sender, EventArgs e)
        {
            RegisterService.Timeout = Convert.ToInt32(TimeoutUpDown.Value);
        }

        private void TopMostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostCheckBox.Checked;
        }

        private async void InputDataBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                await Task.Run(() =>
                {
                    var success = DataService.ReadAccounts(dialog.FileName);
                    if (success)
                    {
                        Invoke(() =>
                        {
                            _dataCount.Total = Account.Accounts.Count;
                            _dataCount.Success = 0;
                            _dataCount.Failed = 0;
                            _dataCount.Processed = 0;
                            MessageBox.Show(this, "Đọc dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                    else
                    {
                        Invoke(() =>
                        {
                            _dataCount.Total = Account.Accounts.Count;
                            _dataCount.Success = 0;
                            _dataCount.Failed = 0;
                            _dataCount.Processed = 0;
                            MessageBox.Show(this, "Đọc dữ liệu thất bại. Kiểm tra lại format", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        });
                    }
                });
            }
        }

        public void SuccessCallBack()
        {
            Invoke(() =>
            {
                _dataCount.Success++;
                _dataCount.Processed++;
            });
        }

        public void FailedCallBack()
        {
            Invoke(() =>
            {
                _dataCount.Failed++;
                _dataCount.Processed++;
            });
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            EnableBtn(false);
            try
            {
                await Task.Run(async () =>
                {
                    _cancelSource = new();
                    RegisterService.StartTime = DateTime.Now;
                    RegisterService.RegistedAccount = 0;
                    RegisterService.Index = 0;
                    var tasks = new List<Task>();
                    for (var i = 0; i < (int)ThreadNumberUpDown.Value; i++)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            await RegisterService.StartRegister(SuccessCallBack, FailedCallBack, _cancelSource.Token);
                        }));
                    }
                    await Task.WhenAll(tasks);
                });
            }
            catch (Exception ex)
            {
                Invoke(() => MessageBox.Show(this, "Chương trình gặp lỗi", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error));
                Log.Error($"Got exception while start to register. Error: {ex}");
            }
            finally
            {
                EnableBtn(true);
                Invoke(() => MessageBox.Show(this, "Chương trình đã dừng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
            }
        }

        private void EnableBtn(bool enable)
        {
            Invoke(() =>
            {
                InputDataBtn.Enabled = enable;
                StartBtn.Enabled = enable;
                ThreadNumberUpDown.Enabled = enable;
                TimeoutUpDown.Enabled = enable;
                ReferalTextBox.Enabled = enable;
                OnlyRootLinkCheckBox.Enabled = enable;
                ProxyComboBox.Enabled = enable;

                StopBtn.Enabled = !enable;

                StatusTextBox.Text = enable ? "Đã dừng" : "Đang chạy";
                StatusTextBox.StateActive.Back.Color1 = enable ? Color.Red : Color.Green;
            });
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            _cancelSource.Cancel();
            ChromeDriverInstance.KillAllChromes();
        }

        private void OnlyRootLinkCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnlyRootLink = OnlyRootLinkCheckBox.Checked;
        }

        private void ReferalTextBox_TextChanged(object sender, EventArgs e)
        {
            ReferLinkRoot = ReferalTextBox.Text;
        }

        private void ProxyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProxyComboBox.SelectedIndex == 1) MyProxy.Type = ProxyType.Socks5;
            else MyProxy.Type = ProxyType.Http;
        }
    }
}
