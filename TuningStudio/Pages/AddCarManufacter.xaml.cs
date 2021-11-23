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
    /// Логика взаимодействия для AddCarManufacter.xaml
    /// </summary>
    public partial class AddCarManufacter : Page
    {
        public AddCarManufacter()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            if(CountryCB == null || AddNewBrandTB.Text == "")
            {
                MessageBox.Show("Enter the data");
            }
            else
            {
                Brand newBrand = new Brand();

                var selectedCountry = CountryCB.SelectedItem as Country;
            
                newBrand.CountryID = selectedCountry.ID;

                newBrand.NameOfBrand = AddNewBrandTB.Text;

                MainWindow.db.Brand.Add(newBrand);
                try
                {
                    MainWindow.db.SaveChanges();
                }
                catch 
                {
                    MessageBox.Show("Error");
                }
                this.NavigationService.GoBack();
            }
            
        }

        private void CountryCB_Loaded(object sender, RoutedEventArgs e)
        {
            CountryCB.ItemsSource = MainWindow.db.Country.ToList();
            CountryCB.DisplayMemberPath = "NameOfCountry";
        }
    }
}
