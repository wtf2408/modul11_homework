using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace modul11
{

    public partial class ConsultantPage : Page
    {
        public Consultant Consultant { get; set; }
        public ObservableCollection<Client> Clients { get; set; }

        int currentID;



        public ConsultantPage()
        {
            InitializeComponent();

            Consultant = new Consultant();

            Clients = new ObservableCollection<Client>();

            listboxconsultant.ItemsSource = Clients;
        }

        private void OnClickToClient(object sender, SelectionChangedEventArgs e)
        {
            if (listboxconsultant.SelectedItem is Client currentClient)
            {
                textBox_firstName.DataContext = currentClient;
                textBox_lastName.DataContext = currentClient;
                textBox_phoneNumber.DataContext = currentClient;
                textBox_passport.Password = currentClient.Passport;

                currentID = currentClient.ID - 1;
            }
        }

        private void OnClickApplyChanges(object sender, RoutedEventArgs e)
        {
            ClientDB.SaveChange(Clients);
        }

    }
}
