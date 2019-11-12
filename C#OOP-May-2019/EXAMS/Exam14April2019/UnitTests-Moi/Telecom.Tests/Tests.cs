namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            phone = new Phone("az", "ti");
            phone.AddContact("Pesho", "4676567");
        }

        [Test]
        public void TestIfMakeIsEmpty()
        {
            Assert.That(() => new Phone("", "make"), Throws.ArgumentException);

        }

        [Test]
        public void TestIfMakeIsNull()
        {
            Assert.That(() => new Phone(null, "make"), Throws.ArgumentException);
        }

        [Test]
        public void TestIfModelIsNullOrEmpty()
        {
            Assert.That(() => new Phone("az", ""), Throws.ArgumentException);
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(phone.Make, Is.EqualTo("az"));
            Assert.That(phone.Model, Is.EqualTo("ti"));
        }

        [Test]
        public void TestAddContacts()
        {
            Assert.That(phone.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAddContactIfPersonAlreadyExist()
        {
            Assert.That(() => phone.AddContact("Pesho", "4676567"),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Person already exists!"));
        }

        [Test]
        public void TestCallIfContactMissing()
        {
            Assert.That(() => phone.Call("Lelka"), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Person doesn't exists!"));
        }

        [Test]
        public void TestCall()
        {
            string call = phone.Call("Pesho");

            Assert.That(phone.Call("Pesho"), Is.EqualTo("Calling Pesho - 4676567..."));
        }
    }
}