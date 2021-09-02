using System;

namespace AnimalZooA1.Data
{
	internal abstract class Animal
	{
		private int health = 100;
		private int animalsLeft = 5;

		internal int Health
		{
			get => health;

			set
			{
				if(value > 100)
				{
					value = 100;

				}
				else if(value < 0)
				{
					value = 0;
				}

				health = value;
			}
		}

		internal int AnimalsLeft
		{
			get => animalsLeft;

			set
			{
				if(value < 0)
				{
					value = 0;
				}

				animalsLeft = value;
			}
		}

		internal void Stavration()
		{
			Random random = new Random();
			int randomHealth = random.Next(0, 21);
			Health -= randomHealth;
		}

		internal void Feed()
		{
			Random random = new Random();
			int randomHealth = random.Next(5, 26);
			Health += randomHealth;
		}
	}
}
