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

namespace HotelManagamenStudio
{
    /// <summary>
    /// Interaction logic for Bookingswindow.xaml
    /// </summary>
    public partial class Bookingswindow : Window
    {   
        hotel5Entities hotel = new hotel5Entities();
        CollectionViewSource bookingsviewsource;
        CollectionViewSource paymentsviewsource;
        CollectionViewSource bookingsViewSource2;

        public Bookingswindow()
        {
            InitializeComponent();
            bookingsviewsource = ((CollectionViewSource)(FindResource("bookingsViewSource")));
            paymentsviewsource = ((CollectionViewSource)(FindResource("bookingsViewSource1")));
            DataContext = this;
        }

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
            // bookingsViewSource2.Source = [generic data source]
            System.Windows.Data.CollectionViewSource bookingsViewSource3 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bookingsViewSource3")));
            // Load data by setting the CollectionViewSource.Source property:
            // bookingsViewSource3.Source = [generic data source]
            bookingsViewSource3.Source = hotel.bookings.Local;
        }

        private void addbttn_payments_Click(object sender, RoutedEventArgs e)
        {
            payments payments = new payments();

            payments.payment_id = Convert.ToInt32(payment_idTextBox.Text.Trim());
            payments.booking_id = Convert.ToInt32(booking_idTextBox1.Text.Trim());
            payments.amount = Convert.ToInt32(amountTextBox.Text.Trim());
            payments.additional_payement = Convert.ToInt32(additional_payementTextBox.Text.Trim());



            using (hotel5Entities hotel5 = new hotel5Entities())
            {
                hotel.payments.Add(payments);
                hotel.SaveChanges();

            }
            MessageBox.Show("Submitted succesfully!");
        }

        private void deltebttn_payments_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "EF CRUD Operation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (hotel5Entities hotel = new hotel5Entities())
                {
                    var pay = paymentsviewsource.View.CurrentItem as payments;

                    var paym = (from p in hotel.payments
                                where p.payment_id == pay.payment_id
                                select p).FirstOrDefault();

                    if (paym != null)
                    {
                        hotel.payments.Remove(paym);
                        hotel.SaveChanges();
                        paymentsviewsource.View.Refresh();

                    }

                }
            }
        }

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
                hotel.bookings.Add(bookings);
                hotel.SaveChanges();

            }
            MessageBox.Show("Submitted succesfully!");
        }

        private void deletebttn_bookings_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "EF CRUD Operation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (hotel5Entities hotel = new hotel5Entities())
                {
                    var bok = bookingsviewsource.View.CurrentItem as bookings;

                    var book = (from b in hotel.bookings
                                where b.booking_id == bok.booking_id
                                select b).FirstOrDefault();

                    if (book != null)
                    {
                        hotel.bookings.Remove(book);
                        hotel.SaveChanges();
                        bookingsviewsource.View.Refresh();

                    }

                }
            }
        }

        private void cancelbttn_bookings_Click(object sender, RoutedEventArgs e)
        {
            booking_idTextBox.Text = "";
            check_inDatePicker.Text = "";
            guest_idTextBox.Text = "";
            priceTextBox.Text = "";
            room_idTextBox.Text = "";

            bookingsgrid.Visibility = Visibility.Visible;
        }

        private void cancelbttn_payments_Click(object sender, RoutedEventArgs e)
        {
            additional_payementTextBox.Text = "";
            booking_idTextBox1.Text = "";
            amountTextBox.Text = "";
            payment_idTextBox.Text = "";

            paymentsDataGrid.Visibility = Visibility.Visible;
        }
    }
}
