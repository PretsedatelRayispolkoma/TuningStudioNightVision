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
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        Order currentEditOrder;
        public AddOrderPage(Order editOrder)
        {
            InitializeComponent();
            if (editOrder != null)
            {
                this.currentEditOrder = MainWindow.db.Order.Attach(editOrder);
                NewVehiclesCB.SelectedItem = editOrder.Vehicle;
                NewVehiclesCB.IsEnabled = false;
                NewTypeOfWorkCB.SelectedItem = editOrder.TypeOfWork;
                NewTypeOfWorkCB.IsEnabled = false;
                DateOfOrderDP.SelectedDate = editOrder.DateOfOrder;
                DateOfOrderDP.IsEnabled = false;
                AddOrderBtn.Visibility = Visibility.Hidden;    
                DataContext = this.currentEditOrder;
            }
        }

        public AddOrderPage()
        {
            InitializeComponent();
            StatusGrid.Visibility = Visibility.Hidden;
            DateOfOrderDP.DisplayDateStart = DateTime.Now;
            UpdateOrderBtn.Visibility = Visibility.Hidden;
        }

        private void NewVehiclesCB_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                NewVehiclesCB.ItemsSource = MainWindow.db.Vehicle.Where(v => v.ClientID == MainWindow.IDClient).ToList();
                NewVehiclesCB.DisplayMemberPath = "VINCode";
            }
            else
            {
                NewVehiclesCB.ItemsSource = MainWindow.db.Vehicle.ToList();
                NewVehiclesCB.DisplayMemberPath = "VINCode";
            }
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewTypeOfWorkCB.SelectedItem == null || NewVehiclesCB.SelectedItem == null || DateOfOrderDP.SelectedDate == null)
            {
                MessageBox.Show("Enter the data");
            }
            else
            {
                var selectedType = NewTypeOfWorkCB.SelectedItem as TypeOfWork;
                var selectedVehicle = NewVehiclesCB.SelectedItem as Vehicle;
                Order order = new Order();
                order.TypeOfWorkID = selectedType.ID;
                order.VehicleID = selectedVehicle.ID;

                order.DateOfOrder = DateOfOrderDP.SelectedDate;
                order.IsAccepted = false;

                MainWindow.db.Order.Add(order);
                MainWindow.db.SaveChanges();
                MessageBox.Show("Your order is successfully added");
                this.NavigationService.GoBack();
            }
        }

        private void NewTypeOfWorkCB_Loaded(object sender, RoutedEventArgs e)
        {
            NewTypeOfWorkCB.ItemsSource = MainWindow.db.TypeOfWork.ToList();
            NewTypeOfWorkCB.DisplayMemberPath = "NameOfWork";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void StatusGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if(MainWindow.IDRole != 1)
            {
                StatusGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                InWaitingRB.IsChecked = true;
            }
        }

        private void UpdateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            var currentVehicle = NewVehiclesCB.SelectedItem as Vehicle;
            var currentTOW = NewTypeOfWorkCB.SelectedItem as TypeOfWork;
            if (InWaitingRB.IsChecked == true)
            {
                return;
            }
            else if (AcceptedRB.IsChecked == true)
            {
                currentEditOrder.VehicleID = currentVehicle.ID;
                currentEditOrder.TypeOfWorkID = currentTOW.ID;
                currentEditOrder.IsAccepted = true;
                currentEditOrder.DateOfOrder = DateOfOrderDP.SelectedDate;

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
