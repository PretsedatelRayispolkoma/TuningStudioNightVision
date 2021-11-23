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
            ServicesLV.ItemsSource = MainWindow.db.TypeOfWork.ToList();
        }

        private void AddServiceButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddService());
        }

        private void AutopartsButton_Click(object sender, RoutedEventArgs e)
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
            var servToDelete = ServicesLV.SelectedItem as TypeOfWork;

            if(servToDelete == null)
            {
                return;
            }
            MainWindow.db.TypeOfWork.Remove(servToDelete);
            try
            {
                MainWindow.db.SaveChanges();
                this.NavigationService.Refresh();
            }
            catch
            {
                MessageBox.Show("You can't delete base services which  are the foundation of the whole company!");
            }
        }

        private void QuitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AutorizationPage());
        }
    }
}
