using System.Collections.Generic;
using Week_3_BankApp.Abstraction.Interfaces;
using Week_3_BankApp.In_Memory_Db;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace Week_3_BankApp.Implementation.Repositories
{
    public class StatementRepository : IStatementRepository
    {
        private readonly IDb _database;

        public StatementRepository()
        {
            _database = new Db();
        }
        public bool Add(Statement statement)
        {
            if (statement == null) return false;

            _database.Statements.Add(statement);
            return true;
        }

        public void Delete(string id)
        {
            Statement statementToDelete = new Statement();
            foreach (var statement in _database.Statements)
            {
                if (statement.StatementId == id)
                {
                    statementToDelete = statement;
                    break;
                }
            }

            if (statementToDelete == null) return;

            _database.Statements.Remove(statementToDelete);
        }

        public Statement Get(string id)
        {
            Statement statementToReturn = new Statement();
            foreach (var statement in _database.Statements)
            {
                if (statement.StatementId == id)
                {
                    statementToReturn = statement;

                }
                else
                {
                    statementToReturn = null; break;
                }
                
            }

            return statementToReturn;
        }

        public IEnumerable<Statement> GetAll()
        {
            return _database.Statements;
        }

        public void Update(Statement statementToUpdate)
        {
            for (int i = 0; i < _database.Statements.Count; i++)
            {
                if (_database.Statements[i].StatementId == statementToUpdate.StatementId)
                {
                    _database.Statements[i] = statementToUpdate;
                    break;
                }
            }
        }
    }
}
