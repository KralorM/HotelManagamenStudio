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
using System.Runtime.CompilerServices;

namespace HotelManagamenStudio
{
    /// <summary>
    /// Interaction logic for Employeewindow.xaml
    /// </summary>
    public partial class Employeewindow : Window
    {   
        hotel5Entities hotel5Entities = new hotel5Entities();
        CollectionViewSource employeViewSource1;
        CollectionViewSource employeViewSource;


        public Employeewindow()
        {
            InitializeComponent();
            employeViewSource1 = ((CollectionViewSource)(FindResource("employeesViewSource")));
            employeViewSource = ((CollectionViewSource)(FindResource("employeesViewSource1")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource employeesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // employeesViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource employeesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("employeesViewSource1")));
            // Load data by setting the CollectionViewSource.Source property:
            // employeesViewSource1.Source = [generic data source]

            hotel5Entities.employees.Load();
            employeesViewSource1.Source = hotel5Entities.employees.Local;
        }

        private void Addbttn_Click(object sender, RoutedEventArgs e)
        {
            employees employees = new employees();

            employees.employee_id = Convert.ToInt32(employee_idTextBox.Text);
            employees.room_id = Convert.ToInt32(room_idTextBox.Text);
            employees.hire_date = DateTime.Parse(hire_dateDatePicker.Text);
            employees.Position = positionTextBox.Text;
            employees.salary = Convert.ToDecimal(salaryTextBox.Text);
            employees.first_name = first_nameTextBox.Text;
            employees.last_name = last_nameTextBox.Text;

            using (hotel5Entities hotel5 = new hotel5Entities())
            {
                hotel5.employees.Add(employees);
                hotel5.SaveChanges();

            }
            MessageBox.Show("Submitted succesfully!");

           
        }

        private void Deltebttn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this row?","EF CRUD OPERATION",MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (hotel5Entities hotel = new hotel5Entities())
                {
                    var emp = employeViewSource.View.CurrentItem as employees;

                    var employees = (from m in hotel.employees
                                     where m.employee_id == emp.employee_id
                                     select m).FirstOrDefault();
                    if (employees != null)
                    {
                        hotel.employees.Remove(employees);
                        hotel.SaveChanges();
                    }

                }
            }


            //if (MessageBox.Show("Are you sure you want to delete this row?", "EF CRUD Operation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    using (hotel5Entities hotel = new hotel5Entities())
            //    {
            //        var pay = paymentsviewsource.View.CurrentItem as payments;

            //        var paym = (from p in hotel.payments
            //                    where p.payment_id == pay.payment_id
            //                    select p).FirstOrDefault();

            //        if (paym != null)
            //        {
            //            hotel.payments.Remove(paym);
            //            hotel.SaveChanges();
            //            paymentsviewsource.View.Refresh();

            //        }

            //    }
            //}
        }

        private void Cancelbttn_Click(object sender, RoutedEventArgs e)
        {
            employee_idTextBox.Text = "";
            room_idTextBox.Text = "";
            hire_dateDatePicker.Text = "";
            positionTextBox.Text = "";
            salaryTextBox.Text = "";
            first_nameTextBox.Text = "";
            last_nameTextBox.Text = "";

            empgrid.Visibility = Visibility.Visible;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            hotel5Entities hotel5Entities = new hotel5Entities();

            this.employeesDataGrid.ItemsSource = hotel5Entities.employees.ToList();
        }
    }
}
