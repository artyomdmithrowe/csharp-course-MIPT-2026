using System;
using System.Collections.Generic;
using System.Linq;

namespace ZooApp
{
    public class Zoo
    {
        private readonly IVeterinaryProvider _veterinaryService;
        private readonly IInventoryStorage _inventoryStorage;

        public Zoo(IVeterinaryProvider veterinaryService, IInventoryStorage inventoryStorage)
        {
            _veterinaryService = veterinaryService;
            _inventoryStorage = inventoryStorage;
        }

        public void AddAnimal(Animal animal)
        {
            if (!_veterinaryService.IsHealthy(animal))
            {
                Console.WriteLine("Animal is unhealthy, it can't be added to the zoo.");
                return;
            }

            try
            {
                _inventoryStorage.AddInventoryItem(animal);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddInventoryItem(IInventory inventoryItem)
        {
            if (inventoryItem is IAlive)
            {
                Console.WriteLine("It is an animal. This thing can't be added to the zoo. Use AddAnimal method.");
                return;
            }

            try
            {
                _inventoryStorage.AddInventoryItem(inventoryItem);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Thing> GetThings()
        {
            return _inventoryStorage.GetInventoryItems().OfType<Thing>().ToList();
        }

        public List<Animal> GetAnimals()
        {
            return _inventoryStorage.GetInventoryItems().OfType<Animal>().ToList();
        }

        public List<Herbo> GetContactedAnimals()
        {
            return GetAnimals().OfType<Herbo>().Where(herbo => _veterinaryService.IsFriendly(herbo)).ToList();
        }
    }
}
