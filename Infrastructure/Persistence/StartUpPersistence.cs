using Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence
{
    public static class StartUpPersistence
    {
        /// <summary>
        /// Crea el contexto de la DB
        /// </summary>
        public static void CreateDbContext()
        {
            using (var client = new StarWarsDbContext())
            {
                client.Database.EnsureCreated();
            }
        }
        /// <summary>
        /// Agrega las dependencias relacionadas con la persistencia
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistenceDI(this IServiceCollection services)
        {
            // Persistencia
            services.AddScoped<StarWarsDbContext>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddEntityFrameworkSqlite().AddDbContext<StarWarsDbContext>();

            return services;
        }
    }
}
