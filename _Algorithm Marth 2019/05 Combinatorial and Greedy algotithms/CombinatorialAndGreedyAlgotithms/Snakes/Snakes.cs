using System;
using System.Collections.Generic;

namespace Snakes
{
    class Snakes
    {
        private static char[] currentSnakeShape;
        //Конкретната форма на змията ще се определя от буквите за посоката в приоритет R D L U, като винаги имаме стартова позиция, която отбелязваме с S. Тези букви ще ги подаваме в параметъра direction по-надолу в метода GenerateSnakes.
        //Слагаме си фиктивна координатна система за да отбелязваме през кои блокчета сме минали. В нея змията винаги ще започва от 0(х),0(y).
        //При това положение ход надясно е 0,1. Нагоре е 1,0.
        // Така ще броиме от къде сме минали. Тоест ако стигнем пак до 0,0 да не минаваме пак оттам.

        //Тук ще пазим до къде сме стигнали. Дали съм стъпил на текущия ред и колона и дали там вече няма парченце змия.
        private static HashSet<string> visitedCells = new HashSet<string>();

        //В задачата има условие да не принтираме завъртяните и флипнатите форми на змиите. Тоест това "『" и това "』" е змия с една и съща форма, просто флипната по вертикала. Трябва да принтираме само една от тези форми с приоритет в посоките R D L U. Затова трябва да пазим всички форми на змии до които сме стигнали.
        private static HashSet<string> snakesShapes = new HashSet<string>();
        private static HashSet<string> allPossibleSnakesShapes = new HashSet<string>(); //Всички възможни варианти на всички змии.

        static void GenerateSnakes(int index, int row, int col, char direction)
            //index - текущото блокче от дължината на змията.
            //row, col - позицията във фиктивната координатна система
        {
            if (index >= currentSnakeShape.Length) 
                //Ако змията е попълнена
            {
                MarkSnakeShape(); //Запазваме текущата форма на змията.
            }
            else
            {
                string cell = $"{row} {col}";

                if (!visitedCells.Contains(cell))
                //Ако cell не се съдържа във visitedCells, значи не съм бил тук и мога да стъпя.
                {
                    currentSnakeShape[index] = direction;
                    //Току що минах на ....(съответната посока през която змията минава, изразена с букви.)

                    visitedCells.Add(cell); //Отбелязваме, че вече сме били тук, за да не отидем после пак.

                    //Започваме рекусивно да извикваме попълването на посоката на змията, в реда, указан в условието на задачата.
                    GenerateSnakes(index + 1, row, col + 1, 'R');
                    GenerateSnakes(index + 1, row + 1, col, 'D');
                    GenerateSnakes(index + 1, row, col - 1, 'L');
                    GenerateSnakes(index + 1, row - 1, col, 'U');

                    visitedCells.Remove(cell); //На връщане трябва да отмаркираме - backtracking.
                }               
            }
        }

        private static void MarkSnakeShape()
        {
            var normalSnake = new string(currentSnakeShape);

            if (allPossibleSnakesShapes.Contains(normalSnake))
                //Ако вече съм я срещал тази змия в някаква форма (флипната, ротирана).
            {
                return;
            }
            //Ако не съм я срещал, генерирам всички възможни нейни варианти.
            snakesShapes.Add(normalSnake); 
            
            //Първия възможен случай до който съм стигнал. Или примерно, това "﹃" ми е първата възможна форма. А всичките фариации на тази форма, вече ще ги добавя, за да не се повторят в следващите пъти;
            var flippedSnake = Flip(normalSnake);
            var reversedSnake = Reverse(normalSnake);
            var reversedFlippedSnake = Flip(reversedSnake);
            //Всички възможни вариации на normalSnake, трябва да се обработят и добавят в allPossibleSnakesShapes, за да може като стигна следващия път до някоя от тези, да не я показвам (да я махна).

            //Следващото, което ни трябва, са всички възможни ротации на normalSnake, flippedSnake, reversedSnake и reversedFlippedSnake.

            for (int i = 0; i < 4; i++) //Всички възможни ротации са 4
            {
                allPossibleSnakesShapes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                allPossibleSnakesShapes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                allPossibleSnakesShapes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                allPossibleSnakesShapes.Add(reversedFlippedSnake);
                reversedFlippedSnake = Rotate(reversedFlippedSnake);
            }
        }

        private static string Rotate(string snake)
        {
            //За да я завъртиме трябва:
            // 1. Надясно да стане надолу или R -> D
            // 2. Надолу да стане наляво или D -> L
            // 3. Наляво да стане нагоре или L -> U
            // 4. Нагоре да стане надясно или U -> R

            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'L'; break;
                    case 'L': newSnake[i] = 'U'; break;
                    case 'U': newSnake[i] = 'R'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        private static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }

            return new string(newSnake);
        }

        private static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'U': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'U'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        static void Main(string[] args)
        {
            int snakeLength = int.Parse(Console.ReadLine());
            currentSnakeShape = new char[snakeLength];

            GenerateSnakes(0, 0, 0, 'S');

            foreach (var snakeShape in snakesShapes)
            {
                Console.WriteLine(snakeShape);
            }

            Console.WriteLine($"Snakes count = {snakesShapes.Count}");
        }
    }
}
