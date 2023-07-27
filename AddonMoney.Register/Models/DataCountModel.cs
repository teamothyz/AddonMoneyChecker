using System.ComponentModel;

namespace AddonMoney.Register.Models
{
    public class DataCountModel : INotifyPropertyChanged
    {
        private int _total = 0;
        private int _success = 0;
        private int _failed = 0;
        private int _processed = 0;


        public int Total 
        { 
            get => _total;
            set
            {
                _total = value;
                NotifyChange(nameof(Total));
            }
        }

        public int Success
        {
            get => _success;
            set
            {
                _success = value;
                NotifyChange(nameof(Success));
            }
        }

        public int Failed
        {
            get => _failed;
            set
            {
                _failed = value;
                NotifyChange(nameof(Failed));
            }
        }

        public int Processed
        {
            get => _processed;
            set
            {
                _processed = value;
                NotifyChange(nameof(Processed));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
