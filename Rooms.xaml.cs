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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        hotel5Entities contex = new hotel5Entities();
        CollectionViewSource roomsViewSource;


        public Rooms()
        {
            InitializeComponent();
            roomsViewSource = ((CollectionViewSource)(FindResource("roomsViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            
            // Load data by setting the CollectionViewSource.Source property:
            // guestsViewSource1.Source = [generic data source]
            System.Windows.Data.CollectionViewSource roomsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roomsViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // roomsViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource roomsViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roomsViewSource1")));
            // Load data by setting the CollectionViewSource.Source property:
            // roomsViewSource1.Source = [generic data source]
            System.Windows.Data.CollectionViewSource roomsViewSource2 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roomsViewSource2")));
            // Load data by setting the CollectionViewSource.Source property:
            // roomsViewSource2.Source = [generic data source]
            contex.rooms.Load();
            roomsViewSource.Source = contex.rooms.Local;
            this.roomsDataGrid.ItemsSource = contex.rooms.Local;
            
        }

        private void Cancel_bttn_Click(object sender, RoutedEventArgs e)
        {
            room_idTextBox.Text = "";
            room_squareTextBox.Text = "";
            additional_bedTextBox.Text = "";
            capacityTextBox.Text = "";

            roomsGrid.Visibility = Visibility.Visible;
        }

        private void delete_bttn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?", "EF CRUD Operation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (hotel5Entities hotel = new hotel5Entities())
                {
                    var rom = roomsViewSource.View.CurrentItem as rooms;

                    var room = (from r in hotel.rooms
                                where r.room_id == rom.room_id
                                select r).FirstOrDefault();

                    if (room != null)
                    {
                        hotel.rooms.Remove(room);
                        hotel.SaveChanges();
                        roomsViewSource.View.Refresh();
                        

                    }

                }
            }
        }

        private void add_bttn_Click(object sender, RoutedEventArgs e)
        {
            rooms rooms = new rooms();

            //guests.guest_id = GuestIDTextBox.Text.Trim();
            rooms.room_id = Convert.ToInt32(room_idTextBox.Text.Trim());
            rooms.room_square = room_squareTextBox.Text.Trim();
            rooms.additional_bed = additional_bedTextBox.Text.Trim();
            rooms.capacity = Convert.ToInt32(capacityTextBox.Text);
            

            using (hotel5Entities hotel5 = new hotel5Entities())
            {
                hotel5.rooms.Add(rooms);
                hotel5.SaveChanges();

            }
            MessageBox.Show("Submitted succesfully!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hotel5Entities hotel5Entities = new hotel5Entities();

            this.roomsDataGrid.ItemsSource = hotel5Entities.rooms.ToList();
        }
    }
}
