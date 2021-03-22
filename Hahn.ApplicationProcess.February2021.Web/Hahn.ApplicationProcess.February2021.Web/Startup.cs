using Hahn.ApplicationProcess.February2021.Data.Extensions;
using Hahn.ApplicationProcess.February2021.Web.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Web.Schema;

namespace Hahn.ApplicationProcess.February2021.Web
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
            //adding the necessary methods and extensions to services
            services.AddControllers();
            services.AddCountryService();
            services.AddRepositoryPatternService();
            services.AddInMemoryDbContext();
            services.AddUnitOfWork();
            services.AddAssetProvider();
            services.AddAutoMapperConig();
            services.AddAutoMapper(typeof(Startup));
            //configure swagger with default values
            services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<SwashbuckleSchema>();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hahn.ApplicationProcess.February2021.Web", Version = "v1" });
            });
            //adding cors
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicationProcess.February2021.Web v1"));
            }
            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();
            //app.UseAuthorization();
            //allowing any resource to access the apis in production this has to change
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
