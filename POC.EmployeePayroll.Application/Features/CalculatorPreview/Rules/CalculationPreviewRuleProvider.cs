using Microsoft.Extensions.DependencyInjection;
using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules
{
    public class CalculationPreviewRuleProvider
    {
        private IList<IBusinessRule> _rules;
        public CalculationPreviewRuleProvider(IServiceProvider serviceProvider)
        {
            _rules = serviceProvider.GetServices<IBusinessRule>().ToList();
        }
        public void ExecuteRules(Person person)
        {
            _rules.Where(x => x.CanExecute(person)).ToList().ForEach(x => x.Execute(person));
        }
    }
}
