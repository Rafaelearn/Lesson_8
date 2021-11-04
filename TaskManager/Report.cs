using System;
using System.IO;

namespace TaskManager
{
    class Report
    {
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
        public Person Author { get; private set; }
        public Report(string text, Person employee)
        {
            Text = text;
            Author = employee;
            Date = new DateTime(); // Генератор даты 
        }
        public Report(FileInfo file, Person employee)
        {
            using (StreamReader reader = new StreamReader(file.FullName))
            {
                Text = reader.ReadToEnd();
            }
            Author = employee;
            Date = new DateTime();
        }
        public void Display()
        {
            Console.WriteLine($"Author: {Author.ToString()} Time: {Date.ToShortDateString()} {Date.ToLongTimeString()}");
            Console.WriteLine("Report: ");
            Console.WriteLine(Text);
        }
    }
}
