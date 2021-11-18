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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Page
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void AddWork_Click(object sender, RoutedEventArgs e)
        {
            TypeOfWork tow = new TypeOfWork();
            tow.NameOfWork = NewWorkTB.Text;
            tow.Description = NewDescrTB.Text;
            MainWindow.db.TypeOfWork.Add(tow);
            MainWindow.db.SaveChanges();
            MessageBox.Show("The changes is successfuly saved");
            this.NavigationService.GoBack();
        }
    }
}
