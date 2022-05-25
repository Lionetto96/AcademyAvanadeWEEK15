using Avanade.Amazon.Core.BusinessLayers;
using Avanade.Amazon.Core.Cosmos.Repositories;
using Avanade.Amazon.Core.DataAccessLayers;
using Avanade.Amazon.Core.DataAccessLayers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Avanade.Amazon.Api
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
            //Registrazione delle dipendenze
            services.AddScoped<IBookRepository, EfBookRepository>();
            //services.AddScoped<IBookRepository, CosmosBookRepository>();
            services.AddScoped<MainBusinessLayer>();

            //Aggiunta dei controller
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
