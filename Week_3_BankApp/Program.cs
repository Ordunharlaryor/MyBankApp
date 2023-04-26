using Week_3_BankApp.DI;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Implementation.Services;
using Week_3_BankApp.UI;
using Microsoft.Extensions.DependencyInjection;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace BankApp_Week_3
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInterface.UI();

            // Register the dependencies in the default IOC container
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountManagementService, AccountManagementService>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IStatementRepository, StatementRepository>();
            services.AddSingleton<IMenu, Menu>();
            services.AddTransient<DIContainer, DIContainer>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            // Use the dependencies from the container
            var userService = serviceProvider.GetRequiredService<IUserService>();
            var accountManagementService = serviceProvider.GetRequiredService<IAccountManagementService>();
        }
    }
 }

    
