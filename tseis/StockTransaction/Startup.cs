﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StockTransaction.Context;

namespace StockTransaction
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
            var taxControlHost = Configuration["GR8TAXCONTROL_SERVICE_HOST"];
            services.AddHttpClient("taxControl", c =>
            {
                //Remark below not using https but http
                c.BaseAddress = new Uri("http://" + taxControlHost + ":80/");

                c.DefaultRequestHeaders.Add("Accept", "application/json");

            });

            var host = "gr8transactiondb";
            services.AddDbContext<TransactionsControllerContext>(opt =>
                opt.UseSqlServer("Data Source=" + host + "; User ID=SA; Password=F19ItOnk; Connect Timeout=30; Encrypt=False; TrustServerCertificate=False; ApplicationIntent=ReadWrite; MultiSubnetFailover=False"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TransactionsControllerContext db)
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
            db.Database.Migrate();
			app.UseHttpsRedirection();
			app.UseMvc();
        }
    }
}
