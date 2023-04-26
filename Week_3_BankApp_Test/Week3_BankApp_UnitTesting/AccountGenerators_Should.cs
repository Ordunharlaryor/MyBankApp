using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class AccountGenerators_Should
    {

        [Test]
        public void GeneratorUniqueAccountNumber_ShouldReturnStringOfLength10()
        {
            // Act
            var result = AccountGenerator.GeneratorUniqueAccountNumber();

            // Assert
            Assert.AreEqual(10, result.Length);
        }

        [Test]
        public void GeneratorUniqueAccountNumber_ShouldReturnStringStartingWith222()
        {
            // Act
            var result = AccountGenerator.GeneratorUniqueAccountNumber();

            // Assert
            Assert.IsTrue(result.StartsWith("222"));
        }

        [Test]
        public void GeneratorUniqueAccountNumber_ShouldReturnStringWithOnlyDigits()
        {
            // Act
            var result = AccountGenerator.GeneratorUniqueAccountNumber();

            // Assert
            Assert.IsFalse(int.TryParse(result, out int result2));
        }

        [Test]
        public void GeneratorUniqueAccountNumber_ShouldReturnUniqueStrings()
        {
            // Act
            var result1 = AccountGenerator.GeneratorUniqueAccountNumber();
            var result2 = AccountGenerator.GeneratorUniqueAccountNumber();

            // Assert
            Assert.AreNotEqual(result1, result2);
        }
    }
}

