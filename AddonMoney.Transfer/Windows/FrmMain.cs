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
            ProfilesTextBox.Lines = DataService.ReadUserDataDirs();
            ActiveControl = kryptonLabel1;
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
            await Task.Run(async () =>
            {
                try
                {
                    EnableBtn(true);
                    if (MyProxy.Type != ProxyType.None && MyProxy.Proxies.Count == 0)
                    {
                        Invoke(() => MessageBox.Show(this, "Vui lòng nhập proxies", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }

                    var _2captchaKey = _2captchaTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(_2captchaKey))
                    {
                        Invoke(() => MessageBox.Show(this, "Vui lòng nhập 2captcha API", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }
                    KeyHandler.SaveKey(_2captchaKey);

                    var lines = new HashSet<string>();
                    var profiles = new List<DriverProfile>();
                    foreach (var line in ProfilesTextBox.Lines)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        lines.Add(line);
                        profiles.Add(new DriverProfile(line));
                    }
                    ProfilesTextBox.Lines = lines.ToArray();
                    DataService.WriteUserDataDirs(lines.ToArray());
                    CaptchaV2Client.InitKey(_2captchaKey, "https://addon.money", "6LeuIL4UAAAAAHgT1ir2kCjOaU6F1UAcTmWiFr5M");

                    _tokenSource = new();
                    var sessionName = $"{DateTime.Now:yyyyMMdd.HHmmss}";
                    var tasks = new List<Task>();
                    foreach (var profile in profiles)
                    {
                        tasks.Add(Task.Run(async () =>
                        {
                            var result = await TransferService.Transfer(profile, _tokenSource.Token);
                            if (result.Item1)
                            {
                                _successCount++;
                            }
                            else
                            {
                                _failedCount++;
                            }
                            UpdateProcessedCount();
                            DataService.WriteResult(sessionName, profile, result.Item1, result.Item2);
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
                    Invoke(() => MessageBox.Show(this, "Chương trình đã kết thúc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information));
                    EnableBtn(false);
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

                ThreadUpDown.Enabled = !isRun;
                TimeoutUpDown.Enabled = !isRun;
                AccountsInputBtn.Enabled = !isRun;
                StartBtn.Enabled = !isRun;
                _2captchaTextBox.ReadOnly = isRun;
                StopBtn.Enabled = isRun;
                ProfilesTextBox.ReadOnly = isRun;
                ProxyInputBtn.Enabled = !isRun;
                NoneProxyRadioBtn.Enabled = !isRun;
                HTTPProxyRadioBtn.Enabled = !isRun;
                Socks5ProxyRadioBtn.Enabled = !isRun;
            });
        }

        private void ProfilesTextBox_TextChanged(object sender, EventArgs e)
        {
            ProCountTextBox.Text = ProfilesTextBox.Lines.Length.ToString();
        }

        private async void ProxyInputBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            await Task.Run(() =>
            {
                var dialog = new OpenFileDialog();
                var result = DialogResult.Cancel;
                Invoke(() => result = dialog.ShowDialog(this));
                if (result == DialogResult.OK)
                {
                    var success = DataService.ReadProxies(dialog.FileName);
                    Invoke(() =>
                    {
                        ProxyCountTextBox.Text = MyProxy.Proxies.Count.ToString();
                        Invoke(() =>
                        {
                            if (success) MessageBox.Show(this, "Đã đọc proxies xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else MessageBox.Show(this, "Đã đọc proxies thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    });
                }
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
