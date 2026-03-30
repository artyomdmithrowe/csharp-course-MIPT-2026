using Xunit;

namespace ZooApp.Tests;

public class InventoryStorageTests
{
    [Fact]
    public void AddInventoryItem_AddsItem_WhenNumberIsUnique()
    {
        InventoryStorage storage = new();
        Table table = new(number: 100);

        storage.AddInventoryItem(table);

        IReadOnlyList<IInventory> items = storage.GetInventoryItems();
        Assert.Single(items);
        Assert.Same(table, items[0]);
    }

    [Fact]
    public void AddInventoryItem_Throws_WhenNumberAlreadyExists()
    {
        InventoryStorage storage = new();

        storage.AddInventoryItem(new Table(number: 100));

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(
            () => storage.AddInventoryItem(new Computer(number: 100)));

        Assert.Contains("already exists", exception.Message);
    }

    [Fact]
    public void GetInventoryItems_ReturnsCopyOfCurrentState()
    {
        InventoryStorage storage = new();
        storage.AddInventoryItem(new Table(number: 100));

        IReadOnlyList<IInventory> firstSnapshot = storage.GetInventoryItems();
        storage.AddInventoryItem(new Computer(number: 101));
        IReadOnlyList<IInventory> secondSnapshot = storage.GetInventoryItems();

        Assert.Single(firstSnapshot);
        Assert.Equal(2, secondSnapshot.Count);
    }
}
