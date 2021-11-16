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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (var authUser in MainWindow.db.Autorization)
            {
                if (authUser.Login == LoginTB.Text.Trim())
                {
                    if (authUser.Password == PasswordPB.Password.Trim() && authUser.RoleID == 2)
                    {
                        MessageBox.Show("Hi, dude..");
                        this.NavigationService.Navigate(new MainPage());
                    }
                    if (authUser.Password == PasswordPB.Password.Trim() && authUser.RoleID == 1)
                    {
                        MessageBox.Show("Hello, Boss");
                        this.NavigationService.Navigate(new MainPage());
                    }
                }
            } 
        }
    }
}
