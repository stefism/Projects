using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfFigure = Console.ReadLine();

            switch (typeOfFigure)
            {
                case "square":
                    double squareSideLenght = double.Parse(Console.ReadLine());
                    double squareFace = squareSideLenght * squareSideLenght;
                    Console.WriteLine("{0:F3}", squareFace);
                    break;

                case "rectangle":
                    double rectangleHeight = double.Parse(Console.ReadLine());
                    double rectangleWidth = double.Parse(Console.ReadLine());
                    double rectangleArea = rectangleHeight * rectangleWidth;
                    Console.WriteLine("{0:F3}", rectangleArea);
                    break;

                case "circle":
                    double circleRadius = double.Parse(Console.ReadLine());
                    double circleArea = Math.PI * circleRadius * circleRadius;
                    Console.WriteLine("{0:F3}", circleArea);
                    break;

                case "triangle":
                    double triangleSizeLenght = double.Parse(Console.ReadLine());
                    double triangleSide = double.Parse(Console.ReadLine());
                    double triangleArea = (triangleSizeLenght * triangleSide) / 2;
                    Console.WriteLine("{0:F3}", triangleArea);
                    break;

                //default:
                    //Console.WriteLine("Undefined figure");
                    //break;

            }
        }
    }
}
