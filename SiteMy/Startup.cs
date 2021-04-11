using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiteMy.Models;
using IdentityServer4.AccessTokenValidation;
using Bll.Services;
using Bll.Services.Contracts;
using Dal.Repositories.Contracts;
using Dal.Repositories;
using ExelImportUtil;

namespace SiteMy
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigin", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.WithMethods("GET", "PUT", "POST", "DELETE");
                    builder.AllowAnyHeader();
                });
            });

            services.AddMvc();
            services.AddControllers();
            services.AddHealthChecks();
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddTransient<IEpplusImportFile, EpplusImportFile>();
            services.AddTransient<IMobilePhoneService, MobilePhoneService>();

            services.AddControllersWithViews();

            services.AddTransient<SortingPhoneService>();
            services.AddControllersWithViews();

            services.AddTransient<IPlumbingService, PlumbingService>();
            services.AddControllersWithViews();

            services.AddScoped<IMobilePhoneRepositories, MobilePhoneRepositories>();

            services.AddScoped<IPlumbingRepositories, PlumbingRepositories>();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAllOrigin");
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
