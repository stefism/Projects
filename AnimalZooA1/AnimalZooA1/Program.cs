using AnimalZooA1.Contracts;
using AnimalZooA1.Data;

namespace AnimalZooA1
{
	class Program
	{
		static void Main(string[] args)
		{
			IEngine engine = new Engine();

			engine.Run();
		}
	}
}
