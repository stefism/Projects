using SimpleSnake.Enums;
using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const int DefaultLenght = 6;
        private const int DefaultX = 8;
        private const int DefaultY = 7;

        private List<Coordinate> snakeBody;

        public Snake()
        {
            snakeBody = new List<Coordinate>();
            Direction = Direction.Right;
            InitializeBody();
        }

        public Direction Direction { get; set; }

        public Coordinate Head => snakeBody.Last();

        public IReadOnlyCollection<Coordinate> Body 
            => snakeBody.AsReadOnly();

        public void Move()
        {
            Coordinate newHead = GetNewHeadCoordinates();

            snakeBody.Add(newHead);
            snakeBody.RemoveAt(0);
        }

        private Coordinate GetNewHeadCoordinates()
        {
            Coordinate newHeadCoordinate 
                = new Coordinate(Head.CoordinateX, Head.CoordinateY);

            switch (Direction)
            {
                case Direction.Right:
                    newHeadCoordinate.CoordinateX++;
                    break;

                case Direction.Left:
                    newHeadCoordinate.CoordinateX--;
                    break;

                case Direction.Down:
                    newHeadCoordinate.CoordinateY++;
                    break;

                case Direction.Up:
                    newHeadCoordinate.CoordinateY--;
                    break;
            }

            return newHeadCoordinate;
        }

        public void Eat(Food food)
        {
            for (int i = 0; i < food.Points; i++)
            {
                Coordinate newHeadCoordinate = GetNewHeadCoordinates();
                snakeBody.Add(newHeadCoordinate);
            }
        }

        private void InitializeBody()
        {
            int x = DefaultX;
            int y = DefaultY;

            for (int i = 0; i <= DefaultLenght; i++)
            {
                snakeBody.Add(new Coordinate(x, y));
                x++;
            }
        }
    }
}
