using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                int next = numbers[i] + numbers[numbers.Count - 1 - i];
                result.Add(next);
            }

            if (numbers.Count % 2 == 1)
            {
                // 1 2 3 - вход
                result.Add(numbers[numbers.Count / 2]);
                // Тука му казваш да ти добави средния елемент на масива!
                //Средния елемент на масива на позиция [1] е ДВЕ!
                result.Add(numbers.Count / 2); 
                //- не! А тука му казваш - добави ми резултата от делението на дължината на масива на две.
                // Което 3 / 2 целочислено е едно.
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
