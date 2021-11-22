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
    /// Логика взаимодействия для BrandsPage.xaml
    /// </summary>
    public partial class BrandsPage : Page
    {
        public BrandsPage()
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
            this.NavigationService.Navigate(new ServicesPage());
        }

        private void BrandsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }

        private void BrandsPage_Loaded(object sender, RoutedEventArgs e)
        {
            var currentRole = MainWindow.IDRole;
            if(currentRole == 2)
            {
                AddBrandButton.Visibility = Visibility.Hidden;
            }
            else
            {
                AddBrandButton.Visibility = Visibility.Visible;
            }
        }

        private void AutopartsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutopartsPage());
        }

        private void BrandsLV_Loaded(object sender, RoutedEventArgs e)
        {
            BrandsLV.ItemsSource = MainWindow.db.Body.ToList();
        }

        private void AddBrandButton_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                AddBrandButton.Visibility = Visibility.Hidden;
            }
        }

        private void AddBrandButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddBrandPage());
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutopartsPage());
        }

        private void DeleteBtn_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var brToDelete = BrandsLV.SelectedItem as Body;

            if(brToDelete == null)
            {
                return;
            }

            try
            {
                MainWindow.db.Body.Remove(brToDelete);
                MainWindow.db.SaveChanges();
                this.NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
    }
}

