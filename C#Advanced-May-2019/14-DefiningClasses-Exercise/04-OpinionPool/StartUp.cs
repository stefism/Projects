using System;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int numberOfNames = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNames; i++)
            {
                string[] currentMember = Console.ReadLine().Split();

                string memberName = currentMember[0];
                int memberAge = int.Parse(currentMember[1]);

                Person person = new Person(memberName, memberAge);

                Family.AddMemberToDictionary(person);
            }

            Family.PrintMembersThan30Age();
        }
    }
}
