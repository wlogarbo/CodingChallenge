using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Domain.Entities;
using Poc.EmployeePayroll.Domain.Enums;

namespace Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules
{
    public class EmployeeDeduction : IBusinessRule
    {
        public bool CanExecute(Person person)
        {
            return person.PersonType == PersonType.Employee;
        }

        public void Execute(Person person)
        {
            person.BenefitDeductionAmount = person.BenefitDeduction / 26;
        }
    }
}
