using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    class EqualityScale<T>
    {
        private T left;
        private T right;

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
