using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
        {
            return height * width;
        }

        public override double CalculatePerimeter()
        {
            return (2 * width) + (2 * height);
        }

        public override string Draw()
        {
            StringBuilder sb = new StringBuilder();

            DrawLine('*', '*');

            for (int i = 0; i < height - 2; i++)
            {
                DrawLine('*', ' ');
            }

            DrawLine('*', '*');

            void DrawLine(char borderSymbol, char innerSymbol)
            {
                sb.Append(borderSymbol);
                //Console.Write(borderSymbol);

                for (int i = 0; i < width - 2; i++)
                {
                    sb.Append(innerSymbol);
                    //Console.Write(innerSymbol);
                }

                sb.AppendLine(borderSymbol.ToString());
                //Console.WriteLine(borderSymbol);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
