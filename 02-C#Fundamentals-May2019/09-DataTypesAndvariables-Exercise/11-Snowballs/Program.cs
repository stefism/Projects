using System;
using System.Numerics;

namespace _11_Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int snowballs = int.Parse(Console.ReadLine());

            BigInteger snowballMaxValue = 0;

            BigInteger snowMaxValue = 0;
            BigInteger timeMaxValue = 0;
            BigInteger qualityMaxValue = 0;

            for (int i = 0; i < snowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger currentSnowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuality);

                if (currentSnowballValue > snowballMaxValue)
                {
                    snowballMaxValue = currentSnowballValue;
                    snowMaxValue = snowballSnow;
                    timeMaxValue = snowballTime;
                    qualityMaxValue = snowballQuality;
                }
            }

            Console.WriteLine($"{snowMaxValue} : {timeMaxValue} = {snowballMaxValue} ({qualityMaxValue})");
        }
    }
}
