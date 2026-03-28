using System;

namespace ZooApp
{
    public abstract class Herbo : Animal
    {
        private const int _kindnessMax = 10;
        private int _kindness;

        public Herbo(int number, int food, int health, int kindness)
            : base(number, food, health)
        {
            Kindness = kindness;
        }
        
        public int Kindness
        {
            get => _kindness;

            set
            {
                if (value > _kindnessMax)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"Kindness can't be more than {_kindnessMax}.");
                }

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Kindness can't be less than 0.");
                }

                _kindness = value;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}, Number: {Number}, Food: {Food}, Health: {Health}, Kindness: {Kindness}";
        }
    }
}
