using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules;
using Poc.EmployeePayroll.Domain.Entities;
using System;

namespace Poc.EmployeePayroll.Infrastructure.Services
{
    public class CalculationPreviewService : ICalculationPreviewService
    {
        private IPersonFactory _personFactory;
        private CalculationPreviewRuleProvider _ruleProvider;

        public CalculationPreviewService(CalculationPreviewRuleProvider ruleProvider, IPersonFactory personFactory)
        {
            _ruleProvider = ruleProvider;
            _personFactory = personFactory;
        }
        public Person RunCalculation(Person employee)
        {
            if (employee.PersonType != Domain.Enums.PersonType.Employee)
                throw new Exception("Preview calculations on persons other than Employees are not permitted!");

            employee = _personFactory.Create(employee);

            _ruleProvider.ExecuteRules(employee);
            employee.PayrollAmount = employee.Salary - employee.BenefitDeductionAmount + employee.DiscountAmount;

            foreach (var dependent in employee.Dependents)
            {
                _ruleProvider.ExecuteRules(dependent);
                employee.PayrollAmount = employee.PayrollAmount - dependent.BenefitDeductionAmount + dependent.DiscountAmount;
            }

            return employee;
        }
    }
}
