using System;
using System.Linq;
using System.Text;

namespace _02_RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine().Split();

            var sb = new StringBuilder();

            foreach (var word in inputWords)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(word);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
