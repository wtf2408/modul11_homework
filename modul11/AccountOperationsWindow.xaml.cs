using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace modul11
{

    public partial class AccountOperationsWindow : Window
    {
        private Client currentClient;
        public Client CurrentClient
        {
            get => currentClient; 
            set
            {
                currentClient = value;
                ClientName.DataContext = currentClient;
            }
        }

        private ObservableCollection<Client> clients;
        public ObservableCollection<Client> Clients
        {
            get => clients; 
            set 
            { 
                clients = value;
                ListClients.ItemsSource = clients;
            }
        }

        string currentAccountType;


        public AccountOperationsWindow()
        {
            InitializeComponent();
            PaymentPanel.Visibility = Visibility.Hidden;
        }

        

        private void PaymentPanelVisibility(object sender, RoutedEventArgs e)
        {
            if (PaymentPanel.Visibility == Visibility.Visible) PaymentPanel.Visibility = Visibility.Hidden;
            
            else PaymentPanel.Visibility = Visibility.Visible;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void ExitToMainWindow(object sender, EventArgs e)
        {
            Hide();
            AccountComboBox.SelectedItem = null;
            ClientBalance.DataContext = null;
            PaymentPanel.Visibility = Visibility.Hidden;
            transferAmount.Foreground = new SolidColorBrush(Colors.White);
        }

        public void CloseWindow(object sender, EventArgs e)
        {
            Close();
        }


        private void OnClickComboboxItem(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox).SelectedItem != null)
            {
                var accountType = ((sender as ComboBox).SelectedItem as TextBlock).Text;

                if (accountType == "Депозитный")
                {
                    ClientBalance.DataContext = currentClient.DepositAccount; currentAccountType = accountType;
                }
                else if (accountType == "Недепозитный")
                {
                    ClientBalance.DataContext = currentClient.Account; currentAccountType = accountType;
                }
            }
        }

        private void OnClickTransferMoney(object sender, RoutedEventArgs e)
        {
            if (ListClients.SelectedItem != null && transferAmount.Text != null)
            {
                switch (currentAccountType)
                {
                    case "Депозитный":
                        AccountComboBox.Foreground = new SolidColorBrush(Colors.DarkRed);
                        break;
                    case "Недепозитный":
                        if (ListClients.SelectedItem is Client outClient)
                        {
                            var amount = int.Parse(transferAmount.Text);

                            if (amount < currentClient.Account.Balance) outClient.Account.TopUp(currentClient.Account, amount);
                            else transferAmount.Foreground = new SolidColorBrush(Colors.DarkRed);
                        }
                        break;
                }
                ListClients.SelectedItem = null;
                transferAmount.Text = null;
            }
        }



        private void TransferAmountGotFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            (sender as TextBox).Foreground = new SolidColorBrush(Colors.White);
        }

        private void AccountComboBoxGotFocus(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).Foreground = new SolidColorBrush(Colors.Black);
        }
    }

    
    
    

}
