using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace PrimeNumberCounter
{
    class Program
    {
        private static object lockObj = new object();

        static void Main(string[] args)
        {
            //Thread thread = new  Thread(PrintPrimeCount(1, 10_000_000)); //За начало на треда трябва да се подаде метод, който не получава параметри и не връща резултат. Можем да напишем и тред с ламбда израз;

            //PrintPrimeCount(1, 10_000_0000);

            //Thread thread2 = new Thread(() =>
            //{
            //    // описание на метода -> код. Метода си няма име и директно имплементацията му е тук.
            //});

            //Като направим тред, той само се инициализира но НЕ започва работа. Ние трябва да кажем на треда кога да започне;
            //thread.Start(); //С това казваме на треда да започне да работи.
            //thread.Join(); //Ако не сме сигурни дали програмата ще изчака треда да приключи след като се затвори,  с join казваме задължително програмата да изчака да треда да приключи и тогава да се затвори.
            // С тредове се прави многонишково програмиране.

            Task.Run(() => PrintPrimeCount(1, 10_000_000)); 
            //Задължително по този начин с този синтаксис трябва да го пуснеме за да работи асинхронно! Иначе си работи синхронно!
            // Асинхронно! Докато това работи се изпълняват и другите неща.
            //PrintPrimeCount(); - синхронно


            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        static async Task PrintPrimeCount(int min, int max)
        {
            Stopwatch sw = Stopwatch.StartNew();

            int count = 0;

            //for (int i = 1; i <= n; i++)
            Parallel.For(min, max + 1, i =>
            //При паралел, ако искаме от 0 до 100, трябва да напишем от 0 до 101! - Затворен интервал се нарича.
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
                    lock (lockObj)
                    {
                        count++;
                    }
                    //Когато имаме общи данни (много нишки имат достъп до тях), в случая брояча, задължително трябва да използваме локинг механизъм и да го заключим, за да имаме верни данни. Иначе ще има разминаване.
                }
            });

            Console.WriteLine(count);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
