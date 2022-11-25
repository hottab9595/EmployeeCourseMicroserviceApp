using AutoMapper;
using Common.RabbitMQ.Core.Fanout.Consumer;
using Common.RabbitMQ.Core.Fanout.Publishing;
using Common.RabbitMQ.Interfaces;
using Common.RabbitMQ.Models.Fanout;
using EmployeeMicroservice.Db;
using LogMicroservice.Db.Core;
using LogMicroservice.Db.Interfaces;
using LogMicroservice.Sevices;
using LogMicroservice.Sevices.Core;
using LogMicroservice.Sevices.Interfaces;
using LogMicroservice.Sevices.Models.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LogMicroservice.Api
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

            services.AddScoped<ILogService, LogService>();

            var lol = Configuration.GetSection("RabbitMqLog");
            services.Configure<RabbitMqFanoutConfigurationModel>(Configuration.GetSection("RabbitMqLog"));
            services.AddSingleton<IRabbitMqSender<RabbitMqLogPublishModel>, RabbitMqFanoutSender<RabbitMqLogPublishModel>>();

            services.AddHostedService<RabbitMqFanoutConsumer>();
            

      
            services.AddSingleton(new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
