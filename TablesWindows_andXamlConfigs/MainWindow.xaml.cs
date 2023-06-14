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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace HotelManagamenStudio
{
     /// <summary>
    /// W konstruktorze Mainwindow inicjalizowane są 
    /// obiekty CollectionViewSource i przypisywane są im źródła danych.
    /// </summary>
    public partial class MainWindow : Window
    {   
        hotel5Entities context = new hotel5Entities();
        CollectionViewSource guestViewSource;
        CollectionViewSource bookingsViewSource;


        public MainWindow()
        {
            InitializeComponent();
            guestViewSource = ((CollectionViewSource)FindResource("guestsViewSource"));
            bookingsViewSource = ((CollectionViewSource)FindResource("guestsViewSource1"));
            DataContext = this;

            var guest = from g in context.guests
                        select g;

            
            this.Resultguestgrid.ItemsSource = guest.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load is an extension method on IQueryable,    
            // defined in the System.Data.Entity namespace.   
            // This method enumerates the results of the query,    
            // similar to ToList but without creating a list.   
            // When used with Linq to Entities, this method    
            // creates entity objects and adds them to the context.   
            context.guests.Load();

            // After the data is loaded, call the DbSet<T>.Local property    
            // to use the DbSet<T> as a binding source.   
            guestViewSource.Source = context.guests.Local;
        }
        //private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        //{

        //}

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            guests guests = new guests();

            //guests.guest_id = GuestIDTextBox.Text.Trim();
            guests.first_name = FirstNameTextBox.Text.Trim();
            guests.last_name = LastNameTextBox.Text.Trim();
            guests.phone = phoneTextBox.Text.Trim();
            guests.adress = addressTextBox.Text.Trim();
            guests.nationality = NationalityTextBox.Text.Trim();

            using (hotel5Entities hotel5 = new hotel5Entities())
            {
                context.guests.Add(guests);
                context.SaveChanges();

            }
            MessageBox.Show("Submitted succesfully!");
                
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_Executed_3(object sender, ExecutedRoutedEventArgs e)
        {
            
        }

        private void CommandBinding_Executed_4(object sender, ExecutedRoutedEventArgs e)
        {
            GuestIDTextBox.Text = "";
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";
            phoneTextBox.Text = "";
            addressTextBox.Text = "";
            NationalityTextBox.Text = "";

            existingGuestGrid.Visibility = Visibility.Visible;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?","EF CRUD Operation",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                using (hotel5Entities hotel = new hotel5Entities())
                {
                    var gur = guestViewSource.View.CurrentItem as guests;

                    var gust = (from g in context.guests
                                where g.guest_id == gur.guest_id
                                select g).FirstOrDefault();

                    if (gust != null)
                    {
                        context.guests.Remove(gust);
                        context.SaveChanges();
                        guestViewSource.View.Refresh();

                    }

                }
            }
        }
    }
}
