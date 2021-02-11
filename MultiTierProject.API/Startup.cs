using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultiTierProject.API.Extension;
using MultiTierProject.API.Filters;
using MultiTierProject.Core.Intefaceses.Repositories;
using MultiTierProject.Core.Intefaceses.Services;
using MultiTierProject.Core.Intefaceses.UnitOfWorks;
using MultiTierProject.Data;
using MultiTierProject.Data.Repositories;
using MultiTierProject.Data.UnitOfWorks;
using MultiTierProject.Service.Services;

namespace MultiTierProject.API
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
            services.AddDbContext<MultiTierDbContext>(options => {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("MultiTierProject.Data");
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(); 
            services.AddScoped(typeof(NotFoundFilter<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddControllers();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptio();

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
