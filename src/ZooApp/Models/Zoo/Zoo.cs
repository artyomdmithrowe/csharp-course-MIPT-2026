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
                throw new InvalidOperationException("Animal is unhealthy, it can't be added to the zoo.");
            }

            _inventoryStorage.AddInventoryItem(animal);
        }

        public void AddThing(Thing thing)
        {
            _inventoryStorage.AddInventoryItem(thing);
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

        public int GetAnimalsCount() => GetAnimals().Count;

        public int GetTotalFoodPerDay() => GetAnimals().Sum(animal => animal.Food);
    }
}
