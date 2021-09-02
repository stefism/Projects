using AnimalZooA1.Contracts;
using AnimalZooA1.Data;
using System;

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
