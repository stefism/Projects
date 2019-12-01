using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestConstructor()
        {
            Warrior warrior = new Warrior("Pesho", 15, 100);

            Assert.AreEqual("Pesho", warrior.Name);
            Assert.AreEqual(15, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [Test]
        public void TestEmptyName()
        {
            //Assert.Throws<ArgumentException>(()
            //    =>
            //{
            //    Warrior warrior = new Warrior("", 25, 100);
            //});

            Assert.That(() => new Warrior("", 25, 100), Throws.ArgumentException);
        }

        [Test]
        public void TestWhiteSpaceName()
        {
            //Assert.Throws<ArgumentException>(()
            //    =>
            //{
            //    Warrior warrior = new Warrior("   ", 25, 100);
            //});

            Assert.That(() => new Warrior("    ", 25, 100), Throws.ArgumentException);
        }

        [Test]
        public void TestDamageZero()
        {
            //Assert.Throws<ArgumentException>(()
            //    =>
            //{
            //    Warrior warrior = new Warrior("Pesho", 0, 10);
            //});

            Assert.That(() => new Warrior("Pesho", 0, 10), Throws.ArgumentException);
        }

        [Test]
        public void TestDamageBelowZero()
        {
            //Assert.Throws<ArgumentException>(()
            //    =>
            //{
            //    Warrior warrior = new Warrior("Pesho", -10, 50);
            //});

            Assert.That(() => new Warrior("Pesho", -10, 50), Throws.ArgumentException);
        }

        [Test]
        public void TestHealthBelowZero()
        {
            //Assert.Throws<ArgumentException>(()
            //    =>
            //{
            //    Warrior warrior = new Warrior("Pesho", 15, -10);
            //});

            Assert.That(() => new Warrior("Pesho", 15, -10), Throws.ArgumentException);
        }

        [Test]
        public void TestAttackWorksCorrectly()
        {
            int expAttackerHp = 95;
            int expDefenderHp = 80;

            Warrior attacker = new Warrior("Pesho", 10, 100);
            Warrior defender = new Warrior("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expAttackerHp, attacker.HP);
            Assert.AreEqual(expDefenderHp, defender.HP);
        }

        [Test]
        public void TestAttackWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 25);
            Warrior defender = new Warrior("Gosho", 5, 45);

            //Assert.Throws<InvalidOperationException>(()
            //    =>
            //{
            //    attacker.Attack(defender);
            //});

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException);
        }

        [Test]
        public void TestAttackEnemyWithLowHp()
        {
            Warrior attacker = new Warrior("Pesho", 10, 45);
            Warrior defender = new Warrior("Gosho", 5, 25);

            //Assert.Throws<InvalidOperationException>(()
            //    =>
            //{
            //    attacker.Attack(defender);
            //});

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException);
        }

        [Test]
        public void TestAttackStrongerEnemy()
        {
            Warrior attacker = new Warrior("Pesho", 10, 35);
            Warrior defender = new Warrior("Gosho", 40, 100);

            //Assert.Throws<InvalidOperationException>(()
            //    =>
            //{
            //    attacker.Attack(defender);
            //});

            Assert.That(() => attacker.Attack(defender), Throws.InvalidOperationException);
        }

        [Test]
        public void TestKillEnemy()
        {
            int expAttackerHp = 55;
            int expDefenderHp = 0;

            Warrior attacker = new Warrior("Pesho", 50, 100);
            Warrior defender = new Warrior("Gosho", 45, 40);

            attacker.Attack(defender);

            Assert.AreEqual(expAttackerHp, attacker.HP);
            Assert.AreEqual(expDefenderHp, defender.HP);
        }
    }
}