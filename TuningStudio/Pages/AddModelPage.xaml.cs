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
    /// Логика взаимодействия для AddModelPage.xaml
    /// </summary>
    public partial class AddModelPage : Page
    {
        public AddModelPage()
        {
            InitializeComponent();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void BrandCB_Loaded(object sender, RoutedEventArgs e)
        {
            BrandCB.ItemsSource = MainWindow.db.Brand.ToList();
            BrandCB.DisplayMemberPath = "NameOfBrand";
        }

        private void AddModelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(BrandCB.SelectedItem == null || AddNewModelTB.Text == "")
            {
                MessageBox.Show("Enter the data");
            }
            else
            {
                Model newModel = new Model();

                var selectedBrand = BrandCB.SelectedItem as Brand;

                newModel.BrandID = selectedBrand.ID;

                newModel.NameOfModel = AddNewModelTB.Text;

                MainWindow.db.Model.Add(newModel);
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
    }
}
