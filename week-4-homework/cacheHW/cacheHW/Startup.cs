using cacheHW.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace cacheHW
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
            services.AddControllers();

            // add Filter
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ResponseGuidAttribute));
            });

            // services
            services.AddServicesDependencyInjection();
            services.AddContextDependencyInjection(Configuration);
            services.AddCustomizeSwagger();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1); // Remove Schema on Swagger UI
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Patika");
                c.DocumentTitle = "Patika";
            });

            // error handling 
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetail()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. App Level."
                        }.ToString());
                    }
                });
            });


            app.UseHttpsRedirection();


            // middleware 
            app.UseMiddleware<HeartbeatMiddleware>();
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


            // add services
            app.AddApplicationServiceDependencyInjection();
        }
    }
}
