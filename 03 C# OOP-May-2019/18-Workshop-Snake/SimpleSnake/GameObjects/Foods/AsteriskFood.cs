using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class AsteriskFood : Food
    {
        private const string FoodSymbol = "*";
        private const int FoodPoints = 1;
        public AsteriskFood(Coordinate coordinate) 
            : base(FoodSymbol, FoodPoints, coordinate)
        {
        }
    }
}
