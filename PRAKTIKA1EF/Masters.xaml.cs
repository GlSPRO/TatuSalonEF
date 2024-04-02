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
    /// Логика взаимодействия для Masters.xaml
    /// </summary>
    public partial class Masters : Window
    {
        private tatuSalonPRAKTIKAEntities AllDannye = new tatuSalonPRAKTIKAEntities();

        public Masters()
        {
            InitializeComponent();
            Masters1.ItemsSource = AllDannye.masters.ToList();

        }

        private void ADDstring_Button_Click(object sender, RoutedEventArgs e)
        {
            masters b = new masters();

            b.master_name = TB_name.Text;
            b.rating = Convert.ToDecimal(TB_age.Text);

            AllDannye.masters.Add(b);

            AllDannye.SaveChanges();
            Masters1.ItemsSource = AllDannye.masters.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Masters1.SelectedItem != null)
            {
                var select = Masters1.SelectedItem as masters;

                select.master_name = TB_name.Text;
                select.rating = Convert.ToDecimal(TB_age.Text);


                AllDannye.SaveChanges();
                Masters1.ItemsSource = AllDannye.masters.ToList();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Masters1.SelectedItem != null)
            {
                AllDannye.masters.Remove(Masters1.SelectedItem as masters);

                AllDannye.SaveChanges();
                Masters1.ItemsSource = AllDannye.masters.ToList();
            }
        }

        private void Masters1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Masters1.SelectedItem != null)
            {
                var select = Masters1.SelectedItem as masters;

                TB_name.Text = select.master_name;
                TB_age.Text = select.rating.ToString();

            }
        }
    }
}

