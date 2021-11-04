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
        public Person Customer { get;private set; }
        public Person TeamLeader { get; set; }
        public DateTime Deadline { get; set; }
        public StatusProject Status { get; private set; } = StatusProject.Project;

        public Project(string discription, DateTime deadLine, Person teamLider, Person customer)
        {
            Discription = discription;
            Customer = customer;
            TeamLeader = teamLider;
            Deadline = deadLine;
        }

        public void AddTask(string discription, DateTime deadLine)
        {
            Tasks.Add(new Task(discription, deadLine, TeamLeader));
        }

        public void Display()
        {
            Console.WriteLine(Discription);
            Console.WriteLine($"TeamLeader: {TeamLeader}");
            Console.WriteLine($"Customer: {Customer}");
        }
    }
}
