using System;
using System.Collections.Generic;
using System.IO;

namespace TaskManager
{
    // Do interface 
    enum StatusTask
    {
        Appointed,
        Rejected,
        Delegated,
        InWork,
        Closed
    }
    class Task
    {
        public string Discription { get;private set; }
        public List<Report> Reports { get; private set; } = new List<Report>();
        public Employee Appointer { get; private set; }
        public Employee Receiver { get; set; } = null;
        private DateTime deadLine;
        public DateTime DeadLine
        {
            get { return deadLine; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new FormatException("Невозможно задать уже просроченный проект!");
                }
                deadLine = value;
            }
        }
        public StatusTask Status { get; private set; } = StatusTask.Appointed;
        public Task(string discription, DateTime deadline, Employee appointer)
        {
            Discription = discription;
            DeadLine = deadline;
            Appointer = appointer;
        }
        public bool Appoint(Employee employee)
        {
            if (Status == StatusTask.InWork)
            {
                Console.WriteLine("Задача уже назначена");
                return false;
            }
            else
            {
                TypeAnswer answer = employee.GetAnswer();
                if (answer == TypeAnswer.Accept)
                {
                    Console.WriteLine($"Cотрудник {employee.Name} принял задачу {Discription}");
                    Status = StatusTask.InWork;
                    Receiver = employee;
                }
                else if (answer == TypeAnswer.Delegate)
                {
                    //2 раза делегировать задачу невозможно
                    Console.WriteLine($"Cотрудник {employee.Name}  делегирует задачу {Discription} следующему сотруднику");
                    if (Status == StatusTask.Delegated)
                    {
                        Status = StatusTask.Rejected;
                        return  true;
                    }
                    Status = StatusTask.Delegated;
                    return false;
                }
                else
                {
                    Console.WriteLine("Задача откланена");
                    Status = StatusTask.Rejected;
                }
                return true;
            }
        }
        public void AddReport(string text, Customer customer)
        {
            if (customer.GetAnswerOnReport())
            {
                Reports.Add(new Report(text, Receiver));
                Console.WriteLine($"Отчет по задаче {Discription} утвержден!");
                Status = StatusTask.Closed;
            }
            else
            {
                Console.WriteLine($"{customer.Name} не утверждает отчет по задаче {Discription}!");
            }

        }
        public void Display()
        {
            Console.WriteLine("Description: ");
            Console.WriteLine(Discription);
            Console.WriteLine($"Appointer: {Appointer}");
            Console.WriteLine($"Receiver: {Receiver}");
            Console.WriteLine("Reports: ");
            foreach (var item in Reports)
            {
                item.Display();
            }
            if (Reports.Count == 0)
            {
                Console.WriteLine("NO");
            }
        }

    }
}
