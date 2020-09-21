using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumberCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintPrimeCount); //За начало на треда трябва да се подаде метод, който не получава параметри и не връща резултат. Можем да напишем и тред с ламбда израз;

            Thread thread2 = new Thread(() => 
            {
                // описание на метода -> код. Метода си няма име и директно имплементацията му е тук.
            });

            //Като направим тред, той само се инициализира но НЕ започва работа. Ние трябва да кажем на треда кога да започне;
            thread.Start(); //С това казваме на треда да започне да работи.
            thread.Join(); //Ако не сме сигурни дали програмата ще изчака треда да приключи след като се затвори,  с join казваме задължително програмата да изчака да треда да приключи и тогава да се затвори.
            // С тредове се прави многонишково програмиране.

            //Task.Run(PrintPrimeCount); // Асинхронно! Докато това работи се изпълняват и другите неща.
            //PrintPrimeCount(); - синхронно

            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        static void PrintPrimeCount()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = 10000000;
            int count = 0;

            for (int i = 1; i <= n; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
