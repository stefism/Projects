using System;

namespace P02._DrawingShape_Before
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle peshoCircle = new Circle();
            Circle peshoCircle2 = new Circle();
            Circle peshoCircle3 = new Circle();

            var goshoRec = new Rectangle();
            var goshoRec2 = new Rectangle();
            var goshoRec3 = new Rectangle();

            DrawingManager drawer = new DrawingManager();

            drawer.Draw(peshoCircle);
        }
    }
}
