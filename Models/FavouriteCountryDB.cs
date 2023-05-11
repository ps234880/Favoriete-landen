using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace favoriete_landen.Models
{
    public class FavouriteCountryDB
    {
        #region Messages
        public static readonly string UNKNOWN = "Unknown";
        public static readonly string OK = "Ok";
        public static readonly string NOTFOUND = "Not found";
        #endregion

        private readonly string connString = ConfigurationManager.ConnectionStrings["favourite_countries"].ConnectionString;

        #region Customers
        // Geeft een lijst van customers.
        public string GetCustomers(ICollection<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentException("Ongeldig argument bij gebruik van GetIngredients");
            }

            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        SELECT c.customerId, c.customerName
                        FROM customers c
                        ORDER BY c.customerName
                    ";
                    MySqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Customer customer = new()
                        {
                            CustomerId = (int)reader["customerId"],
                            CustomerName = (string)reader["customerName"],
                        };
                        customers.Add(customer);
                    }
                    methodResult = OK;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(GetCustomers));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }

        // Voegt een record toe aan de customer tabel
        public string CreateCustomer(Customer customer)
        {
            if (customer == null || string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new ArgumentException("Ongeldig argument bij gebruik van Createcustomer");
            }

            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        INSERT INTO customers(customerId, customerName) 
                        VALUES (NULL, @customerName);
                    ";
                    sql.Parameters.AddWithValue("@customerName", customer.CustomerName);

                    if (sql.ExecuteNonQuery() == 1)
                    {
                        methodResult = OK;
                    }
                    else
                    {
                        methodResult = $"customer {customer.CustomerName} could not be created.";
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(CreateCustomer));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }

        // Verwijderd een record van de customer tabel van de geselecteerde customerid.
        public string DeleteCustomer(int customerId)
        {
            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        DELETE 
                        FROM customers
                        WHERE customerId = @customerId 
                    ";
                    sql.Parameters.AddWithValue("@customerId", customerId);
                    if (sql.ExecuteNonQuery() == 1)
                    {
                        methodResult = OK;
                    }
                    else
                    {
                        methodResult = $"Klant met id {customerId} kon niet verwijderd worden.";
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(DeleteCustomer));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }
        #endregion

        #region Countries

        // Geeft een lijst van countries.
        public string GetCountries(ICollection<Country> countries)
        {
            if (countries == null)
            {
                throw new ArgumentException("Ongeldig argument bij gebruik van GetIngredients");
            }

            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        SELECT c.countryId, c.countryName
                        FROM countries c
                        ORDER BY c.countryName
                    ";
                    MySqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Country country = new()
                        {
                            CountryId = (int)reader["countryId"],
                            CountryName = (string)reader["countryName"],
                        };
                        countries.Add(country);
                    }
                    methodResult = OK;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(GetCustomers));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }
        #endregion

        #region Favourite Countries
        // Geeft een lijst van countries van de geselecteerde customerid.
        public string GetFavouriteCountries(ICollection<Country> countries, int customerId)
        {
            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        SELECT countries.CountryID, countries.CountryName
                        FROM `favourite_countries`
                        INNER JOIN countries ON favourite_countries.CountryID = countries.CountryID
                        WHERE favourite_countries.CustomerID = @customerId
                    ";
                    sql.Parameters.AddWithValue("@customerId", customerId);
                    MySqlDataReader reader = sql.ExecuteReader();

                    while (reader.Read())
                    {
                        Country favouriteCountries = new()
                        {
                            CountryId = (int)reader["countryId"],
                            CountryName = (string)reader["countryName"],
                        };
                        countries.Add(favouriteCountries);
                    }
                    methodResult = countries == null ? NOTFOUND : OK;
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(GetFavouriteCountries));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }

        // Voegt een record toe aan favourite countries van de geselecteerde customerid.
        public string AddFavouriteCountries(Customer customer, Country country)
        {
            if (customer == null || string.IsNullOrEmpty(customer.CustomerName))
            {
                throw new ArgumentException("Ongeldig argument bij gebruik van Createcustomer");
            }

            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        INSERT INTO favourite_countries(customerId, countryId) 
                        VALUES (@customerId, @countryId);
                    ";

                    sql.Parameters.AddWithValue("@customerId", customer.CustomerId);
                    sql.Parameters.AddWithValue("@countryId", country.CountryId);

                    if (sql.ExecuteNonQuery() == 1)
                    {
                        methodResult = OK;
                    }
                    else
                    {
                        methodResult = $"customer {customer.CustomerName} could not be created."; // later aanpassen
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(CreateCustomer));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }

        // Verwijderd een record van favourite countries van de geselecteerde customerid en countryid.
        public string RemoveFavouriteCountry(int customerId, int countryId)
        {
            string methodResult = UNKNOWN;

            using (MySqlConnection conn = new(connString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand sql = conn.CreateCommand();
                    sql.CommandText = @"
                        DELETE 
                        FROM favourite_countries 
                        WHERE (customerId = @customerId) AND (countryId = @countryId)
                    ";
                    sql.Parameters.AddWithValue("@customerId", customerId);
                    sql.Parameters.AddWithValue("@countryId", countryId);

                    if (sql.ExecuteNonQuery() == 1)
                    {
                        methodResult = OK;
                    }
                    else
                    {
                        methodResult = $"Country met id {countryId} kon niet verwijderd worden.";
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(nameof(RemoveFavouriteCountry));
                    Console.Error.WriteLine(e.Message);
                    methodResult = e.Message;
                }
            }
            return methodResult;
        }
        #endregion
    }
}
