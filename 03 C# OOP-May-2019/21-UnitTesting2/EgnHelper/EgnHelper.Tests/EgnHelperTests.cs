using NUnit.Framework;
using System;

namespace EgnHelper.Tests
{
    public class EgnHelperTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase ("7523169263")]
        [TestCase ("8032056031")]
        [TestCase ("7542011030")]
        public void TestForValidEgn(string egn)
        {
            EgnValidator validate = new EgnValidator();

            bool result = validate.IsValid(egn);

            Assert.AreEqual(true, result); // Èëè ...
            //Assert.IsTrue(result);
        }

        [TestCase ("7542548030")]
        [TestCase ("8872548030")]
        [TestCase ("88aas48030")]
        [TestCase("7523169262")]
        public void TestForInvalidEgn(string egn)
        {
            EgnValidator validate = new EgnValidator();
            bool result = validate.IsValid(egn);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void TestIfEgnIsNullThrowException()
        {
            EgnValidator validate = new EgnValidator();

            Assert.That(() => validate.IsValid(null),
                Throws.ArgumentNullException);
        }
    }
}