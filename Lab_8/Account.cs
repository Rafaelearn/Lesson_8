using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_8
{
    enum TypeAccount
    {
        accountCurrent = 1,
        accountSavings
    }
    class Account:IDisposable
    {
        Random random = new Random();
        static ulong lastNumber = 4364_2868_4768_0000;
        public ulong Number { get; private set; }
        public TypeAccount Type { get; set; }
        private  Queue<BankTransaction> transactions = new Queue<BankTransaction>();
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
                transactions.Enqueue(new BankTransaction(-money));
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
            transactions.Enqueue(new BankTransaction(money));
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
                transactions.Enqueue(new BankTransaction(money));
                return true;
            }
        }
        public void Display()
        {
            Console.WriteLine("Информация о счете:\n" + $"{Type}\t{Number}\t{balance}$");
        }
        public void Dispose()
        {
            using (StreamWriter fileWriter = new StreamWriter(@"..\..\resource\output.txt", false))
            {
                while (transactions.Count != 0)
                {
                    fileWriter.WriteLine(transactions.Dequeue().ToString());
                }
            }
            GC.SuppressFinalize(this);
        }
        public override string ToString()
        {
            return $"{Type}\t{Number}\t{balance}$";
        }
    }
}
