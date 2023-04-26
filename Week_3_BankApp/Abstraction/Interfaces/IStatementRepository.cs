using System.Collections.Generic;
using Week_3_BankApp.Model;

namespace Week_3_BankApp.Repository.Abstraction
{
    public interface IStatementRepository
    {
        bool Add(Statement statement);
        void Delete(string id);
        void Update(Statement statementToUpdate);
        Statement Get(string id);
        IEnumerable<Statement> GetAll();
    }
}
