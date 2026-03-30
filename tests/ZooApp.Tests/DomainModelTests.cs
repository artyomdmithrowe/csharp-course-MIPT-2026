using Xunit;

namespace ZooApp.Tests;

public class DomainModelTests
{
    [Fact]
    public void AnimalConstructor_Throws_WhenNumberIsNotPositive()
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => new Tiger(number: 0, food: 6, health: 80));

        Assert.Contains("Number must be greater than 0", exception.Message);
    }

    [Fact]
    public void ThingConstructor_Throws_WhenNumberIsNotPositive()
    {
        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => new Table(number: 0));

        Assert.Contains("Number must be greater than 0", exception.Message);
    }

    [Fact]
    public void FoodSetter_Throws_WhenFoodIsNegative()
    {
        Tiger tiger = new(number: 1, food: 6, health: 80);

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => tiger.Food = -1);

        Assert.Contains("Food can't be less than 0", exception.Message);
    }

    [Fact]
    public void HealthSetter_Throws_WhenHealthIsNegative()
    {
        Tiger tiger = new(number: 1, food: 6, health: 80);

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => tiger.Health = -1);

        Assert.Contains("Health can't be less than 0", exception.Message);
    }

    [Fact]
    public void HealthSetter_Throws_WhenHealthIsAboveMax()
    {
        Tiger tiger = new(number: 1, food: 6, health: 80);

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => tiger.Health = 101);

        Assert.Contains("Health can't be more than 100", exception.Message);
    }

    [Fact]
    public void KindnessSetter_Throws_WhenKindnessIsNegative()
    {
        Rabbit rabbit = new(number: 1, food: 2, health: 85, kindness: 8);

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => rabbit.Kindness = -1);

        Assert.Contains("Kindness can't be less than 0", exception.Message);
    }

    [Fact]
    public void KindnessSetter_Throws_WhenKindnessIsAboveMax()
    {
        Rabbit rabbit = new(number: 1, food: 2, health: 85, kindness: 8);

        ArgumentOutOfRangeException exception = Assert.Throws<ArgumentOutOfRangeException>(
            () => rabbit.Kindness = 11);

        Assert.Contains("Kindness can't be more than 10", exception.Message);
    }

    [Fact]
    public void AnimalToString_ReturnsFormattedDescription()
    {
        Tiger tiger = new(number: 2, food: 6, health: 75);

        string result = tiger.ToString();

        Assert.Equal("Tiger, Number: 2, Food: 6, Health: 75", result);
    }

    [Fact]
    public void HerboToString_ReturnsFormattedDescription()
    {
        Rabbit rabbit = new(number: 1, food: 2, health: 85, kindness: 8);

        string result = rabbit.ToString();

        Assert.Equal("Rabbit, Number: 1, Food: 2, Health: 85, Kindness: 8", result);
    }

    [Fact]
    public void ThingToString_ReturnsFormattedDescription()
    {
        Table table = new(number: 100);

        string result = table.ToString();

        Assert.Equal("Table, Number: 100", result);
    }
}
