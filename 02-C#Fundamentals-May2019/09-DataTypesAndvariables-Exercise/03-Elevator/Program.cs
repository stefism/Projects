using System;

namespace _03_Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberOfPeople = double.Parse(Console.ReadLine());
            double elevatorCapacity = double.Parse(Console.ReadLine());

            double elevatorCourses = Math.Ceiling(numberOfPeople / elevatorCapacity);

            Console.WriteLine(elevatorCourses);

        }
    }
}
