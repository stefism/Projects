namespace Brickwork
{
    using Brickwork.Core.Contracts;
    using Brickwork.IO;
    using Brickwork.IO.Contracts;

    public class Startup
    {
        static void Main(string[] args)
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();
           
            while (true)
            {
                try
                {
                    IBuilder builder = new Builder();

                    IEngine engine = new Engine(builder, reader, writer);
                    engine.Run();
                }
                catch (System.Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
