using System;
using System.Text;

namespace _02VolwelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            VolwelsCount(text);
        }

        static void VolwelsCount(string text)
        {
            string textLower = text.ToLower();
            int countLower = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (textLower[i] == 'a' || textLower[i] == 'e' || textLower[i] == 'i' || textLower[i] == 'o' || textLower[i] == 'u')
                {
                    countLower++;
                }
            }

            Console.WriteLine(countLower);
        }
    }
}
