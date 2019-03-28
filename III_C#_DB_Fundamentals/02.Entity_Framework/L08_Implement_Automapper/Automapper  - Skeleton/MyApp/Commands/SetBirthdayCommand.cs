
namespace MyApp.Commands
{
    using Contracts;
    using Data;
    using System;
    using System.Linq;

    public class SetBirthdayCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetBirthdayCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArguments)
        {
            if (inputArguments.Length != 2)
            {
                throw new ArgumentException("You must enter employeeId and date of birth!");
            }

            var employeeId = int.Parse(inputArguments[0]);
            var date = DateTime.ParseExact(inputArguments[1], "dd-MM-yyyy", null);

            var employee = this.context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .FirstOrDefault();

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} does not exist!");
            }

            employee.Birthday = date;
            context.SaveChanges();

            return $"Set day of birth: {employee.Birthday} to Employee: {employee.FirstName} {employee.LastName}";
        }
    }
}
