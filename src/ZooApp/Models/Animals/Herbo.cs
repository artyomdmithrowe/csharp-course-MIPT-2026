using System;

namespace ZooApp
{
    public class Herbo : Animal
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
                    Console.WriteLine($"Kindness can't be more than {_kindnessMax}. Kindness was set to {_kindnessMax}");
                    _kindness = _kindnessMax;
                    return;
                }

                if (value < 0)
                {
                    Console.WriteLine($"Kindness can't be less than 0. Kindness was set to 0");
                    _kindness = 0;
                    return;
                }

                _kindness = value;
            }
        }
    }
}
