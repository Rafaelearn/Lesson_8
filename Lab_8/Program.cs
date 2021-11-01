using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    enum TypeAccount
    {
        accountCurrent = 1,
        accountSavings
    }
    class Account
    {
        Random random = new Random();
        static ulong lastNumber = 4364_2868_4768_0000;
        public ulong Number { get; private set; }
        public TypeAccount Type { get; set; }
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine("Баланс не может быть отрицательным. Баланс: 0$");
                }
                else
                {
                    balance = value;
                }
            }
        }

        public Account(TypeAccount type, decimal balance)
        {
            Type = type;
            Balance = balance;
            Number += lastNumber + (ulong)random.Next(1, 10);
            lastNumber = Number;
        }
        public Account(TypeAccount type) : this(type, 0)
        {
        }
        public bool Withdraw(decimal money)
        {
            if (money > Balance)
            {
                return false;
            }
            else
            {
                Balance -= money;
                return true;
            }
        }
        public void PutMoney(decimal money)
        {
            if (money <= 0)
            {
                Console.WriteLine("Операцию произвести невозможно! Сумма должна быть больше 0");
            }
            Balance += money;
        }
        public bool PutMoneyFromAccount(ref Account account, decimal money)
        {
            if (!account.Withdraw(money))
            {
                return false;
            }
            else
            {
                Balance += money;
                return true;
            }
        }
        public void Display()
        {
            Console.WriteLine("Информация о счете:\n" + $"{Type}\t{Number}\t{balance}$");
        }
        public override string ToString()
        {
            return $"{Type}\t{Number}\t{balance}$";
        }
    }
    class BankTransaction
    {

    }
    class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song PrevSong { get; set; } = null;

        public Song(string name, string author) : this(name, author, null)
        {

        }
        public Song(string name, string author, Song song)
        {
            Name = name;
            Author = author;
            PrevSong = song;
        }
        public string Title()
        {
            return Name + " " + Author;
        }
        public void Dispay()
        {
            Console.WriteLine($"\"{Name}\" by {Author}");
        }
        public override bool Equals(Object obj)
        {
            Song songEqual = obj as Song;
            if (Title().Equals(songEqual.Title()))
            {
                return true;
            }
            return false;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
