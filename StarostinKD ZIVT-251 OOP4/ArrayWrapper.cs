using System;
using System.Collections.Generic;
using System.Text;

namespace StarostinKD_ZIVT_251_OOP4
{
    public class ArrayWrapper
    {
        private Student[] students;
        private int count;          // Текущее количество элементов
        private int capacity;       // Максимальная вместимость

        // Конструктор - создает массив из списка студентов
        public ArrayWrapper(Student[] initialStudents)
        {
            capacity = initialStudents.Length;
            students = new Student[capacity];
            count = 0;

            foreach (var student in initialStudents)
            {
                Add(student);
            }
        }

        // Индексатор - позволяет обращаться к элементам по индексу
        public Student this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException($"Индекс {index} вне диапазона (0-{count - 1})");

                return students[index];
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new IndexOutOfRangeException($"Индекс {index} вне диапазона (0-{count - 1})");

                students[index] = value;
            }
        }

        // Добавление студента в массив
        public bool Add(Student student)
        {
            if (count >= capacity)
            {
                // Увеличиваем массив, если места недостаточно
                Resize();
            }

            students[count] = student;
            count++;
            return true;
        }

        // Увеличение размера массива
        private void Resize()
        {
            capacity *= 2;
            Student[] newArray = new Student[capacity];
            Array.Copy(students, newArray, count);
            students = newArray;
        }

        // Удаление элемента по индексу
        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                return false;

            // Сдвигаем элементы влево
            for (int i = index; i < count - 1; i++)
            {
                students[i] = students[i + 1];
            }

            students[count - 1] = null;
            count--;
            return true;
        }

        // Удаление элемента по значению
        public bool Remove(Student student)
        {
            int index = IndexOf(student);
            if (index == -1)
                return false;

            return RemoveAt(index);
        }

        // Поиск индекса студента
        public int IndexOf(Student student)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i] == student)
                    return i;
            }
            return -1;
        }

        // Вывод всех элементов
        public void PrintAll(string title = "Массив студентов")
        {
            Console.WriteLine($"\n=== {title} ===");
            Console.WriteLine($"Всего: {count}\n");

            if (count == 0)
            {
                Console.WriteLine("Массив пуст");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"[{i}] {students[i].GetStudentInfo()}");
            }
        }
        // Метод отчисления
        public void StartDeduction()
        {
            int countDeduction = 0;
            foreach (var student in students)
            {
                if (student.GetDecision()==true)
                {
                    // Отмечаем как отчисленного
                    student.Deduction = true;
                    countDeduction++;
                    Console.WriteLine($"Отчислен: {student.Surname} {student.Name}");
                }
            }

            Console.WriteLine($"\nВсе студенты отчислены");
            Console.WriteLine($"Студентов отчислено: {countDeduction} из {count}");
        }
    }
}
