using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Java;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StarostinKD_ZIVT_251_OOP4
{
    interface Student_Interface
    {
        string GetStudentInfo();
        bool GetDecision();
    }
    public class Student : Student_Interface
    {

        public string Surname;
        public string Name;
        public string Group;

        public Dictionary<string, int> Marks;

        public bool Deduction = false;

        private static string[] Groups = { "ЗИВТ-251", "ЗИВТ-252", "ЗИВТ-253" };
        private static string[] Subjects = { "Программирование", "Философия", "Сети", "Методы оптимизации"};
        // Задача 1.1 Создать массив фамилий
        public static string[] Surnames = {"Старостин", "Лепилина", "Дзигилевич", "Якушина", "Буняк", "Петренко", "Жмайло",
            "Наместникова", "Еремина", "Мамро", "Какенов", "Гребенюк", "Акишев", "Гришаева", "Терещенок", "Никитин",
            "Зубковский", "Рогожин", "Карпова", "Маляш"};
        // Задача 1.2 Создать массив имен
        public static string[] Names = {"Кирилл", "Полина", "Арина", "Юлия", "Андрей", "Евгений", "Александр", "Екатерина", "Галина",
            "Михаил", "Ильяс", "Павел", "Дияз", "Дарья", "Сергей", "Андрей", "Даниил", "Вадим", "Валентина", "Максим"};

        // Конструкторы
        public Student()
        {
            var Student = GenerateStudent();

            Surname = Student.Surname;
            Name = Student.Name;
            Group = Student.Group;
            Marks = Student.Marks;
        }
        public Student(string surname, string name, string group, Dictionary<string,int> marks)
        {
            Surname = surname;
            Name = name;
            Group = group;
            Marks = marks;
        }

        // Метод получения информации о студенте
        public string GetStudentInfo()
        {
            string info = $"Фамилия: {Surname}\nИмя: {Name}\nГруппа: {Group}\nОценки:\n";
            foreach (var Mark in Marks)
            {
                info +=  $"{Mark.Key} - {Mark.Value}\n";
            }
            return info;
        }

        // Метод определения отчисления
        public bool GetDecision()
        {
            int Points = 0;
            bool Mark2 = false;
            double AverageMark;
            foreach(int Mark in Marks.Values)
            {
                Points += Mark;
                if (Mark == 2)
                {
                    Mark2 = true;
                }
            }
            AverageMark = (double)Points / Marks.Count;

            bool lowAVG = AverageMark < 3.5;
            bool Deduction = lowAVG || Mark2;
            return Deduction;

        }

        // Метод создания рандомного студента
        private static readonly Random random = new Random();
        public static Student GenerateStudent()
        {
            string Surname = Surnames[random.Next(Surnames.Length)];
            string Name = Names[random.Next(Names.Length)];
            string Group = Groups[random.Next(Groups.Length)];
            Dictionary<string, int> Marks = new Dictionary<string, int>();

            foreach(string subject in Subjects)
            {
                Marks.Add(subject, random.Next(2,6));
            }
            return new Student (Surname, Name, Group, Marks);
        }
    }
}
