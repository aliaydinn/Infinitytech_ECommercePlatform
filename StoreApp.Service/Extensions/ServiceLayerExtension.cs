using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StoreApp.Service.FluentValidation;
using StoreApp.Service.Services.Abstractions;
using StoreApp.Service.Services.Concretions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceLayerExtension( this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IOrderService, OrderService>();
            
            services.AddAutoMapper(assembly);

            services.AddValidatorsFromAssemblyContaining<ProductValidator>();
            return services;
        }


        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(opt =>
            {
                opt.LowercaseUrls = true;
            });
        }
    }
}
