using System;

namespace _06_BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            // 85 x 100

            int leftBrackedCounter = 0;
            int leftBrackedRepeatCounter = 0;
            int rightBrackedCounter = 0;
            bool brackedRepeat = false;

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {

                    leftBrackedCounter++;
                    leftBrackedRepeatCounter++;

                    if (leftBrackedRepeatCounter == 2)
                    {
                        brackedRepeat = true;
                    }
                }

                if (input == ")")
                {
                    rightBrackedCounter++;
                    leftBrackedRepeatCounter = 0;
                }
            }

            if (leftBrackedCounter == rightBrackedCounter && brackedRepeat == false)
            {
                Console.WriteLine("BALANCED");
            }

            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
