using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SnackJobs.Api.Tiers.Business.Abstract;
using SnackJobs.Api.Tiers.Business.Concrete;
using SnackJobs.Api.Tiers.Core.Users;
using SnackJobs.Api.Tiers.Data;
using SnackJobs.Api.Tiers.Data.Abstract;
using SnackJobs.Api.Tiers.Data.Concrete;

namespace SnackJobs.Api
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
            



            var inst = new Installer();
            inst.InstallDb(services, Configuration);
            inst.MvcInstaller(services, Configuration);
            inst.InstallSwagger(services, Configuration);

            services.AddScoped<IRefreshTokenDal, RefreshTokenDal>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICustomIdentityManager, CustomIdentityManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, UserDal>();

            services.AddScoped<IGivenApplicationService, GivenApplicationManager>();
            services.AddScoped<IGivenApplicationDal, GivenApplicationDal>();

            services.AddScoped<IDoneApplicationService, DoneApplicationManager>();
            services.AddScoped<IDoneApplicationDal, DoneApplicationDal>();

            

            services.AddScoped<ILocationService, LocationManager>();
            services.AddScoped<ILocationDal, LocationDal>();
            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();


            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });
            app.UseMvc();
        }
    }
}
