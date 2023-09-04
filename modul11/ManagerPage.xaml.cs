using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace modul11
{

    public partial class ManagerPage : Page
    {
        private Manager Manager { get; set; }
        public ObservableCollection<Client> Clients { get; set; }
        public AccountOperationsWindow AccountWindow {get; set;}

        int currentID;


        public ManagerPage()
        {

            InitializeComponent();

            Manager = new Manager();

            Clients = new ObservableCollection<Client>();

            AccountWindow = new AccountOperationsWindow();
            
            listboxmanager.ItemsSource = Clients;

            
        }

        private void OnClickToListboxItem(object sender, SelectionChangedEventArgs e)
        {
            if (listboxmanager.SelectedItem is Client currentClient)
            {

                textBox_firstName.DataContext = currentClient;
                textBox_lastName.DataContext = currentClient;
                textBox_phoneNumber.DataContext = currentClient;
                textBox_passport.DataContext = currentClient;

                currentID = currentClient.ID - 1;


                AccountPanal.IsEnabled = true;

                var accountCount = currentClient.GetAccountsCount();
                switch (accountCount)
                {
                    case 0:

                        EnableController(false, true);
                        break;

                    case 1:

                        EnableController(true, true);
                        break;

                    case 2:

                        EnableController(true, false);
                        break;

                }
            }
            else AccountPanal.IsEnabled = false;
        
        }

        private void OnClickApplyChanges(object sender, RoutedEventArgs e)
        {
            ClientDB.SaveChange(Clients);
        }

        private void OnClickAddClient(object sender, RoutedEventArgs e)
        {
            Manager.AddClient(Clients);
        }

        private void OnClickManageAccountButton(object sender, RoutedEventArgs e)
        {
            AccountWindow.Show();
            AccountWindow.Clients = Clients;
            AccountWindow.CurrentClient = Clients[currentID];
        }



        private void OnClickOpenAccount(object sender, RoutedEventArgs e)
        {
            string inputSum = InputSumToTheAccount.Text;
            if (!string.IsNullOrEmpty(inputSum))
            {
                if (ComboBoxTypesAccount.Text == "Депозитный")
                {
                    Clients[currentID].DepositAccount = new DepositAccount(int.Parse(inputSum));
                    EnableController(true, false);
                }

                else if (ComboBoxTypesAccount.Text == "Недепозитный")
                {
                    Clients[currentID].Account = new Account(int.Parse(inputSum));
                    EnableController(true, false);
                }
            }
            else InputSumToTheAccount.Foreground = new SolidColorBrush(Colors.Red);


        }

        private void InputSumLostFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            InputSumToTheAccount.Foreground = new SolidColorBrush(Colors.White);
        }

        

        /// <summary>
        /// метод установливает свойство IsEnabled у элементов:
        /// ManageAccountButton, OpenAccountButton
        /// </summary>
        private void EnableController(bool enabled1, bool enabled2)
        {
            InputSumToTheAccount.Text = string.Empty;
            ComboBoxTypesAccount.Text = string.Empty;

            ManageClientAccountButton.IsEnabled = enabled1;
            OpenAccountButton.IsEnabled = enabled2;
        }
    }
}
