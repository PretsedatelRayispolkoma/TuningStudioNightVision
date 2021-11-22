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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void VehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VehiclesPage());
        }

        private void BrandsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BrandsPage());
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServicesPage());
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddOrderPage());
        }

        private void OrdersLV_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.IDRole == 2)
            {
                //var yourOrders = from veh in MainWindow.db.Vehicle
                //                 join ord in MainWindow.db.Order on veh.ID equals ord.VehicleID
                //                 join tow in MainWindow.db.TypeOfWork on ord.TypeOfWorkID equals tow.ID
                //                 where veh.ClientID == MainWindow.IDClient
                //                 select new
                //                 {
                //                     veh.ClientID,
                //                     veh.VINCode,
                //                     tow.NameOfWork
                //                 };
                //OrdersLV.ItemsSource = yourOrders.ToList();

                //var currentVehicles = MainWindow.db.Vehicle.Where(v => v.Client. == MainWindow.IDClient);
                OrdersLV.ItemsSource = MainWindow.db.Order.Where(o => o.Vehicle.ClientID == MainWindow.IDClient).ToList();

            }
            else if(MainWindow.IDRole == 1)
            {
                //var allOrders = from veh in MainWindow.db.Vehicle
                //                join ord in MainWindow.db.Order on veh.ID equals ord.VehicleID
                //                join tow in MainWindow.db.TypeOfWork on ord.TypeOfWorkID equals tow.ID
                //                select new
                //                {
                //                    veh.ClientID,
                //                    veh.VINCode,
                //                    tow.NameOfWork
                //                };
                //OrdersLV.ItemsSource = allOrders.ToList();
                OrdersLV.ItemsSource = MainWindow.db.Order.ToList();
            }
            
        }

        private void AutopartsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutopartsPage());
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderToDelete = OrdersLV.SelectedItem as Order;

            if(orderToDelete == null)
            {
                return;
            }
            
            try
            {
                MainWindow.db.Order.Remove(orderToDelete);
                MainWindow.db.SaveChanges();
                this.NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutorizationPage());
        }

        private void UpdateBtn_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                UpdateBtn.Visibility = Visibility.Hidden;
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
