using Xunit;

namespace ZooApp.Tests;

public class ZooTests
{
    private readonly VeterinaryService _veterinaryService = new();
    private readonly InventoryStorage _inventoryStorage = new();

    [Fact]
    public void AddAnimal_AddsHealthyAnimalToZoo()
    {
        Zoo zoo = CreateZoo();
        Rabbit rabbit = new(number: 1, food: 2, health: 85, kindness: 8);

        zoo.AddAnimal(rabbit);

        Assert.Single(zoo.GetAnimals());
        Assert.Contains(rabbit, zoo.GetAnimals());
    }

    [Fact]
    public void AddAnimal_Throws_WhenAnimalIsUnhealthy()
    {
        Zoo zoo = CreateZoo();
        Wolf wolf = new(number: 1, food: 4, health: 60);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => zoo.AddAnimal(wolf));

        Assert.Contains("unhealthy", exception.Message);
    }

    [Fact]
    public void GetAnimalsCount_ReturnsOnlyAnimalsCount()
    {
        Zoo zoo = CreateZoo();
        zoo.AddAnimal(new Rabbit(number: 1, food: 2, health: 85, kindness: 8));
        zoo.AddAnimal(new Tiger(number: 2, food: 6, health: 75));
        zoo.AddThing(new Table(number: 100));

        int count = zoo.GetAnimalsCount();

        Assert.Equal(2, count);
    }

    [Fact]
    public void GetTotalFoodPerDay_ReturnsSumOfAnimalFood()
    {
        Zoo zoo = CreateZoo();
        zoo.AddAnimal(new Rabbit(number: 1, food: 2, health: 85, kindness: 8));
        zoo.AddAnimal(new Tiger(number: 2, food: 6, health: 75));

        int totalFood = zoo.GetTotalFoodPerDay();

        Assert.Equal(8, totalFood);
    }

    [Fact]
    public void GetContactedAnimals_ReturnsOnlyFriendlyHerbivores()
    {
        Zoo zoo = CreateZoo();
        Rabbit friendlyRabbit = new(number: 1, food: 2, health: 85, kindness: 8);
        Monkey unfriendlyMonkey = new(number: 2, food: 3, health: 90, kindness: 4);
        Tiger tiger = new(number: 3, food: 6, health: 80);

        zoo.AddAnimal(friendlyRabbit);
        zoo.AddAnimal(unfriendlyMonkey);
        zoo.AddAnimal(tiger);

        List<Herbo> result = zoo.GetContactedAnimals();

        Assert.Single(result);
        Assert.Contains(friendlyRabbit, result);
    }

    [Fact]
    public void AddThing_AddsOnlyThingsToThingCollection()
    {
        Zoo zoo = CreateZoo();
        Table table = new(number: 100);

        zoo.AddThing(table);

        Assert.Single(zoo.GetThings());
        Assert.Contains(table, zoo.GetThings());
    }

    private Zoo CreateZoo()
    {
        return new Zoo(_veterinaryService, _inventoryStorage);
    }
}
