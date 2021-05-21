using AgendaMatic.Domain.Interfaces.Interactors;
using AgendaMatic.Domain.Interfaces.Managers;
using AgendaMatic.Domain.Interfaces.Persistence.Repositories;
using AgendaMatic.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace AgendaMatic.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<Startup>>();
            services.AddSingleton(typeof(ILogger), logger);
        
            services.AddScoped<IScheduleManager, ScheduleManager>();
            services.AddScoped<IUserManager, UserManager>();

            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddControllers();

            services.AddDbContext<ScheduleContext>(
                 options => options
                     .UseSqlServer(Configuration.GetConnectionString("Agenda"))
                     .EnableSensitiveDataLogging()
                     .EnableDetailedErrors()
            );

            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Agenda Api",
                    Version = "v1",
                    Description = "Api Agenda",
                    Contact = new OpenApiContact()
                    {
                        Name = "José Luis Saa",
                        Email = "jlsv@live.cl"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "Agenda Api");
                });
            }

            app.UseApiVersioning();

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
