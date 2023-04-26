using Week_3_BankApp.Repository.Abstraction;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Implementation.Services;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.Model;


namespace Week_3_BankApp.DI
{
    public class DIContainer
    {
        private readonly IUserService _userService;
        private readonly IAccountManagementService _accountManagementService;
        private readonly IAccountRepository _accountRepo;
        private ICustomerRepository _customerRepo;
        private readonly IStatementRepository _statementRepo;
        private readonly IMenu _menu;

        public DIContainer()
        {
            _accountRepo = new AccountRepository();
            _customerRepo = new CustomerRepository();
            _statementRepo = new StatementRepository();
            _menu = new Menu();

            _userService = new UserService(_customerRepo, _accountRepo);
            _accountManagementService = new AccountManagementService(_accountRepo, _statementRepo);
        }

        public IUserService UserService => _userService;
        public IAccountManagementService AccountManagementService => _accountManagementService;
        public IAccountRepository AccountRepo => _accountRepo;
        public ICustomerRepository CustomerRepo => _customerRepo;
        public IStatementRepository StatementRepo => _statementRepo;
        public IMenu Menu => _menu;
    }
}
