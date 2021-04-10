using Autofac;
using Avr.ServisOtomasyonu.Api.Extensions;
using Avr.ServisOtomasyonu.Api.Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddYazismaMvc()
                .AddServisOtomasyonDbContext(Configuration)
                .AddYazismaSwagger(Configuration)
                .AddCustomConfiguration(Configuration)
                .AddCustomAuthentication(Configuration)
                .AddAutoMapperConfiguration();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                    builder => builder.WithOrigins("http://localhost:56512"));
            });

            services.AddAutoMapper(typeof(Startup));
        }

        public void ConfigureContainer(Autofac.ContainerBuilder builder)
        {
            builder.RegisterModule(new ApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ConfigureExceptionHandler();

            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Servis Otomasyonu API");
                s.OAuthClientId("cleint-id");
                s.OAuthClientSecret("client-secret");
                s.OAuthRealm("client-realm");
                s.OAuthAppName("OAuth-app");
                s.EnableFilter();
                s.EnableDeepLinking();
                s.MaxDisplayedTags(5);
                s.ShowExtensions();
                s.ShowCommonExtensions();
                s.EnableValidator();
                s.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });

            app.UseCors("AllowOrigin");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(s =>
            {
                s.MapControllers();
            });
        }
    }
}
