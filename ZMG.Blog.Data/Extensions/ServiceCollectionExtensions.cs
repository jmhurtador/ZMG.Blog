using Microsoft.Extensions.DependencyInjection;
using ZMG.Blog.Core.Interfaces.Repositories;
using ZMG.Blog.Data.Repositories;

namespace ZMG.Blog.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register service into AspNet Core DI container.
        /// </summary>
        /// <param name="services">Service Collection instance</param>
        /// <returns>Service Collection instance with the services added</returns>
        public static IServiceCollection AddZmgBlogDataServices(this IServiceCollection services)
        {
            services.AddTransient<IPostRepository, PostRepository>();

            return services;
        }
    }
}
