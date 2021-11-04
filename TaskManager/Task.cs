using System;
using System.Collections.Generic;
using System.IO;

namespace TaskManager
{
    // Do interface 
    enum StatusTask
    {
        NoAppointed = 0,
        Appointed,
        InWork,
        Closed
    }
    class Task
    {
        public string Discription { get;private set; }
        public List<Report> Reports { get; private set; } = new List<Report>();
        public Person Appointer { get; private set; }
        public Person Receiver { get; set; }
        public DateTime Deadline { get; set; }
        public StatusTask Status { get; set; } = StatusTask.NoAppointed;

        public Task(string discription, DateTime deadline, Person appointer)
        {
            Discription = discription;
            Deadline = deadline;
            Appointer = appointer;
        }
        public void AddReport(FileInfo file)
        {
            Reports.Add(new Report(file, Receiver));
        }
        public void Display()
        {
            Console.WriteLine("Description: ");
            Console.WriteLine(Discription);
            Console.WriteLine($"Appointer: {Appointer}"); // Подсказка от  VS2021
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
