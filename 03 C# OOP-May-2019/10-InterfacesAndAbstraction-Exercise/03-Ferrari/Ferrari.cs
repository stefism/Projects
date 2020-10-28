namespace _03_Ferrari
{
    public class Ferrari : Icar
    {
        public Ferrari(string carName, string model, string driverName)
        {
            CarName = carName;
            Model = model;
            DriverName = driverName;
        }

        public string CarName { get; private set; }

        public string Model { get; private set; }

        public string DriverName { get; private set; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Gas!";
        }
    }
}
