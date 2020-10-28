using P03._ShoppingCart;
using P03._ShoppingCart_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03._ShoppingCart_Before
{
    public class SpecialCalculationStrategy : IPriceCalculationStrategy
    {
        public decimal Calculate(OrderItem item)
        {
            decimal total = item.Quantity * .4m;
            int setsOfThree = item.Quantity / 3;
            total -= setsOfThree * .2m;

            return total;
        }

        public bool IsMatch(OrderItem item)
        {
            if (item.Sku.StartsWith("SPECIAL"))
            {
                return true;
            }

            return false;
        }
    }
}
