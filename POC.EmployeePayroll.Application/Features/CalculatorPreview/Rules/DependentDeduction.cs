using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Domain.Entities;
using Poc.EmployeePayroll.Domain.Enums;

namespace Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules
{
    public class DependentDeduction : IBusinessRule
    {
        public bool CanExecute(Person person)
        {
            return person.PersonType == PersonType.Dependent;
        }

        public void Execute(Person person)
        {
            person.BenefitDeductionAmount = person.BenefitDeduction / 26;
        }
    }
}
