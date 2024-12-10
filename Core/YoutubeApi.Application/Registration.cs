using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using YoutubeApi.Application.Exceptions;
using FluentValidation;
using System.Globalization;
using MediatR;
using YoutubeApi.Application.Behaviors;


namespace YoutubeApi.Application
{
    public static class Registration
    {

        public static void AddApplication(this IServiceCollection services)
        {

            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
        }
    }
}
