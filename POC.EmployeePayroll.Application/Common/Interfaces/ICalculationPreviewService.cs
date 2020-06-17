using Poc.EmployeePayroll.Domain.Entities;

namespace Poc.EmployeePayroll.Application.Common.Interfaces
{
    public interface ICalculationPreviewService
    {
        Person RunCalculation(Person employee);
    }
}
