using FSLChallengeDotNet.API.Constants;
using FSLChallengeDotNet.API.Extensions;
using FSLChallengeDotNet.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FSLChallengeDotNet.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext(Configuration.GetConnectionString(AppConstants.DATABASE_NAME));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(AppConstants.API_VERSION, new OpenApiInfo
                {
                    Title = AppConstants.SWAGGER_DOC_TITLE,
                    Version = AppConstants.API_VERSION
                });
            });

            services.Resolve();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "";
                    c.SwaggerEndpoint(AppConstants.SWAGGER_ENDPOINT_URL, AppConstants.SWAGGER_DOC_TITLE);
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
