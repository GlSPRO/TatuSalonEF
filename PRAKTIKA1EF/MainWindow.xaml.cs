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


        private void ADDstring_Button_Click(object sender, RoutedEventArgs e)
        {
            appointments a = new appointments();

            a.service_id = Convert.ToInt32(TB_ServiceID.Text);
            a.master_id = Convert.ToInt32(TB_MastersID.Text);
            a.client_Familiya = TB_Familiya.Text;
            a.client_name = TB_name.Text;
            a.client_Otchestvo = TB_Otchestvo.Text;
            a.age = Convert.ToInt32(TB_age.Text);
            a.phone_number = Convert.ToInt32(TB_phone_number.Text);
            AllDannye.appointments.Add(a);

            AllDannye.SaveChanges();
            ClientDG.ItemsSource = AllDannye.appointments.ToList();

        }
        private void TB_age_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (ClientDG.SelectedItem != null)
            {
                var select = ClientDG.SelectedItem as appointments;

                select.client_id = Convert.ToInt32(TB_Update.Text);
                select.service_id = Convert.ToInt32(TB_ServiceID.Text);
                select.master_id = Convert.ToInt32(TB_MastersID.Text);
                select.client_Familiya = TB_Familiya.Text;
                select.client_name = TB_name.Text;
                select.client_Otchestvo = TB_Otchestvo.Text;
                select.age = Convert.ToInt32(TB_age.Text);
                select.phone_number = Convert.ToInt32(TB_phone_number.Text);

                AllDannye.SaveChanges();
                ClientDG.ItemsSource = AllDannye.appointments.ToList();
            }
        }


        private void ClientDG_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (ClientDG.SelectedItem != null)
            {
                var select = ClientDG.SelectedItem as appointments;

                TB_Update.Text = select.client_id.ToString();
                TB_ServiceID.Text = select.service_id.ToString();
                TB_MastersID.Text = select.master_id.ToString();
                TB_Familiya.Text = select.client_Familiya;
                TB_name.Text = select.client_name;
                TB_Otchestvo.Text = select.client_Otchestvo;
                TB_age.Text = select.age.ToString();
                TB_phone_number.Text = select.phone_number.ToString();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ClientDG.SelectedItem != null)
            { 
                AllDannye.appointments.Remove(ClientDG.SelectedItem as appointments);

                AllDannye.SaveChanges();
                ClientDG.ItemsSource = AllDannye.appointments.ToList();
            }
        }
    }
}
