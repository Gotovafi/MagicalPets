using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetApp.Core.ApplicationService;
using PetApp.Core.ApplicationService.Services;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using PetApp.Infrastructure.SQL;
using PetApp.Infrastructure.Static.Data;
using PetApp.Infrastructure.Static.Data.Repositories;
using System;

namespace Petweeb.UI.RestApi
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
            //services.AddDbContext<PetAppContext>(opt => opt.UseInMemoryDatabase("Db"));

            services.AddDbContext<PetAppContext>(opt => opt.UseSqlite("Data Source=MagicalPets.db"));

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();

            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<PetAppContext>(optionsAction: opt => opt.UseSqlite("Data Source=petApp.db"));
        }
        /*connection*/
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<PetAppContext>();
                    ctx.Database.EnsureCreated();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
