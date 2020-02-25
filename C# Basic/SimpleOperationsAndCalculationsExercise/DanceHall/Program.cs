using System;

namespace DanceHall
{
    class Program
    {
        static void Main(string[] args)
        {
            //0. Да разберем квадратурата на залата
            //1. Да разберем свободната площ в залата.
            //2. Свободната площ в залата е равна на
            //квадратурата на залата, минус квадратурата
            //на гардероба, минус квадратурата на пейката.
            //ok 3. Квадратурата на гардероба е равна на
            //страна А на гардероба по страна Б на гардероба.
            //4. Квадратурата на пейката е равна на
            //-10 пъти квадратурата на залата.
            double HallLenght = double.Parse(Console.ReadLine());
            double HallWidht = double.Parse(Console.ReadLine());
            double hallCm2 = (HallLenght * 100) * (HallWidht * 100); //0
            double sideWardrobe = double.Parse(Console.ReadLine());

            double WardrobeCm2 = (sideWardrobe * 100) * (sideWardrobe * 100); //3
            double benchM2 = hallCm2 / 10; //4

            double hallFreeArea = hallCm2 - WardrobeCm2 - benchM2;//1, 2
            //7.04 см2 за 1 танцьор
            //5. Брой танцьори в залата е равно на свободната площ
            // в залата по 7.04
            double numberDancers = hallFreeArea / 7040;

            Console.WriteLine(Math.Floor(numberDancers));

        
        }
    }
}
