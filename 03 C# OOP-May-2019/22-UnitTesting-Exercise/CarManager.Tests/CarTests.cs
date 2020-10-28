using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("Opel", "Astra", 3.5, 40.5);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Opel", car.Make);
            Assert.AreEqual("Astra", car.Model);
            Assert.AreEqual(3.5, car.FuelConsumption);
            Assert.AreEqual(40.5, car.FuelCapacity);
        }

        [Test]
        public void TestConstructorWithInvalidMakeProperty()
        {
            Assert.That(() => new Car(null, "A6", 3.5, 40.5), Throws.ArgumentException);
            Assert.That(() => new Car(string.Empty, "A6", 3.5, 40.5), Throws.ArgumentException);
        }

        [Test]
        public void TestConstructorWithInvalidModelProperty()
        {
            Assert.That(() => new Car("Audi", null, 3.5, 40.5), Throws.ArgumentException);
            Assert.That(() => new Car("Audi", string.Empty, 3.5, 40.5), Throws.ArgumentException);
            
        }

        [Test]
        public void TestConstructorWithInvalidFuelConsumptionProperty()
        {
            
            Assert.That(() => new Car("Audi", "A6", -1, 40.5), Throws.ArgumentException);
        }

        [Test]
        public void TestConstructorWithInvalidFuelConsumptionProperty2()
        {
            Assert.That(() => new Car("Audi", "A6", 0, 40.5), Throws.ArgumentException);
           
        }

        [Test]
        public void TestConstructorWithInvalidFuelCapacityProperty()
        {
            Assert.That(() => new Car("Audi", "A6", 5, -1), Throws.ArgumentException);
            
        }

        [Test]
        public void TestConstructorWithInvalidFuelCapacityProperty2()
        {
            
            Assert.That(() => new Car("Audi", "A6", 5, 0), Throws.ArgumentException);
        }

        [Test]
        public void TestRefuel()
        {
            car.Refuel(3);

            Assert.AreEqual(3, car.FuelAmount);
        }

        [Test]
        public void TestInvalidRefuel()
        {
            Assert.That(() => car.Refuel(-1), Throws.ArgumentException);
            
        }

        [Test]
        public void TestInvalidRefuel2()
        {
            
            Assert.That(() => car.Refuel(0), Throws.ArgumentException);
        }

        [Test]
        public void TestFuelAmountInRefuel()
        {
            car.Refuel(41);

            Assert.AreEqual(40, 5, car.FuelAmount);
        }

        [Test]
        public void TestDriveMethod()
        {
            car.Refuel(20);
            car.Drive(2);

            Assert.AreEqual(19.93, car.FuelAmount);
        }

        [Test]
        public void TestDriveWithNotEnoughFuel()
        {
            Assert.That(() => car.Drive(2), Throws.InvalidOperationException);
        }

    }
}