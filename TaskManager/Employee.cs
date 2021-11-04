namespace TaskManager
{
    using System;
    enum TypeAnswer
    {
        Accept,
        Delegate,
        Reject
    }
    class Employee : Person
    {
        static Random random = new Random();
        static private int lastID = 0;
        public int ID { get; private set; }
        public Employee(string name):base(name)
        {
            ID = lastID;
            lastID++;
        }
        public override void Display()
        {
            Console.WriteLine($"{ID} {Name}");
        }
        public TypeAnswer GetAnswer()
        {
            //Так как это мат. модель то предполагаем, что сотрудник отвечает 50 процентов принял 15 делегировал 35 откланил
            int randChoise = random.Next(0, 100);
            if (randChoise < 50)
            {
                return TypeAnswer.Accept;
            }
            else if (randChoise <65)
            {
                return TypeAnswer.Delegate;
            }
            else
            {
                return TypeAnswer.Reject;
            }
        }
    }
}
