using NUnit.Framework;

namespace Banking2.nUnit.Models
{
    using Banking.Models;
    [TestFixture]
    public class TestTransaction
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Transaction_ShouldGetSetValue_Successful()
        {
            // Arrange
            var tran = new Transaction
            {
                // Act
                id = 1,
                description = "testing",
                date = DateTime.Now,
                amount = 100,
                account_number = "1111"
            };

            // Assert
            Assert.AreEqual(1, tran.id);
            Assert.AreEqual("testing", tran.description);
            Assert.AreEqual(100, tran.amount);
            Assert.AreEqual("1111", tran.account_number);
            Assert.GreaterOrEqual(DateTime.Now, tran.date);
        }
    }
}
