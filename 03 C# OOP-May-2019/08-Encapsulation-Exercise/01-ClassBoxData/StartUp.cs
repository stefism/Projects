using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main()
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = null;

            try
            {
                box = new Box(lenght, width, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (box != null)
            {
                Console.WriteLine($"Surface Area - {box.CalculateSurfaceArea(box):F2}");
                Console.WriteLine($"Lateral Surface Area - {box.CalculateLateralSurfaceArea(box):F2}");
                Console.WriteLine($"Volume - {box.CalculateVolume(box):F2}");
            }
        }
    }
}
