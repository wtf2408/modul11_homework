using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace modul11
{

    public partial class ManagerPage : Page
    {
        public Manager Manager { get; set; }
        public ObservableCollection<Client> Clients { get; set; }

        int currentID; 

        public ManagerPage()
        {

            InitializeComponent();

            Manager = new Manager();

            Clients = new ObservableCollection<Client>();

            listboxmanager.ItemsSource = Clients;
        }




        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listboxmanager.SelectedItem is Client currentClient)
            {
                textBox_firstName.Text = currentClient.FirstName;
                textBox_lastName.Text = currentClient.LastName;
                textBox_phoneNumber.Text = currentClient.PhoneNumber;
                textBox_passport.Text = currentClient.Passport;
                currentID = currentClient.ID;
            }
        }

        private void OnClickApplyChanges(object sender, RoutedEventArgs e)
        {
            if (currentID != 0)
            {
                Manager.SetClientProrerty(Clients,
                currentID - 1,
                textBox_firstName.Text,
                textBox_lastName.Text,
                textBox_phoneNumber.Text,
                textBox_passport.Text);
            }
            ClientDB.SaveChange(Clients);

        }



        private void OnClickAddClient(object sender, RoutedEventArgs e)
        {
            Manager.AddClient(Clients);
        }
    }
}
