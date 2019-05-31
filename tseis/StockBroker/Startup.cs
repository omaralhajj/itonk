using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
			
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
