using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class DollarFood : Food
    {
        private const string FoodSymbol = "$";
        private const int FoodPoints = 2;
        public DollarFood(Coordinate coordinate) 
            : base(FoodSymbol, FoodPoints, coordinate)
        {
        }
    }
}
