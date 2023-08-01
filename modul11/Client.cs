

namespace modul11
{
    public class Client
    {
        public static int lastID;
        static Client()
        {
            lastID = 0;
        }

        public Client()
        {
            ID = ++lastID;
        }
        public Client(int id, string firstName, string lastName, string passport, string phoneNumber)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Passport = passport;
            PhoneNumber = phoneNumber;
            
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Passport { get; set; }
        public string PhoneNumber { get; set; }


    }
}
