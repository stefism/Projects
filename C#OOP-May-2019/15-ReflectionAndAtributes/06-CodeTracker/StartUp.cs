using System;

namespace _06_CodeTracker
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        public static void Main(string[] args)
        {
            var tracker = new _06_CodeTracker.Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
