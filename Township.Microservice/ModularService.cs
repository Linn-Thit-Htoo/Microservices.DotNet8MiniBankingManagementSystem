using Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;
using Microsoft.EntityFrameworkCore;
using Township.Microservice.Features.Township;

namespace Township.Microservice
{
    public static class ModularService
    {
        public static IServiceCollection AddFeatures(this IServiceCollection services, WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            }, ServiceLifetime.Transient);

            services.AddScoped<DA_Township>();
            services.AddScoped<BL_Township>();
            builder.Services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            return services;
        }
    }
}
