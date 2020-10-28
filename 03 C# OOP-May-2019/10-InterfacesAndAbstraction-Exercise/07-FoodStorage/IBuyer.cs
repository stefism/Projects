using System;
using System.Collections.Generic;
using System.Text;

namespace _05_BorderControl
{
    public interface IBuyer
    {
        int BuyFood(int value);
        int Food { get; }
    }
}
