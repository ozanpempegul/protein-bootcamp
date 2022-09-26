using AutoMapper;
using cacheHW.Data;
using cacheHW.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace cacheHW
{
    public static class ExtensionAddServices
    {


        public static void AddContextDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            // db  sql server or posgre
            var dbtype = Configuration.GetConnectionString("DbType");
            if (dbtype == "SQL")
            {
                var dbConfig = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConfig)
                   );
            }
        }
        public static void AddServicesDependencyInjection(this IServiceCollection services)
        {

            // add services
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();


            // uow
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());


            // services
            services.AddSingleton<SingletonService>();
            services.AddScoped<ScopedService>();
            services.AddTransient<TransientService>();
        }

        public static void AddCustomizeSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Protein Cache Api Management", Version = "v1.0" });
                c.OperationFilter<ExtensionSwaggerFileOperationFilter>();

            });
        }

    }
}
