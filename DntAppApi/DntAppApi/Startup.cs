using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DntAppApi.core.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DntAppApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Need To Add For Configuration Of  Connection String With DbContext
            services.AddDbContext<MPContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Need To Add Service And implementation To Use In Our Application
            services.AddScoped<IProduct_Repository, Product_Repository>();

            // Need To Add For Cross Origin Resourse Sharing Calls
            services.AddCors(
                       options => {
                           options.AddPolicy(
                          "MAYUR", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
                       });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request                    //pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            // Need To Add For Cross Origin Resourse Sharing Calls
            app.UseCors("MAYUR");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
