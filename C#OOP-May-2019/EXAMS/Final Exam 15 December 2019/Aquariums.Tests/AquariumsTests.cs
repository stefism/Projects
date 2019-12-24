namespace Aquariums.Tests
{
    using System;
    using NUnit.Framework;

    public class AquariumsTests
    {
        [Test]
        public void TestConstructor()
        {
            Aquarium auqarium = new Aquarium("Edno", 20);
            Assert.AreEqual("Edno", auqarium.Name);
            Assert.AreEqual(20, auqarium.Capacity);
            Assert.AreEqual(0, auqarium.Count);
        }

        [Test]
        public void TestAdd()
        {
            Aquarium auqarium = new Aquarium("Edno", 1);
            Fish fish = new Fish("Ribka");

            auqarium.Add(fish);

            Assert.AreEqual(1, auqarium.Count);
        }

        [Test]
        public void TestAddIsFull()
        {
            Aquarium auqarium = new Aquarium("Edno", 1);
            Fish fish = new Fish("Ribka");
            Fish fish2 = new Fish("Ribka2");

            auqarium.Add(fish);

            Assert.That(() => auqarium.Add(fish2), Throws.InvalidOperationException);
        }

        [Test]
        public void TestRemoveFish()
        {
            Aquarium auqarium = new Aquarium("Edno", 2);
            Fish fish = new Fish("Ribka");
            Fish fish2 = new Fish("Ribka2");

            auqarium.Add(fish);
            auqarium.Add(fish2);

            auqarium.RemoveFish("Ribka");

            Assert.AreEqual(1, auqarium.Count);
        }

        [Test]
        public void TestRemoveFishIsNone()
        {
            Aquarium auqarium = new Aquarium("Edno", 2);
            Fish fish = new Fish("Ribka");

            auqarium.Add(fish);

            Assert.That(() => auqarium.RemoveFish("PleaseGod!"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestSellFishIsNotExist()
        {
            Aquarium auqarium = new Aquarium("Edno", 2);
            Fish fish = new Fish("Ribka");

            auqarium.Add(fish);

            Assert.That(() => auqarium.SellFish("Molia"), Throws.InvalidOperationException);
        }

        [Test]
        public void TestSellFish()
        {
            Aquarium auqarium = new Aquarium("Edno", 2);
            Fish fish = new Fish("Ribka");

            auqarium.Add(fish);

            Fish selledFish = auqarium.SellFish("Ribka");

            Assert.AreEqual("Ribka", selledFish.Name);
            Assert.IsFalse(selledFish.Available);
        }

        [Test]
        public void TestReport()
        {
            Aquarium auqarium = new Aquarium("Edno", 2);
            Fish fish = new Fish("Ribka");

            auqarium.Add(fish);

            string result = auqarium.Report();
            string expected = $"Fish available at {auqarium.Name}: {fish.Name}";

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void TestInvalidAquariumName()
        {
            Assert.That(() => new Aquarium(null, 20), Throws.ArgumentNullException);
        }

        [Test]
        public void TestInvalidAquariumName2()
        {
            Assert.That(() => new Aquarium(string.Empty, 20), Throws.ArgumentNullException);
        }

        [Test]
        public void TestInvalidCapacity()
        {
            Assert.That(() => new Aquarium("Ribka", -1), Throws.ArgumentException);
        }
    }
}
