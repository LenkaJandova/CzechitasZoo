using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czechitasZoo.classes
{
	internal class Goat : Animal
	{
		public Goat(string name) : base(name)
		{
		}

		public override FoodType Food => FoodType.GRASS;
	}
}
