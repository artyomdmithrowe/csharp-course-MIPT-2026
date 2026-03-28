using Microsoft.Extensions.DependencyInjection;

namespace ZooApp;

internal static class Program
{
    private static void Main()
    {
        ServiceProvider serviceProvider = ConfigureServices();
        Zoo zoo = serviceProvider.GetRequiredService<Zoo>();

        Console.WriteLine("Moscow Zoo ERP");
        Console.WriteLine();

        Console.WriteLine("Adding animals:");
        TryAddAnimal(zoo, new Rabbit(number: 1, food: 2, health: 85, kindness: 8));
        TryAddAnimal(zoo, new Tiger(number: 2, food: 6, health: 75));
        TryAddAnimal(zoo, new Wolf(number: 3, food: 4, health: 60));

        try
        {
            TryAddAnimal(zoo, new Monkey(number: -1, food: 3, health: 80, kindness: 7));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Failed to create animal: {ex.Message}");
            Console.WriteLine();
        }

        TryAddAnimal(zoo, new Monkey(number: 4, food: 3, health: 80, kindness: 7));

        Console.WriteLine("Adding inventory items:");
        TryAddThing(zoo, new Table(number: 100));
        TryAddThing(zoo, new Computer(number: 101));
        TryAddThing(zoo, new Computer(number: 4));

        PrintZooStats(zoo);
        PrintContactZooAnimals(zoo);
        PrintThings(zoo);
    }

    private static ServiceProvider ConfigureServices()
    {
        ServiceCollection services = new();

        services.AddSingleton<IVeterinaryProvider, VeterinaryService>();
        services.AddSingleton<IInventoryStorage, InventoryStorage>();
        services.AddSingleton<Zoo>();

        return services.BuildServiceProvider();
    }

    private static void TryAddAnimal(Zoo zoo, Animal animal)
    {
        try
        {
            zoo.AddAnimal(animal);
            Console.WriteLine($"Added animal: {animal}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Failed to add animal {animal}: {ex.Message}");
        }

        Console.WriteLine();
    }

    private static void TryAddThing(Zoo zoo, Thing thing)
    {
        try
        {
            zoo.AddThing(thing);
            Console.WriteLine($"Added thing: {thing}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Failed to add thing {thing}: {ex.Message}");
        }

        Console.WriteLine();
    }

    private static void PrintZooStats(Zoo zoo)
    {
        Console.WriteLine($"Animals count: {zoo.GetAnimalsCount()}");
        Console.WriteLine($"Total food per day: {zoo.GetTotalFoodPerDay()} kg");
    
        Console.WriteLine();
    }

    private static void PrintContactZooAnimals(Zoo zoo)
    {
        Console.WriteLine("Animals for contact zoo:");

        foreach (Herbo herbo in zoo.GetContactedAnimals())
        {
            Console.WriteLine(herbo);
        }

        Console.WriteLine();
    }

    private static void PrintThings(Zoo zoo)
    {
        Console.WriteLine("Inventory items:");

        foreach (Thing thing in zoo.GetThings())
        {
            Console.WriteLine(thing);
        }

        Console.WriteLine();
    }
}
