using System;
using System.Collections.Generic;

namespace TaskManager
{
    enum StatusProject
    {
        Project = 0,
        Execution,
        Closed
    }
    class Project
    {
        public string Discription { get; set; }
        public List<Task> Tasks { get;  set; } = new List<Task>();
        public Customer Customer { get;private set; }
        public Employee TeamLeader { get; set; }
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
        public StatusProject Status { get; private set; } = StatusProject.Project;
        public Project(string discription, DateTime deadLine, Employee teamLider, Customer customer)
        {
            Discription = discription;
            Customer = customer;
            TeamLeader = teamLider;
            DeadLine = deadLine;
        }

        public void AddTask(string discription, DateTime deadLine)
        {
            if (Status != StatusProject.Project)
            {
                Console.WriteLine("Невозможно задать задачу");
            }
            else
            {
                Tasks.Add(new Task(discription, deadLine, TeamLeader));
            }
        }
        public void Start()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Status != StatusTask.InWork)
                {
                    Tasks.RemoveAt(i);  
                }
            }
        }
        public void AddReport(int indTask, string text)
        {
            if (indTask < Tasks.Count)
            {
                Tasks[indTask].AddReport(text, Customer);
            }
            else
            {
                Console.WriteLine("Такой задачи не существует...");
            }
        }
        public void ShowNoAppointedTask()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Status != StatusTask.InWork)
                {
                    Console.WriteLine($"{i}) {Tasks[i].Status} {Tasks[i].Discription}");
                }
            }
        }
        public void TryFinish()
        {
            foreach (var item in Tasks)
            {
                if (item.Status != StatusTask.Closed)
                {
                    return;
                }
            }
            Status = StatusProject.Closed;
        }
        public void Display()
        {
            Console.WriteLine("Вся информация по проекту: ");
            Console.WriteLine(Discription);
            Console.WriteLine($"Status project: {Status}");
            Console.WriteLine($"TeamLeader: {TeamLeader}");
            Console.WriteLine($"Customer: {Customer}");
            Console.WriteLine($"List Tasks: ");
            foreach (var item in Tasks)
            {
                item.Display();
            }
        }
    }
}
