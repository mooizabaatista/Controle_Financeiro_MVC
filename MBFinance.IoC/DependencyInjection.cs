using MBFinance.Application.Interfaces;
using MBFinance.Application.Services;
using MBFinance.Domain.Interfaces;
using MBFinance.Infra.Context;
using MBFinance.Infra.Repositories;
using MBFinance.Infra.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace MBFinance.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterApps(IServiceCollection services)
        {
            //Context
            services.AddScoped<ApplicationDbContext>();

            //Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            //Services
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();

            //UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
