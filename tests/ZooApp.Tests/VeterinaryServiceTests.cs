using Xunit;

namespace ZooApp.Tests;

public class VeterinaryServiceTests
{
    [Fact]
    public void IsHealthy_ReturnsTrue_WhenHealthIsAboveThreshold()
    {
        VeterinaryService service = new();
        Tiger tiger = new(number: 1, food: 10, health: 80);

        bool result = service.IsHealthy(tiger);

        Assert.True(result);
    }

    [Fact]
    public void IsHealthy_ReturnsFalse_WhenHealthIsAtOrBelowThreshold()
    {
        VeterinaryService service = new();
        Wolf wolf = new(number: 1, food: 6, health: 70);

        bool result = service.IsHealthy(wolf);

        Assert.False(result);
    }

    [Fact]
    public void IsFriendly_ReturnsTrue_WhenKindnessIsAboveThreshold()
    {
        VeterinaryService service = new();
        Rabbit rabbit = new(number: 1, food: 2, health: 90, kindness: 8);

        bool result = service.IsFriendly(rabbit);

        Assert.True(result);
    }

    [Fact]
    public void IsFriendly_ReturnsFalse_WhenKindnessIsAtOrBelowThreshold()
    {
        VeterinaryService service = new();
        Monkey monkey = new(number: 1, food: 3, health: 90, kindness: 5);

        bool result = service.IsFriendly(monkey);

        Assert.False(result);
    }
}
