using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace P08MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<Student> studentsList = new List<Student>();

            while ((input = Console.ReadLine()) != "end of dates")
            {
                string[] users = input.Split(new char[] { ' ', ',' }).ToArray();
                string name = users[0];
                List<DateTime> dates = new List<DateTime>();
                Student student = new Student();

                if (studentsList.Any(x => x.Name == name))
                {
                    var currentStudent = studentsList.First(x => x.Name == name);
                    for (int i = 1; i < users.Length; i++)
                    {
                        DateTime date = DateTime.ParseExact(users[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        dates.Add(date);
                    }
                    currentStudent.AttendancyDate.AddRange(dates);
                }
                else
                {
                    student.Name = name;
                    for (int i = 1; i < users.Length; i++)
                    {
                        DateTime date = DateTime.ParseExact(users[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        dates.Add(date);
                    }
                    student.AttendancyDate = dates;
                    studentsList.Add(student);
                }
                
            }

            
            while ((input = Console.ReadLine()) != "end of comments")
            {
                string[] usersComments = input.Split('-').ToArray();
                string userName = usersComments[0];
                string comment = usersComments[1];

                if (studentsList.Any(x => x.Name == userName) && studentsList.Find(x => x.Name == userName).Comments == null)
                {
                    studentsList.Find(x => x.Name == userName).Comments = new List<string>();
                    studentsList.Find(x => x.Name == userName).Comments.Add(comment);
                }
                else if (studentsList.Any(x => x.Name == userName) && studentsList.Find(x => x.Name == userName).Comments != null)
                {
                    studentsList.Find(x => x.Name == userName).Comments.Add(comment);
                }    

            }

            foreach (var student in studentsList.OrderBy(x => x.Name))
            {
                Console.WriteLine(student.Name + Environment.NewLine + "Comments:");
                if (student.Comments != null)
                {
                    foreach (var comment in student.Comments)
                    {
                        Console.WriteLine($"- {comment}");
                    }
                }
               
                Console.WriteLine("Dates attended:");
                foreach (var date in student.AttendancyDate.OrderBy(x => x.Date))
                {
                    Console.WriteLine("-- {0}", date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                }
            }
        }

    }
    class Student
    {
        public string Name { get; set; }      
        public List<DateTime> AttendancyDate { get; set; }
        public List<string> Comments { get; set; }
    }
}
