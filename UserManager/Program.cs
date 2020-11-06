using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManager
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag = true;
            ContrillerStudent contrillerStudent = new ContrillerStudent();
            Run();
            while (flag)
            {
                Console.WriteLine("Введите команду");
                Console.WriteLine("* - для выхода");
                Console.WriteLine("s - add User");
                Console.WriteLine("del - add User");

                Console.WriteLine();
                string s = Console.ReadLine();

                switch (s)
                {
                    case "*": flag = false; break;
                    case "s": Console.WriteLine(); AddUser(); break;
                    case "del": Console.WriteLine(); DellUSer(); break;
                }
            }
        }

        private static void DellUSer()
        {
            ContrillerStudent contrillerStudent = new ContrillerStudent();
            Console.WriteLine("Введите Имя");
            string name = Console.ReadLine();

            contrillerStudent.DellUser(name);
            Console.Clear();
            Run();
        }

        private static void AddUser()
        {
            ContrillerStudent contrillerStudent = new ContrillerStudent();
            Console.WriteLine("Введите Имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите Возрост");
            string age = Console.ReadLine();

            contrillerStudent.Add(name, age);
            Console.Clear();
            Run();
        }

        private static void Run()
        {
            ContrillerStudent contrillerStudent = new ContrillerStudent();

            for (int i = 0; i < contrillerStudent.Students.Count; i++)
            {
                Console.WriteLine(contrillerStudent.Students[i]);
            }
            Console.WriteLine("________________________________");
        }
    }
}