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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listboxconsultant.SelectedItem is Client currentClient)
            {
                textBox_firstName.Text = currentClient.FirstName;
                textBox_lastName.Text = currentClient.LastName;
                textBox_phoneNumber.Text = currentClient.PhoneNumber;
                textBox_passport.Password = currentClient.Passport;
                currentID = currentClient.ID;
            }
        }

        private void OnClickApplyChanges(object sender, RoutedEventArgs e)
        {
            if (currentID != 0)
            {
                Consultant.SetClientPhone(Clients, currentID - 1, textBox_phoneNumber.Text);
            }
            ClientDB.SaveChange(Clients);

        }

    }
}
