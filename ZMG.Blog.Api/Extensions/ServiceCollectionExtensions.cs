using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZMG.Blog.Core.Models.Configurations;

namespace ZMG.Blog.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddZmgBlogApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtConfiguration>(configuration.GetSection("Jwt"));
            
            return services;
        }
    }
}
