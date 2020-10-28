using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName 
        {
            get => firstName;

            private set 
            {
                ValidateName(value, "First name cannot contain fewer than 3 symbols!");

                firstName = value;
            }
        }

        public string LastName 
        { 
            get => lastName;
            
            private set 
            {
                ValidateName(value, "Last name cannot contain fewer than 3 symbols!");

                lastName = value;
            }
        }

        public int Age 
        {
            get => age;

            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                age = value;
            } 
        }

        public decimal Salary 
        {
            get => salary;

            private set 
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }

                salary = value;
            } 
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                percentage /= 2;
            }

            decimal increase = (percentage / 100) * Salary;
            Salary += increase;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }

        private void ValidateName(string value, string message)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
