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
    /// Логика взаимодействия для VehiclesPage.xaml
    /// </summary>
    public partial class VehiclesPage : Page
    {
        public VehiclesPage()
        {
            InitializeComponent();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void VehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ServicesPage());
        }

        private void BrandsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BrandsPage());
        }

        private void VehiclesLV_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole == 2)
            {
                var yourVehicles = from color in MainWindow.db.Color
                                   join vehicle in MainWindow.db.Vehicle on color.ID equals vehicle.ColorID
                                   join body in MainWindow.db.Body on vehicle.BodyID equals body.ID
                                   where vehicle.ClientID == MainWindow.IDClient
                                   select new
                                   {
                                       vehicle.ID,
                                       vehicle.ClientID,
                                       body.NameOfBody,
                                       vehicle.VINCode,
                                       vehicle.Year,
                                       color.NameOfColor
                                   };

                VehiclesLV.ItemsSource = yourVehicles.ToList();
                VehiclesLV.DisplayMemberPath = "ID";
                VehiclesLV.DisplayMemberPath = "ClientID";
                VehiclesLV.DisplayMemberPath = "VINCode";
                VehiclesLV.DisplayMemberPath = "Year";
                VehiclesLV.DisplayMemberPath = "NameOfColor";
                VehiclesLV.DisplayMemberPath = "NameOFBody";

            }
            else if(MainWindow.IDRole == 1)
            {
                var currentVehicles = from color in MainWindow.db.Color
                                      join vehicle in MainWindow.db.Vehicle on color.ID equals vehicle.ColorID
                                      join body in MainWindow.db.Body on vehicle.BodyID equals body.ID
                                      select new
                                      {
                                          vehicle.ID,
                                          vehicle.ClientID,
                                          body.NameOfBody,
                                          vehicle.VINCode,
                                          vehicle.Year,
                                          color.NameOfColor
                                      };
                VehiclesLV.ItemsSource = currentVehicles.ToList();
            }
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddVehiclepage());
        }

        private void AutopartsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutopartsPage());
        }
    }
}
