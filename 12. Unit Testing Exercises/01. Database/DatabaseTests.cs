namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2, 3);
        }

        [Test]
        public void DatabaseCountWorksCorrectly()
        {
            int expectedCount = 3;

            int databaseCount = database.Count;

            Assert.NotNull(database);
            Assert.AreEqual(expectedCount, databaseCount);

        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, })]
        public void CreatingDatabaseShouldAddElemetsCorrectly(int[] data)
        {
            database = new(data);
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }

        [Test]
        public void DatabaseAddMethodShouldAddElementsCorrectly()
        {
            int element = 1;

            database = new();
            database.Add(element);

            Assert.NotNull(database);

        }

        [TestCase(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16})]
        public void DatabaseAddMethodShouldThrowAnException(int[] data)
        {
            database = new(data);

            int elementToAdd = 17;

            string expectedExceptionMessage = "Array's capacity must be exactly 16 integers!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(elementToAdd));

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {                        
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(2));            

        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowAnException()
        {
            database = new();            

            string expectedExceptionMessage = "The collection is empty!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [TestCase(new int[] {1, 2, 3, 4, 5})]

        public void DatabaseFetchMethodShouldCopyArrayCorrectly(int[] copiedArray)
        {
            database = new();

            foreach(int element in copiedArray)
            {
                database.Add(element);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(copiedArray, actualResult);


        }




    }
}
