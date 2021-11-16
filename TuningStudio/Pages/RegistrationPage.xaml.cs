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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {

            if(NewFirstNameTB.Text == null || NewLastNameTB.Text == null || NewPhoneNumberTB.Text == null || NewLoginTB.Text == null || NewPasswordPB.Password.Trim() == null)
            {
                MessageBox.Show("Enter the data in full");
            }
            else
            {
                Client newClient = new Client();

                Autorization newUser = new Autorization();
                string newLogin = NewLoginTB.Text;

                foreach (var login in MainWindow.db.Autorization)
                {
                    if (NewLoginTB.Text.Trim() == login.Login)
                    {
                        MessageBox.Show("The login already exist");
                        break;
                    }
                }
                
                newClient.FirstName = NewFirstNameTB.Text;
                newClient.LastName = NewLastNameTB.Text;
                newClient.PhoneNumber = NewPhoneNumberTB.Text;
                newUser.Login = newLogin;
                newUser.Password = NewPasswordPB.Password.Trim();
                newUser.RoleID = 2;
                newUser.ClientID = newClient.ID;
                MainWindow.db.Autorization.Add(newUser);
                MainWindow.db.Client.Add(newClient);
               // MainWindow.db.SaveChanges();
                MessageBox.Show("The registration is successful");
                this.NavigationService.GoBack();
                    
            }         
        }
    }
}
