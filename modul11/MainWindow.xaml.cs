using System.Windows;


namespace modul11
{
    public partial class MainWindow : Window
    {
        ManagerPage managerPage = new ManagerPage();

        ConsultantPage consultantPage = new ConsultantPage();


        public MainWindow()
        {
            InitializeComponent();

        }
        private void ButtonExit(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void ManagerButtonClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = managerPage;

            managerPage.Clients.Clear();

            var clients = ClientDB.GetClients();

            foreach (var item in clients)
            {
                managerPage.Clients.Add(item);
            }

            Client.lastID = clients.Count;
        }

        private void ConsultantButtonClick(object sender, RoutedEventArgs e)
        {
            mainFrame.Content = consultantPage;

            consultantPage.Clients.Clear();

            var clients = ClientDB.GetClients();

            foreach (var item in clients)
            {
                consultantPage.Clients.Add(item);
            }
        }
    }
}
