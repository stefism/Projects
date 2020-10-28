using System.Numerics;

namespace _05_BorderControl
{
    public class Robot : Resident, IRobot
    {
        public Robot(string model, BigInteger id) : base(model, id)
        {
            Name = model;
            Id = id;
        }
    }
}
