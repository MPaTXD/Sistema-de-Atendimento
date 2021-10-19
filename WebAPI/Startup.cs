using App.Apps;
using App.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfaceAtendimento;
using Domain.Interfaces.InterfaceFormulario;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Domain.ViewModel.Atendimento;
using Domain.ViewModel.Ordem;
using Entites.Entites;
using Entites.ViewModel;
using Infrastructure.Configs;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<ContextBase>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Ordem, ViewModelBaseOrdem>();
                cfg.CreateMap<Funcionario, ViewModelBaseFuncionario>();
                cfg.CreateMap<Atendimento, ViewModelBaseAtendimento>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // INTERFACE E REPOSITORY
            services.AddSingleton(typeof(IGeneric<>), typeof(RepositoryGeneric<>));
            services.AddSingleton<IFuncionario, RepositoryFuncionario>();
            services.AddSingleton<IOrdem, RepositoryOrdem>();
            services.AddSingleton<IAtendimento, RepositoryAtendimento>();

            // SERVIÇOS INTERFACE
            services.AddSingleton<IServiceFuncionario, ServiceFuncionario>();
            services.AddSingleton<IServiceOrdem, ServiceOrdem>();
            services.AddSingleton<IServiceAtendimento, ServiceAtendimento>();

            // INTERFACE APP
            services.AddSingleton<IAppFuncionario, AppFuncionario>();
            services.AddSingleton<IAppOrdem, AppOrdem>();
            services.AddSingleton<IAppAtendimento, AppAtendimento>();

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
