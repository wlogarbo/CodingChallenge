using FluentValidation;
using MediatR;
using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Domain.Entities;
using Poc.EmployeePayroll.Domain.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Poc.EmployeePayroll.Application.Features.CalculatorPreview
{
    public class PreviewCalculatorCalculate
    {     
        public class Query : IRequest<Response>
        {
            public Person Person { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(v => v.Person)
                    .NotEmpty()
                    .SetValidator(new EmployeeValidator());
            }
        }

        public class EmployeeValidator : AbstractValidator<Person>
        {
            public EmployeeValidator()
            {
                RuleFor(v => v.FirstName)
                    .NotEmpty();
                RuleFor(v => v.PersonType)
                    .Must(t => t == PersonType.Employee);
                RuleForEach(v => v.Dependents).SetValidator(new DependentValidator());
            }
        }

        public class DependentValidator : AbstractValidator<Person>
        {
            public DependentValidator()
            {
                RuleFor(v => v.FirstName)
                    .NotEmpty();
                RuleFor(v => v.PersonType)
                    .Must(t => t == PersonType.Dependent);
            }
        }

        public class Response
        {
            public double PayrollAmount { get; set; }
            public Person Employee { get; set; }
        }

        public class PreviewCalculatorCalculateHandler : IRequestHandler<Query, Response>
        {
            private readonly ICalculationPreviewService _previewService;

            public PreviewCalculatorCalculateHandler(ICalculationPreviewService previewService)
            {
                _previewService = previewService;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var personResponse = _previewService.RunCalculation(request.Person);

                var response = new Response()
                {
                    PayrollAmount = personResponse.PayrollAmount,
                    Employee = request.Person
                };

                return response;
            }
        }
    }
}
