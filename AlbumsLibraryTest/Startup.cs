using AlbumsLibraryTest.BLL.Managers;
using AlbumsLibraryTest.BLL.Managers.Interfaces;
using AlbumsLibraryTest.BLL.Services.Managers;
using AlbumsLibraryTest.BLL.Services.Managers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlbumsLibraryTest
{
    public class Startup
    {
        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Ctor

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddTransient<IAlbumsCollectionManager, AlbumsCollectionManager>();
            services.AddTransient<IUsersCollectionManager, UsersCollectionManager>();

            services.AddTransient<IAlbumsManager, AlbumsManager>();
            services.AddTransient<IUsersManager, UsersManager>();

            services.AddHttpClient();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddXmlSerializerFormatters();
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
                policy.AllowCredentials();
            });

            app.UseHttpsRedirection();
            app.UseHttpsRedirection();
            app.UseMvc();
        }

        #endregion
    }
}
