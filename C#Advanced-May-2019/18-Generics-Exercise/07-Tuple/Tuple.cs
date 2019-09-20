﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _07_Tuple
{
    public class Tuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;

        public Tuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public string GetInfo()
        {
            return $"{item1} -> {item2}";
        }
    }
}
