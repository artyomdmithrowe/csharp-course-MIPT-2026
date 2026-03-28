using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooApp
{
    public class InventoryStorage : IInventoryStorage
    {
        private readonly List<IInventory> _inventoryItems = new List<IInventory>();

        public void AddInventoryItem(IInventory inventoryItem)
        {
            if (_inventoryItems.Any(x => x.Number == inventoryItem.Number))
            {
                throw new InvalidOperationException($"Inventory item with number {inventoryItem.Number} already exists.");
            }

            _inventoryItems.Add(inventoryItem);
        }

        public IReadOnlyList<IInventory> GetInventoryItems() => _inventoryItems.ToList();
    }
}
