using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            var shareControlHost = Configuration["GR8SHARECONTROL_SERVICE_HOST"];
            var traderControlHost = Configuration["GR8STOCKTRADER_SERVICE_HOST"];
            var transactionControlHost = Configuration["GR8STOCKTRANSACTION_SERVICE_HOST"];

            services.AddHttpClient("shareControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + shareControlHost + ":80/");

                c.DefaultRequestHeaders.Add("Accept", "application/json");

            });

            services.AddHttpClient("traderControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + traderControlHost + ":80/");

                c.DefaultRequestHeaders.Add("Accept", "application/json");

            });

            services.AddHttpClient("transactionControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + transactionControlHost + ":80/");

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
