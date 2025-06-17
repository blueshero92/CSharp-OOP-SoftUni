namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;

        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void SetUp()
        {
            name = "Dido";
            damage = 20;
            hp = 100;

            warrior = new(name, damage, hp);
        }

        [Test]
        public void WarriorConstructorSetsParametersCorrectly()
        {
            string expectedName = "Dido";
            int expectedDamage = 20;
            int expectedHP = 100;

            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(" ")]
        [TestCase("     ")]
        [TestCase(null)]
        public void WarriorNameShouldThrowAnExceptionWhenNullOrWhitespace(string emptyName)
        {
            string exceptionMessage = "Name should not be empty or whitespace!";
            ArgumentException ex = Assert.Throws<ArgumentException>
                (() => new Warrior(emptyName, damage, hp));

            Assert.AreEqual (exceptionMessage, ex.Message);
        }

        [TestCase(0)]
        [TestCase(-2)]
        [TestCase(-10)]
        public void WarriorDamageShouldThrowAnExceptionWhenZeroOrNegative(int invalidDamage)
        {
            string exceptionMessage = "Damage value should be positive!";
            ArgumentException ex = Assert.Throws<ArgumentException>
                (() => new Warrior(name, invalidDamage, hp));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }
        
        [TestCase(-2)]
        [TestCase(-10)]
        public void WarriorHPShouldThrowAnExceptionWhenNegative(int invalidHP)
        {
            string exceptionMessage = "HP should not be negative!";
            ArgumentException ex = Assert.Throws<ArgumentException>
                (() => new Warrior(name, damage, invalidHP));

            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseAttackerHP()
        {
            Warrior attacker = new("Rusana", 25, 100);
            Warrior defender = new("Gercheto", 30, 150);

            attacker.Attack(defender);

            int expectedResult = 70;

            Assert.AreEqual(expectedResult, attacker.HP);

        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionWhenHPIsLowerThanMinimumHP()
        {
            Warrior attacker = new("Rusana", 25, 25);
            Warrior defender = new("Gercheto", 15, 150);

            string exceptionMessage = "Your HP is too low in order to attack other warriors!";
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));

            Assert.AreEqual(exceptionMessage, ex.Message);

        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionWhenDefenderHPIsLowerThanMinimumHP()
        {
            Warrior attacker = new("Rusana", 25, 100);
            Warrior defender = new("Gercheto", 15, 20);

            string exceptionMessage = "Enemy HP must be greater than 30 in order to attack him!";
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));

            Assert.AreEqual(exceptionMessage, ex.Message);

        }

        [Test]
        public void WarriorAttackMethodShouldThrowAnExceptionWhenDefenderDamageIsHigherThanAttackerHP()
        {
            Warrior attacker = new("Rusana", 25, 40);
            Warrior defender = new("Gercheto", 50, 100);

            string exceptionMessage = "You are trying to attack too strong enemy";
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>
                (() => attacker.Attack(defender));

            Assert.AreEqual(exceptionMessage, ex.Message);

        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseDefenderHPToZeroIfAttackerDamageIsGreaterThanDefenderHP()
        {
            Warrior attacker = new("Rusana", 50, 100);
            Warrior defender = new("Gercheto", 15, 40);

            attacker.Attack(defender);

            int expectedResult = 0;

            Assert.AreEqual(expectedResult, defender.HP);

        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseDefenderHP()
        {
            Warrior attacker = new("Rusana", 40, 150);
            Warrior defender = new("Gercheto", 50, 100);

            attacker.Attack(defender);

            int expectedResult = 60;

            Assert.AreEqual(expectedResult, defender.HP);

        }
    }
}