using System;
using System.Collections.Generic;
using System.Threading;

namespace Tetris
{
    class Program
    {
        //Settings
        static int TetrisRows = 20;
        static int TetrisCols = 10;
        static int InfoCols = 10;
        static int ConsoleRows = 1 + TetrisRows + 1;
        static int ConsoleCols = 1 + TetrisCols + 1 + InfoCols + 1;
        static List<bool[,]> TetrisFigures = new List<bool[,]>()
        {
            new bool[,] // ----
            {
                {true, true, true, true}
            }, 
            new bool[,] // O
            {
                {true, true},
                {true, true}
            }, 
            new bool[,] // T
            {
                {false, true, false},
                {true,  true, true},
            }, 
            new bool[,] // S
            {
                {false, true, true},
                {true,  true, false},
            }, 
            new bool[,] // Z
            {
                {true,  true, false},
                {false, true, true},
            }, 
            new bool[,] // J
            {
                {true, false, false},
                {true, true,  true}
            }, 
            new bool[,] // L
            {
                {false, false, true},
                {true,  true,  true}
            }, 
            
        };

        //State
        static int Score = 0;
        static int Frame = 0;
        static int FramesToMoveFigure = 15;
        static int CurrentFigureIndex = 2;
        static int CurrentFigureRow = 0;
        static int CurrentFigureCol = 0;
        static bool[,] TetrisField = new bool[TetrisRows, TetrisCols];

        static void Main(string[] args)
        {
            Console.Title = "Tetris. Version 1.0";
            Console.WindowHeight = ConsoleRows + 1;
            Console.WindowWidth = ConsoleCols;
            Console.BufferHeight = ConsoleRows + 1;
            Console.BufferWidth = ConsoleCols;
            Console.CursorVisible = false;
            //Console.SetError.ToString("");
            //DrawBorder();
            //DrawInfo();
            //DrawCurrentFigure();

            while (true)
            {
                Frame++;
                // user input
                // change state
                // redraw UI

                //Score++;

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.Escape)
                    {
                        return;
                    }

                    if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
                    {
                        // TODO: Move current figure left
                        CurrentFigureCol--; // TODO: Out of range
                    }

                    if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
                    {
                        // TODO: Move current figure right
                        CurrentFigureCol++; // TODO: Out of range
                    }

                    if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
                    {
                        Frame = 1;
                        Score++;
                        CurrentFigureRow++;
                        // TODO: Move current figure down
                    }

                    if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
                    {
                        // TODO: Implement 90-degree rotation of the current fugure
                    }
                }

                // Update the game state

                if (Frame % FramesToMoveFigure == 0)
                {
                    // TODO: Move current figure

                    CurrentFigureRow++;
                    Frame = 0;
                    
                }

                DrawBorder();
                DrawInfo();
                DrawCurrentFigure();

                //Frame++;
                Thread.Sleep(40);
            }
        }

        static void DrawBorder()
        {
            Console.SetCursorPosition(0, 0);

            string line = "╔";

            line += new string('═', TetrisCols); // Е това прави същото, което прави долния цикъл.

            //for (int i = 0; i < TetrisCols; i++)
            //{
            //    line += "═";
            //}

            line += "╦";

            line += new string('═', InfoCols);

            line += "╗";

            Console.Write(line);

            for (int i = 0; i < TetrisRows; i++)
            {
                string middleLine = "║";
                middleLine += new string(' ', TetrisCols);
                middleLine += "║";
                middleLine += new string(' ', InfoCols);
                middleLine += "║";
                Console.Write(middleLine);
            }

            string endLine = "╚";
            endLine += new string('═', TetrisCols);
            endLine += "╩";
            endLine += new string('═', InfoCols);
            endLine += "╝";
            Console.Write(endLine);
        }

        static void DrawInfo()
        {
            Write("Score:", 1, 3 + TetrisCols);
            Write(Score.ToString(), 2, 3 + TetrisCols);
            Write("Frame:", 4, 3 + TetrisCols);
            Write(Frame.ToString(), 5, 3 + TetrisCols);
        }

        static void DrawCurrentFigure()
        {
            var currentFigure = TetrisFigures[CurrentFigureIndex];

            for (int row = 0; row < currentFigure.GetLength(0); row++) // GetLength(0) дава броя редове в двумерен масив или нулевото измерение.
            {
                for (int col = 0; col < currentFigure.GetLength(1); col++) // GetLength(1) дава броя колони в двумерен масив
                {
                    if (currentFigure[row, col]) // Проверяваме дали има нещо на съответния ред и съответната колона.
                    {
                        Write("*", row + 1 + CurrentFigureRow, col + 1 + CurrentFigureCol); // Ако има нещо, с метода write() го рисуваме на съответния ред и колона.
                    }
                }
            }
        }


        static void Write(string text, int row = 0, int col = 0, ConsoleColor color = ConsoleColor.Yellow)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(col, row);
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
