using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private const int DummyHealthAlive = 11;

        private const string DummyIsDeadMessage = "Dummy is dead.";
        private const string DummyIsNotDeadMessage = "Target is not dead.";
        private const string DummyHealthDoesntChangeMessage = "Dummy's health doesn't change after attack";


        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(AxeAttack, AxeDurability);

            dummy = new Dummy(DummyHealth, DummyExperience);

            dummy.TakeAttack(axe.AttackPoints);
        }

        [Test]
        public void DummyLosesHealthWhenAttacked()
        {
            Assert.That(dummy.Health, Is.EqualTo(0), DummyHealthDoesntChangeMessage);
        }

        [Test]

        public void DeadDummyThrowsAnExceptionIfAttacked()
        {          
            dummy.IsDead();          

            InvalidOperationException exception 
                = Assert.Throws <InvalidOperationException>(() => dummy.TakeAttack(axe.AttackPoints));            

            Assert.AreEqual(DummyIsDeadMessage, exception.Message);
        }

        [Test]

        public void DeadDummyShouldGiveXP()
        {            
            dummy.IsDead();
            dummy.GiveExperience();

            Assert.That(dummy.GiveExperience() != 0);
        }

        [Test]
        public void AliveDummyShouldNotGiveXP()
        {           
            dummy = new Dummy(DummyHealthAlive, DummyExperience);

            dummy.TakeAttack(axe.AttackPoints);                    
            
            InvalidOperationException ex 
                = Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

            Assert.AreEqual(DummyIsNotDeadMessage, ex.Message);
        }
    }
}