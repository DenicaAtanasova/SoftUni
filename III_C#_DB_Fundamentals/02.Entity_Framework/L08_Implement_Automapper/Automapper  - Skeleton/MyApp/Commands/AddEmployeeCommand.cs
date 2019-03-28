
namespace MyApp.Commands
{
    using AutoMapper;
    using Contracts;
    using Core.ViewModels;
    using Data;
    using Models;
    using System;

    public class AddEmployeeCommand : ICommand
    {
        private readonly MyAppContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(MyAppContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] inputArguments)
        {
            if(inputArguments.Length != 3)
            {
                throw new ArgumentException("You must enter firstname, lastname and salary!");
            }

            var firstName = inputArguments[0];
            var lastName = inputArguments[1];
            var salary = decimal.Parse(inputArguments[2]);

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return $"Registered employee {firstName} {lastName}";
        }
    }
}
