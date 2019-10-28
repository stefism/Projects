using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(5, 7);

            Console.WriteLine(rec.Draw());

            //Circle circle = new Circle(6);

            //Console.WriteLine(circle.Draw());
        }
    }
}
