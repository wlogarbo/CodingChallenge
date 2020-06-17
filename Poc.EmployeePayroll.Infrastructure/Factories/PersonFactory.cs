using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Domain.Entities;
using System;

namespace Poc.EmployeePayroll.Infrastructure.Factories
{
    /// <summary>
    /// This Factory would construct all the person's attributes, i.e. salaries, benefits, deductions, etc
    /// </summary>
    public class PersonFactory : IPersonFactory
    {
        public Person Create(Person person)
        {
            if (person.PersonType != Domain.Enums.PersonType.Employee)
                throw new Exception("Employee must be of PersonType Employee!");

            person.Salary = 2000;
            person.BenefitDeduction = 1000;

            foreach (Person dependent in person.Dependents)
            {
                if (dependent.PersonType != Domain.Enums.PersonType.Dependent)
                    throw new Exception("Dependent must be of PersonType Dependent!");

                dependent.BenefitDeduction = 500;
            }

            return person;
        }
    }
}
