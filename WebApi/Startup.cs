using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using ComponentRegistrar;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Mapping;
using WebApi.Validators;

namespace WebApi
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
            InstallAutomapper(services);
            services.AddServices(Configuration);
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    //options.SuppressModelStateInvalidFilter = true;
                })

                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(Controllers_CourseController));
                });
            
            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<LessonValidator>();
            });
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            
            // Add Cors
            services.AddCors(o => o.AddPolicy("Cors", builder =>
            {
                builder.WithOrigins("https://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("Cors");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            // HERE
            app.UseRequestLocalization(GetLocalizationOptions());
            app.UseRouting();

            app.UseAuthorization();
            if (!env.IsProduction())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
               
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
                });
            }
            app.UseMiddleware(typeof(Middleware.ErrorHandlingMiddleware));
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        
        private static IServiceCollection InstallAutomapper(IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
            return services;
        }
        
        private static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CourseMappingsProfile>();
                cfg.AddProfile<LessonMappingsProfile>();
                cfg.AddProfile<BusinessLogic.Services.Mapping.CourseMappingsProfile>();
                cfg.AddProfile<BusinessLogic.Services.Mapping.LessonMappingsProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
        
        private RequestLocalizationOptions GetLocalizationOptions()
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("ru-RU"),
                new CultureInfo("en-GB")
            };
            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("ru-RU"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            return options;
        }
    }
}