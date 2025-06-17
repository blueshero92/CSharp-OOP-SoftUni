using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 10;
        private const int AxeDurability = 10;
        private const int AxeZeroDurability = 0;
        private const int DummyHealth = 10;
        private const int DummyExperience = 10;



        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void SetUp()
        {
            axe = new Axe(AxeAttack, AxeDurability);
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            
            axe.Attack(dummy);

            Assert.That(axe.DurabilityPoints, Is.EqualTo(9), "Axe Durability doesn't change after attack.");
        }

        [Test]        
        public void AttackingWithABrokenAxeShouldThrowException()
        {
            axe = new Axe(AxeAttack, AxeZeroDurability);           

            string exceptionMessage = "Axe is broken.";

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
            Assert.AreEqual(exceptionMessage, exception.Message);

        }
    }
}