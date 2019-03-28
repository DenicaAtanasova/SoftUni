
namespace MyApp.Commands
{
    using MyApp.Commands.Contracts;
    using MyApp.Data;
    using System;
    using System.Linq;

    public class SetAddressCommand : ICommand
    {
        private readonly MyAppContext context;

        public SetAddressCommand(MyAppContext context)
        {
            this.context = context;
        }

        public string Execute(string[] inputArguments)
        {
            if (inputArguments.Length != 2)
            {
                throw new ArgumentException("You must enter employeeId and address");
            }

            var employeeId = int.Parse(inputArguments[0]);
            var employeeAddress = inputArguments[1];

            var employee = this.context.Employees
                .Where(e => e.EmployeeId == employeeId)
                .FirstOrDefault();

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id {employeeId} does not exist!");
            }

            employee.Address = employeeAddress;
            context.SaveChanges();

            return $"Set address: {employee.Address} to Employee: {employee.FirstName} {employee.LastName}";
        }
    }
}
