using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_8
{
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
}
