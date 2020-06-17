using Microsoft.Extensions.DependencyInjection;
using Poc.EmployeePayroll.Application.Common.Interfaces;
using Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules;
using Poc.EmployeePayroll.Infrastructure.Factories;
using Poc.EmployeePayroll.Infrastructure.Services;

namespace Poc.EmployeePayroll.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton(typeof(ICalculationPreviewService), typeof(CalculationPreviewService));
            services.AddSingleton(typeof(IPersonFactory), typeof(PersonFactory));

            services.AddSingleton(typeof(IBusinessRule), typeof(EmployeeDeduction));
            services.AddSingleton(typeof(IBusinessRule), typeof(DependentDeduction));
            services.AddSingleton(typeof(IBusinessRule), typeof(ANameDiscount));

            return services;
        }
    }
}
