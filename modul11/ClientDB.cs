using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace modul11
{
    static class ClientDB
    {
        static string path = @"D:\\modul11_homework_clients.json";

        public static ObservableCollection<Client> GetClients()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    string clients = sr.ReadToEnd();
                    ObservableCollection<Client> result = JsonConvert.DeserializeObject<ObservableCollection<Client>>(clients) ?? new ObservableCollection<Client>();
                    return result;
                }
            }
        }


        public static void SaveChange(ObservableCollection<Client> clients)
        {
            using (StreamWriter sw  = new StreamWriter(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(clients));
            }
        }
    }
}
