using System.ComponentModel;

namespace TelegramSessionChecking
{
    public partial class FrmMain : Form
    {
        private readonly BindingList<SessionFile> _sessions = new();
        private readonly Dictionary<string, string> _proxies = new();
        private CancellationTokenSource _tokenSrc = new();
        private static readonly string _appId = "21254074";
        private static readonly string _appHash = "471098b0f3cb8b0914e7e1191899a2e13";
        private DateTime _sessionTime = DateTime.Now;

        public FrmMain()
        {
            InitializeComponent();
            SessionDataGridView.AutoGenerateColumns = false;
            SessionDataGridView.DataSource = _sessions;
            ActiveControl = kryptonLabel1;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            _sessions.Clear();
            _sessionTime = DateTime.Now;
            try
            {
                var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sessions");
                var files = Directory.GetFiles(folder);
                foreach (var file in files)
                {
                    _sessions.Add(new SessionFile
                    {
                        FilePath = file
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Lỗi load danh sách file sessions: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _sessions.Clear();
            }
            finally
            {
                AddProxyToSession();
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            _tokenSrc.Cancel();
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            LoadButton.Enabled = false;
            AddProxyButton.Enabled = false;
            ThreadNumericUpDown.Enabled = false;
            try
            {
                var totalThreads = (int)ThreadNumericUpDown.Value;
                var tasks = new List<Task>();
                _tokenSrc = new();
                foreach (var session in _sessions)
                {
                    if (_tokenSrc.IsCancellationRequested) break;
                    if (session.Live != null) continue;
                    var token = _tokenSrc.Token;
                    tasks.Add(Task.Run(() => session.Check(_appId, _appHash, _sessionTime, token)));
                    if (tasks.Count(t => !t.IsCompleted) >= totalThreads)
                    {
                        await Task.WhenAny(tasks);
                        tasks.RemoveAll(t => t.IsCompleted);
                    };
                }
                if (tasks.Any()) await Task.WhenAll(tasks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Lỗi chạy chương trình: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                StartButton.Enabled = true;
                StopButton.Enabled = false;
                LoadButton.Enabled = true;
                AddProxyButton.Enabled = true;
                ThreadNumericUpDown.Enabled = true;
                MessageBox.Show(this, "Chương trình đã chạy xong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddProxyButton_Click(object sender, EventArgs e)
        {
            ActiveControl = kryptonLabel1;
            try
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != DialogResult.OK) return;

                _proxies.Clear();
                using var reader = new StreamReader(dialog.FileName);
                while (reader.Peek() != -1)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    var details = line.Split("|");
                    _proxies[details[1]] = details[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Lỗi đọc file chứa proxy: {ex.Message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _proxies.Clear();
            }
            finally
            {
                AddProxyToSession();
            }
        }

        private void AddProxyToSession()
        {
            foreach (var session in _sessions)
            {
                _proxies.TryGetValue(session.Name, out string? proxy);
                session.Proxy = proxy ?? string.Empty;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadButton_Click(sender, e);
        }
    }
}