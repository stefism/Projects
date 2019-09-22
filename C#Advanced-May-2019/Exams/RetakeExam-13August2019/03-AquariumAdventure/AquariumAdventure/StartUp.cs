namespace AquariumAdventure
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium("Ocean", 5, 15);

            Fish fish = new Fish("Goldy", "gold", 4);
            Fish fish2 = new Fish("Pepo", "green", 6);
            Fish fish3 = new Fish("Bobby", "orange", 4);

            aquarium.Add(fish);
            aquarium.Add(fish2);
            aquarium.Add(fish3);

            System.Console.WriteLine(fish.ToString());

            System.Console.WriteLine(aquarium.Report());

            System.Console.WriteLine(fish.ToString());

            ;
        }
    }
}
