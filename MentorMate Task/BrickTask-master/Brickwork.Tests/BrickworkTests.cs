namespace Brickwork.Tests
{
    using NUnit.Framework;

    public class BrickworkTests
    {
        [SetUp]
        public void Setup()
        {
            IBuilder builder = new Builder();
        }

        [TestCase("Row must be even number", 33)]
        public void ValidIfThrowsExeptionWhenRowsAreNotEven(string message, int data)
        {
            IBuilder builder = new Builder();
            Assert.That(() => builder.Rows = data, Throws.ArgumentException, message);
        }

        [TestCase("Coll must be even number", 33)]
        public void ValidIfThrowsExeptionWhenCollsAreNotEven(string message, int data)
        {
            IBuilder builder = new Builder();
            Assert.That(() => builder.Colls = data, Throws.ArgumentException, message);
        }

        [TestCase("Rows must be a number between 1 and 101", 1)]
        [TestCase("Rows must be a number between 1 and 101", 101)]
        public void ValidIfThrowsExeptionWhenRowsAreOutsideBoundaries(string message, int data)
        {
            IBuilder builder = new Builder();
            Assert.That(() => builder.Rows = data, Throws.ArgumentException, message);
        }

        [TestCase("Colls must be a number between 1 and 101", 1)]
        [TestCase("Colls must be a number between 1 and 101", 101)]
        public void ValidIfThrowsExeptionWhenCollsAreOutsideBoundaries(string message, int data)
        {
            IBuilder builder = new Builder();
            Assert.That(() => builder.Colls = data, Throws.ArgumentException, message);
        }

        [TestCase("Bricks must be with size 2")]
        public void ValidIfThrowsExeptionWhenBricksAreInvalid(string message)
        {
            int[,] wall = new int[2, 2]
                {
                    {1, 1},
                    {1, 2}
            };

            IBuilder builder = new Builder();
            builder.Rows = 2;
            builder.Colls = 2;
            builder.CreateBase();

            for (int count = 0; count < wall.GetLength(0); count++)
            {
                builder.CreateFirstLayer(GetRow(wall, count), count);
            }

            Assert.That(() => builder.ValidateBricks(), Throws.ArgumentException, message);
        }

        [TestCase("Count input numbers for every row must be the same as the input size")]
        public void ValidIfThrowsExeptionWhenInputCollsAreDifferentThanBaseColls(string message)
        {
            int[,] wall = new int[4, 4]
                {
                    {1, 1, 3, 4},
                    {2, 2, 3 ,4},
                    {5, 6, 7 ,7},
                    {5, 6, 8 ,8},
            };

            IBuilder builder = new Builder();
            builder.Rows = 2;
            builder.Colls = 2;
            builder.CreateBase();

            Assert.IsFalse(builder.CreateFirstLayer(GetRow(wall, 0), 0), message);
        }


        // Performance drop in high row/coll values  
        [TestCase("Builder cannot build new wall with size 10 x 10", 10, 10)]
        [TestCase("Builder cannot build new wall with size 30 x 30", 30, 30)]
        [TestCase("Builder cannot build new wall with size 80 x 20", 80, 20)]
        [TestCase("Builder cannot build new wall with size 100 x 30", 100, 30)]
        [TestCase("Builder cannot build new wall with size 30 x 38", 30, 38)]
        public void ValidIfBuilderSuccesfullyFinishedWallWithSizeN(string message, params int[] data)
        {
            int rows = data[0];
            int colls = data[1];

            int[,] wall = NumberGenerator.Generate(rows, colls);

            IBuilder builder = new Builder();
            builder.Rows = rows;
            builder.Colls = colls;
            builder.CreateBase();

            for (int count = 0; count < wall.GetLength(0); count++)
            {
                builder.CreateFirstLayer(GetRow(wall, count), count);
            }

            builder.ValidateBricks();
            Assert.IsTrue(builder.TryBuildNewLayer(), message);
        }

        public int[] GetRow(int[,] matrix, int row)
        {
            int[] newRow = new int[matrix.GetLength(1)];
            for (int coll = 0; coll < matrix.GetLength(1); coll++)
            {
                newRow[coll] = matrix[row, coll];
            }

            return newRow;
        }
    }
}