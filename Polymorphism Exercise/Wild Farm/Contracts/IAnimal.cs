

namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FootEaten { get; }
        string ProduceSound();
        void Feed(IFood food);
    }
}
