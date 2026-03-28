using System.Collections.Generic;

namespace ZooApp
{
    public interface IInventoryStorage
    {
        void AddInventoryItem(IInventory inventoryItem);

        IReadOnlyList<IInventory> GetInventoryItems();
    }
}
