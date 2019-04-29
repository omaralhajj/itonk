using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using StockBroker.Models;

namespace StockBroker
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
            var shareControlHost = "gr8sharecontrol";
            var traderControlHost = "gr8tradercontrol";
            var transactionControlHost = "gr8transactioncontrol";

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddHttpClient("shareControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + shareControlHost);

                c.DefaultRequestHeaders.Add("Accept", "application/json");

            });

            services.AddHttpClient("traderControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + traderControlHost);

                c.DefaultRequestHeaders.Add("Accept", "application/json");

            });

            services.AddHttpClient("transactionControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + transactionControlHost);

                c.DefaultRequestHeaders.Add("Accept", "application/json");

            });

            //var connection = @"Server=(localdb)\mssqllocaldb;Database=gr8ShareControlDB;Trusted_Connection=True;ConnectRetryCount=0";
            //services.AddDbContext<DBmodel>
            //    (options => options.UseSqlServer(connection));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
