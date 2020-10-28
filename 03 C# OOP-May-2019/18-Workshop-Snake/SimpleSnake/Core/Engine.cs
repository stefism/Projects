using SimpleSnake.Enums;
using SimpleSnake.Factories;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private const string SnakeSymbol = "]";
        private const string BoardSymbol = "\u2588";

        private DrawManager drawManager;
        private Snake snake;
        private Food food;
        private Coordinate boardCoordinate;

        public Engine(DrawManager drawManager, 
            Snake snake, Coordinate boardCoordinate)
        {
            this.drawManager = drawManager;
            this.snake = snake;
            this.boardCoordinate = boardCoordinate;
            
            InitializeFood();
            InitializeBorders();
        }

        public void Run()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    SetCorrectDirection(Console.ReadKey());
                }
                drawManager.Draw(food.Symbol, new List<Coordinate>() {food.Coordinate});

                drawManager.Draw(SnakeSymbol, snake.Body);

                snake.Move();

                drawManager.UndoDraw();

                if (HasFoodCollision())
                {
                    snake.Eat(food);

                    InitializeFood();
                }

                if (HasBorderCollision())
                {
                    Console.SetCursorPosition(10, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("GAME OVER !!!");
                    Console.WriteLine("Press any key to continue ...");
                    
                    Console.ReadKey();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    StartUp.Main();
                    //return;
                }

                Thread.Sleep(150);
            }
        }

        private bool HasBorderCollision()
        {
            int snakeHeadCoordinateX = snake.Head.CoordinateX;
            int snakeHeadCoordinateY = snake.Head.CoordinateY;

            int boardCoordinateX = boardCoordinate.CoordinateX;
            int boardCoordinateY = boardCoordinate.CoordinateY;

            return snakeHeadCoordinateX == boardCoordinateX - 1
                || snakeHeadCoordinateX == 0
                || snakeHeadCoordinateY == boardCoordinateY
                || snakeHeadCoordinateY == 0;
        }

        private void InitializeBorders()
        {
            List<Coordinate> allCoordinates = new List<Coordinate>();

            InitializeHorizontalBorderCoordinates(0, allCoordinates);
            InitializeHorizontalBorderCoordinates
                (boardCoordinate.CoordinateY, allCoordinates);

            InitializeVerticalBorderCoordinates(0, allCoordinates);
            InitializeVerticalBorderCoordinates
                (boardCoordinate.CoordinateX, allCoordinates);

            drawManager.Draw(BoardSymbol, allCoordinates);
        }

        private void InitializeVerticalBorderCoordinates
            (int coordinateX, List<Coordinate> allCoordinates)
        {
            for (int coordinateY = 0; coordinateY 
                < boardCoordinate.CoordinateY; coordinateY++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeHorizontalBorderCoordinates
            (int coordinateY, List<Coordinate> allCoordinates)
        {
            for (int coordinateX = 0; coordinateX 
                < boardCoordinate.CoordinateX; coordinateX++)
            {
                allCoordinates.Add(new Coordinate(coordinateX, coordinateY));
            }
        }

        private void InitializeFood()
        {
            food = FoodFactory.GetRandomFood
                (boardCoordinate.CoordinateX, boardCoordinate.CoordinateY);
        }

        private bool HasFoodCollision()
        {
            int snakeHeadCoordinateX = snake.Head.CoordinateX;
            int snakeHeadCoordinateY = snake.Head.CoordinateY;

            int foodCoordinateX = food.Coordinate.CoordinateX;
            int foodCoordinateY = food.Coordinate.CoordinateY;

            return snakeHeadCoordinateX == foodCoordinateX
                && snakeHeadCoordinateY == foodCoordinateY; 
        }

        private void SetCorrectDirection(ConsoleKeyInfo input)
        {
            Direction currentSnakeDirection = snake.Direction;

            switch (input.Key)
            {
                case ConsoleKey.DownArrow:
                    if (currentSnakeDirection != Direction.Up)
                    {
                        currentSnakeDirection = Direction.Down;
                    }
                    break;
                
                case ConsoleKey.LeftArrow:
                    if (currentSnakeDirection != Direction.Right)
                    {
                        currentSnakeDirection = Direction.Left;
                    }
                    break;
                
                case ConsoleKey.RightArrow:
                    if (currentSnakeDirection != Direction.Left)
                    {
                        currentSnakeDirection = Direction.Right;
                    }
                    break;

                case ConsoleKey.UpArrow:
                    if (currentSnakeDirection != Direction.Down)
                    {
                        currentSnakeDirection = Direction.Up;
                    }
                    break;
            }

            snake.Direction = currentSnakeDirection;
        }
    }
}
