using App.Apps;
using App.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceAtendimento;
using Domain.Interfaces.InterfaceEndereco;
using Domain.Interfaces.InterfaceEstado;
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacePessoaF;
using Domain.Interfaces.InterfacePessoaJ;
using Domain.Interfaces.InterfacesServices;
using Domain.Interfaces.InterfaceTelefone;
using Domain.Services;
using Infrastructure.Configs;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemAPP {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<ContextBase>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddSingleton<IOperador, RepositoryOperador>();
            services.AddSingleton<IAtendimento, RepositoryAtendimento>();
            services.AddSingleton<IFormulario, RepositoryFormulario>();
            services.AddSingleton<IEndereco, RepositoryEndereco>();
            services.AddSingleton<ITelefone, RepositoryTelefone>();
            services.AddSingleton<IEstado, RepositoryEstado>();
            services.AddSingleton<IPessoaF, RepositoryPessoaF>();
            services.AddSingleton<IPessoaJ, RepositoryPessoaJ>();


            services.AddSingleton<IAppOperador, AppOperador>();
            services.AddSingleton<IAppAtendimento, AppAtendimento>();
            services.AddSingleton<IAppFormulario, AppFormulario>();
            services.AddSingleton<IAppEstado, AppEstado>();
            services.AddSingleton<IAppEndereco, AppEndereco>();
            services.AddSingleton<IAppTelefone, AppTelefone>();
            services.AddSingleton<IAppPessoaF, AppPessoaF>();
            services.AddSingleton<IAppPessoaJ, AppPessoaJ>();


            services.AddSingleton<IServiceOperador, ServiceOperador>();
            services.AddSingleton<IServiceAtendimento, ServiceAtendimento>();
            services.AddSingleton<IServiceFormulario, ServiceFormulario>();
            services.AddSingleton<IServiceEstado, ServiceEstado>();
            services.AddSingleton<IServiceEndereco, ServiceEndereco>();
            services.AddSingleton<IServiceTelefone, ServiceTelefone>();
            services.AddSingleton<IServicePessoaF, ServicePessoaF>();
            services.AddSingleton<IServicePessoaJ, ServicePessoaJ>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
