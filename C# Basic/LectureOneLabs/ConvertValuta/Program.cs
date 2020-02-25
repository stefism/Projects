using System;

namespace ConvertValuta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Програма за конвертиране на валута спрямо лев:");
            Console.Write("Въведете името на валутата: "); var ImeValuta = Console.ReadLine();
            Console.Write("Вашата валута е: "); Console.WriteLine(ImeValuta);
            Console.Write("Въведете обменен курс: "); double ObmenenKurs = double.Parse(Console.ReadLine());
            Console.Write("Колко: "); Console.Write(ImeValuta); Console.Write(" желаете да обмените: "); int Kolko = int.Parse(Console.ReadLine());
            double Rezultat = Kolko * ObmenenKurs;
            Console.Write(Kolko); Console.Write(ImeValuta); Console.Write("Са равни на : "); Console.Write(Rezultat); Console.Write(" лева.");

        }
    }
}
