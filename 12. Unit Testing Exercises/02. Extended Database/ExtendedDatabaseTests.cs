namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;
        private Person person1;
        private Person person2;

        [SetUp]
        public void SetUp()
        {
            Person[] persons =
        {
            new Person(1, "Pesho"),
            new Person(2, "Gosho"),
            new Person(3, "Ivan_Ivan"),
            new Person(4, "Pesho_ivanov"),
            new Person(5, "Gosho_Naskov"),
            new Person(6, "Pesh-Peshov"),
            new Person(7, "Ivan_Kaloqnov"),
            new Person(8, "Ivan_Draganchov"),
            new Person(9, "Asen"),
            new Person(10, "Jivko"),
            new Person(11, "Toshko")
        };

            database = new Database(persons);
        }

        [Test]
        public void DatabaseCountWorksCorrectly()
        {
            int expectedCount = 11;

            int databaseCount = database.Count;

            Assert.NotNull(database);
            Assert.AreEqual(expectedCount, databaseCount);

        }

        [Test]
        public void DatabaseAddMethodShouldAddPeopleCorrectly()
        {
            Person person = new(12, "Deyan Dimitrov");

            database.Add(person);

            int expectedResult = 12;

            Assert.AreEqual(expectedResult, database.Count);           
            
        }

        [Test]
        public void DatabaseAddMethodShouldThrowUsernameException()
        {
            Person person = new Person(3, "Pesho");

            string expectedExceptionMessage = "There is already user with this username!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(person));

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowIdException()
        {
            Person person = new Person(1, "Dido");

            string expectedExceptionMessage = "There is already user with this Id!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(person));

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [Test]
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIs16()
        {
            Person person = new Person(12, "Dido");
            Person person2 = new Person(13, "Rusana");
            Person person3 = new Person(14, "Mitko");
            Person person4 = new Person(15, "Gery");
            Person person5 = new Person(16, "Hris");

            database.Add(person);
            database.Add(person2);
            database.Add(person3);
            database.Add(person4);
            database.Add(person5);

            string expectedExceptionMessage = "Array's capacity must be exactly 16 integers!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17,"Misho")));

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            database.Remove();

            Assert.That(database.Count, Is.EqualTo(10));

        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowAnExceptionOnEmptyArray()
        {
            database = new Database();

            string expectedExceptionMessage = "Operation is not valid due to the current state of the object.";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.Remove());

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldWorkCorrectly()
        {
            string expectedUserName = "Pesho";
            string actualResult = database.FindByUsername("Pesho").UserName;
            
            Assert.AreEqual(expectedUserName, actualResult);
        }

        [Test]
        public void DatabaseFindByUsernameMethodShouldBeCaseSensitive()
        {
            string expectedUserName = "peShO";
            string actualResult = database.FindByUsername("Pesho").UserName;

            Assert.AreNotEqual(expectedUserName, actualResult);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void DatabaseFindByUsernameMethodShouldThrowArgumentNullException(string username)
        {                  

            string expectedExceptionMessage = "Username parameter is null!";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(username));

            Assert.AreEqual(expectedExceptionMessage, ex.ParamName);
        }

        [TestCase("Damyan")]
        [TestCase("Orlin")]
        public void DatabaseFindByUsernameMethodShouldThrowInvalidOperationException(string username)
        {           

            string expectedExceptionMessage = "No user is present by this username!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }

        [Test]
        public void DatabaseFindByIdMethodShouldWorkCorrectly()
        {
            long expectedId = 1;
            long actualResult = database.FindById(expectedId).Id;

            Assert.AreEqual(expectedId, actualResult);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-20)]
        public void DatabaseFindByIdMethodShouldThrowArgumentOutOfRangeException(long id)
        {

            string expectedExceptionMessage = "Id should be a positive number!";

            ArgumentOutOfRangeException ex = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));

            Assert.AreEqual(expectedExceptionMessage, ex.ParamName);
        }

        [Test]
        [TestCase(16)]
        [TestCase(21)]
        public void DatabaseFindByIdMethodShouldThrowInvalidOperationException(long id)
        {
            string expectedExceptionMessage = "No user is present by this ID!";

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => database.FindById(id));

            Assert.AreEqual(expectedExceptionMessage, ex.Message);
        }







    }
}