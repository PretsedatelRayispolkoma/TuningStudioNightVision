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
    /// Логика взаимодействия для AddAutopartPage.xaml
    /// </summary>
    public partial class AddAutopartPage : Page
    {
        public AddAutopartPage()
        {
            InitializeComponent();
        }

        private void NewManufCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewManufCB.ItemsSource = MainWindow.db.Manufacturer.ToList();
            NewManufCB.DisplayMemberPath = "NameOfManufacturer";
        }

        private void NewWorkCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewWorkCB.ItemsSource = MainWindow.db.TypeOfWork.ToList();
            NewWorkCB.DisplayMemberPath = "NameOfWork";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AddAutopartBtn_Click(object sender, RoutedEventArgs e)
        {
            Autopart newAutopart = new Autopart();
            var selectedManuf = NewManufCB.SelectedItem as Manufacturer;
            var selectedWork = NewWorkCB.SelectedItem as TypeOfWork;

            newAutopart.Unit = NewUnitTB.Text;
            newAutopart.ManufacturerID = selectedManuf.ID;
            newAutopart.TypeOfWorkID = selectedWork.ID;

            try
            {
                newAutopart.GuaranteeMonth = Convert.ToInt32(NewGuaranteeTB.Text);
            }
            catch
            {
                MessageBox.Show("Not the appropriate recording format (Guarantee)");
                return;
            }

            MainWindow.db.Autopart.Add(newAutopart);
            MainWindow.db.SaveChanges();
            MessageBox.Show("Successfuly added");
            this.NavigationService.GoBack();
        }
    }
}
