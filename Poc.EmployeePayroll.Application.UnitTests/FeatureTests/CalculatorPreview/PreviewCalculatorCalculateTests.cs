using FluentValidation;
using FluentValidation.TestHelper;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Application.Features.CalculatorPreview;
using Poc.EmployeePayroll.Domain.Entities;
using Shouldly;
using System.Threading;
using static Poc.EmployeePayroll.Application.Features.CalculatorPreview.PreviewCalculatorCalculate;

namespace Poc.EmployeePayroll.Application.UnitTests.FeatureTests.CalculatorPreview
{
    [TestClass]
    public class PreviewCalculatorCalculateTests
    {
        //TODO Fix the Exists tests
        [TestMethod]
        public void PreviewCalculatorCalculate_Exists()
        {
            var calculate = new PreviewCalculatorCalculate();
        }
        [TestMethod]
        public void Query_Exists()
        {
            var query = new Query();
        }
        
        [TestMethod]
        public void Query_ImplementsIRequest()
        {
            var query = new Query();

            query.ShouldBeAssignableTo<IRequest<Response>>();
        }

        [TestMethod]
        public void Query_ShouldHaveProperties()
        {
            var query = new PreviewCalculatorCalculate.Query();

            query.Person.ShouldBeAssignableTo<Person>();
        }

        [TestMethod]
        public void QueryValidator_Exists()
        {
            var queryValidator = new QueryValidator();
            var employeeValidator = new EmployeeValidator();
            var dependentValidator = new DependentValidator();
        }

        [TestMethod]
        public void QueryValidator_ShouldImplementAbstractValidator()
        {
            var queryValidator = new QueryValidator();
            queryValidator.ShouldBeAssignableTo<AbstractValidator<Query>>();
        }

        [TestMethod]
        public void EmployeeValidator_ShouldImplementAbstractValidator()
        {
            var employeeValidator = new EmployeeValidator();
            employeeValidator.ShouldBeAssignableTo<AbstractValidator<Person>>();
        }


        [TestMethod]
        public void DependentValidator_ShouldImplementAbstractValidator()
        {
            var dependentValidator = new DependentValidator();
            dependentValidator.ShouldBeAssignableTo<AbstractValidator<Person>>();
        }

        [TestMethod]
        public void QueryValidator_ShouldHaveRules()
        {
            var queryValidator = new QueryValidator();
            queryValidator.ShouldHaveValidationErrorFor(v => v.Person, null as Person);
            queryValidator.ShouldHaveChildValidator(v => v.Person, typeof(EmployeeValidator));
        }

        [TestMethod]
        public void EmployeeValidator_ShouldHaveRules()
        {
            var employeeValidator = new EmployeeValidator();
            employeeValidator.ShouldHaveValidationErrorFor(v => v.FirstName, null as string);
            employeeValidator.ShouldHaveValidationErrorFor(v => v.PersonType, Domain.Enums.PersonType.Dependent);
            employeeValidator.ShouldHaveChildValidator(v => v.Dependents, typeof(DependentValidator));
        }

        [TestMethod]
        public void DependentValidator_ShouldHaveRules()
        {
            var dependentValidator = new DependentValidator();
            dependentValidator.ShouldHaveValidationErrorFor(v => v.FirstName, null as string);
            dependentValidator.ShouldHaveValidationErrorFor(v => v.PersonType, Domain.Enums.PersonType.Employee);
        }

        [TestMethod]
        public void Response_Exists()
        {
            var response = new Response();
        }

        [TestMethod]
        public void Response_ShouldHaveProperties()
        {
            var response = new Response();

            response.Employee.ShouldBeAssignableTo<Person>();
            response.PayrollAmount.ShouldBeAssignableTo<double>();
        }

        [TestMethod]
        public void QueryHandler_Exists()
        {
            var mockPreviewService = new Mock<ICalculationPreviewService>();

            var queryHandler = new PreviewCalculatorCalculateHandler(mockPreviewService.Object);
        }

        [TestMethod]
        public void QueryHandler_ImplementsIRequestHandler()
        {
            var mockPreviewService = new Mock<ICalculationPreviewService>();

            var queryHandler = new PreviewCalculatorCalculateHandler(mockPreviewService.Object);

            queryHandler.ShouldBeAssignableTo<IRequestHandler<Query, Response>>();
        }

        [TestMethod]
        public void QueryHandler_ShouldReturnResponse()
        {
            var query = new Query()
            {
                Person = new Person()
            };

            var mockPreviewService = new Mock<ICalculationPreviewService>();
            mockPreviewService.Setup(c => c.RunCalculation(It.IsAny<Person>())).Returns(query.Person);

            var queryHandler = new PreviewCalculatorCalculateHandler(mockPreviewService.Object);

            var response = queryHandler.Handle(query, new CancellationToken());

            //TODO Add more tests here
            response.Result.ShouldBeAssignableTo<Response>();
        }
    }
}
