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
    /// Логика взаимодействия для AutopartsPage.xaml
    /// </summary>
    public partial class AutopartsPage : Page
    {
        public AutopartsPage()
        {
            InitializeComponent();
        }


        private void AutopartsLV_Loaded(object sender, RoutedEventArgs e)
        {
            AutopartsLV.ItemsSource = MainWindow.db.Autopart.ToList();
        }

        private void AddAutopartButton_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                AddAutopartButton.Visibility = Visibility.Hidden;
            }
        }

        private void AddAutopartButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddAutopartPage());
        }

        private void AutopartsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
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
            this.NavigationService.Navigate(new MainPage());
        }

        private void DeleteAPButton_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                DeleteAPButton.Visibility = Visibility.Hidden;
            }
        }

        private void DeleteAPButton_Click(object sender, RoutedEventArgs e)
        {
            var apToDelete = AutopartsLV.SelectedItem as Autopart;
            if(apToDelete == null)
            {
                return;
            }

           // MessageBox.Show(apToDelete.ID.ToString());

            try
            {
                MainWindow.db.Autopart.Remove(apToDelete);
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

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
