using System;
using System.Collections.Generic;
using System.Linq;

namespace L02_Average_Student_Grades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var studentsWithGrades = new Dictionary<string, List<double>>();

            while (n-- > 0)
            {
                var input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var student = input[0];
                var grade = double.Parse(input[1]);

                if (!studentsWithGrades.ContainsKey(student))
                {
                    studentsWithGrades.Add(student, new List<double>());
                }

                studentsWithGrades[student].Add(grade);
            }

            foreach (var student in studentsWithGrades)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => string.Format("{0:F2}", x)))} (avg: {student.Value.Average():F2})");

            }
        }
    }
}
