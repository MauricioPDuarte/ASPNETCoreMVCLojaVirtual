using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LojaVirtual
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Permite que, ao utilizar o HTTPS(porta:443), seja redirecionado para o nosso projeto.
            app.UseHttpsRedirection();

            // Define os arquivos defaults(index.html) para inciar antes de carregar os arquivos estáticos.
            app.UseDefaultFiles();
            
            // Permite a utilização dos arqivos estáticos.
            app.UseStaticFiles();
            
            app.UseRouting();
            app.UseAuthorization();


            /*
             * https://www.site.com.br -> Qual controlador? (Gestão) -> Rotas 
             * https://www.site.com.br/Produto/Visualizar/MouseRazorZk
             * https://www.site.com.br/Produto/Visualizar/10
             *
             */

            // Padrão do MVC para lidar com as rotas e parâmetros para acessar os controllers(classes).
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
