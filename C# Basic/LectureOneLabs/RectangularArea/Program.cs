using System;

namespace RectangularArea
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Програма за намиране лицето на триъгълник");
            Console.Write("Въведете число за страна А "); int StranaA = int.Parse(Console.ReadLine());
            Console.Write("Въведете число за страна В "); int StranaB = int.Parse(Console.ReadLine());

            int Rezultat = StranaA * StranaB;

            Console.Write("Лицето на триъгълника е: "); Console.WriteLine(Rezultat);
        }
    }
}
