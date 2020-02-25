using System;

namespace _05_Html
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();

            Console.WriteLine("<h1>");
            Console.WriteLine($"    {title}");
            Console.WriteLine("</h1>");

            string article = Console.ReadLine();

            Console.WriteLine("<article>");
            Console.WriteLine($"    {article}");
            Console.WriteLine("</article>");

            while (true)
            {
                string comments = Console.ReadLine();

                if (comments == "end of comments")
                {
                    break;
                }

                Console.WriteLine("<div>");
                Console.WriteLine($"    {comments}");
                Console.WriteLine("</div>");
            }
        }
    }
}
