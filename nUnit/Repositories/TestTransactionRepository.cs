using NUnit.Framework;

namespace Banking2.nUnit.Repositories
{
    using Banking.Interfaces;
    using Banking.Models;
    using Banking.nUnit.Mocks;
    using Banking.Repositories;
    using Banking.Response;

    [TestFixture]
    public class TestTransactionRepository
    {
        private ITransactionRepository _transRepository;
        private IResponse<Transaction> _response;
        private readonly Transaction tranSample = new Transaction
        { id = 1, date = DateTime.Now, account_number = "2222", amount = 90 };

        [SetUp]
        public void Setup()
        {
            // Arrange
            var mockDbContext = MockDbContext.DbContextMock(new List<Transaction> { tranSample });

            _response = MockResponse<Transaction>.ResponseMock(new List<Transaction> { tranSample });
            _transRepository = new TransactionRepository(mockDbContext, _response);
        }

        [Test]
        public void AddNewTransaction_ShouldCreateTransaction_Successful()
        {
            // Act
            var result = _transRepository.AddNewTransaction(tranSample);

            // Assert
            Assert.IsTrue(result.Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, result.Payload);
        }

        [Test]
        public void AddNewTransaction_ShouldFailTransaction_Failure()
        {
            // Act
            var result = _transRepository.AddNewTransaction(null);

            // Assert
            Assert.IsFalse(result.Result);
            Assert.AreEqual(null, result.Payload);
        }

        [Test]
        public void DeleteTransaction_ShouldDeleteTransaction_Successful()
        {
            // Act
            var result = _transRepository.DeleteTransactionById(tranSample.id);

            // Assert
            Assert.IsTrue(result.Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, result.Payload);
        }

        [Test]
        public void DeleteTransaction_ShouldFailTransaction_Failure()
        {
            // Act
            var result = _transRepository.DeleteTransactionById(3000);

            // Assert
            Assert.IsFalse(result.Result);
            Assert.AreEqual(null, result.Payload);
        }

        [Test]
        public void GetTransaction_ShouldDeleteTransaction_Successful()
        {
            // Act
            var result = _transRepository.GetTransactionById(tranSample.id);

            // Assert
            Assert.IsTrue(result.Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, result.Payload);
        }

        [Test]
        public void GetTransaction_ShouldFailTransaction_Failure()
        {
            // Act
            var result = _transRepository.GetTransactionById(3000);

            // Assert
            Assert.IsFalse(result.Result);
            Assert.AreEqual(null, result.Payload);
        }

        [Test]
        public void GetAllTransaction_ShouldCreateTransaction_Successful()
        {
            // Act
            var result = _transRepository.GetTransactions();

            // Assert
            Assert.IsTrue(result.Result);
            Assert.AreEqual(new List<Transaction> { tranSample }.Count, result.Payload.Count);
        }

        [Test]
        public void UpdateTransaction_ShouldDeleteTransaction_Successful()
        {
            // Act
            var result = _transRepository.UpdateTransaction(tranSample);

            // Assert
            Assert.IsTrue(result.Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, result.Payload);
        }

        [Test]
        public void UpdateTransaction_ShouldFailTransaction_Failure()
        {
            // Act
            var result = _transRepository.UpdateTransaction(null);

            // Assert
            Assert.IsFalse(result.Result);
            Assert.AreEqual(null, result.Payload);
        }
    }
}
