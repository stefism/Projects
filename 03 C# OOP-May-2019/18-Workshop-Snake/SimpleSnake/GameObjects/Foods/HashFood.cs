using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class HashFood : Food
    {
        private const string FoodSymbol = "#";
        private const int FoodPoints = 3;
        public HashFood(Coordinate coordinate) 
            : base(FoodSymbol, FoodPoints, coordinate)
        {
        }
    }
}
