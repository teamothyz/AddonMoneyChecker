using AddonMoney.Client.Services;
using AddonMoney.Data.API;
using Serilog;

namespace AddonMoney.Client
{
    public partial class FrmMain : Form
    {
        public static int Timeout { get; private set; } = 30;
        public static int TimeSleep { get; private set; } = 30;

        private CancellationTokenSource CancellationToken = null!;
        private readonly List<AddonMoneyService> _services = new();

        public FrmMain()
        {
            InitializeComponent();
            ActiveControl = kryptonLabel5;
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel5;
            try
            {
                var lines = new HashSet<string>();
                _services.Clear();
                foreach (var line in ProfilesTextBox.Lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    lines.Add(line);
                    _services.Add(new AddonMoneyService(line));
                }
                ProfilesTextBox.Lines = lines.ToArray();
                CancellationToken = new();
                EnableBtn(false);

                while (!CancellationToken.IsCancellationRequested)
                {
                    var tasks = new List<Task>();
                    var now = GetGMT7Now();
                    var start = now.Hour >= 3 && now.Hour < 14 ? 0 : _services.Count / 2;
                    var end = now.Hour >= 3 && now.Hour < 14 ? _services.Count / 2 : _services.Count;
                    for (int i = start; i < end; i++)
                    {
                        tasks.Add(Run(_services[i]));
                    }
                    await Task.WhenAll(tasks);
                    tasks.Clear();
                    await Task.Delay(1000);
                }
            }
            catch (Exception ex)
            {
                if (CancellationToken.IsCancellationRequested) MessageBox.Show(this, "Bạn đã dừng chương trình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else MessageBox.Show(this, $"Có lỗi xảy ra: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                EnableBtn(true);
                MessageBox.Show(this, "Chương trình đã dừng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task Run(AddonMoneyService service)
        {
            try
            {
                var account = await Task.Run(async () => await service.ScanInfo(CancellationToken.Token));
                if (account == null) return;

                if (!account.Success)
                {
                    var errRq = new UpdateErrorRequest
                    {
                        Host = HostService.GetHostName(),
                        Message = account.ErrorMsg
                    };
                    await ApiService.SendError(errRq);
                }
                else
                {
                    var balanceRq = new UpdateBalanceRequest
                    {
                        Id = account.Id,
                        Balance = account.Balance,
                        Name= account.Name,
                        TodayEarn = account.TodayEarn,
                        Profile = account.Profile
                    };
                    await ApiService.SendBalance(balanceRq);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Got exception when running scan service for {service.Profile}.", ex);
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel5;
            CancellationToken.Cancel();
        }

        private void EnableBtn(bool enable)
        {
            Invoke(() =>
            {
                StartBtn.Enabled = enable;
                StopBtn.Enabled = !enable;

                ProfilesTextBox.Enabled = enable;
                SleepTimeUpDown.Enabled = enable;

                RunStatusTextBox.Text = enable ? "Đã dừng" : "Đang chạy";
                RunStatusTextBox.StateCommon.Back.Color1 = enable ? Color.FromArgb(255, 128, 128) : Color.GreenYellow;
            });
        }

        private void TimeoutUpDown_ValueChanged(object sender, EventArgs e)
        {
            Timeout = (int)TimeoutUpDown.Value;
        }

        private void ProfilesTextBox_TextChanged(object sender, EventArgs e)
        {
            ProfileCountTextBox.Text = ProfilesTextBox.Lines.Count(line => !string.IsNullOrWhiteSpace(line)).ToString();
        }

        public static DateTime GetGMT7Now()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo gmt7TimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(utcNow, gmt7TimeZone);
        }

        private void SleepTimeUpDown_ValueChanged(object sender, EventArgs e)
        {
            TimeSleep = (int)SleepTimeUpDown.Value;
        }

        private void TopMostCheckBtn_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostCheckBtn.Checked;
        }
    }
}
