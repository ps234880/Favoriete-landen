using favoriete_landen.Models;
using favoriete_landen.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace favoriete_landen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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

        // Hier wordt de record van favoriete landen opgehaald wanneer er een customer id is geslecteerd.
        private Customer? selectedCustomer;
        public Customer? SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                FavouriteCountries.Clear();
                selectedCustomer = value;

                if (selectedCustomer != null)
                {
                    db.GetFavouriteCountries(FavouriteCountries, selectedCustomer.CustomerId);
                }
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Country> countries = new();
        public ObservableCollection<Country> Countries
        {
            get { return countries; }
            set { countries = value; OnPropertyChanged(); }
        }

        private Country? selectedCountry;
        public Country? SelectedCountry
        {
            get { return selectedCountry; }
            set { selectedCountry = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Country> favouriteCountries = new();
        public ObservableCollection<Country> FavouriteCountries
        {
            get { return favouriteCountries; }
            set { favouriteCountries = value; OnPropertyChanged(); }
        }

        private Country? selectedFavouriteCountry;

        public Country? SelectedFavouriteCountry
        {
            get { return selectedFavouriteCountry; }
            set { selectedFavouriteCountry = value; OnPropertyChanged(); }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            PopulateCustomers();
            PopulateCountries();
            PopulateFavouriteCountries();
            DataContext = this;
        }

        private void PopulateCustomers()
        {
            Customers.Clear();
            string dbResult = db.GetCustomers(Customers);
            if (dbResult != FavouriteCountryDB.OK)
            {
                MessageBox.Show($"{dbResult} {serviceDeskBericht}");
            }
        }

        private void PopulateCountries()
        {
            Countries.Clear();
            string dbResult = db.GetCountries(Countries);
            if (dbResult != FavouriteCountryDB.OK)
            {
                MessageBox.Show($"{dbResult} {serviceDeskBericht}");
            }
        }

        // Vult alleen als er een customerId is geslecteerd
        private void PopulateFavouriteCountries()
        {
            FavouriteCountries.Clear();
            if (selectedCustomer != null)
            {
                string dbResult = db.GetFavouriteCountries(FavouriteCountries, selectedCustomer.CustomerId);
                if (dbResult != FavouriteCountryDB.OK)
                {
                    MessageBox.Show($"{dbResult} {serviceDeskBericht}");
                }
            }
        }

        private void CreateCustomer(object sender, RoutedEventArgs e)
        {
            CreateCustomerWindow createCustomerWindow = new();
            createCustomerWindow.ShowDialog();
            PopulateCustomers();
        }

        // Eventhandler van favourite country add button. Hier wordt een record van de favourite_country tabel toegevoegd.
        // Verder wordt de record alleen toegevoegd in de favourite_country tabel als de customer niet hetzelfde land heeft gekozen.
        private void AddFavouriteCountry(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer != null && SelectedCountry == null)
            {
                MessageBox.Show($"Select a country name.");
            }
            else if (selectedCustomer == null && selectedCountry != null)
            {
                MessageBox.Show($"Select a customer name.");
            }
            else if (SelectedCustomer == null && selectedCountry == null)
            {
                MessageBox.Show($"Select a customer name and country name.");
            }
            else if (SelectedCustomer != null && SelectedCountry != null)
            {
                foreach (var item in favouriteCountries)
                {
                    if (item.CountryId == selectedCountry.CountryId && selectedCountry != null)
                    {
                        MessageBox.Show("Cannot add the same country to favourite countries.");
                        return;
                    }
                }

                if (MessageBox.Show($"Do you want to add {selectedCountry.CountryName} to your favourite countries?", "Information", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string dbResult = db.AddFavouriteCountries(selectedCustomer, selectedCountry);
                    MessageBox.Show($"{selectedCountry.CountryName} has been added to your favourite countries.");
                    if (dbResult != FavouriteCountryDB.OK)
                    {
                        MessageBox.Show($"{dbResult} {serviceDeskBericht}");
                    }
                    PopulateFavouriteCountries();
                }
            }
        }

        // Eventhandler van favourite country delete button. Hier wordt een record van een favourite_country tabel verwijderd.
        private void RemoveFavouriteCountry(object sender, RoutedEventArgs e)
        {
            if (selectedFavouriteCountry != null)
            {
                if (MessageBox.Show($"Do you want to remove {SelectedFavouriteCountry.CountryName} from your favourite countries?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string dbResult = db.RemoveFavouriteCountry(selectedCustomer.CustomerId, selectedFavouriteCountry.CountryId);
                    if (dbResult == FavouriteCountryDB.OK)
                    {
                        MessageBox.Show($"{SelectedFavouriteCountry.CountryName} has been removed from your favourite countries list.");
                    }
                    else
                    {
                        MessageBox.Show($"{dbResult} {serviceDeskBericht}");
                    }
                    PopulateFavouriteCountries();
                }
            }
            else if (SelectedCustomer == null && selectedFavouriteCountry == null)
            {
                MessageBox.Show($"Select a favourite country and customer name.");
            }
            else if (SelectedCustomer != null && selectedFavouriteCountry == null)
            {
                MessageBox.Show($"Select a favourite country.");
            }
        }

        // Eventhandler van customer delete button. Hier wordt een record van een customertabel verwijderd.
        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            if (SelectedCustomer != null)
            {
                if (MessageBox.Show($"Do you want to delete {selectedCustomer.CustomerName}?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string dbResult = db.DeleteCustomer(selectedCustomer.CustomerId);
                    if (dbResult == FavouriteCountryDB.OK)
                    {
                        MessageBox.Show($"{selectedCustomer.CustomerName} has been deleted.");
                    }
                    else
                    {
                        MessageBox.Show($"{dbResult} {serviceDeskBericht}");
                    }
                    PopulateCustomers();
                }
            }
            else
            {
                MessageBox.Show($"Select a customer name.");
            }
        }
    }
}
