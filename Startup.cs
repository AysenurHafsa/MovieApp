using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;



namespace MovieApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //MVC yapısını projeye dahil ediyoruz
            services.AddRazorPages();
            //hata aldık ve bu satırı ekledik
                services.AddMvc().AddMvcOptions(x => x.EnableEndpointRouting = false);
                services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); // wwwroot klasöründekiler dışarıya açılmış oldu.
                            // wwwroot => /scc/style.css        /img/1.jpg

            app.UseStaticFiles(new StaticFileOptions{
               FileProvider = new PhysicalFileProvider(Path.Combine
               (Directory.GetCurrentDirectory(),"node_modules")),
                RequestPath="/modules"
            });
            // modules/bootstrap/dist/scc/bootstrap.min.css   klosörünü dışarı açıyor.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });*/

            //home /index/3
            app.UseMvcWithDefaultRoute();
           app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}" );
            });

        }
    }
}
