using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using CGAP_API.Repository.Departamentos;
using CGAP_API.Repository.Perfis;
using CGAP_API.Repository.Products;
using CGAP_API.Repository.Salas;
using CGAP_API.Repository.Usuarios;
using CGAP_API.Settings;

namespace CGAP_API
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add framework services.
            services.AddMvc()
                    .AddJsonOptions(a => a.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver()); ;

            //using Dependency Injection
            services.AddSingleton<IProdutosRepository, ProdutosRepository>();
            services.AddSingleton<IDepartamentosRepository, DepartamentoRepository>();
            services.AddSingleton<IPerfisRepository, PerfisRepository>();
            services.AddSingleton<ISalaRepository, SalaRepository>();
            services.AddSingleton<IUsuariosRepository, UsuariosRepository>();
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod());
            });

            // Configure MyOptions using config by installing Microsoft.Extensions.Options.ConfigurationExtensions
            services.Configure<CustomSettings>(Configuration);

            // Configure MyOptions using code
            services.Configure<CustomSettings>(myOptions =>
            {
                myOptions.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors(builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                }
            );
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{ id?}");
            });

        }
    }
}
