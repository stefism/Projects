using System;

namespace Snakes
{
    class Snakes
    {
        private static char[] currentSnakeShape;
        //Конкретната форма на змията ще се определя от буквите за посоката в приоритет R D L U, като винаги имаме стартова позиция, която отбелязваме с S. Тези букви ще ги подаваме в параметъра direction по-надолу в метода GenerateSnakes.
        //Слагаме си фиктивна координатна система за да отбелязваме през кои блокчета сме минали. В нея змията винаги ще започва от 0(х),0(y).
        //При това положение ход надясно е 0,1. Нагоре е 1,0.
        // Така ще броиме от къде сме минали. Тоест ако стигнем пак до 0,0 да не минаваме пак оттам.

        static void GenerateSnakes(int index, int row, int col, char direction)
            //index - текущото блокче от дължината на змията.
            //row, col - позицията във фиктивната координатна система
        {
            if (index >= currentSnakeShape.Length) 
                //Ако змията е попълнена
            {
                Console.WriteLine(new string(currentSnakeShape));
            }
            else
            {
                currentSnakeShape[index] = direction;
                //Току що минах на ....(съответната посока през която змията минава, изразена с букви.)

                //Започваме рекусивно да извикваме попълването на посоката на змията, в реда, указан в условието на задачата.
                GenerateSnakes(index + 1, row, col + 1, 'R');
                GenerateSnakes(index + 1, row + 1, col, 'D');
                GenerateSnakes(index + 1, row, col - 1, 'L');
                GenerateSnakes(index + 1, row - 1, col, 'U');
            }
        }

        static void Main(string[] args)
        {
            int snakeLength = int.Parse(Console.ReadLine());
            currentSnakeShape = new char[snakeLength];
        }
    }
}
