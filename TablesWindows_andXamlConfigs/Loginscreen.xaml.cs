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
    /// Kod ten służy do tworzenia ekranu logowania.
    /// </summary>
    public partial class Loginscreen : Window
    {
        public Loginscreen()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metoda Submit_bttn_Click na początku sprawdza czy Passwordbox i usernamebox są puste jeżeli tak przechodzi do wewnętrzenj części if statementu
        /// Potem sprawdzana jest poprawność wprowadzonego hasła, jeśli jest ono prawidłowe wtedy otwiera nam się główne okno, natomiast jeżeli nie wyskakuje powiadomienie
        /// o zle wprowadzonych danych.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
