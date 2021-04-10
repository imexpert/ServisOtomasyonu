using Avr.Core.Security.Jwt;
using Avr.Core.Utilities.Exceptions;
using Avr.Core.Utilities.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Web.Extensions
{
    public static class StartupExtensionMethods
    {
        public static IServiceCollection AddServisOtomasyonuMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter<ServisOtomasyonuException>));
            })
                // Added for functional tests
                .AddNewtonsoftJson();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddRazorRuntimeCompilation();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
