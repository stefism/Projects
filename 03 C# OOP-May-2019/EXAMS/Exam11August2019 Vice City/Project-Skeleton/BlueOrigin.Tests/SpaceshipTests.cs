namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private Spaceship testShip;

        [SetUp]
        public void SetUp()
        {
            testShip = new Spaceship("Lelka", 1);
        }

       [Test]
       public void TestSpaceshipConstructor()
        {
            Spaceship spaceship = new Spaceship("Sovalka", 20);
            Assert.AreEqual("Sovalka", spaceship.Name);
            Assert.AreEqual(20, spaceship.Capacity);
        }

        [TestCase(null, 20)]
        [TestCase("", 20)]
        public void TestInvalidNameForSpaceshipConstructor
            (string name, int capacity)
        {
            Assert.That(() => new Spaceship(name, capacity), 
                Throws.ArgumentNullException);
        }

        [Test]
        public void TestInvalidCapacity()
        {
            Assert.That(() => new Spaceship("Kosmos", -1), 
                Throws.ArgumentException);
        }

        [Test]
        public void TestAddMethodAndCount()
        {
            Astronaut gosko = new Astronaut("Gosko", 20);

            testShip.Add(gosko);
            Assert.AreEqual(1, testShip.Count);
        }

        [Test]
        public void TestAddIfSpaceshipIsFull()
        {
            Astronaut gosko = new Astronaut("Gosko", 20);
            Astronaut mincho = new Astronaut("Mincho", 8);

            testShip.Add(gosko);

            Assert.That(() => testShip.Add(mincho), 
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestAddIfAstronaultExist()
        {
            Spaceship ship = new Spaceship("Koko", 3);

            Astronaut gosko = new Astronaut("Gosko", 20);

            ship.Add(gosko);

            Assert.That(() => ship.Add(gosko),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestAstronaultOxygen()
        {
            Astronaut gosko = new Astronaut("Gosko", 20);

            Assert.AreEqual(20, gosko.OxygenInPercentage);
        }

        [Test]
        public void TestRemoveIsTrue()
        {
            Astronaut gosko = new Astronaut("Gosko", 20);
            
            testShip.Add(gosko);

            bool isRemoveGosko = testShip.Remove("Gosko");

            Assert.IsTrue(isRemoveGosko);
        }

        [Test]
        public void TestRemoveIsFalse()
        {
            Astronaut gosko = new Astronaut("Gosko", 20);

            testShip.Add(gosko);

            bool isRemoveMinko = testShip.Remove("Minko");

            Assert.IsFalse(isRemoveMinko);
        }
    }
}