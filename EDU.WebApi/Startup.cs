using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDU.Application.Boundaries.GetUser;
using EDU.Application.UseCases;
using EDU.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentMediator;
using EDU.WebApi.Controllers;
using EDU.Domain.Users;
using EDU.Infrastructure.Repositories;
using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using EDU.Application.UseCases.Departments;
using EDU.WebApi.Presenters;
using EDU.Domain.Repositories;
using EDU.Application;

namespace EDU.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services
                .AddUseCases()
                .AddRepositories()
                .AddPresenters()
                .AddServices(Configuration);

            // TODO: separate to infrastructure
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services
                .AddHttpContextAccessor()
                .AddControllers()
                .AddControllersAsServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
