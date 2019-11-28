namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            DrawManager drawManager = new DrawManager();
            Snake snake = new Snake();
            Coordinate boardCoordinate 
                = new Coordinate(50, 20);

            Engine engine = new Engine(drawManager, snake, boardCoordinate);

            engine.Run();
        }
    }
}
