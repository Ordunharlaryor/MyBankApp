using System.Collections.Generic;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Abstraction.Interfaces;

namespace Week_3_BankApp.Implementation.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDb _database;
        public CustomerRepository()
        {
            _database = new Db();
        }
        public bool Add(Customer customer)
        {
            if (customer == null) return false;

            _database.Customers.Add(customer);
            return true;
        }

        public void Delete(string id)
        {
            Customer customerToDelete = new Customer();
            foreach (var customer in _database.Customers)
            {
                if (customer.CustomerId == id)
                {
                    customerToDelete = customer;
                    break;
                }
            }

            if (customerToDelete == null) return;

            _database.Customers.Remove(customerToDelete);
        }

        public Customer Get(string id)
        {
            Customer customerToReturn = new Customer();
            foreach (var customer in _database.Customers)
            {
                if (customer.CustomerId == id)
                {
                    customerToReturn = customer;
                    break;
                }
            }

            return customerToReturn;
        }

        public Customer GetByEmail(string email)
        {
            Customer customerToReturn = new Customer();
            foreach (var customer in _database.Customers)
            {
                if (customer.Email == email)
                {
                    customerToReturn = customer;
                    break;
                }
            }

            return customerToReturn;
        }

        public List<Customer> GetAll()
        {
            return _database.Customers;
        }

        public void Update(Customer customerToUpdate)
        {
            for (int i = 0; i < _database.Customers.Count; i++)
            {
                if (_database.Customers[i].CustomerId == customerToUpdate.CustomerId)
                {
                    _database.Customers[i] = customerToUpdate;
                    break;
                }
            }
        }
    }
}
