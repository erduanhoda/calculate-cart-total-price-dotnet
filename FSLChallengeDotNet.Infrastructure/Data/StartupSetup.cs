using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace FSLChallengeDotNet.Infrastructure.Data
{
    public static class StartupSetup
    {
        public static void AddDbContext(this IServiceCollection services, string connecitonString)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connecitonString));
        }
    }
}
