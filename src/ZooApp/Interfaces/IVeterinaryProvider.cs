namespace ZooApp
{
    public interface IVeterinaryProvider
    {
        bool IsHealthy(Animal animal);
        bool IsFriendly(Herbo herbo);
    }
}
