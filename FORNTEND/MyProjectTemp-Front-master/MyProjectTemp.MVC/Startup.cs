using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MyProjectTemp.MVC.Services;

namespace Asp_net_Core_Project_with_Admin_Template_Setup
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Configura un cliente HttpClient para toda la aplicación
            services.AddHttpClient("API Client", client =>
            {
                client.BaseAddress = new Uri("https://localhost/MyProjectTempApi/Api/");
                // Configura aquí otros aspectos del cliente, como headers si es necesario
            });

            // Registra ApiService para inyección de dependencias
            services.AddScoped<ApiService>(serviceProvider =>
            {
                // Obtiene la fábrica de HttpClient
                var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
                // Crea un cliente HttpClient utilizando el nombre configurado anteriormente
                var httpClient = httpClientFactory.CreateClient("API Client");

                // Retorna una nueva instancia de ApiService utilizando el HttpClient configurado
                return new ApiService(httpClient);
            });

            // Asegúrate de registrar aquí otros servicios necesarios para tu aplicación
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
