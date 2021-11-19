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
using TuningStudio.DB;

namespace TuningStudio.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public AddOrderPage()
        {
            InitializeComponent();
        }

        private void NewVehiclesCB_Loaded(object sender, RoutedEventArgs e)
        {
            var currentUserCars = from vehicle in MainWindow.db.Vehicle
                                  where vehicle.ClientID == MainWindow.IDClient
                                  select vehicle;
            NewVehiclesCB.ItemsSource = currentUserCars.ToList();
            NewVehiclesCB.DisplayMemberPath = "VINCode";
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewTypeOfWorkCB.SelectedItem == null || NewVehiclesCB.SelectedItem == null)
            {
                MessageBox.Show("Enter the data");
            }
            else
            {
                var selectedType = NewTypeOfWorkCB.SelectedItem as TypeOfWork;
                var selectedVehicle = NewVehiclesCB.SelectedItem as Vehicle;
                Order order = new Order();
                order.TypeOfWorkID = selectedType.ID;
                order.VehicleID = selectedVehicle.ID;
                MainWindow.db.Order.Add(order);
                MainWindow.db.SaveChanges();
                MessageBox.Show("Your order is successfully added");
                this.NavigationService.GoBack();
            }
        }

        private void NewTypeOfWorkCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewTypeOfWorkCB.ItemsSource = MainWindow.db.TypeOfWork.ToList();
            NewTypeOfWorkCB.DisplayMemberPath = "NameOfWork";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
