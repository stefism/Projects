using System;

namespace Choreography
{
    class Program
    {
        static void Main(string[] args)
        {
            double stepNumber = double.Parse(Console.ReadLine());
            double dencersNumber = double.Parse(Console.ReadLine());
            double dayForLearn = double.Parse(Console.ReadLine());

            double totalPercentStepsForDay = Math.Ceiling((stepNumber / dayForLearn) / stepNumber * 100);
            double percentStepsForDencer = totalPercentStepsForDay / dencersNumber;

            if (totalPercentStepsForDay < 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {percentStepsForDencer:F2}%."
);
            }
            else
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {percentStepsForDencer:F2}% steps to be learned per day."
);
            }
        }
    }
}
