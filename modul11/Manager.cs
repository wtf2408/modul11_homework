using System.Collections.ObjectModel;


namespace modul11
{
    public class Manager
    {

        public void AddClient(ObservableCollection<Client> clients)
        {
            clients.Add(new Client());
        }

        public void SetClientProrerty(ObservableCollection<Client> clients,
            int id,
            string firstName,
            string lastName,
            string phoneNumber,
            string passport)
        {
            clients[id].FirstName = firstName;
            clients[id].LastName = lastName;
            clients[id].PhoneNumber = phoneNumber;
            clients[id].Passport = passport;

        }


}
}
