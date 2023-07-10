using IEscola.Api.Filters;
using IEscola.Application.Interfaces;
using IEscola.Application.Services;
using IEscola.Domain.Interfaces;
using IEscola.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IEscola.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIEscolaServices(this IServiceCollection services, IConfiguration configuration)
        {
            //container de DI
            services.AddHttpContextAccessor();
            var settings = configuration.GetSection("Settings").Get<Settings>();
            services.Configure<Settings>(configuration.GetSection("Settings"));
            services.AddSingleton<ISettings, Settings>();
            services.AddScoped<ISettingsService, SettingsService>();

            //Services
            services.AddScoped<IDisciplinaService, DisciplinaService>();

            //Repositories
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();

            //Outros Objetos
            services.AddScoped<INotificador, Notificador>();

            //ActionFilter
            services.AddScoped<AuthorizationActionFilterAsyncAttribute>();

            //ANOTAÇÕES:
            //vida util dos objetos na memoria -> qd a aplicação subir
            //services.AddSingleton -> permite uma unica instancia da classe na memoria e perdura enquanto a app esta rodando
            //services.AddScoped -> permite uma instancia unica durante a requisição e qd retorna ela sai da memoria
            //services.AddTransient -> Uma instancia nova por chamada e não request
            //Singleton não pode ter dependencia para Scoped


            return services;
        }
    }
}
