using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.ComponentModel.Design;

namespace HotelManagamenStudio
{
    /// <summary>
    /// Klasa Bookingswindow dziedziczy po klasie Window oznacza to, że reprezentuje okno w 
    /// interfejsie użytkownika.
    /// </summary>
    public partial class Bookingswindow : Window
    {
        /// <summary>
        /// W konstruktorze 
        /// Bookingswindow inicjalizowane są obiekty 
        /// CollectionViewSource i przypisywane są im źródła danych.
        /// Kolejno dla tabel bookings,payments
        /// </summary>
        hotel5Entities hotel = new hotel5Entities();
        CollectionViewSource bookingsviewsource;
        CollectionViewSource paymentsviewsource;
        CollectionViewSource bookingsViewSource2;
        CollectionViewSource bookingsViewSource3;

        public Bookingswindow()
        {
            InitializeComponent();
            bookingsviewsource = ((CollectionViewSource)(FindResource("bookingsViewSource")));
            paymentsviewsource = ((CollectionViewSource)(FindResource("bookingsViewSource1")));
            bookingsViewSource2 = ((CollectionViewSource)(FindResource("bookingsViewSource2")));
            bookingsViewSource3 = ((CollectionViewSource)(FindResource("bookingsViewSource3")));
            DataContext = this;
        }

        /// <summary>
        /// Metoda Window_Loaded jest wywoływana po załadowaniu okna i 
        /// służy do ustawienia źródła danych dla niektórych kontrolkami w 
        /// interfejsie użytkownika.Ładujemy tutaj zródło dla tabeli bookings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource bookingsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookingsViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bookingsViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource bookingsViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookingsViewSource1")));
            // Load data by setting the CollectionViewSource.Source property:
            // bookingsViewSource1.Source = [generic data source]
            hotel.bookings.Load();
            bookingsViewSource1.Source = hotel.bookings.Local;
            
            System.Windows.Data.CollectionViewSource bookingsViewSource2 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookingsViewSource2")));
            // Load data by setting the CollectionViewSource.Source property:
            System.Windows.Data.CollectionViewSource bookingsViewSource3 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookingsViewSource3")));
            // Load data by setting the CollectionViewSource.Source property:
            // bookingsViewSource3.Source = [generic data source]
            bookingsViewSource3.Source = hotel.bookings.Local;

        }
        /// <summary>
        /// Metoda addbttn_bookings_Click obsługuje kliknięcie przycisku "Add" i 
        /// dodaje nową rezerwację do bazy danych na podstawie danych wprowadzonych 
        /// przez użytkownika.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addbttn_bookings_Click(object sender, RoutedEventArgs e)
        {
            bookings bookings = new bookings();

            bookings.booking_id = Convert.ToInt32(booking_idTextBox.Text.Trim());
            bookings.guest_id = Convert.ToInt32(guest_idTextBox.Text.Trim());
            bookings.room_id = Convert.ToInt32(room_idTextBox.Text.Trim());
            bookings.price = priceTextBox.Text.Trim();
            bookings.check_in = DateTime.Parse(check_inDatePicker.Text.Trim());


            using (hotel5Entities hotel5 = new hotel5Entities())
            {
                hotel5.bookings.Add(bookings);
                hotel5.SaveChanges();

            }
            bookingsViewSource3.View.Refresh();
            MessageBox.Show("Submitted succesfully!");
        }
        /// <summary>
        /// Metoda deletebttn_bookings_Click obsługuje kliknięcie przycisku "Delete" i 
        /// usuwa zaznaczoną rezerwację z bazy danych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deletebttn_bookings_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "EF CRUD Operation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (hotel5Entities hotel = new hotel5Entities())
                {
                    var bok = bookingsViewSource3.View.CurrentItem as bookings;

                    var book = (from b in hotel.bookings
                                where b.booking_id == bok.booking_id
                                select b).FirstOrDefault();

                    if (book != null)
                    {
                        hotel.bookings.Remove(book);
                        hotel.SaveChanges();
                        bookingsViewSource3.View.Refresh();
                     

                    }

                }
            }
        }
        /// <summary>
        /// Metoda cancelbttn_bookings_Click obsługuje kliknięcie przycisku "Cancel" i czyści wprowadzone dane, 
        /// przywracając widok tabeli rezerwacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelbttn_bookings_Click(object sender, RoutedEventArgs e)
        {
            booking_idTextBox.Text = "";
            check_inDatePicker.Text = "";
            guest_idTextBox.Text = "";
            priceTextBox.Text = "";
            room_idTextBox.Text = "";

            bookingsgrid.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Metoda cancelbttn_bookings_Click obsługuje kliknięcie przycisku "Cancel" i czyści wprowadzone dane, 
        /// przywracając widok tabeli rezerwacji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hotel5Entities hotel5Entities = new hotel5Entities();

            this.bookingsDataGrid.ItemsSource = hotel5Entities.bookings.ToList();
        }
    }
}
