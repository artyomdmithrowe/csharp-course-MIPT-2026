namespace ZooApp
{
    public class VeterinaryService : IVeterinaryProvider
    {
        private const int _healthThreshold = 70;
        private const int _kindnessThreshold = 5;

        public bool IsHealthy(Animal animal) => animal.Health > _healthThreshold;
        public bool IsFriendly(Herbo herbo) => herbo.Kindness > _kindnessThreshold;
    }
}
