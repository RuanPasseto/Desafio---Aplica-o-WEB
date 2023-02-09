using ControleDeContatos.Data;
using Desafio___Aplicação_WEB.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Desafio___Aplicação_WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration= configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddScoped<IContatosRepositorio, ContatosRepositorio>();
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

        }
    }
}
