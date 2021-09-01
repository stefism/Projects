using A1_Invoice_System.Contracts;
using A1_Invoice_System.Data;

namespace A1_Invoice_System
{
	class Program
	{
		static void Main()
		{
			IEngine engine = new Engine();

			engine.Run();
		}
	}
}
