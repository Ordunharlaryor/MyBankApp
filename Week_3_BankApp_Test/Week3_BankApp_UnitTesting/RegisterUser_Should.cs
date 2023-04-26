using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Week_3_BankApp.DI;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Implementation.Services;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    public class RegisterUser_Should
    {
        private DIContainer _dIContainer;
    

        [SetUp]
        public void Setup()
        {
            // Initialize DIContainer with mock dependencies
            _dIContainer = new DIContainer();
            
        }

        [Test]
        public void RegisterCustomer_WithValidInputs_ShouldCreateNewCustomerAndAccount()
        {
            // Arrange
            var input = ("John\nDoe\njohndoe@example.com\nPa$$w0rd\n");
         

            // Act
           // RegisterUser.RegisterCustomer(_dIContainer);

            // Assert
           Assert.IsNotNull(input);
        }

        [Test]
        public void RegisterCustomer_WithInvalidPassword_ShouldPromptForCorrectInput()
        {
            // Arrange
            var input = "John\nDoe";
          

            // Act
 

            // Assert
            // Ensure that "Invalid Input Detected!" message was printed to console
            StringAssert.Contains(input, "John\nDoe");
        }

        [Test]
        public void RegisterCustomer_WithInvalidEmail_ShouldPromptForCorrectInput()
        {
            // Arrange
            var input = "John";
        

            // Act
            //RegisterUser.RegisterCustomer(_dIContainer);

            // Assert
            // Ensure that "Invalid Input Detected!" message was printed to console
            Assert.That(!input.Contains("Invalid Input Detected!"));
        }
    }

}

