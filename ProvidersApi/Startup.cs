using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProviderApi.Services;
using System.Net.Http;
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;

namespace ProviderApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProviderManager, ProviderManager>();

            services.AddDistributedSqlServerCache(options => {
                options.ConnectionString = Configuration.GetConnectionString("providerCache");
                options.SchemaName = "dbo";
                options.TableName = "providerCache";

                options.DefaultSlidingExpiration = TimeSpan.FromDays(32);
                options.ExpiredItemsDeletionInterval = TimeSpan.FromDays(1);
            });

            services.AddScoped<IExternalProviderService, ExternalProviderService>(sp =>
            {
                var providerUri = new System.Uri(@"https://api.cqc.org.uk/public");

                var httpClient = new HttpClient();
                httpClient.BaseAddress = providerUri;

                return new ExternalProviderService(httpClient);
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.DateFormatString =  "yyyy-MM-dd" );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Providers", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProvidersApi v1"));
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
