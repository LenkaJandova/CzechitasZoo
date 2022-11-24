
using czechitasZoo.classes;


var zoo = new Zoo();
//TODO massive refactoring, exception controll, tests for nullability.....
bool? anotherAnimal = null;
do
{
	string? animalType = null;
	do
	{
		Console.WriteLine(zoo);
		Console.WriteLine("Please add animal, you can pick from tiger and goat");
		string? animal = Console.ReadLine();
		switch (animal)
		{
			case "goat":
				animalType = "goat";
				break;
			case "tiger":
				animalType = "tiger";
				break;
			default:
				Console.WriteLine("wrong answer, try again");
				break;
		}
	}
	while (animalType == null);

	string? animalName = null;
	do
	{
		Console.WriteLine("Please add animal name.");
		string? input2 = Console.ReadLine();
		if (string.IsNullOrEmpty(input2))
		{
			Console.WriteLine("wrong answer, try again");
		}
		else
		{
			animalName = input2;
		}
	}
	while (animalName == null);

	switch (animalType)
	{
		case "goat":
			zoo.AddAnimal(new Goat(animalName));
			break;
		case "tiger":
			zoo.AddAnimal(new Tiger(animalName));
			break;
	}

	Console.WriteLine("Would you like to add another animal Y/N?");
	string? input = Console.ReadLine();
	if (input == "Y")
	{
		anotherAnimal = true;
	}
	else
	{
		anotherAnimal = false;
	}
} while (anotherAnimal == true);


while (true)
{
	zoo.Update();
	Console.WriteLine(zoo);
	Thread.Sleep(1000);
}
