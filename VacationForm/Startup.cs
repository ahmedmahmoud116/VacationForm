using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Data.DBContexts;
using Pomelo.EntityFrameworkCore.MySql;
using Service.Services;
using Service.Serv;
using Repository.RepositoryInterface;
using Repository.Repo;

namespace VacationForm
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
            string mySqlConnectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<VacationContext>(options => options.UseMySql(mySqlConnectionStr));
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>(); //when you ran up into IEmployeeService create EmployeeService
            services.AddScoped<IVacationRepository, VacationRepository>();
            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IEmployeeBalanceRepository, EmployeeBalanceRepository>();
            services.AddScoped<IEmployeeBalanceService, EmployeeBalanceService>();
            services.AddScoped<IEmployeeRequestRepository, EmployeeRequestRepository>();
            services.AddScoped<IEmployeeRequestService, EmployeeRequestService>();
            services.AddControllers();
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
