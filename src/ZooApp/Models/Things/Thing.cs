using System;

namespace ZooApp
{
    public abstract class Thing : IInventory
    {
        public int Number { get; }

        public Thing(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Number must be greater than 0.");
            }

            Number = number;
        }

        public override string ToString()
        {
            return $"{GetType().Name}, Number: {Number}";
        }
    }
}
