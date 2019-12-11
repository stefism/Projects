using EgnHelper;
using NUnit.Framework;
using System;

namespace Sandbox.Tests
{
    public class SandBoxTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetEgnInformationMethod()
        {
            string egn = "7552010005";
            string expected = "ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград";

            string info = Program.GetEgnInformation(egn);

            Assert.AreEqual(expected, info);
        }

        [Test]
        public void TestValidateFromUserMethod()
        {
            Program.ValidateFromUser(new EgnValidator(), "7552010005");

            //Program.Main();
        }
    }
}