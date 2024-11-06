using DogMateCleanArch.Domain.Repository;
using DogMateCleanArch.Infra.Data;
using DogMateCleanArch.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DogMateCleanArch.Infra;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PostDbContext>(options =>
        
            options.UseMySQL(configuration.GetConnectionString("PostDbContext") ??
                             throw new InvalidOperationException("Connecting string PostDbConnection not found"))
            );
        
        services.AddTransient<IPostRepository, PostRepository>();
        return services;
    }
}