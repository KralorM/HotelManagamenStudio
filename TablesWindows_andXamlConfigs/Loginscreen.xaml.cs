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

namespace HotelManagamenStudio
{
    /// <summary>
    /// Interaction logic for Loginscreen.xaml
    /// </summary>
    public partial class Loginscreen : Window
    {
        public Loginscreen()
        {
            InitializeComponent();
        }

        private void Submmit_bttn_Click(object sender, RoutedEventArgs e)
        {
            if (Passwordbox1.Password != "" && Username_txtbox.Text != "" )
            {
                if (Passwordbox1.Password == "1234" && Username_txtbox.Text == "Manager1")
                {
                    MessageBox.Show("Correct information login in...");
                    
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Invalid information, try again");
                    return;
                }
            }
        }
    }
}
