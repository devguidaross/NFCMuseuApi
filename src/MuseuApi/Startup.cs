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
using MuseuApi.Db;
using MuseuApi.Models;

namespace MuseuApi
{
    public class Startup
    {
        public static MuseuContext MuseuContext;
        
        public Startup(IConfiguration configuration)
        {
            MuseuContext = new MuseuContext(); 
            Configuration = configuration;
            ConnectionString = Configuration["ConnectionStrings:MuseuDbConnectionString"];
        }

        public IConfiguration Configuration { get; }
        public static string ConnectionString { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info()
                {
                    Version = "v1",
                    Title = "MuseuNFC Web Api",
                    Description = "",
                    TermsOfService = "None",
                    Contact = "guilherme.daros@outlook.com"
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
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}