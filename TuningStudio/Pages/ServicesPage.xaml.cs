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

namespace TuningStudio.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesPage.xaml
    /// </summary>
    public partial class ServicesPage : Page
    {
        public ServicesPage()
        {
            InitializeComponent();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MainPage());
        }

        private void VehiclesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VehiclesPage());
        }

        private void ServicesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }

        private void BrandsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BrandsPage());
        }

        private void AddServiceButton_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                AddServiceButton.Visibility = Visibility.Hidden;
            }
        }

        private void ServicesLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ServicesLV_Loaded(object sender, RoutedEventArgs e)
        {
            var allServices = from serv in MainWindow.db.TypeOfWork
                              select new
                              { 
                                serv.NameOfWork,
                                serv.Description
                              };
            ServicesLV.ItemsSource = allServices.ToList();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddService());
        }

        private void AutopartsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutopartsPage());
        }
    }
}
