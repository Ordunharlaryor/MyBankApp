using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    public class Validation_Should
    {

        [Test]
        public void Validate_ShouldReturnTrueForNullOrEmptyString()
        {
            // Arrange
            string test = "5";

            // Act
            var result = Validation.Validate(test);

            // Assert
            Assert.That(result, Is.EqualTo(string.IsNullOrWhiteSpace(test) || result is string));
        }

        [Test]
        public void Validate_ShouldReturnFalseForCorrectString()
        {
            // Arrange
            string test = "1";

            // Act
            var result = Validation.Validate(test);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Validate_ShouldReturnFalseForIncorrectString()
        {
            // Arrange
            string test = "5" ;

            // Act
            var result = Validation.Validate(test);

            // Assert
            Assert.IsFalse(result);
        }
    }
}

