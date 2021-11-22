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

        private void CountryCB_Loaded(object sender, RoutedEventArgs e)
        {
            CountryCB.ItemsSource = MainWindow.db.Country.ToList();
            CountryCB.DisplayMemberPath = "NameOfCountry";
        }

        private void AddBrandBtn_Click(object sender, RoutedEventArgs e)
        {
            Brand newBrand = new Brand();
            Model newModel = new Model();
            Body newBody = new Body();

            var selectedCountry = CountryCB.SelectedItem as Country;

            newBrand.NameOfBrand = NewBrandTB.Text;
            newBrand.CountryID = selectedCountry.ID;

            newModel.NameOfModel = NewModelTB.Text;
            newModel.BrandID = newBrand.ID;

            newBody.NameOfBody = NewBodyTB.Text;
            newBody.ModelID = newModel.ID;

            MainWindow.db.Brand.Add(newBrand);
            MainWindow.db.Model.Add(newModel);
            MainWindow.db.Body.Add(newBody);
            MainWindow.db.SaveChanges();
            MessageBox.Show("Changes are successfuly saved");
            this.NavigationService.GoBack();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
