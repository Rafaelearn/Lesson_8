using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    class Program
    {
        private const string PathToTeamList = @"..\..\Resourses\Team.txt";

        static void Main(string[] args)
        {
            Project project = new Project("discription project 1", new DateTime(), new Person("Jason"), new Person("Linda"));
            List<Person> listEmp = new List<Person>(); 
            using (StreamReader reader = new StreamReader(PathToTeamList))
            {
                string[] dates;
                while ((dates = reader.ReadLine().Split()) != null)
                {
                    if (dates.Length != 1)
                    {
                        throw new FormatException("Wrong the format of date in Team.txt");
                    }
                    listEmp.Add(new Person(dates[0]));
                }
            }

        }
    }
}
