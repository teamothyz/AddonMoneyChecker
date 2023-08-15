using AddonMoney.Client.Models;
using AddonMoney.Client.Services;
using AddonMoney.Data.API;
using ChromeDriverLibrary;
using Serilog;

namespace AddonMoney.Client
{
    public partial class FrmMain : Form
    {
        public static int Timeout { get; private set; } = 30;
        public static int TimeSleep { get; private set; } = 30;

        private CancellationTokenSource CancellationToken = new();
        private readonly List<AddonMoneyService> _services = new();
        public static string ProxyPrefix { get; private set; } = "http://";

        public FrmMain()
        {
            InitializeComponent();
            VPSNameTextBox.Text = HostService.GetHostName();
            HostService.ReadProfileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profile.data"));
            ProfileCountTextBox.Text = ProfileInfo.Profiles.Count.ToString();
            ProxyTypeComboBox.SelectedIndex = 0;

            var config = HostService.GetConfig();
            Timeout = config.Item1;
            TimeSleep = config.Item2;
            TimeoutUpDown.Value = Timeout;
            TimeScanUpDown.Value = TimeSleep;
            Group1TimeUpdown.Value = config.Item3;
            Group2TimeUpdown.Value = config.Item4;

            ActiveControl = kryptonLabel5;
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel5;
            try
            {
                var lines = new HashSet<string>();
                _services.Clear();
                var index = 1;
                foreach (var profile in ProfileInfo.Profiles)
                {
                    _services.Add(new AddonMoneyService(profile, index));
                    index++;
                }
                CancellationToken = new();
                EnableBtn(false);
                if (Group1TimeUpdown.Value >= Group2TimeUpdown.Value)
                {
                    Invoke(() => MessageBox.Show(this, "Thời gian 1 phải bé hơn thời gian 2", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning));
                    return;
                }
                await Task.Run(() =>
                {
                    HostService.SaveProfileInfo();
                    HostService.WriteConfig(Timeout, TimeSleep, (int)Group1TimeUpdown.Value, (int)Group2TimeUpdown.Value);
                });
                if (!_services.Any()) return;
                _ = ProxyService.Check(_services.Select(s => s.ProfileInfo).ToList(), CancellationToken.Token);

                #region Check And Enable Extension Each 15 Minutes
                var nextScan = DateTime.Now;
                var nextEnable = DateTime.Now;
                var oldStart = -1;
                while (!CancellationToken.IsCancellationRequested)
                {
                    var needToScan = nextScan <= DateTime.Now;
                    var needEnable = nextEnable <= DateTime.Now;
                    if (needToScan || needEnable)
                    {
                        nextEnable = DateTime.Now.AddMinutes(15);
                        if (needToScan)
                        {
                            nextScan = DateTime.Now.AddMinutes(TimeSleep);
                        }

                        var now = DateTime.Now;
                        var start = now.Hour >= (int)Group1TimeUpdown.Value && now.Hour < (int)Group2TimeUpdown.Value ? 0 : _services.Count / 2;
                        var end = now.Hour >= (int)Group1TimeUpdown.Value && now.Hour < (int)Group2TimeUpdown.Value ? _services.Count / 2 : _services.Count;

                        if (oldStart != start)
                        {
                            oldStart = start;
                            ChromeDriverInstance.KillAllChromes();
                            for (int i = 0; i < _services.Count; i++)
                            {
                                if (!(start <= i && i < end))
                                {
                                    await _services[i].Close();
                                    await Task.Delay(1000, CancellationToken.Token).ConfigureAwait(false);
                                }
                            }
                        }

                        for (int i = 0; i < _services.Count; i++)
                        {
                            if (start <= i && i < end)
                            {
                                await Run(needToScan, _services[i]).ConfigureAwait(false);
                                await Task.Delay(1000, CancellationToken.Token).ConfigureAwait(false);
                            }
                        }
                    }
                    await Task.Delay(3000, CancellationToken.Token).ConfigureAwait(false);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Invoke(() =>
                {
                    if (CancellationToken.IsCancellationRequested) MessageBox.Show(this, "Bạn đã dừng chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else MessageBox.Show(this, $"Có lỗi xảy ra: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
            }
            finally
            {
                EnableBtn(true);
                Invoke(() =>
                {
                    MessageBox.Show(this, "Chương trình đã dừng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                });
            }
        }

        private async Task Run(bool needToScan, AddonMoneyService service)
        {
            try
            {
                var account = await Task.Run(() => service.ScanInfo(needToScan, CancellationToken.Token)).ConfigureAwait(false);
                if (account.Success)
                {
                    var balanceRq = new UpdateBalanceRequest
                    {
                        Id = account.Id,
                        Balance = account.Balance,
                        Name = account.Name,
                        TodayEarn = account.TodayEarn,
                        Profile = account.Profile,
                        VPS = HostService.GetHostName(),
                        EarningLevel = account.EarningLevel,
                        Email = account.Email
                    };
                    await ApiService.SendBalance(balanceRq).ConfigureAwait(false);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception when running scan service for {service.ProfileName}.", ex);
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel5;
            CancellationToken.Cancel();
            ChromeDriverInstance.KillAllChromes();
        }

        private void EnableBtn(bool enable)
        {
            Invoke(() =>
            {
                StartBtn.Enabled = enable;
                ProxyTypeComboBox.Enabled = enable;
                StopBtn.Enabled = !enable;

                TimeoutUpDown.Enabled = enable;
                Group1TimeUpdown.Enabled = enable;
                Group2TimeUpdown.Enabled = enable;
                TimeScanUpDown.Enabled = enable;
                DataInputBtn.Enabled = enable;

                RunStatusTextBox.Text = enable ? "Đã dừng" : "Đang chạy";
                RunStatusTextBox.StateCommon.Back.Color1 = enable ? Color.FromArgb(255, 128, 128) : Color.GreenYellow;
            });
        }

        private void TimeoutUpDown_ValueChanged(object sender, EventArgs e)
        {
            Timeout = (int)TimeoutUpDown.Value;
        }

        private void SleepTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            TimeSleep = (int)TimeScanUpDown.Value;
        }

        private void TopMostCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostCheckBtn.Checked;
        }

        private void VPSNameTextBox_TextChanged(object sender, EventArgs e)
        {
            HostService.SetHost(VPSNameTextBox.Text);
        }

        private void ProxyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProxyTypeComboBox.SelectedIndex == 1)
            {
                ProxyPrefix = "socks5://";
            }
            else
            {
                ProxyPrefix = "http://";
            }
        }

        private async void DataInputBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                await Task.Run(() =>
                {
                    var success = HostService.ReadProfileInfo(dialog.FileName);
                    if (success)
                    {
                        Invoke(() =>
                        {
                            ProfileCountTextBox.Text = ProfileInfo.Profiles.Count.ToString();
                            MessageBox.Show(this, "Đọc dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        });
                    }
                    else
                    {
                        Invoke(() =>
                        {
                            ProfileCountTextBox.Text = ProfileInfo.Profiles.Count.ToString();
                            MessageBox.Show(this, "Đọc dữ liệu thất bại. Kiểm tra lại format", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        });
                    }
                });
            }
        }
    }
}
