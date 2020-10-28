namespace SoftJail.DataProcessor
{

    using Data;
    using Microsoft.EntityFrameworkCore;
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
            //Ok.
        {
            var sb = new StringBuilder();

            var dtos = JsonConvert
                .DeserializeObject<ImportDepartmentDto[]>(jsonString);

            var validDep = new List<Department>();

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var cells = new List<Cell>();

                bool isCellValid = true;

                foreach (var cell in dto.Cells)
                {
                    if (!IsValid(cell))
                    {
                        sb.AppendLine("Invalid Data");
                        isCellValid = false;
                        cells = new List<Cell>();
                        break;
                    }

                    var validCell = new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    };

                    cells.Add(validCell);
                }

                if (!isCellValid)
                {
                    continue;
                }

                var department = new Department
                {
                    Name = dto.Name,
                    Cells = cells
                };

                validDep.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(validDep);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
            //Ok.
        {
            var sb = new StringBuilder();

            var dtos = JsonConvert
                .DeserializeObject<ImportPrisionersDto[]>(jsonString);

            var validPrisioners = new List<Prisoner>();

            foreach (var prisionerDto in dtos)
            {
                if (!IsValid(prisionerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var mails = new List<Mail>();

                bool isMailValid = true;

                foreach (var mail in prisionerDto.Mails)
                {
                    if (!IsValid(mail))
                    {
                        sb.AppendLine("Invalid Data");
                        isMailValid = false;
                        mails = new List<Mail>();
                        break;
                    }

                    var email = new Mail
                    {
                        Description = mail.Description,
                        Sender = mail.Sender,
                        Address = mail.Address
                    };

                    mails.Add(email);
                }

                if (!isMailValid)
                {
                    continue;
                }

                DateTime? releaseDate = null;

                if (prisionerDto.ReleaseDate != null)
                {
                    releaseDate = DateTime
                        .ParseExact(prisionerDto.ReleaseDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None);
                }
                           
                var prisioner = new Prisoner
                {
                    FullName = prisionerDto.FullName,
                    Nickname = prisionerDto.Nickname,
                    Age = prisionerDto.Age,
                    IncarcerationDate = DateTime
                        .ParseExact(prisionerDto.IncarcerationDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None),
                    ReleaseDate = releaseDate,
                    Bail = prisionerDto.Bail,
                    CellId = prisionerDto.CellId, // TODO: Дали е валидна?
                    Mails = mails
                };

                validPrisioners.Add(prisioner);
                sb.AppendLine($"Imported {prisioner.FullName} {prisioner.Age} years old");
            }

            context.Prisoners.AddRange(validPrisioners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
            //Ok.
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportOfficersDto[]), new XmlRootAttribute("Officers"));

            using (var sr = new StringReader(xmlString))
            {
                var dtos = (ImportOfficersDto[])serializer.Deserialize(sr);

                var validOfficers = new List<Officer>();
                //var validPrisioners = new List<Prisoner>();

                foreach (var officerDto in dtos)
                {
                    // TODO: Валидация на департамента?
                    if (!IsValid(officerDto))
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    //Валидация на Id на призионера? 
                    //The prisoner Id will always be valid

                    var officer = new Officer
                    {
                        FullName = officerDto.Name,
                        Salary = officerDto.Money,
                        Position = (Position)Enum
                                .Parse(typeof(Position), officerDto.Position),
                        Weapon = (Weapon)Enum
                                .Parse(typeof(Weapon), officerDto.Weapon),
                        DepartmentId = officerDto.DepartmentId,                        
                    };

                    //var officerPrisioner = new List<OfficerPrisoner>();

                    foreach (var prisioner in officerDto.Prisoners)
                    {
                        var currentOfficerPrisoner = new OfficerPrisoner();

                        var currPrisioner = context.Prisoners
                            .FirstOrDefault(p => p.Id == prisioner.Id);

                        currentOfficerPrisoner.Prisoner = currPrisioner;
                        currentOfficerPrisoner.Officer = officer;

                        officer.OfficerPrisoners.Add(currentOfficerPrisoner);

                        //validPrisioners.Add(currPrisioner);

                        //officerPrisioner.Prisoner = currPrisioner;
                    }


                    //context.OfficersPrisoners.Add(officerPrisioner);
                    //context.SaveChanges();

                    validOfficers.Add(officer);
                    sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                }

                context.Officers.AddRange(validOfficers);
                
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}