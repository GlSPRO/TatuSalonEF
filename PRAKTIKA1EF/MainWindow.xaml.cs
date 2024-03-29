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

namespace PRAKTIKA1EF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private tatuSalonPRAKTIKAEntities AllDannye = new tatuSalonPRAKTIKAEntities();
        public MainWindow()
        {
            InitializeComponent();
            ClientDG.ItemsSource = AllDannye.appointments.ToList();
        }

        private void ClientDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Click_Clients_Click(object sender, RoutedEventArgs e)
        {
            Client masters = new Client();
            masters.Show();
        }

        private void Click_Servises_Click(object sender, RoutedEventArgs e)
        {
            Servises masters = new Servises();
            masters.Show();
        }

        private void Click_Master_Click(object sender, RoutedEventArgs e)
        {
            Masters masters = new Masters();
            masters.Show();
        }
    }
}
