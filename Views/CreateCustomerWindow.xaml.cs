using favoriete_landen.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace favoriete_landen.Views
{
    /// <summary>
    /// Interaction logic for CreateCustomerWindow.xaml
    /// </summary>
    public partial class CreateCustomerWindow : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Fields
        private readonly FavouriteCountryDB db = new();
        private readonly string serviceDeskBericht = "\n\nNeem contact op met de service desk";
        #endregion

        #region Properties
        private ObservableCollection<Customer> customers = new();
        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set { customers = value; OnPropertyChanged(); }
        }

        private Customer newCustomer = new();
        public Customer NewCustomer
        {
            get { return newCustomer; }
            set { newCustomer = value; OnPropertyChanged(); }
        }

        public CreateCustomerWindow()
        {
            InitializeComponent();

            DataContext = this;
        }
        #endregion

        // Eventhandler van customer add button. Hier wordt een record van de customer tabel toegevoegd.
        private void CreateCustomerClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewCustomer.CustomerName))
            {
                MessageBox.Show("Enter your customer name.");
                return;
            }

            string dbResult = db.CreateCustomer(NewCustomer);
            if (dbResult == FavouriteCountryDB.OK)
            {
                MessageBox.Show($"Customer {NewCustomer.CustomerName} has been created.");
                Close();
            }
            else
            {
                MessageBox.Show($"{dbResult} {serviceDeskBericht}");
            }
        }
    }
}
