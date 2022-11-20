
using czechitasZoo.classes;


var zoo = new Zoo();
zoo.AddAnimal(new Goat("Pepa"));
zoo.AddAnimal(new Tiger("David"));
Console.WriteLine(zoo);


while (true)
{
	zoo.Update();
	Console.WriteLine(zoo);
	Thread.Sleep(1000);
}
