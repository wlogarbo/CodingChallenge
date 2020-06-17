using Poc.EmployeePayroll.Domain.Entities;

namespace Poc.EmployeePayroll.Application.Common.Interfaces
{
    public interface IBusinessRule
    {
        bool CanExecute(Person person);
        void Execute(Person person);
    }
}
