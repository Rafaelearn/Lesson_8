using System;
using System.IO;

namespace TaskManager
{
    class Report
    {
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
        public Employee Author { get; private set; }
        public Report(string text, Employee employee)
        {
            Text = text;
            Author = employee;
            Date = DateTime.Now;
        }
        public Report(FileInfo file, Employee employee)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                Text = reader.ReadToEnd();
            }
            Author = employee;
            Date = DateTime.Now;
        }
        public void Display()
        {
            Console.WriteLine($"Author: {Author} Time: {Date.ToShortDateString()} {Date.ToLongTimeString()}");
            Console.WriteLine("Report: ");
            Console.WriteLine(Text);
        }
    }
}
