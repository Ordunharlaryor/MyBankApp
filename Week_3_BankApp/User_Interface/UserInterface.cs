using System;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.DI;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.UI
{
    public class UserInterface
    {
            public static void UI()
            {
                Console.WriteLine("Welcome to ODUNAYOR'S BANK OF NIGERIA");
                Console.WriteLine("Choose an operation");
                DIContainer dIContainer = new DIContainer();
                MainMenu.StartApplication(dIContainer);
            }
        }
    }

