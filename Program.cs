//*******************************************************************************
//* Практическая работа № 15                                                    *
//* Выполнил: Пирогов Д., группа 2ИСП                                           *
//* Задание: разработать программу агоритма решения задачи, используя структуры *
//*******************************************************************************

using System;

namespace pr15
{
    class Program
    {
        public struct Student
        {
            public string fullname;
            public string groupnumber;
            public int[] grades;
            public Student(string fullname, string groupnumber, int[] grades)
            {
                this.fullname = fullname;
                this.groupnumber = groupnumber;
                this.grades = grades;
            }
            public double Average()
            {
                int sum = 0;
                foreach (var grade in grades) sum += grade;
                return (double)sum / grades.Length;
            }
        }
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Практическая работа № 15. \nЗдравствуйте! ");
            try
            {
                Console.Write("\nВведите количество студентов: ");
                int n = int.Parse(Console.ReadLine());

                Student[] students = new Student[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nВведите информацию о {i + 1}-м студенте: ");

                    Console.Write("Фамилия и инициалы: ");
                    string fullName = Console.ReadLine();

                    Console.Write("Номер группы: ");
                    string groupNumber = Console.ReadLine();

                    int[] grades = new int[5];
                    Console.WriteLine("Успеваемость (оценки по 5 дисциплинам): ");
                    for (int j = 0; j < 5; j++)
                    {
                        Console.Write($"Оценка {j + 1}: ");
                        grades[j] = int.Parse(Console.ReadLine());
                    }
                    students[i] = new Student(fullName, groupNumber, grades);
                }

                int excellent = 0, good = 0, satisfactory = 0, unsatisfactory = 0;

                foreach (var student in students)
                {
                    double grade = student.Average();

                    if (grade >= 4.5) excellent++;
                    else if (grade >= 3.5) good++;
                    else if (grade >= 2.5) satisfactory++;
                    else unsatisfactory++;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nСтатистика по студентам:");
                Console.WriteLine($"Отличники: {((double)excellent / n) * 100:F2}%");
                Console.WriteLine($"Хорошисты: {((double)good / n) * 100:F2}%");
                Console.WriteLine($"Троечники: {((double)satisfactory / n) * 100:F2}%");
                Console.WriteLine($"Неуспевающие: {((double)unsatisfactory / n) * 100:F2}%");
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
}