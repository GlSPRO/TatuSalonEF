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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        private tatuSalonPRAKTIKAEntities AllDannye = new tatuSalonPRAKTIKAEntities();

        public Client()
        {
            InitializeComponent();
            Clients.ItemsSource = AllDannye.clients.ToList();

        }

        private void ClientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ADDstring_Button_Click(object sender, RoutedEventArgs e)
        {
            clients a = new clients();

            a.client_Familiya = TB_Familiya.Text;
            a.client_name = TB_name.Text;
            a.client_Otchestvo = TB_Otchestvo.Text;
            a.age = Convert.ToInt32(TB_age.Text);
            a.phone_number = TB_phone_number.Text;
            AllDannye.clients.Add(a);

            AllDannye.SaveChanges();
            Clients.ItemsSource = AllDannye.clients.ToList();

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItem != null)
            {
                var select = Clients.SelectedItem as clients;

                select.client_Familiya = TB_Familiya.Text;
                select.client_name = TB_name.Text;
                select.client_Otchestvo = TB_Otchestvo.Text;
                select.age = Convert.ToInt32(TB_age.Text);


                AllDannye.SaveChanges();
                Clients.ItemsSource = AllDannye.clients.ToList();
            }
        }

        private void Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Clients.SelectedItem != null)
            {
                var select = Clients.SelectedItem as clients;

                TB_name.Text = select.client_name;
                TB_Familiya.Text = select.client_Familiya;
                TB_Otchestvo.Text = select.client_Otchestvo;
                TB_age.Text = select.age.ToString();
                TB_phone_number.Text = select.phone_number.ToString();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Clients.SelectedItem != null)
            {
                AllDannye.clients.Remove(Clients.SelectedItem as clients);

                AllDannye.SaveChanges();
                Clients.ItemsSource = AllDannye.clients.ToList();
            }
        }
    }
}
