using HiL_Store.Domain.Entities;
using HiL_Store.Domain.Entities.StoreEntities;
using HiL_Store.Domain.Interfaces.Authentication;
using HiL_Store.Domain.Interfaces.CreationService;
using HiL_Store.Domain.Interfaces.Repository;
using HiL_Store.Domain.Services.Authentication;
using HiL_Store.Domain.Services.CreationService;
using HiL_Store.EF.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiL_Store.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {

                services.AddSingleton<IPasswordHasher, PasswordHasher>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<ICategoryCreationService, CategoryCreationService>();
                services.AddSingleton<IProductCreationService, ProductCreationService>();

                services.AddSingleton<IGenericDataService<Account>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();
                services.AddSingleton<IGenericDataService<Category>, CategoryDataService>();
                services.AddSingleton<ICategoryService, CategoryDataService>();
                services.AddSingleton<IGenericDataService<Product>, ProductDataService>();
                services.AddSingleton<IProductService, ProductDataService>();
                services.AddSingleton<IGenericDataService<CategoryProduct>, CategoryProductDataService>();
                services.AddSingleton<ICategoryProductService, CategoryProductDataService>();

            });

            return host;
        }
    }
}
