using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _03_WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words;

            using (var reader = new StreamReader("words.txt"))
            {
                words = reader.ReadLine().Split();
            }

            string inputText;

            using (var reader = new StreamReader("text.txt"))
            {
                inputText = reader.ReadToEnd();
            }

            string[] splittedInput = inputText.Split();

            foreach (var word in words)
            {

            }
        }
    }
}
