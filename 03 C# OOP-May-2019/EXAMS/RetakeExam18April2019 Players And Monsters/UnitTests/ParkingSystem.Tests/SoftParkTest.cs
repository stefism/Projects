namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private SoftPark softPark;
        private Car testCar = new Car("Opel", "CA4567AA");
        private Dictionary<string, Car> testParking;

        [SetUp]
        public void Setup()
        {
            softPark = new SoftPark();
            testParking = new Dictionary<string, Car>
            {
                {"A2", null},
                {"A3", null}
            };
            softPark.ParkCar("A1", testCar);
        }

        [Test]
        public void TestInialDictionaryCount()
        {
            Assert.That(softPark.Parking.Count, Is.EqualTo(12));
        }

        [Test]
        public void TestParkCarIfParkSpotNotExist()
        {
            Assert.That(() => softPark.ParkCar("Spot", testCar), Throws.ArgumentException);
        }

        [Test]
        public void TestParkCarIfParkSpotIsTaken()
        {
            Assert.That(() => softPark.ParkCar("A1", testCar), Throws.ArgumentException);
        }

        [Test]
        public void TestParkCarIfCarAlreadyExist()
        {
            Assert.That(() => softPark.ParkCar("A2", testCar), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveCarIfParkSpotNotExist()
        {
            Assert.That(() => softPark.RemoveCar("F3", testCar), Throws.ArgumentException);
        }

        [Test]
        public void TestRemoveCarIfThisCarInThisSpotNotExist()
        {
            Car car2 = new Car("Audi", "4546");

            Assert.That(() => softPark.RemoveCar("A1", car2), Throws.ArgumentException);
        }

        [Test]
        public void TestRemoveCarSuccessfully()
        {
            Car car2 = new Car("Audi", "4546");
            softPark.ParkCar("A2", car2);

            softPark.RemoveCar("A2", car2);

            Assert.That(testParking["A2"] == null);
        }

        [Test]
        public void TestMakeCar()
        {
            Car car2 = new Car("Audi", "4546");

            Assert.That(car2.Make, Is.EqualTo("Audi"));
        }
    }
}