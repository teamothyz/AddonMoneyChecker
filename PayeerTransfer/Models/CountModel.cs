using System.ComponentModel;

namespace PayeerTransfer.Models
{
    public class CountModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int _total = 0;
        public int Total
        {
            get => _total;
            set
            {
                _total = value;
                NotifyChanged(nameof(Total));
            }
        }

        private int _sucess = 0;
        public int Success
        {
            get => _sucess;
            set
            {
                _sucess = value;
                NotifyChanged(nameof(Success));
            }
        }

        private int _failed = 0;
        public int Failed
        {
            get => _failed;
            set
            {
                _failed = value;
                NotifyChanged(nameof(Failed));
            }
        }

        private int _processed = 0;
        public int Processed
        {
            get => _processed;
            set
            {
                _processed = value;
                NotifyChanged(nameof(Processed));
            }
        }

        public void Set(int total)
        {
            Total = total;
            Success = 0;
            Failed = 0;
            Processed = 0;
        }

        private void NotifyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
