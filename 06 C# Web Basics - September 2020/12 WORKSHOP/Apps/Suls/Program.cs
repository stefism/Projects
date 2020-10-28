using SUS.MvcFramework;
using System.Threading.Tasks;

namespace Suls
{
    public class Program
    {
        // Microsoft.EntityFrameworkCore.SqlServer
        // Microsoft.EntityFrameworkCore.Tools
        // Microsoft.EntityFrameworkCore.Design
        public static async Task Main(string[] args)
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
