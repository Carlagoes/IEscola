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

            //Services
            services.AddScoped<IDisciplinaService, DisciplinaService>();

            //Repositories
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();

            //Outros Objetos
            services.AddScoped<INotificador, Notificador>();


            //vida util dos objetos na memoria -> qd a aplicação subir
            //services.AddSingleton -> permite uma unica instancia da classe na memoria e perdura enquanto a app esta rodando
            //services.AddScoped -> permite uma instancia unica durante a requisição e qd retorna ela sai da memoria
            //services.AddTransient -> Uma instancia nova por chamada e não request
            //Singleton não pode ter dependencia para Scoped


            return services;
        }
    }
}
