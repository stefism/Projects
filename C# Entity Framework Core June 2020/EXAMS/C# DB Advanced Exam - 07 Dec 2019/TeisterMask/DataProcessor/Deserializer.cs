namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Text;
    using System.Xml.Serialization;
    using TeisterMask.DataProcessor.ImportDto;
    using System.IO;
    using TeisterMask.Data.Models;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ImportProjectDto[]), new XmlRootAttribute("Projects"));

            using (var sr = new StringReader(xmlString))
            {
                var projectsDtos = (ImportProjectDto[])serializer.Deserialize(sr);

                List<Project> validProjects = new List<Project>();

                foreach (var projectDto in projectsDtos)
                {
                    if (!IsValid(projectDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //Validate OpenDate
                    DateTime projectOpenDate;

                    bool isOpenDateValid = DateTime
                        .TryParseExact(projectDto.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out projectOpenDate);                   

                    if (!isOpenDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    //AddValidProject
                    var project = new Project
                    {
                        Name = projectDto.Name,
                        OpenDate = projectOpenDate
                    };

                    //TODO: Probably validate DueDate?
                    DateTime projectDueDate;

                    if (projectDto.DueDate != null)
                    {
                        bool isDueDateValid = DateTime
                        .TryParseExact(projectDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out projectDueDate);

                        project.DueDate = projectDueDate; //TODO: Probably validate DueDate?
                    }
                    else
                    {
                        project.DueDate = null;
                    }

                    //Validate Tasks
                    foreach (var task in projectDto.Tasks)
                    {
                        if (!IsValid(task))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        DateTime taskOpenDate;

                        bool isTaskOpenDateValid = DateTime
                        .TryParseExact(task.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out taskOpenDate);

                        DateTime taskDueDate;

                        bool isTaskDueDateValid = DateTime
                        .TryParseExact(task.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out taskDueDate);

                        //•	1. invalid name, open or due date are missing
                        //•	2. task open date is before project open date
                        //•	3. task due date is after project due date

                        bool isDueDateValid = DateTime
                        .TryParseExact(projectDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out projectDueDate);

                        if (task.OpenDate == null || task.DueDate == null
                            || taskOpenDate < projectOpenDate
                            || taskDueDate > projectDueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Task taskToAdd = new Task
                        {
                            Name = task.Name,
                            OpenDate = taskOpenDate,
                            DueDate = taskDueDate,
                            ExecutionType = (ExecutionType)task.ExecutionType,
                            LabelType = (LabelType)task.LabelType
                        };

                        project.Tasks.Add(taskToAdd);
                    }

                    validProjects.Add(project);
                    
                    sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
                }

                context.Projects.AddRange(validProjects);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var emplDtos = JsonConvert
                .DeserializeObject<ImportEmployeeDto[]>(jsonString);

            List<Employee> validEmpl = new List<Employee>();

            foreach (var emplDto in emplDtos)
            {
                if (!IsValid(emplDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = emplDto.Username,
                    Email = emplDto.Email,
                    Phone = emplDto.Phone
                };

                foreach (var taskDto in emplDto.Tasks)
                {
                    Task task = context.Tasks.FirstOrDefault(t => t.Id == taskDto);

                    if (task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask 
                    { 
                        Employee = employee,
                        Task = task
                    });
                }

                validEmpl.Add(employee);

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {employee.EmployeesTasks.Count} tasks.");
            }

            context.Employees.AddRange(validEmpl);
            context.SaveChanges();
            
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}