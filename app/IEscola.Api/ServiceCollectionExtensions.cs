using IEscola.Application.Interfaces;
using IEscola.Application.Services;
using IEscola.Domain.Interfaces;
using IEscola.Infra.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEscola.Api
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIEscolaServices(this IServiceCollection services, IConfiguration configuration)
        {
            //container de DI
            services.AddScoped<IDisciplinaService, DisciplinaService>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();


            //vida util dos objetos na memoria -> qd a aplicação subir
            //services.AddSingleton -> permite uma unica instancia da classe na memoria
            //services.AddScoped -> permite uma instancia unica durante a requisição e qd retorna ela sai da memoria
            //services.AddTransient -> Uma instancia nova por chamada e não request
            //Singleton não pode ter dependencia para Scoped


            return services;
        }
    }
}
