using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace favoriete_landen.Models
{
    public class Customer : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        private int customerId;
        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; OnPropertyChanged(); }
        }

        private string? customerName = null!;
        public string? CustomerName
        {
            get { return customerName; }
            set { customerName = value; OnPropertyChanged(); }
        }
    }
}
