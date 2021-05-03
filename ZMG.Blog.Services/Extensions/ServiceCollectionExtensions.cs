using Microsoft.Extensions.DependencyInjection;
using ZMG.Blog.Core.Interfaces.Services;
using ZMG.Blog.Services.Services;

namespace ZMG.Blog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register service into AspNet Core DI container.
        /// </summary>
        /// <param name="services">Service Collection instance</param>
        /// <returns>Service Collection instance with the services added</returns>
        public static IServiceCollection AddZmgBlogServices(this IServiceCollection services)
        {

            services.AddTransient<IPostService, PostService>();

            //services.AddAutoMapper(typeof(ServiceCollectionExtensions));

            return services;
        }
    }
}
