using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czechitasZoo.classes
{
	abstract class Animal : Updateable
	{

		public string Name { get; set; }
		abstract public FoodType Food { get; }
		public bool isAlive { get; set; } = true;
		public int Hunger { get; set; }
		public Zoo MyZoo { get; set; }

		static Random rnd = new Random();
		public static int maxHunger = 30;

		public Animal(string name)
		{
			Name = name;
			Hunger = rnd.Next(1, maxHunger);
		}

		public virtual void Update()
		{
			if (isAlive)
			{
				Hunger++;
				if (Hunger >= maxHunger -10)
				{
					Feed();
				}

				if (Hunger >= maxHunger)
				{
					isAlive = false;
				}
			}
		}

		public void Feed()
		{
			foreach (FoodType type in Enum.GetValues(typeof(FoodType)))
			{
				if (this.Food == type && MyZoo.Feeder.ContainsKey(type))
				{
					var feedingQuantity = Math.Min(MyZoo.Feeder[type], this.Hunger);
					MyZoo.Feeder[type] -= feedingQuantity;
					this.Hunger -= feedingQuantity;
					Console.WriteLine($"Right now, {this.Name} is eating {feedingQuantity} of {type}");
				}
			}
		}
		public override string ToString()
		{
			return String.Format("{0} Name: {1} Hunger: {2} is alive: {3}",
				this.GetType().Name, Name, Hunger, isAlive);
		}


	}
}
