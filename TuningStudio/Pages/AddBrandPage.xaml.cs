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
    /// Логика взаимодействия для AddBrandPage.xaml
    /// </summary>
    public partial class AddBrandPage : Page
    {
        public AddBrandPage()
        {
            InitializeComponent();
        }

        private void AddBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NewBrandCB.SelectedItem == null || NewModelCB.SelectedItem == null || NewBodyTB.Text == "")
            {
                MessageBox.Show("Enter the data");
            }
            else
            {
                Body newBody = new Body();

                var selectedModel = NewModelCB.SelectedItem as Model;

                newBody.ModelID = selectedModel.ID;

                newBody.NameOfBody = NewBodyTB.Text;

                MainWindow.db.Body.Add(newBody);

                try
                {
                    MainWindow.db.SaveChanges();
                    MessageBox.Show("Changes are successfuly saved");
                }
                catch {
                    MessageBox.Show("Error");
                }

                this.NavigationService.GoBack();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void NewBrandTB_Loaded(object sender, RoutedEventArgs e)
        {
            NewBrandCB.ItemsSource = MainWindow.db.Brand.ToList();
            NewBrandCB.DisplayMemberPath = "NameOfBrand";
        }

        private void NewModelTB_Loaded(object sender, RoutedEventArgs e)
        {
            NewModelCB.IsEnabled = false;
        }

        private void AddNewBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddCarManufacter());
        }

        private void NewBrandCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedBrand = NewBrandCB.SelectedItem as Brand;
            NewModelCB.ItemsSource = MainWindow.db.Model.Where(m => m.BrandID == selectedBrand.ID ).ToList();
            NewModelCB.DisplayMemberPath = "NameOfModel";
            NewModelCB.IsEnabled = true;
        }

        private void NewModelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewBodyTB.IsEnabled = true;
        }

        private void NewBodyTB_Loaded(object sender, RoutedEventArgs e)
        {
            NewBodyTB.IsEnabled = false;
        }

        private void AddModelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddModelPage());
        }
    }
}
