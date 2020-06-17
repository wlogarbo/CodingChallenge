using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poc.EmployeePayroll.Domain.Entities;

namespace Poc.EmployeePayroll.Domain.UnitTests.EntitiesTests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void Person_Exists()
        {
            var person = new Person();
        }
    }
}
