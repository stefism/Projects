namespace P03_StudentSystem
{
    public class Student
    {
        public Student(string name, int age, double grade)
        {
            Name = name;
            Age = age;
            Grade = grade;
        }

        public double Grade { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            string typeOfStudent = string.Empty;

            if (Grade >= 5.00)
            {
                typeOfStudent = "Excellent student.";
            }
            else if (Grade >= 3.50 && Grade < 5.00)
            {
                typeOfStudent = "Average student.";
            }
            else
            {
                typeOfStudent = "Very nice person.";
            }

            return $"{Name} is {Age} years old. {typeOfStudent}";
        }
    }
}