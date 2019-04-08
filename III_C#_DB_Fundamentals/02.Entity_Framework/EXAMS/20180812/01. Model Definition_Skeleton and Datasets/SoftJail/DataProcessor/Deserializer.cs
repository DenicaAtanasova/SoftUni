namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departmentsDto = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var sb = new StringBuilder();

            var departments = new List<Department>();
            foreach (var departmentDto in departmentsDto)
            {
                if (!isValid(departmentDto) || !departmentDto.Cells.All(isValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentDto.Name,
                };

                context.Departments.Add(department);

                var cells = new List<Cell>();
                foreach (var dtoCell in departmentDto.Cells)
                {
                    Cell cell = new Cell()
                    {
                        CellNumber = dtoCell.CellNumber,
                        HasWindow = dtoCell.HasWindow,
                        DepartmentId = department.Id
                    };

                    cells.Add(cell);
                }

                context.Cells.AddRange(cells);
                context.SaveChanges();

                sb.AppendLine($"Imported {department.Name} with {cells.Count} cells");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersDto = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            var sb = new StringBuilder();

            foreach (var prisonerDto in prisonersDto)
            {
                if (!isValid(prisonerDto) || !prisonerDto.Mails.All(isValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var prisoner = new Prisoner
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                if(!string.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    prisoner.ReleaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }

                context.Prisoners.Add(prisoner);

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");

                var mails = new List<Mail>();
                foreach (var mailDto in prisonerDto.Mails)
                {
                    var mail = new Mail
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address,
                        PrisonerId = prisoner.Id
                    };

                    mails.Add(mail);
                }

                context.Mails.AddRange(mails);
                context.SaveChanges();
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            var officersDto = (ImportOfficerDto[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var officerDto in officersDto)
            {
                bool isValidPosition = Enum.TryParse(officerDto.Position, out Position position);
                bool isValidWeapon = Enum.TryParse(officerDto.Weapon, out Weapon weapon);

                if (!isValid(officerDto) || !isValidPosition || !isValidWeapon)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = officerDto.Name,
                    Salary = officerDto.Money,
                    Position = position,//Enum.Parse<Position>(officerDto.Position),
                    Weapon = weapon,//Enum.Parse<Weapon>(officerDto.Weapon),
                    DepartmentId = officerDto.DepartmentId,
                    OfficerPrisoners = officerDto.Prisoners
                        .Select(p => new OfficerPrisoner
                        {
                            PrisonerId = p.Id
                        })
                        .ToArray()
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        private static bool isValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}