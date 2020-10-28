using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private int databaseCount;
        Database.Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database.Database(1, 2, 3, 4);
            databaseCount = database.Count;
        }

        [Test]
        public void TestConstructor()
        {
            Assert.That(database.Count, Is.EqualTo(4));
        }

        [Test]
        public void TestAddElement()
        {
            database.Add(6);

            Assert.That(database.Count, Is.EqualTo(databaseCount + 1));
        }

        [Test]
        public void TestIsDatabaseCountIsExactly16Elements()
        {
            for (int i = 1; i <= 12; i++)
            {
                database.Add(i);
            }

            Assert.That(() => database.Add(1), Throws
                .InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void TestRemoveFromCollection()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(databaseCount - 1));
        }

        [Test]
        public void TestRemoveFromEmptyCollection()
        {
            for (int i = 1; i <= 4; i++)
            {
                database.Remove();
            }

            Assert.That(() => database.Remove(), Throws
                .InvalidOperationException.With.Message
                .EqualTo("The collection is empty!"));
        }

        [Test]
        public void TestFetchMethodInCollection()
        {
            int[] fetchArray = database.Fetch();

            Assert.That(database.Count, Is.EqualTo(fetchArray.Length));
        }
    }
}