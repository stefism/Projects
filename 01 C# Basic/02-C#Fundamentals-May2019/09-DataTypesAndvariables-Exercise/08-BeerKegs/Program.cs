using System;
using System.Numerics;

namespace _08_BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            double maxVolumeKeg = 0;
            string maxVolumeKegModel = "";

            for (int i = 0; i < numberOfKegs; i++)
            { 
                string kegModel = Console.ReadLine();
                double kegRadius = double.Parse(Console.ReadLine());
                //decimal kegHeight = decimal.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());



                double currentKegVolume = Math.PI * Math.Pow(kegRadius, 2) * kegHeight;

                if (currentKegVolume > maxVolumeKeg)
                {
                    maxVolumeKeg = currentKegVolume;
                    maxVolumeKegModel = kegModel;
                }
            }

            Console.WriteLine(maxVolumeKegModel);
        }
    }
}
