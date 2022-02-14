using AutoMapper;
using Common.Middleware;
using EmployeeMicroservice.Db;
using EmployeeMicroservice.Db.Core;
using EmployeeMicroservice.Db.Interfaces;
using EmployeeMicroservice.Services.Helpers;
using EmployeeMicroservice.Services.Interfaces;
using EmployeeMicroservice.Services.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeMicroservice.Api
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
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddTransient<IContext, Context>();
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IUnitOfWork, ContextUnitOfWork>();

            services.Scan(scan => scan
                .FromAssemblyOf<ICrud<BaseModel>>()
                .AddClasses(classes => classes.AssignableTo<ICoreService>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            services.AddTransient<IUtils, Utils>();

            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Services.MappingProfile());
            }).CreateMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
