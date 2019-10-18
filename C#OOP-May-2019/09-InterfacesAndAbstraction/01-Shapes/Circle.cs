using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            double thickness = 0.4;
            double innerRange = radius - thickness;
            double outerRange = radius + thickness;
            double step = 0.5;

            for (double row = radius; row >= -radius; row--)
            {
                for (double col = -radius; col < outerRange; col+= step)
                {
                    double point = col * col + row * row;

                    if (point >= innerRange * innerRange
                        && point <= outerRange * outerRange)
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
