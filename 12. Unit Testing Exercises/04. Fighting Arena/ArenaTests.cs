namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
            
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
            
        }

        [Test]
        public void ArenaShouldAddWarriorsCorrectly()
        {
            int expextedResult = 1;
            Warrior warrior = new("Dido", 30, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expextedResult, arena.Count);
        }

        [Test]
        public void ArenaEnrollMethodShouldAddWarriorsCorrectly()
        {
            
            Warrior warrior = new("Dido", 30, 100);

            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void ArenaEnrollMethodShouldThrowAnExceptionIfWarriorIsAlreadyEnrolled()
        {
            Warrior warrior = new("Dido", 30, 100);

            arena.Enroll(warrior);

            string expectedErrorMessage = "Warrior is already enrolled for the fights!";
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Dido", 15, 85)));

            Assert.AreEqual(expectedErrorMessage, ex.Message);
        }

        [Test]
        public void ArenaFightMethodShouldWorkCorrectly()
        {
            Warrior attacker = new("Dido", 30, 100);
            Warrior defender = new("Mitko", 25, 120);

            int expectedAttackerHP = 75;
            int expectedDefenderHP = 90;

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void ArenaFightMethodShouldThrowAnExceptionIfAttackerIsMissing()
        {
            Warrior attacker = new("Dido", 30, 100);
            Warrior defender = new("Mitko", 25, 120);

            arena.Enroll(defender);

            string ExpectedErrorMessage = $"There is no fighter with name {attacker.Name} enrolled for the fights!";
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() 
                => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual(ExpectedErrorMessage, ex.Message);
        }

        [Test]
        public void ArenaFightMethodShouldThrowAnExceptionIfDefenderIsMissing()
        {
            Warrior attacker = new("Dido", 30, 100);
            Warrior defender = new("Mitko", 25, 120);

            arena.Enroll(attacker);

            string ExpectedErrorMessage = $"There is no fighter with name {defender.Name} enrolled for the fights!";
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual(ExpectedErrorMessage, ex.Message);
        }
    }
}
