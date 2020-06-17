using Poc.EmployeePayroll.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Poc.EmployeePayroll.Domain.Entities
{
    public class Person
    {
        public Person()
        {
            Id = Guid.NewGuid();
            Dependents = new List<Person>();
        }
        public Guid Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        [DisplayName("Person Type")]
        public PersonType PersonType { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Salary { get; set; }

        [DisplayName("Benefit Deduction")]
        public double BenefitDeduction { get; set; }
        public List<Person> Dependents { get; set; }
                
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Benefit Deduction Amount")]
        public double BenefitDeductionAmount { get; set; }


        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Discount Amount")]
        public double DiscountAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Payroll Amount")]
        public double PayrollAmount { get; set; }

    }
}
