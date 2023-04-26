using System.Collections.Generic;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Repository.Abstraction
{
    public interface ICustomerRepository
    {
        bool Add(Customer customer);
        void Delete(string id);
        void Update(Customer customerToUpdate);
        Customer Get(string id);
        Customer GetByEmail(string email);
        List<Customer> GetAll();
    }
}
