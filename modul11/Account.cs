using System;
using System.ComponentModel;

namespace modul11
{
    public class Account : IAccount<float>, INotifyPropertyChanged
    {
        public readonly string AccoutType = "Недепозитный";
        public Account(float sum)
        {
            balance = sum;
        }
        private float balance;
        public float Balance 
        { 
            get => balance; 
            set 
            { 
                balance = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Balance))); 
            } 
        }


        public void TopUp(IAccount<float> account, float amount) 
        {
            account.Balance = account.Balance - amount;
            this.Balance += amount;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

    }

    public class DepositAccount : IAccount<double>
    {
        public readonly string AccoutType = "Депозитный";

        public DepositAccount(double depositSum) 
        { 
            balance = depositSum;
        }
        private double balance;
        public double Balance
        {
            get => balance;
            set
            {
                balance = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Balance)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

    public interface IAccount<T>
    {
        public T Balance { get; set; }
    }




    

}
