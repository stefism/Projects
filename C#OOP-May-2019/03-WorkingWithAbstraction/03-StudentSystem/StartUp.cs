namespace P03_StudentSystem
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();

                if (commands[0] == "Exit")
                {
                    studentSystem.Exit();
                }

                string studentName = commands[1];

                if (commands[0] == "Create")
                {
                    int studentAge = int.Parse(commands[2]);
                    double studentAverage = double.Parse(commands[3]);

                    Student currentStudent = new Student(studentName, studentAge, studentAverage);

                    studentSystem.CreateStudent(currentStudent);
                }

                try
                {
                    if (commands[0] == "Show")
                    {
                        Console.WriteLine(studentSystem.ShowStudent(studentName));
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
    }
}
