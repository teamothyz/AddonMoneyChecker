using AddonMoney.Transfer.Models;
using AddonMoney.Transfer.Services;
using CaptchaResolver;
using CaptchaResolver.Clients;
using ChromeDriverLibrary;
using Serilog;

namespace AddonMoney.Transfer.Windows
{
    public partial class FrmMain : Form
    {
        private int _successCount = 0;
        private int _failedCount = 0;
        private int _threadNum = 2;
        private CancellationTokenSource _tokenSource = new();

        public FrmMain()
        {
            InitializeComponent();
            _2captchaTextBox.Text = KeyHandler.GetKey() ?? string.Empty;
            ActiveControl = kryptonLabel1;
            CaptchaComboBox.SelectedIndex = 0;
            TopMost = true;
        }

        private void ThreadUpDown_ValueChanged(object sender, EventArgs e)
        {
            _threadNum = Convert.ToInt32(ThreadUpDown.Value);
        }

        private void TimeoutUpDown_ValueChanged(object sender, EventArgs e)
        {
            TransferService.Timeout = Convert.ToInt32(TimeoutUpDown.Value);
        }

        private void TopMostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostCheckBox.Checked;
        }

        private async void AccountsInputBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            await Task.Run(() =>
            {
                var dialog = new OpenFileDialog();
                var result = DialogResult.Cancel;
                Invoke(() => result = dialog.ShowDialog(this));
                if (result == DialogResult.OK)
                {
                    var success = DataService.ReadAccounts(dialog.FileName);
                    Invoke(() =>
                    {
                        AccCountTextBox.Text = Account.Accounts.Count.ToString();
                        ProxyCountTextBox.Text = Account.Accounts.Count(acc => acc.Proxy != null).ToString();
                        Invoke(() =>
                        {
                            if (success) MessageBox.Show(this, "Đã đọc dữ liệu xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show(this, "Đã đọc dữ liệu thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    });
                }
            });
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var successAccounts = new List<Account>();
            await Task.Run(async () =>
            {
                try
                {
                    EnableBtn(true);
                    if (MyProxy.Type != ProxyType.None && Account.Accounts.Any(a => a.Proxy == null))
                    {
                        Invoke(() => MessageBox.Show(this, "Phát hiện có account không sử dụng proxy", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }

                    var _2captchaKey = _2captchaTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(_2captchaKey))
                    {
                        Invoke(() => MessageBox.Show(this, "Vui lòng nhập 2captcha API", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }
                    KeyHandler.SaveKey(_2captchaKey);
                    CaptchaV2Client.InitKey(_2captchaKey, "https://addon.money", "6LeuIL4UAAAAAHgT1ir2kCjOaU6F1UAcTmWiFr5M");
                    AnyCaptchaV2Client.InitKey(_2captchaKey, "https://addon.money", "6LeuIL4UAAAAAHgT1ir2kCjOaU6F1UAcTmWiFr5M");

                    Func<CancellationToken, Task<string>> captchaFunc = CaptchaComboBox.SelectedIndex == 0 
                    ? (token) => CaptchaV2Client.GetToken(token) : (token) => AnyCaptchaV2Client.GetToken(token);

                    _tokenSource = new();
                    var sessionName = $"{DateTime.Now:yyyyMMdd.HHmmss}";
                    var tasks = new List<Task>();
                    foreach (var account in Account.Accounts)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            var result = await TransferService.Transfer(account, (int)MinNumericUpDown.Value, captchaFunc, _tokenSource.Token);
                            if (result.Item1)
                            {
                                lock (Account.Accounts)
                                {
                                    successAccounts.Add(account);
                                    _successCount++;
                                }
                            }
                            else
                            {
                                lock (Account.Accounts)
                                {
                                    _failedCount++;
                                }
                            }
                            UpdateProcessedCount();
                            DataService.WriteResult(sessionName, account, result.Item1, result.Item2);
                        }));
                        if (tasks.Count(t => !t.IsCompleted) == _threadNum) await Task.WhenAll(tasks);
                    }
                    if (tasks.Any(t => !t.IsCompleted)) await Task.WhenAll(tasks);
                }
                catch (Exception ex)
                {
                    Log.Error($"Got exception while starting transfer. Error {ex}");
                    Invoke(() => MessageBox.Show(this, $"Lỗi: {ex.Message}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
                finally
                {
                    await Task.Run(() => ChromeDriverInstance.KillAllChromes());
                    successAccounts.ForEach(a => Account.Accounts.Remove(a));
                    EnableBtn(false);
                    Invoke(() =>
                    {
                        AccCountTextBox.Text = Account.Accounts.Count.ToString();
                        ProxyCountTextBox.Text = Account.Accounts.Count(acc => acc.Proxy != null).ToString();
                        MessageBox.Show(this, "Chương trình đã kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    });
                }
            });
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            _tokenSource.Cancel();
            ChromeDriverInstance.KillAllChromes();
        }

        private void UpdateProcessedCount()
        {
            Invoke(() =>
            {
                SuccessTextBox.Text = _successCount.ToString();
                FailedTextBox.Text = _failedCount.ToString();
            });
        }

        private void EnableBtn(bool isRun)
        {
            Invoke(() =>
            {
                if (isRun)
                {
                    StatusTextBox.Text = "Đang chạy";
                    StatusTextBox.StateCommon.Back.Color1 = Color.LimeGreen;
                }
                else
                {
                    StatusTextBox.Text = "Đã dừng";
                    StatusTextBox.StateCommon.Back.Color1 = Color.Tomato;
                }

                CaptchaComboBox.Enabled = !isRun;
                ThreadUpDown.Enabled = !isRun;
                TimeoutUpDown.Enabled = !isRun;
                AccountsInputBtn.Enabled = !isRun;
                StartBtn.Enabled = !isRun;
                _2captchaTextBox.ReadOnly = isRun;
                StopBtn.Enabled = isRun;
                NoneProxyRadioBtn.Enabled = !isRun;
                HTTPProxyRadioBtn.Enabled = !isRun;
                Socks5ProxyRadioBtn.Enabled = !isRun;
                MinNumericUpDown.Enabled = !isRun;
            });
        }

        private void NoneProxyRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            MyProxy.Type = ProxyType.None;
        }

        private void HTTPProxyRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            MyProxy.Type = ProxyType.Http;
        }

        private void Socks5ProxyRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            MyProxy.Type = ProxyType.Socks5;
        }
    }
}
