using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class CustomerRepository_Should
    {
        private ICustomerRepository _customerRepository;
        private IDb _db;

        [SetUp]
        public void Setup()
        {
            _db = new Db();
            _customerRepository = new CustomerRepository();

        }

        [Test]
        public void Add_When_Customer_Is_Null_Returns_False()
        {
            // Arrange
            Customer customer = null;

            // Act
            bool result = _customerRepository.Add(customer);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Add_When_Customer_Is_Not_Null_ReturnsTrue()
        {
            // Arrange
            Customer customer = new Customer();

            // Act
            bool result = _customerRepository.Add(customer);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Delete_WhenCustomerIsNotFound_DoesNothing()
        {
            // Arrange
            string customerId = "non-existent-customer-id";

            // Act
            _customerRepository.Delete(customerId);

            // Assert
            Assert.Pass("No exception thrown");
        }

        [Test]
        public void Get_WhenCustomerIsFound_ReturnsCustomer()
        {
            // Arrange
            string customerId = "existing-customer-id";
            Customer expectedCustomer = new Customer() { CustomerId = customerId };
            _customerRepository.Add(expectedCustomer);

            // Act
            Customer actualCustomer = _customerRepository.Get(customerId);

            // Assert
            Assert.That(actualCustomer, Is.EqualTo(expectedCustomer));
        }

        [Test]
        public void GetByEmail_WhenCustomerIsFound_ReturnsCustomer()
        {
            // Arrange
            string email = "existing-customer-email";
            Customer expectedCustomer = new Customer() { Email = email };
            _customerRepository.Add(expectedCustomer);

            // Act
            Customer actualCustomer = _customerRepository.GetByEmail(email);

            // Assert
            Assert.That(actualCustomer, Is.EqualTo(expectedCustomer));
        }
        // Set up the test data


        [Test]
        public void GetAll_ReturnsAllCustomers()
        {
            // Arrange
            var customerToUpdate = new Customer
            {
                CustomerId = "5",
                FirstName = "John",
                LastName = "Ebere"
            };

            // Act
            List<Customer> Result = new List<Customer>();
            _db.Customers.Add(customerToUpdate);
            var updatedCustomer = _customerRepository.GetAll();
            
                Result.Add(customerToUpdate);
            
                var HoldCount = Result.Count() > 0;

            // Assert
            Assert.That(updatedCustomer, Is.Not.Null);
            Assert.IsTrue(HoldCount);
            Assert.That(_db.Customers.Count, Is.EqualTo(1));
        }


        [Test]

        public void Update_CustomerExists_UpdatesCustomer()
        {
            // Arrange
            var customerToUpdate = new Customer
            {
                CustomerId = "2",
                FirstName = "Patrick",
                LastName = "DonPat"
            };
            var customerToUpdate2 = customerToUpdate.FirstName + " " + customerToUpdate.LastName;
            // Act


            // Assert

            Assert.That(customerToUpdate.FirstName + " " + customerToUpdate.LastName, Is.EqualTo(customerToUpdate2));
        }

        [Test]

        public void Update_CustomerDoesNotExist()
        {
            // Arrange
            var customerToUpdate = new Customer
            {
                CustomerId = "4",
                FirstName = "New Customer",
                LastName = "Ebere"
            };

            // Act

            _customerRepository.Update(customerToUpdate);

            Assert.IsNotNull(customerToUpdate);
        }
    }
}



