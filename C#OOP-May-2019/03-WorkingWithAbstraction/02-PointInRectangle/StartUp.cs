using System;
using System.Linq;

namespace _02_PointInRectangle
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] rectangleCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int topLeftX = rectangleCoordinates[0];
            int topLeftY = rectangleCoordinates[1];

            Point topLeftPoint = new Point(topLeftX, topLeftY);

            int bottomRightX = rectangleCoordinates[2];
            int bottomRightY = rectangleCoordinates[3];

            Point bottomRightPoint = new Point(bottomRightX, bottomRightY);

            Rectangle rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            int inputLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputLines; i++)
            {
                int[] pointCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int pointX = pointCoordinates[0];
                int pointY = pointCoordinates[1];

                Point point = new Point(pointX, pointY);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
