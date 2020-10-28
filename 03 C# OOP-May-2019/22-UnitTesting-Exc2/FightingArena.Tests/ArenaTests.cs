using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void TestConstructor()
        {
            Assert.IsNotNull(arena.Warriors);
        }

        [Test]
        public void TestEnrollWorksCorrectly()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.That(arena.Warriors, Has.Member(warrior));
        }

        [Test]
        public void TestEnrollExistingWarrior()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            arena.Enroll(warrior);

            //Assert.Throws<InvalidOperationException>(()
            //    =>
            //{
            //    arena.Enroll(warrior);
            //});

            Assert.That(() => arena.Enroll(warrior), Throws.InvalidOperationException);
        }

        [Test]
        public void TestCount()
        {
            Warrior warrior = new Warrior("Pesho", 10, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void TestFight()
        {
            int expAttackerHp = 95;
            int expDefenderHp = 40;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expAttackerHp, attacker.HP);
            Assert.AreEqual(expDefenderHp, defender.HP);
        }

        [Test]
        public void TestFightWithMissingWarrior()
        {
            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 50);

            arena.Enroll(attacker);

            //Assert.Throws<InvalidOperationException>(()
            //    =>
            //{
            //    arena.Fight(attacker.Name, defender.Name);
            //});

            Assert.That(() => arena.Fight(attacker.Name, defender.Name),
                Throws.InvalidOperationException);
        }
    }
}
