﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poc.EmployeePayroll.Application.Common.Behaviors;
using Poc.EmployeePayroll.Application.Features.CalculatorPreview.Rules;
using System.Reflection;
using FluentValidation;

namespace Poc.EmployeePayroll.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddSingleton(typeof(CalculationPreviewRuleProvider), typeof(CalculationPreviewRuleProvider));

            return services;
        }
    }
}
