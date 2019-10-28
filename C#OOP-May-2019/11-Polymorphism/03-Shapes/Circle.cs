using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * (radius * radius);
        }

        public override double CalculatePerimeter()
        {
            return (2 * Math.PI) * radius;
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            double thickness = 0.4;
            double innerRange = radius - thickness;
            double outerRange = radius + thickness;
            double step = 0.5;

            for (double row = radius; row >= -radius; row--)
            {
                for (double col = -radius; col < outerRange; col += step)
                {
                    double point = col * col + row * row;

                    if (point >= innerRange * innerRange
                        && point <= outerRange * outerRange)
                    {
                        sb.Append("*");

                    }
                    else
                    {
                        sb.Append(" ");

                    }
                }

                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
