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
using Color = TuningStudio.DB.Color;

namespace TuningStudio.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddVehiclepage.xaml
    /// </summary>
    public partial class AddVehiclepage : Page
    {
        public AddVehiclepage()
        {
            InitializeComponent();
        }

        private void NewColorCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewColorCB.IsEnabled = false;
        }

        private void NewBodyCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(NewBodyCB.SelectedItem != null)
            {
                VinCodeTB.IsEnabled = true;
                
                NewColorCB.IsEnabled = true;
                NewColorCB.ItemsSource = MainWindow.db.Color.ToList();
                NewColorCB.DisplayMemberPath = "NameOfColor";

                yearTB.IsEnabled = true;
            }
            else
            {
                VinCodeTB.IsEnabled = false;
                NewBodyCB.IsEnabled = false;
                yearTB.IsEnabled = false;
            }
        }

        private void NewBrandCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewBrandCB.ItemsSource = MainWindow.db.Brand.ToList();
            NewBrandCB.DisplayMemberPath = "NameOfBrand";
        }

        private void NewModelCB_Loaded(object sender, RoutedEventArgs e)
        {

            NewModelCB.IsEnabled = false;
        }

        private void NewBodyCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewBodyCB.IsEnabled = false;
        }

        private void VinCodeTB_Loaded(object sender, RoutedEventArgs e)
        {
            VinCodeTB.IsEnabled = false;
        }

        private void yearTB_Loaded(object sender, RoutedEventArgs e)
        {
            yearTB.IsEnabled = false;
        }

        private void NewModelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewBodyCB.IsEnabled = true;

            var selectedModel = NewModelCB.SelectedItem as Model;
            var bodiesOfModel = from body in MainWindow.db.Body
                                join model in MainWindow.db.Model on body.ModelID equals model.ID
                                where model.NameOfModel == selectedModel.NameOfModel
                                select body;
            NewBodyCB.ItemsSource = bodiesOfModel.ToList();
            NewBodyCB.DisplayMemberPath = "NameOfBody";
        }

        private void NewBrandCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewModelCB.IsEnabled = true;

            var selectedBrand = NewBrandCB.SelectedItem as Brand;
            var modelsOfBrand = from model in MainWindow.db.Model
                                join brand in MainWindow.db.Brand on model.BrandID equals brand.ID
                                where brand.NameOfBrand == selectedBrand.NameOfBrand
                                select model;
            NewModelCB.ItemsSource = modelsOfBrand.ToList();
            NewModelCB.DisplayMemberPath = "NameOfModel";
        }

        private void AddVehicleBtn_Click(object sender, RoutedEventArgs e)
        {
            if(NewBrandCB.SelectedItem == null || NewBodyCB.SelectedItem == null || NewModelCB.SelectedItem == null ||
                VinCodeTB.Text == "" || NewColorCB.SelectedItem == null || yearTB.Text == "")
            {
                MessageBox.Show("Enter the data");
            }
            else
            {
                var selectedBody = NewBodyCB.SelectedItem as Body;
                var selectedColor = NewColorCB.SelectedItem as Color;

                Vehicle newVehicle = new Vehicle();
                newVehicle.VINCode = VinCodeTB.Text;
                newVehicle.Year = Convert.ToInt32(yearTB.Text);
                newVehicle.ColorID = selectedColor.ID;
                newVehicle.BodyID = selectedBody.ID;
                newVehicle.ClientID = MainWindow.IDClient;

                MainWindow.db.Vehicle.Add(newVehicle);
                MainWindow.db.SaveChanges();
                MessageBox.Show("Vehicle if successfuly added");
                this.NavigationService.GoBack();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
