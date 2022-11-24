using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czechitasZoo.classes
{
	class Zoo : Updateable
	{
		public List<Animal> Pen { get; set; } = new List<Animal>();
		public Dictionary<FoodType, int> Feeder { get; set; } = new Dictionary<FoodType, int>();

		public List<Animal> eatenAnimals = new List<Animal>();
		public void AddAnimal(Animal animal)
		{ 
			Pen.Add(animal);
			animal.MyZoo = this;
		}

		public override string ToString() 
		{
			var sb = new StringBuilder();
			sb.AppendLine("List of the animals in the Zoo: ");
			foreach (Animal animal in Pen)
			{
				sb.AppendLine(animal.ToString());
			}
			return sb.ToString();
		}

		int feedingCounter = 0;
		public void Update()
		{
			feedingCounter ++;
		
			foreach (Animal animal in Pen)
			{
				animal.Update();
			}
			if (feedingCounter == 20)
			{
				feedingCounter = 0;
				SupplyFood();
			}
			Pen.RemoveAll(a => eatenAnimals.Contains(a));
			eatenAnimals.Clear();
		}

		private void SupplyFood()
		{
			Console.WriteLine("Feeding time!");
			
			if (Feeder.ContainsKey(FoodType.GRASS))
			{
				Feeder[FoodType.GRASS] += 20;
			}
			else
			{
				Feeder.Add(FoodType.GRASS, 20);
			}
			if (Feeder.ContainsKey(FoodType.MEAT))
			{
				Feeder[FoodType.MEAT] += 40;
			}
			else
			{
				Feeder.Add(FoodType.MEAT, 40);
			}
		}
		//private void FeedAnimals()
		//{
		//	Console.WriteLine("Feeding time!");
		//	var feeder = new Dictionary<FoodType, int>();
		//	feeder.Add(FoodType.GRASS, 20);
		//	feeder.Add(FoodType.MEAT, 40);

		//	foreach (Animal animal in Pen.Where(a => a.isAlive == true))
		//	{
		//		foreach (FoodType type in Enum.GetValues(typeof(FoodType)))
		//		{
		//			if (animal.Food == type)
		//			{
		//				var feedingQuantity = Math.Min(feeder[type], animal.Hunger);
		//				feeder[type] -= feedingQuantity;
		//				animal.Hunger -= feedingQuantity;
		//				Console.WriteLine($"Right now, {animal.Name} is eating {feedingQuantity} of {type}");

		//			}
		//		}
		//	}
		//}
	}
}
