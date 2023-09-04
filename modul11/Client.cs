using System;
using System.ComponentModel;
using System.Windows;

namespace modul11
{
    public class Client : INotifyPropertyChanged
    {
        public static int lastID = 0;

        // конструктор для нового клиента
        public Client()
        {
            ID = ++lastID;
        }
        // конструктор для уже созданного клиента, получаемого из файла
        public Client(int id, string firstName, string lastName, string passport, string phoneNumber)
        {
            FirstName = firstName;
            ID = id;
            LastName = lastName;
            Passport = passport;
            PhoneNumber = phoneNumber;
        }
        

        public int ID { get; set; }


        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(FirstName);
            }
        }



        private string lastName;
        public string LastName
        {
            get => lastName;
            set 
            { 
                lastName = value; 
                OnPropertyChanged(LastName);
            }
        }


        private string phoneNumber;
        public string PhoneNumber
        {
            get => phoneNumber;
            set 
            { 
                phoneNumber = value;
                OnPropertyChanged(PhoneNumber);
            }
        }


        private string passport;
        public string Passport
        {
            get => passport;
            set 
            { 
                passport = value;
                OnPropertyChanged(Passport);
            }
        }

        public Account Account { get; set; }
        public DepositAccount DepositAccount { get; set; }


        public int GetAccountsCount()
        {
            return Convert.ToInt32(this.Account != null) + Convert.ToInt32(this.DepositAccount != null);
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
        public override bool Equals(object? obj)
        {
            if (obj is Client client)
                return this.ID == client?.ID;
            else return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged<T>(T property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(property)));
        }
    }

     
}
