// Задача 1.3 Объединить массивы (четные имена, нечетные фамилии)
//Создаем 3ий массив для объединения
using StarostinKD_ZIVT_251_OOP4;
using System.Diagnostics.Tracing;

string[] SurnamesNames = new string[Student.Surnames.Length + Student.Names.Length];
// Устанавливаем по четным индексам имена, по нечетным фамилии
for (int i = 0; i < Student.Surnames.Length; i++)
{
    SurnamesNames[i*2] = Student.Names[i];
    SurnamesNames[i*2+1] = Student.Surnames[i];
}
// Выводим полученный массив в формате Имя-пробел-Фамилия-новая строка
for (int i=0; i<SurnamesNames.Length; i++)
{
    if (i % 2 == 0)
    {
        Console.Write(SurnamesNames[i] + " ");
    }
    else
    {
        Console.WriteLine(SurnamesNames[i]);
    }
}
// Задача 2 Отсортировать массив фамилий пузырьком, хотя гораздо проще было использовать Array.Sort(Surnames)
string temp;
for (int i = 0; i < Student.Surnames.Length; i++)
{
    for (int j = 0; j < Student.Surnames.Length - 1 - i; j++)
    {
        if (string.Compare(Student.Surnames[j], Student.Surnames[j + 1], StringComparison.OrdinalIgnoreCase) > 0)
        {
            temp = Student.Surnames[j];
            Student.Surnames[j] = Student.Surnames[j + 1];
            Student.Surnames[j + 1] = temp;
        }
    }
}
//Array.Sort(Surnames);
// Выводим отсортированный массив
for (int i=0; i<Student.Surnames.Length;i++)
{
    Console.WriteLine(Student.Surnames[i]);
}
Console.WriteLine();

// Задача 3

Student student1 = new Student();
Console.WriteLine(student1.GetStudentInfo());

// Создаем список студентов
List<Student> students = new List<Student>();

// Генерируем 100 случайных студентов
Console.WriteLine("Генерация студентов...");
for (int i = 0; i < 100; i++)
{
    Student student = new Student();
    students.Add(student);
}
Console.WriteLine("Студенты созданы.\n");

// Отчисляем
QueueDeduction queue1 = new QueueDeduction(students);
queue1.StartDeduction();
Console.WriteLine();

// Задача 4

Dictionary<string, string> EngRusDict = new Dictionary<string, string>();
EngRusDict.Add("apple", "яблоко");
EngRusDict.Add("book", "книга");
EngRusDict.Add("car", "машина");
EngRusDict.Add("dog", "собака");
EngRusDict.Add("house", "дом");
EngRusDict.Add("sun", "солнце");
EngRusDict.Add("moon", "луна");
EngRusDict.Add("star", "звезда");
EngRusDict.Add("water", "вода");
EngRusDict.Add("fire", "огонь");

Console.WriteLine("Словарь:");
foreach (var word in EngRusDict)
{
    Console.WriteLine($"{word.Key} - {word.Value}");
}

// Задача 5

// Создаем список студентов
Student[] studentsArr = new Student[100];

// Генерируем 100 случайных студентов
Console.WriteLine("Генерация студентов...");
for (int i = 0; i < 100; i++)
{
    Student student = new Student();
    studentsArr[i] = student;
}
Console.WriteLine("Студенты созданы.\n");

// Отчисляем
ArrayWrapper arraystudents = new ArrayWrapper(studentsArr);
arraystudents.StartDeduction();
Console.WriteLine();