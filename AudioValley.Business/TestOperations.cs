using AudioValley.Business.Operations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AudioValley.Business
{
    public  static class TestOperations
    {
        public static IServiceCollection AddOperationExtensions(this IServiceCollection services)
        {
            services.AddScoped<AdressOperations>();

            services.AddScoped<ContactOperations>();

            return services;
        }

        public static IServiceCollection AddServiceExtensions(this IServiceCollection services)
        {
           

            return services;
        }
    }
}
