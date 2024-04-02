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


        private void ADDstring_Button_Click(object sender, RoutedEventArgs e)
        {
            services_1 b = new services_1();

            b.service_name = TB_Otchestvo.Text;
            b.price = Convert.ToDecimal(TB_age.Text);

            AllDannye.services_1.Add(b);

            AllDannye.SaveChanges();
            Services.ItemsSource = AllDannye.services_1.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Services.SelectedItem != null)
            {
                var select = Services.SelectedItem as services_1;

                select.service_name = TB_Otchestvo.Text;
                select.price = Convert.ToDecimal(TB_age.Text);


                AllDannye.SaveChanges();
                Services.ItemsSource = AllDannye.services_1.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Services.SelectedItem != null)
            {
                AllDannye.services_1.Remove(Services.SelectedItem as services_1);

                AllDannye.SaveChanges();
                Services.ItemsSource = AllDannye.services_1.ToList();
            }
        }

        private void Services_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Services.SelectedItem != null)
            {
                var select = Services.SelectedItem as services_1;

                TB_Otchestvo.Text = select.service_name;
                TB_age.Text = select.price.ToString();

            }
        }
    }
}
