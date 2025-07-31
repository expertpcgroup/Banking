using Banking.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.nUnit.Mocks
{
    public class MockDbContext
    {
        public static BankingDBContext DbContextMock(List<Transaction> trans)
        {
            var mockSet = new Mock<DbSet<Transaction>>();
            var mockContext = new Mock<BankingDBContext>(new DbContextOptions<BankingDBContext>());
            var data = trans.AsQueryable();

            mockSet.As<IQueryable<Transaction>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Transaction>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockContext.Setup(c => c.Transactions).Returns(mockSet.Object);

            return mockContext.Object;
        }
    }
}
