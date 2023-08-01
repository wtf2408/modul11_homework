using System.Collections.ObjectModel;

namespace modul11
{
    public class Consultant
    {
        public void SetClientPhone(ObservableCollection<Client> clients, int id, string phoneNumber)
        {
            clients[id].PhoneNumber = phoneNumber;
        }
    }
}