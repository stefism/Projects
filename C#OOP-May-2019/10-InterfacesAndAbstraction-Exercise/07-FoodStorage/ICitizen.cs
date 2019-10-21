using System.Numerics;

namespace _05_BorderControl
{
    public interface ICitizen
    {
        string Name { get; }
        int Age { get; }
        BigInteger Id { get; }
    }
}
