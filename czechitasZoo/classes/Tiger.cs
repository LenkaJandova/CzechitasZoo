using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czechitasZoo.classes
{
	internal class Tiger : Animal
	{
		public Tiger(string name) : base(name)
		{
		}

		public override FoodType Food => FoodType.MEAT;

		public override void Update()
		{
			if (isAlive)
			{
				Hunger++;
				if (Hunger >= Animal.maxHunger - 10)
				{
					Feed();
				}
				if (Hunger >= Animal.maxHunger - 5)
				{
					FeedOnAnimals();
				}
				if (Hunger >= maxHunger)
				{
					base.isAlive = false;
				}
			}
		}

		private void FeedOnAnimals()
		{
			Animal? animalToEat = MyZoo.Pen
				.Where(a => a != this)
				.Where(a => !MyZoo.eatenAnimals.Contains(a))
				.FirstOrDefault();
			if(animalToEat != null)
			{
				MyZoo.eatenAnimals.Add(animalToEat);
				this.Hunger = 0;
				Console.WriteLine($"{this.Name} ate {animalToEat.Name}");

			}

		}
	}
}
