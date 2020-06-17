using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Domain.Entities;

namespace Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules
{
    public class ANameDiscount : IBusinessRule
    {
        public bool CanExecute(Person person)
        {
            return person.FirstName.StartsWith("A", true, System.Globalization.CultureInfo.InvariantCulture);
        }

        public void Execute(Person person)
        {
            person.DiscountAmount = person.BenefitDeductionAmount * .2;
        }
    }
}
