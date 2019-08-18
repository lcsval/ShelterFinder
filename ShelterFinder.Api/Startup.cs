using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShelterFinder.Domain.Interfaces.Handlers;
using ShelterFinder.Domain.Interfaces.Infra;
using ShelterFinder.Domain.Interfaces.Repositories.Read;
using ShelterFinder.Domain.Interfaces.Repositories.Write;
using ShelterFinder.Handler.Handler;
using ShelterFinder.Infra.Repositories;
using ShelterFinder.Infra.Repositories.Read;
using ShelterFinder.Infra.Repositories.Write;

namespace ShelterFinder.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            Settings.ConnectionString = $"{Configuration["ConnectionString"]}";

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services
                .AddCors(options =>
                {
                    options.AddPolicy("AllowAll", corsBuilder.Build());
                })
                .AddMvc();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IShelterReadRepository, ShelterReadRepository>();
            services.AddTransient<IShelterWriteRepository, ShelterWriteRepository>();
            services.AddTransient<IShelterCommandHandler, ShelterCommandHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
