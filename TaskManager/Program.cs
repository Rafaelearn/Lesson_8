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
        static Random random = new Random();
        private const string PathToTeamList = @"..\..\Resourses\Team.txt";

        static void Main(string[] args)
        {
            Project project = new Project("discription project 1", DateTime.Now.AddDays(30), new Employee("Jason"), new Customer("Linda", 89393776955, "yeds@mail.ru"));
            ReadFromFileListEmployee(out List<Employee> team);
            Console.WriteLine("Команда разработчиков");
            foreach (var item in team)
            {
                item.Display();
            }
            // Generator and AutoDistribute for testing
            GeneratorTask(ref project);
            AutoDistributeTasks(ref project, ref team);
            StartInterfaceForTeamLider(ref project, ref team);
            GenerateReportsWhileFinishAllTasks(ref project);
            project.Display();
        }
        static void GenerateReportsWhileFinishAllTasks(ref Project project)
        {
            int j = 0;
            while (project.Status != StatusProject.Closed)
            {
                for (int i = 0; i < project.Tasks.Count; i++)
                {
                    if (project.Tasks[i].Status != StatusTask.Closed)
                    {
                        project.AddReport(i, $"#{j} report on task: {project.Tasks[i].Discription} ");
                    }
                }
                project.TryFinish();
                j++;
            }
        }
        static void StartInterfaceForTeamLider(ref Project project, ref List<Employee> team)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1. Задать задачу");
                Console.WriteLine("2. Распределить задачи");
                Console.WriteLine("_. Перевести проект в исполнение");
                Console.Write("Выбор: ");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                Console.WriteLine();
                switch (consoleKey)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Описание:");
                        string discription = Console.ReadLine();
                        Console.WriteLine("Введите количество дней на задачу: ");
                        if (!int.TryParse(Console.ReadLine(), out int addDay))
                        {
                            throw new FormatException("wrong format for addDay parametr");
                        }
                        project.AddTask(discription, DateTime.Now.AddDays(addDay));
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        project.ShowNoAppointedTask();
                        do
                        {
                            Console.Write("Введите индекс неназначенной задачи: ");
                            if (!int.TryParse(Console.ReadLine(), out int indTask) || indTask > project.Tasks.Count - 1)
                            {
                                throw new FormatException("wrong format of indTask");
                            }
                            Console.Write("Введите индекс сотрудника, которому вы хотели бы  назначить задачу: ");
                            if (!int.TryParse(Console.ReadLine(), out int indEmp) || indEmp > team.Count - 1)
                            {
                                throw new FormatException("wrong format of indEmp");
                            }
                            project.Tasks[indTask].Appoint(team[indEmp]);
                            Console.Write("Выйти(Y): ");
                        } while (!Console.ReadLine().ToUpper().Equals("Y")); ;
                        break;
                    default:
                        project.Start();
                        flag = false;
                        break;
                }
            }
        }
        static void GeneratorTask(ref Project project)
        {
            for (int i = 0; i < 20; i++)
            {
                project.AddTask($"Task {i}", DateTime.Now.AddDays(random.Next(5, 20)));
            }
        }
        static void AutoDistributeTasks(ref Project project, ref List<Employee> team)   
        {
            int i = 0;
            int j = 0;
            while (i < project.Tasks.Count)
            {
                if (project.Tasks[i].Appoint(team[j % team.Count])) 
                {
                    i++;
                }
                j++;
            }
        }
        static void ReadFromFileListEmployee(out List<Employee> listEmp)
        {
            listEmp = new List<Employee>();
            using (StreamReader reader = new StreamReader(PathToTeamList))
            {
                string date;
                while ((date = reader.ReadLine()) != null)
                {
                    listEmp.Add(new Employee(date));
                }
            }
        }
    }
}
