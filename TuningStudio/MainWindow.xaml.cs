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
using TuningStudio.Pages;

namespace TuningStudio
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Yapparov321AtelyeNightVisionEntities db = new Yapparov321AtelyeNightVisionEntities();
        public static int IDClient;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new AutorizationPage();
        }
    }
}
