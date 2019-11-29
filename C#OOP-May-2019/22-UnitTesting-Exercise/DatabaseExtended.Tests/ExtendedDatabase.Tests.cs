using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase.ExtendedDatabase extDatabase;
        Person person1; Person person2; Person person3;
        private int databaseCount;

        [SetUp]
        public void Setup()
        {
            person1 = new Person(7898905, "Ivan");
            person2 = new Person(3434348, "Gosho");
            person3 = new Person(78565645, "Mitko");

            extDatabase = new ExtendedDatabase
                .ExtendedDatabase(person1, person2, person3);

            databaseCount = extDatabase.Count;
        }

        [Test]
        public void TestConstructorToAddExactly16Range()
        {
            Person[] personList = new Person[17];

            Assert.That(() => new ExtendedDatabase.ExtendedDatabase(personList),
                Throws.ArgumentException);
        }

        [Test]
        public void TestToAddOverCapacityOf16Elements()
        {
            for (int i = 1; i <= 13; i++)
            {
                Person currPerson = new Person(i, i.ToString());
                extDatabase.Add(currPerson);
            }

            Person pepi = new Person(67676, "Pepi");

            Assert.That(() => extDatabase.Add(pepi), Throws.InvalidOperationException);
        }

        [Test]
        public void TestAddUserWithSameName()
        {
            Assert.That(() => extDatabase.Add(person1), Throws
                .InvalidOperationException);
        }

        [Test]
        public void TestAddPersonWithSameId()
        {
            Person mimeto = new Person(7898905, "Mimeto");

            Assert.That(() => extDatabase.Add(mimeto), Throws
                .InvalidOperationException);
        }

        [Test]
        public void TestRemovePeople()
        {
            extDatabase.Remove();
            extDatabase.Remove();
            extDatabase.Remove();

            Assert.That(() => extDatabase.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void TestFindByUserNameIfStringIsNullOrEmpty()
        {
            Assert.That(() => extDatabase.FindByUsername(string.Empty), Throws
                .ArgumentNullException);
        }

        [Test]
        public void TestIfUserNameNotExist()
        {
            Assert.That(() => extDatabase.FindByUsername("Draganka"), Throws
                .InvalidOperationException);
        }

        [Test]
        public void TestFinfByUserName()
        {
            Person person = extDatabase.FindByUsername("Ivan");

            Assert.That(person != null);
        }

        [Test]
        public void TestFindPersonByIdAndIdIsNegative()
        {
            Assert.That(() => extDatabase.FindById(-34), Throws
                .Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TestIfPersonIdIsNotExist()
        {
            Assert.That(() => extDatabase.FindById(641), Throws
                .InvalidOperationException);
        }

        [Test]
        public void TestFindPersonById()
        {
            Person person = extDatabase.FindById(7898905);

            Assert.That(person.UserName == "Ivan");
        }
    }
}