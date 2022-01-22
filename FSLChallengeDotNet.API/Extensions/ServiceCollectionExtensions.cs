using FSLChallengeDotNet.Core.Interfaces;
using FSLChallengeDotNet.Core.Services;
using FSLChallengeDotNet.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace FSLChallengeDotNet.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void Resolve(this IServiceCollection services)
        {
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IRepository, Repository>();
        }
    }
}
