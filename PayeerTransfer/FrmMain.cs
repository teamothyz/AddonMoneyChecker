using ChromeDriverLibrary;
using PayeerTransfer.Models;
using PayeerTransfer.Services;
using Serilog;
using System.ComponentModel;

namespace PayeerTransfer
{
    public partial class FrmMain : Form
    {
        private readonly BindingList<Account> _accounts = new();
        private CancellationTokenSource _tokenSource = new();
        private DateTime _session = DateTime.Now;
        private string _fileName = string.Empty;
        private readonly CountModel _countModel = new();

        public FrmMain()
        {
            InitializeComponent();
            AccountDataGridView.AutoGenerateColumns = false;
            AccountDataGridView.DataSource = _accounts;

            TotalLabel.DataBindings.Add("Text", _countModel, "Total");
            SuccessLabel.DataBindings.Add("Text", _countModel, "Success");
            FailedLabel.DataBindings.Add("Text", _countModel, "Failed");
            ProcessedLabel.DataBindings.Add("Text", _countModel, "Processed");

            ActiveControl = kryptonLabel1;
        }

        private async void InputButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            var dialog = new OpenFileDialog();
            if (DialogResult.OK == dialog.ShowDialog(this))
            {
                _accounts.Clear();
                _countModel.Set(_accounts.Count);
                _session = DateTime.Now;
                _fileName = Path.GetFileNameWithoutExtension(dialog.FileName);

                var accounts = await Task.Run(() => DataHandler.ReadAccounts(dialog.FileName));
                if (accounts == null)
                {
                    MessageBox.Show(this, "Lỗi đọc file tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (var acc in accounts)
                {
                    _accounts.Add(acc);
                }
                _countModel.Set(_accounts.Count);
                MessageBox.Show(this, "Đọc file tài khoản thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            try
            {
                EnableBtn(false);
                if (string.IsNullOrWhiteSpace(ReceiverTextBox.Text))
                {
                    MessageBox.Show(this, "Vui lòng nhập người nhận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var receiver = ReceiverTextBox.Text.Trim();
                var code = ProtectCodeTextBox.Text;
                var timeout = (int)TimeOutNumericUpDown.Value;
                var totalThread = (int)ThreadNumericUpDown.Value;
                var tasks = new Task[totalThread];
                Array.Fill(tasks, Task.CompletedTask);

                _tokenSource = new();
                _countModel.Set(_accounts.Count);
                foreach (var account in _accounts)
                {
                    if (_tokenSource.IsCancellationRequested) break;

                    if (account.Status == Models.Status.TransferSuccess || account.Status == Models.Status.TransferNotEnough)
                    {
                        _countModel.Success++;
                        _countModel.Processed++;
                        continue;
                    }
                    if (account.Status == Models.Status.LoginWrongInfo)
                    {
                        _countModel.Failed++;
                        _countModel.Processed++;
                        continue;
                    }

                    var token = _tokenSource.Token;
                    var index = Array.FindIndex(tasks, t => t == null || t.IsCompleted);
                    tasks[index] = Task.Run(async () =>
                    {
                        await ChromeServiceClient.StartSending(index, account, receiver, code, timeout, token);
                        DataHandler.SaveAccount(account, _session, _fileName);
                        Invoke(() =>
                        {
                            if (account.Status == Models.Status.TransferSuccess || account.Status == Models.Status.TransferNotEnough)
                            {
                                _countModel.Success++;
                                _countModel.Processed++;
                            }
                            else
                            {
                                _countModel.Failed++;
                                _countModel.Processed++;
                            }
                        });
                    });
                    if (tasks.Count(t => t != null && !t.IsCompleted) == totalThread)
                    {
                        await Task.Run(() => Task.WaitAny(tasks));
                    }
                }
                await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                if (!_tokenSource.IsCancellationRequested)
                {
                    Log.Error($"Start error: {ex}");
                    MessageBox.Show(this, "Chương trình gặp lỗi khi đang chạy", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                await Task.Run(() => ChromeDriverInstance.KillAllChromes());
                EnableBtn(true);
                MessageBox.Show(this, "Chương trình đã dừng lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void StopButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            _tokenSource.Cancel();
            await Task.Run(() => ChromeDriverInstance.KillAllChromes());
        }

        private void TopMostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostCheckBox.Checked;
        }

        private void EnableBtn(bool enable)
        {
            Invoke(() =>
            {
                StartButton.Enabled = enable;
                InputButton.Enabled = enable;

                StopButton.Enabled = !enable;

                ProtectCodeTextBox.ReadOnly = !enable;
                ReceiverTextBox.ReadOnly = !enable;

                ThreadNumericUpDown.Enabled = enable;
                TimeOutNumericUpDown.Enabled = enable;
            });
        }
    }
}