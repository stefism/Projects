using System;

namespace SubsetSumWithRepeat ///With repeat numbers
{
    class SubsetSumWithRepeat
    {
        static void Main()
        {
            var numbers = new[] { 3, 5, 2 };

            var targetSum = 6;
            
            var possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;

            for (int currPossibleSum = 0; currPossibleSum < possibleSums.Length; currPossibleSum++)
            {
                if (possibleSums[currPossibleSum])
                {
                    for (int currNumber = 0; currNumber < numbers.Length; currNumber++)
                    {
                        var newSum = currPossibleSum + numbers[currNumber];
                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }                        
                    }
                }
            }

            while (targetSum != 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var sum = targetSum - numbers[i];
                    if (sum >=0 && possibleSums[sum])
                    {
                        Console.Write(numbers[i] + " ");
                        targetSum = sum;
                    }
                }
            }

            Console.WriteLine(possibleSums[targetSum]);
        }
    }
}
