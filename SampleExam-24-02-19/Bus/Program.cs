using System;

namespace Bus
{
    class Program
    {
        static void Main(string[] args)
        {
            int passengerInBus = int.Parse(Console.ReadLine());
            int stopNumbers = int.Parse(Console.ReadLine());

            int totalPassengerIn = 0;
            int totalPassengerOut = 0;
            int conductors = 2;

            for (int i = 1; i <= stopNumbers; i++)
            {
                int passengerOut = int.Parse(Console.ReadLine());
                int passengerIn = int.Parse(Console.ReadLine());

                if (i % 2 == 0)
                {
                    passengerInBus = passengerInBus - passengerOut;
                    passengerInBus = (passengerInBus + passengerIn) - conductors;
                }
                else
                {
                    passengerInBus = passengerInBus - passengerOut;
                    passengerInBus = (passengerInBus + passengerIn) + conductors;
                }
            }
            //double finalPassengerInBus = totalPassengerIn - totalPassengerOut;

            Console.WriteLine($"The final number of passengers is : {passengerInBus}");
        }
    }
}
