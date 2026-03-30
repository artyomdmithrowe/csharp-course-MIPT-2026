using System;

namespace ZooApp
{
    public abstract class Animal : IInventory, IAlive
    {
        private int _food;

        private const int _healthMax = 100;
        private int _health;

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
                    throw new ArgumentOutOfRangeException(nameof(value), "Food can't be less than 0.");
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
                    throw new ArgumentOutOfRangeException(nameof(value), $"Health can't be more than {_healthMax}.");
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Health can't be less than 0.");
                }

                _health = value;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}, Number: {Number}, Food: {Food}, Health: {Health}";
        }
    }
}
