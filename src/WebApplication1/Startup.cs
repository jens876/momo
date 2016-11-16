using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            StaticProperties.m_hostingEnv = env;

            String ConnectionString;
            bool production= StaticProperties.m_hostingEnv.IsProduction();
            if(env.ContentRootPath.Contains("hem"))
            {
                production = false;
            }
            else
            {
                production = true;
            }
            if (!production)
            {
                ConnectionString = "server=localhost;user id=root;password=x;persistsecurityinfo=True;port=3306;Encrypt=false;";
            }
            else
            {
                ConnectionString = "server=172.30.86.135;user id=microcredit;password=M1crocred1t;persistsecurityinfo=True;port=3306;Encrypt=false;";
            }
            StaticProperties.m_mySqlConnection = new MySqlConnection(ConnectionString);
            StaticProperties.m_mySqlConnection.Open();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
			if (env.IsProduction())
			{
				loggerFactory.CreateLogger("Startup").LogCritical("Logging something.");
			}

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
