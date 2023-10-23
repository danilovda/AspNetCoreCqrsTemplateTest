using Skeleton.Application.Common.Behaviors;
using Skeleton.Application.Common.Mapping;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Skeleton.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //The first method call will scan our Application assembly
        //and add all our Commands, Queries, and their respective handlers to the DI container.
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //The second method call is our ValidationBehavior registration step.
        //Without this, the validation pipeline would not execute at all.
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        //Next, we need to make sure to also add the validators that we implemented using FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddMappings();

        return services;
    }
}