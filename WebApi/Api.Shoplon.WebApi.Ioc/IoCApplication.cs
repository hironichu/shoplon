using Api.Shoplon.Business.Service;
using Api.Shoplon.Business.Service.Contract;
using Api.Shoplon.Data.Context;
using Api.Shoplon.Data.Context.Contract;
using Api.Shoplon.Data.Repository;
using Api.Shoplon.Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Api.Shoplon.Ioc
{
    public static class IoCApplication
    {
        /// <summary>
        /// Configuration de l'injection des repository du Web API RestFul
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Repositories

            services.AddScoped<IRepositoryClient, RepositoryClient>();
            services.AddScoped<IRepositoryProduct, RepositoryProduct>();
            services.AddScoped<IRepositoryContact, RepositoryContact>();
            services.AddScoped<IRepositoryOrder, RepositoryOrder>();
            services.AddScoped<IRepositoryOrderLine, RepositoryOrderLine>();
            services.AddScoped<IRepositoryPayment, RepositoryPayment>();
            services.AddScoped<IRepositoryCartLine, RepositoryCartLine>();
            return services;
        }


        /// <summary>
        /// Configure l'injection des services
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Service

            services.AddScoped<IServiceClient, ServiceClient>();
            //services.AddScoped<IServiceClient, ServiceClient>();
            return services;
        }

        /// <summary>
        /// Configuration de la connexion de la base de données
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            services.AddDbContext<IShoplonContext, ShoplonDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());

            return services;
        }

    }
}

