using Banking.Models;
using Banking.Response;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
namespace Banking.nUnit.Mocks
{
    public class MockResponse<T> where T: class
    {
        public static IResponse<T> ResponseMock(IList<T>? obj)
        {
            var mock = new Mock<IResponse<T>>();
            mock.SetupProperty(resp => resp.Message, "Successful!");
            mock.SetupProperty(resp => resp.Result, true);
            mock.SetupProperty(resp => resp.TimeStamp, DateTime.UtcNow);
            mock.SetupProperty(resp => resp.Payload, obj);

            return mock.Object;
        }
    }
}
