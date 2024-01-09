//*******************************************************************************
//* Практическая работа № 15                                                    *
//* Выполнил: Пирогов Д., группа 2ИСП                                           *
//* Задание: разработать программу агоритма решения задачи, используя структуры *
//*******************************************************************************

using System;

class Student
{
    public string FullName;
    public string GroupNumber;
    public int[] Grades = new int[5];
}

class Program
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Практическая работа № 15. \nЗдравствуйте! ");
        try
        {
            Console.Write("\nВведите количество студентов: ");
            int n = Int32.Parse(Console.ReadLine());

            Student[] students = new Student[n];

            for (int i = 0; i < n; i++)
            {
                students[i] = new Student();

                Console.WriteLine($"Студент {i + 1}:");
                Console.Write("Фамилия и инициалы: ");
                students[i].FullName = Console.ReadLine();

                Console.Write("Номер группы: ");
                students[i].GroupNumber = Console.ReadLine();

                Console.WriteLine("Оценки по 5 дисциплинам:");

                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"Оценка {j + 1}: ");
                    students[i].Grades[j] = Int32.Parse(Console.ReadLine());
                }
            }

            bool flag = false;

            foreach (var student in students)
            {
                bool Excellent = Array.TrueForAll(student.Grades, grade => grade >= 4);

                if (Excellent)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nСтуденты с оценками 4 и 5:");
                    Console.WriteLine($"Фамилия и инициалы: {student.FullName}, Номер группы: {student.GroupNumber}");
                    double average = student.Grades.Average();
                    Console.WriteLine($"Средний балл: {average:F2}");
                    Console.ForegroundColor = ConsoleColor.White;
                    flag = true;
                }
            }

            if (!flag)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nНет студентов с оценками 4 и 5.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            int excellent = 0, good = 0, countstudents = students.Length;

            foreach (var student in students)
            {
                double average = student.Grades.Average();

                if (average >= 4.5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Студент: {student.FullName}, Средний балл: {average:F2}");
                    excellent++;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (average >= 4.0) good++;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nСтатистика по студентам:");
            Console.WriteLine($"Отличников: {excellent * 100 / countstudents}%");
            Console.WriteLine($"Хорошистов: {good * 100 / countstudents}%");
            Console.WriteLine($"Троечников: {(countstudents - excellent - good) * 100 / countstudents}%");
            Console.WriteLine($"Неуспевающих: {((countstudents - excellent - good) * 100) / countstudents}%");
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (FormatException fe)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка ввода \n" + fe.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nОшибка ввода \n" + e.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
