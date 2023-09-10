using System.ComponentModel;

namespace PayeerTransfer.Models
{
    public class Account : INotifyPropertyChanged
    {
        public static int AccountIndex { get; set; } = 1;
        public static readonly object AccountIndexLocker = new();

        public int Index { get; set; }

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        private Status _status = Status.None;
        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                NotifyChanged(nameof(Status));
            }
        }

        private string _progress = string.Empty;
        public string Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                NotifyChanged(nameof(Progress));
            }
        }

        public Account()
        {
            lock (AccountIndexLocker)
            {
                Index = AccountIndex;
                AccountIndex++;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum Status
    {
        None = 0,

        LoginWrongInfo = 1,
        LoginException = 2,
        LoginSuccess = 3,

        TransferNotEnough = 4,
        TransferError = 5,
        TransferSuccess = 6,

        Error = -1
    }
}
