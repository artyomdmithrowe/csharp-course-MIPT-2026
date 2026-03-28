using System;

namespace ZooApp
{
    public class Animal : IInventory, IAlive
    {
        private const int _healthMax = 100;
        private int _health;

        private int _food;

        public Animal(int number, int food, int health)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0.");
            }

            Number = number;
            Food = food;
            Health = health;
        }

        public int Number { get; }
        public int Food
        {
            get => _food;

            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"Food can't be less than 0. Food was set to 0");
                    _food = 0;
                    return;
                }

                _food = value;
            }
        }
        public int Health
        {
            get => _health;

            set
            {
                if (value > _healthMax)
                {
                    Console.WriteLine($"Health can't be more than {_healthMax}. Health was set to {_healthMax}");
                    _health = _healthMax;
                    return;
                }

                if (value < 0)
                {
                    Console.WriteLine($"Health can't be less than 0. Health was set to 0");
                    _health = 0;
                    return;
                }

                _health = value;
            }
        }
    }
}
