namespace _03_Ferrari
{
    public interface Icar
    {
        string CarName { get; }

        string Model { get; }

        string DriverName { get; }

        string Gas();

        string Brakes();
    }
}
