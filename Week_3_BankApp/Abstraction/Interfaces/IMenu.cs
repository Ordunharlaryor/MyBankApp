using System;
using System.Collections.Generic;
using System.Text;
using Week_3_BankApp.DI;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Abstraction.Interfaces
{
    public interface IMenu
    {
        void MenuMethod(DIContainer dIContainer, Customer customer);
        
    }
}
