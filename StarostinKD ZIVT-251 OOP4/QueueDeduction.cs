using System;
using System.Collections.Generic;
using System.Text;

namespace StarostinKD_ZIVT_251_OOP4
{
    public class QueueDeduction
    {
        private Queue<Student> DeductionQueue;
        private List<Student> ListStudents;
        private int CountStudents;

        // Конструктор
        public QueueDeduction(List<Student> students)
        {
            DeductionQueue = new Queue<Student>();
            ListStudents = students;
            CountStudents = students.Count;
            ListStudents = Selection();
            foreach(Student student in ListStudents)
            {
                DeductionQueue.Enqueue(student);
            }
        }

        // Метод формирования списка на отчисление
        public List<Student> Selection()
        {
            for (int i = ListStudents.Count-1; i>=0; i--)
            {
                if (ListStudents[i].GetDecision() == false)
                {
                    ListStudents.RemoveAt(i);
                }
            }
            return ListStudents;
        }

        // Метод отчисления
        public void StartDeduction()
        {
            while (DeductionQueue.Count > 0)
            {
                // Забираем первого студента из очереди
                Student student = DeductionQueue.Dequeue();

                // Отмечаем как отчисленного
                student.Deduction = true;

                Console.WriteLine($"Отчислен: {student.Surname} {student.Name}");
            }

            Console.WriteLine($"\nВсе студенты отчислены. Очередь пуста.");
            Console.WriteLine($"Студентов отчислено: {ListStudents.Count} из {CountStudents}");
        }
    }
}
