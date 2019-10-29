using _03E_WildFarm_Daskal.Models.Foods.Contracts;

namespace _03E_WildFarm_Daskal.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string AskFood();
        void Feed(IFood food);
    }
}
