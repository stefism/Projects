using NUnit.Framework;
using System;

namespace Lab.Tests
{
    [TestFixture]
    public class AxeTest
    {
        private Axe axe;
        private Dummy dummy;

        //[SetUp]
        //public void CreareClassInstances()
        //{
        //    axe = new Axe(50, 30);
        //    dummy = new Dummy(20, 20);
        //}

        [Test]
        public void TestIfWeaponLossesDurabilityAfterEachAttack()
        {
            axe = new Axe(50, 30);
            dummy = new Dummy(20, 20);

            int axeDurability = axe.DurabilityPoints;

            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(axeDurability-1));
        }

        [Test]
        public void TestAttackWithBrokenWeapon()
        {
            axe = new Axe(5, 0);
            dummy = new Dummy(20, 20);

            Assert.That(() => axe.Attack(dummy), 
                Throws.InvalidOperationException
                .With.Message.EqualTo("Axe is broken."));
        }
    }
}
