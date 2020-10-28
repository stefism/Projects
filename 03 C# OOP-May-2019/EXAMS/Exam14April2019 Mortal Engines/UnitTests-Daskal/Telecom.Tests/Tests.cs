namespace Telecom.Tests
{
    using NUnit.Framework;
    using System;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            phone = new Phone("Make", "Model");
        }

        [Test]
        public void TestConstructor()
        {
            Assert.AreEqual("Make", phone.Make);
            Assert.AreEqual("Model", phone.Model);
        }

        [Test]
        public void TestIfMakeIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(string.Empty, "Model");
            });
        }

        [Test]
        public void TestIfModelIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone("Make", string.Empty);
            });
        }

        [Test]
        public void TestInialCountIsZero()
        {
            Assert.AreEqual(0, phone.Count);
        }

        [Test]
        public void TestAddWorksCorrectly()
        {
            phone.AddContact("Kiki", "45678");
            phone.AddContact("Lili", "76543");

            Assert.AreEqual(2, phone.Count);
        }

        [Test]
        public void TestAddExistingPerson()
        {
            phone.AddContact("Kiki", "45678");

            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.AddContact("Kiki", "45678");
            });
        }

        [Test]
        public void TestCallCorrectly()
        {
            string output = "Calling Kiki - 45678...";

            phone.AddContact("Kiki", "45678");

            Assert.AreEqual(output, phone.Call("Kiki"));
        }

        [Test]
        public void TestCallingNonExistingNumber()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                phone.Call("Sletla");
            });
        }
    }
}