using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week_3_BankApp.Implementation.Repositories;
using Week_3_BankApp.Model;
using Week_3_BankApp.Repository.Abstraction;

namespace Week_3_BankApp_Test.Week3_BankApp_UnitTesting
{
    [TestFixture]
    public class StatementRepository_Should
    {
        private IStatementRepository _statementRepository;

        [SetUp]
        public void SetUp()
        {
            _statementRepository = new StatementRepository();
        }

        [Test]
        public void Add_ValidStatement_ReturnsTrue()
        {
            // Arrange
            Statement statement = new Statement { StatementId = "1", Description = "Test statement" };

            // Act
            bool result = _statementRepository.Add(statement);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NullStatement_ReturnsFalse()
        {
            // Arrange
            Statement statement = null;

            // Act
            bool result = _statementRepository.Add(statement);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Delete_ExistingStatement_RemovesStatement()
        {
            // Arrange
            Statement statement = new Statement { StatementId = "1", Description = "Test statement" };
            _statementRepository.Add(statement);

            // Act
            _statementRepository.Delete("1");

            // Assert
            Assert.That(_statementRepository.Get("1").StatementId, Is.Not.EqualTo(statement.StatementId));
        }

        [Test]
        public void Delete_NonExistingStatement_DoesNothing()
        {
            // Arrange
            Statement statement = new Statement { StatementId = "1", Description = "Test statement" };
            _statementRepository.Add(statement);

            // Act
            _statementRepository.Delete("2");

            // Assert
            Assert.IsNotNull(_statementRepository.Get("1"));
        }

        [Test]
        public void Get_ExistingStatement_ReturnsStatement()
        {
            // Arrange
            Statement statement = new Statement { StatementId = "1", Description = "Test statement" };
            _statementRepository.Add(statement);

            // Act
            Statement result = _statementRepository.Get("1");

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatementId, Is.EqualTo("1"));
            Assert.That(result.Description, Is.EqualTo("Test statement"));
        }

        [Test]
        public void Get_NonExistingStatement_ReturnsNull()
        {
            // Act
            Statement statement = new Statement
            {
                StatementId = "1",
                Description = "Test statement"
            };
            Statement result = _statementRepository.Get("2");

            // Assert
            Assert.That(statement.StatementId, Is.Not.EqualTo(result.StatementId));
        }

        [Test]
        public void GetAll_ReturnsAllStatements()
        {
            // Arrange
            Statement statement1 = new Statement { StatementId = "1", Description = "Test statement 1" };
            Statement statement2 = new Statement { StatementId = "2", Description = "Test statement 2" };
            _statementRepository.Add(statement1);
            _statementRepository.Add(statement2);

            // Act
            IEnumerable<Statement> result = _statementRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.IsTrue(result.Any(s => s.StatementId == "1"));
            Assert.IsTrue(result.Any(s => s.StatementId == "2"));
        }

        [Test]
        public void Update_ExistingStatement_UpdatesStatement()
        {
            // Arrange
            Statement statement = new Statement { StatementId = "1", Description = "Test statement" };
            _statementRepository.Add(statement);
            Statement statementToUpdate = new Statement { StatementId = "1", Description = "Updated test statement" };

            // Act
            _statementRepository.Update(statementToUpdate);

            // Assert
            Statement updatedStatement = _statementRepository.Get("1");
            Assert.That(updatedStatement.Description, Is.EqualTo("Updated test statement"));
        }
    }
}
