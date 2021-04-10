using Avr.ServisOtomasyonu.Web.CustomMiddlewares;
using Avr.ServisOtomasyonu.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Web
{
    public class Startup
    {
        public static string _apiUrl;

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _apiUrl = configuration.GetValue<string>("ApiUrl");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddServisOtomasyonuMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor session)
        {
            //SessionUser.SetContext(session);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(s =>
            {
                s.MapControllers();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });

            app.Use(async (context, next) =>
            {
                string clientIP = context.Connection.RemoteIpAddress?.ToString();

                var http = new HttpClient();

                if (context.Request.Path != "/" && !context.Request.Path.ToString().Contains("favicon") && !context.Request.Path.ToString().Contains("assets"))
                {
                    HttpRequestMessageFeature hreqmf = new HttpRequestMessageFeature(context);
                    HttpRequestMessage httpRequestMessage = hreqmf.HttpRequestMessage;
                    httpRequestMessage.RequestUri = new Uri(_apiUrl + context.Request.Path + context.Request.QueryString.Value);
                    httpRequestMessage.Headers.Add("X-Forwarded-For", clientIP);

                    try 
                    {
                        var response = await http.SendAsync(httpRequestMessage);
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            await context.Response.WriteAsync(result);
                        }
                        else
                        {
                            if (response.StatusCode == HttpStatusCode.NotFound)
                            {
                                context.Response.StatusCode = 404;
                                
                            }
                            else if (response.StatusCode == HttpStatusCode.InternalServerError)
                            {
                                context.Response.StatusCode = 500;
                            }
                            else if (response.StatusCode == HttpStatusCode.BadRequest)
                            {
                                context.Response.StatusCode = 400;
                            }

                            await context.Response.WriteAsync(response.ReasonPhrase);
                        }
                    }
                    catch (Exception ex)
                    {
                        context.Response.StatusCode = 404;
                        await context.Response.WriteAsync(ex.GetBaseException().Message);
                    }
                }
                else
                {
                    await next();
                }
            });
        }
    }
}
