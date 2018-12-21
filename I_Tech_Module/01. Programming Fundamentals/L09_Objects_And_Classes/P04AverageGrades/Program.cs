using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04AverageGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> studentsList = new List<Student>();

            while (n-- > 0)
            {
                string [] input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                double[] grades = input.Skip(1).Select(double.Parse).ToArray();

                Student student = new Student();
                student.StudentGrades = new List<double>();

                student.StudentName = name;

                foreach (double grade in grades)
                {
                    student.StudentGrades.Add(grade);
                }
                studentsList.Add(student);
            }
            foreach (var excellentStudent in studentsList
                                                    .Where(x => x.StudentAvarageGrade >= 5.0)
                                                    .OrderBy(x => x.StudentName)
                                                    .ThenByDescending(x => x.StudentAvarageGrade))
            {
                Console.WriteLine($"{excellentStudent.StudentName} -> {excellentStudent.StudentAvarageGrade:F2}");
            }
        }

        class Student
        {
            public string StudentName { get; set; }
            public List<double> StudentGrades { get; set; }
            public double StudentAvarageGrade => StudentGrades.Average();
        }
    }
}
