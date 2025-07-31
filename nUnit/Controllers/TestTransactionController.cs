using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace Banking.nUnit.Controllers
{
    using Banking.Controllers;
    using Banking.Interfaces;
    using Banking.Models;
    using Banking.nUnit.Mocks;
    using Banking.Repositories;
    using Banking.Response;

    [TestFixture]
    public class TestTransactionController
    {
        private ITransactionRepository _transRepository;
        private IResponse<Transaction> _response;
        private TransactionController tranController;

        private readonly Transaction tranSample = new Transaction
        { id = 1, date = DateTime.Now, account_number = "2222", amount = 90 };

        [SetUp]
        public void Setup()
        {
            // Common Arrange
            var mockDbContext = MockDbContext.DbContextMock(new List<Transaction> { tranSample });
            _response = MockResponse<Transaction>.ResponseMock(new List<Transaction> { tranSample });
            _transRepository = new TransactionRepository(mockDbContext, _response);
            tranController = new TransactionController(_transRepository, _response);
        }


        [Test]
        public void getAllTranactions_ShouldGetResponse_Successful()
        {
            // Act
            var result = tranController.Get();
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsInstanceOf<ActionResult<IResponse<Transaction>>>(result);
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.AreEqual(new List<Transaction> { tranSample }, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }

        [Test]
        public void getTransactionById_ShouldGetResponse_Successful()
        {
            // Act
            var result = tranController.Get(tranSample.id);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.AreEqual(new List<Transaction> { tranSample }, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }

        [Test]
        public void getTransactionByIdNotExisting_ShouldGetResponse_Failure()
        {
            // Act
            var result = tranController.Get(10000);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.IsFalse((okObjectResult.Value as IResponse<Transaction>).Result);
            Assert.AreEqual(null, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }

        [Test]
        public void postTransaction_ShouldCreateResponse_Successful()
        {
            // Act
            var result = tranController.Post(tranSample);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.IsTrue((okObjectResult.Value as IResponse<Transaction>).Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }

        [Test]
        public void putTransaction_ShouldUpateResponse_Successful()
        {
            // Act
            var result = tranController.Put(tranSample);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.IsTrue((okObjectResult.Value as IResponse<Transaction>).Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }

        [Test]
        public void deleteTransactionById_ShouldGetResponse_Successful()
        {
            // Act
            var result = tranController.Delete(tranSample.id);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.IsTrue((okObjectResult.Value as IResponse<Transaction>).Result);
            Assert.AreEqual(new List<Transaction> { tranSample }, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }

        [Test]
        public void deleteTransactionByIdNotExisting_ShouldGetResponse_Failure()
        {
            // Act
            var result = tranController.Delete(10000);
            var okObjectResult = result.Result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okObjectResult);
            Assert.IsInstanceOf<IResponse<Transaction>>(okObjectResult.Value);
            Assert.IsFalse((okObjectResult.Value as IResponse<Transaction>).Result);
            Assert.AreEqual(null, (okObjectResult.Value as IResponse<Transaction>).Payload);
        }
    }
}
