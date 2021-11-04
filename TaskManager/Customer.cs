namespace TaskManager
{
    using System;

    class Customer : Person
    {
        static Random random = new Random();
        public ulong PhoneNumber { get; private set; }
        private string email;
        public string Email
        {
            get { return email; }
            private set
            {
                value.Trim();
                if (!value.Contains("@") || value.Contains(" "))
                {
                    throw new FormatException($"Customer {Name} have wrong format email-string");
                }
                email = value;
            }
        }

        public Customer(string name, ulong number, string email):base(name)
        {
            PhoneNumber = number;
            Email = email;
        }
        public Customer()
        {
            Console.WriteLine("Введите имя заказчика: ");
            Name = Console.ReadLine();
            Console.Write("Введите номер Заказчика: ");
            if (!ulong.TryParse(Console.ReadLine(), out ulong number))
            {
                throw new FormatException($"Customer {Name} have wrong format email-string");
            }
            Console.Write("Введите адрес электронной почты: ");
            Email = Console.ReadLine();
        }
        public override void Display()
        {
            Console.WriteLine($"{Name} Контактные данные: {PhoneNumber} {Email}");
        }
        public bool GetAnswerOnReport()
        {
            //75 % процентов, что отчет будет принят 
            return random.Next(100) < 75; 
        }
    }
}
