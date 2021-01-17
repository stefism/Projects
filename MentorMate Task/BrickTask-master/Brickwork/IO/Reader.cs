namespace Brickwork.IO
{
    using Brickwork.IO.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
