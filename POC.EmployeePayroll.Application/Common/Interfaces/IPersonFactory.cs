using Poc.EmployeePayroll.Domain.Entities;

namespace Poc.EmployeePayroll.Application.Common.Interfaces
{
    public interface IPersonFactory
    {
        Person Create(Person person);
    }
}
