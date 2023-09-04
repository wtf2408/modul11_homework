using modul11;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;


namespace modul11
{
    public partial class MainWindow : Window
    {

        ManagerPage managerPage;

        ConsultantPage consultantPage;

        private bool managerPageIsOpen = false;
        private bool consultantPageIsOpen = false;

        public MainWindow()
        {
            InitializeComponent();

            managerPage = new ManagerPage();
            consultantPage = new ConsultantPage();
        }
        
        private void ManagerButtonClick(object sender, RoutedEventArgs e)
        {
            var clients = ClientDB.GetClients();
            managerPage.Clients.AddCollection(clients);
            ChangePage();
            
        }

        private void ConsultantButtonClick(object sender, RoutedEventArgs e)
        {
            var clients = ClientDB.GetClients();
            consultantPage.Clients.AddCollection(clients);
            ChangePage();
        }


        private void ExitWindow(object sender, RoutedEventArgs e)
        {
            this.Closing += managerPage.AccountWindow.CloseWindow;
            Close();
        }

        private void ChangePage()
        {
            if (!managerPageIsOpen)
            {
                mainFrame.Content = managerPage;
                consultantPageIsOpen=false;
                managerPageIsOpen = true;
            }
            else if (!consultantPageIsOpen)
            {
                mainFrame.Content = consultantPage;
                consultantPageIsOpen = true;
                managerPageIsOpen = false;
            }
        }

    }
    public static class ObservableCollectionExtension
    {
        public static void AddCollection<T>(this ObservableCollection<T> thisCollection, ObservableCollection<T> otherCollection)
        {
            foreach (var item in otherCollection)
            {
                if (!thisCollection.Contains(item))
                    thisCollection.Add(item);
            }
        }
    }
}

