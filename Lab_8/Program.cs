using System;
using System.Collections.Generic;
using System.IO;
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
        public Account(decimal balance) : this(TypeAccount.accountCurrent, balance)
        {
        }
        public Account() : this(TypeAccount.accountCurrent, 0)
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
                BankTransaction  transaction = new BankTransaction(money);
                return true;
            }
        }
        public void PutMoney(decimal money)
        {
            if (money <= 0)
            {
                Console.WriteLine("Операцию произвести невозможно! Сумма должна быть больше 0");
                return;
            }
            Balance += money;
            BankTransaction transaction = new BankTransaction(money);
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
                BankTransaction transaction = new BankTransaction(money);
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
        private static Queue<BankTransaction> transactions = new Queue<BankTransaction>();
        public readonly DateTime dateTime;
        public readonly decimal balance;
        public BankTransaction(decimal balance)
        {
            this.balance = balance;
            dateTime = new DateTime();
            transactions.Enqueue(this);
        }
        public override string ToString()
        {
            return $"{dateTime.ToShortDateString()} {dateTime.ToLongTimeString()} {balance}";
        }
        public void Dispose()
        {
            if (!File.Exists(@"output.txt"))
            {
                File.Create( @"output.txt");
            }
            using (StreamWriter fileWriter = new StreamWriter(@"output.txt", false))
            {
                while (transactions.Count != 0)
                {
                    fileWriter.WriteLine(transactions.Dequeue().ToString());
                }
            }
            GC.SuppressFinalize(this);
        }
    }
    class Song
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public Song PrevSong { get; set; } = null; // Чтобы конструктор Song() не выдал ошибки

        public Song()
        {
            //Без данного конструктора возникнет ошибка.... Song mySong = new Song();
        }
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
            DoTask();
            //DoHomeTask1();
        }
        static void DoTask()
        {
            Account account1 = new Account(TypeAccount.accountCurrent, 100);
            Account account2 = new Account(TypeAccount.accountSavings, 200);
            account2.PutMoneyFromAccount(ref account1, 50);
            account1.PutMoney(100);
            account2.Withdraw(75);
        }
        static void DoHomeTask1()
        {
            //Test ctor
            Song song1 = new Song();
            Song song2 = new Song("Хабиб", "Ягода малинка");
            Song song3 = new Song("Клава Кока", "Пьяную домой", song2);
            song1.Dispay();
            song2.Dispay();
            song3.Dispay();
        }

    }
}
