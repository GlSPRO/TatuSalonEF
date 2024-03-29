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
using System.Windows.Shapes;

namespace PRAKTIKA1EF
{
    /// <summary>
    /// Логика взаимодействия для Servises.xaml
    /// </summary>
    public partial class Servises : Window
    {
        private tatuSalonPRAKTIKAEntities AllDannye = new tatuSalonPRAKTIKAEntities();

        public Servises()
        {
            InitializeComponent();
            Services.ItemsSource = AllDannye.services_1.ToList();

        }

        private void ServisesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
