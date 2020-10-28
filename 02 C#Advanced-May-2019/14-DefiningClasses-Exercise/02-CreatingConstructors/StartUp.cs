using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person(18);
            Person person3 = new Person("Ivan", 18);

            Console.WriteLine(person2.Name);
        }
    }
}
