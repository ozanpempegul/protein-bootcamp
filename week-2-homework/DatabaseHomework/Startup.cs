using DatabaseHomework.DbProvider;
using DatabaseHomework.Repository;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DatabaseHomework;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddSwaggerGen(c =>
        {
            c.CustomSchemaIds(p => p.FullName);
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "DatabaseHW API",
                    Version = "v1",
                    Contact = new OpenApiContact { Name = "DatabaseHW", }
                });
        });

        services.AddSingleton<IDapperDbProvider, DapperDbProvider>();
        services.AddSingleton<ICountryRepository, CountryRepository>();
        services.AddSingleton<IDepartmentRepository, DepartmentRepository>();

        services.AddEntityFrameworkNpgsql().AddDbContext<PatikaDbContext>(opt =>
            opt.UseNpgsql(Configuration.GetConnectionString("MyWebApiConnection")));
    }

    public static void Configure(IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ozan V1"));
        app.UseRouting();

        var option = new RewriteOptions();
        option.AddRedirect("^$", "swagger");
        app.UseRewriter(option);

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}

