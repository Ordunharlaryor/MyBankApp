using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.Utilities;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    public class PasswordGenerators_should
    {
            [Test]
            public void GenerateHash_ShouldReturnStringOfLength44()
            {
                // Arrange
                string input = "password123";

                // Act
                var result = PasswordGenerator.GenerateHash(input);

                // Assert
                Assert.AreEqual(44, result.Length);
            }

            [Test]
            public void AreEqual_ShouldReturnTrueForSameInputs()
            {
                // Arrange
                string input = "password123";
                string hashedInput = PasswordGenerator.GenerateHash(input);

                // Act
                var result = PasswordGenerator.AreEqual(input, hashedInput);

                // Assert
                Assert.IsTrue(result);
            }

            [Test]
            public void AreEqual_ShouldReturnFalseForDifferentInputs()
            {
                // Arrange
                string input1 = "password123";
                string input2 = "Password123";
                string hashedInput = PasswordGenerator.GenerateHash(input1);

                // Act
                var result = PasswordGenerator.AreEqual(input2, hashedInput);

                // Assert
                Assert.IsFalse(result);
            }
        }
    }

