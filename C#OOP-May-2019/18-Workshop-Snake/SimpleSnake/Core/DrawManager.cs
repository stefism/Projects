using SimpleSnake.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.Core
{
    public class DrawManager
    {
        private const string SnakeSymbol = "]";

        private List<Coordinate> snakeBodyElements;

        public DrawManager()
        {
            snakeBodyElements = new List<Coordinate>();
        }
        public void Draw(string symbol, IEnumerable<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                if (symbol == SnakeSymbol)
                {
                    snakeBodyElements.Add(coordinate);
                }

                Console.SetCursorPosition(coordinate.CoordinateX, coordinate.CoordinateY);

                Console.Write(symbol);
            }
        }

        public void UndoDraw()
        {
            Coordinate lastElement = snakeBodyElements.First();

            Console.SetCursorPosition
                (lastElement.CoordinateX, lastElement.CoordinateY);

            Console.Write(" ");

            snakeBodyElements.Clear();
        }
    }
}
