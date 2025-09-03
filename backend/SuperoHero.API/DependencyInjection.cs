using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHeroi.Application.Interfaces;
using SuperHeroi.Application.Services;
using SuperHeroi.Infra.Context;
using SuperHeroi.Infra.Interfaces;
using SuperHeroi.Infra.Repositories;
using System;

namespace SuperHeroi.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //CONTEXT
            services.AddDbContext<SuperHeroDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            // SERVICES
            services.AddScoped<ISuperHeroiService, SuperHeroiService>();
            services.AddScoped<ISuperPoderesService, SuperPoderesService>();
            // REPOSITORIES
            services.AddScoped<ISuperHeroiRepository, SuperHeroiRepository>();
            services.AddScoped<IHeroiSuperPoderesRepository, HeroiSuperPoderesRepository>();
            services.AddScoped<ISuperPoderesRepository, SuperPoderesRepository>(); 
    
            return services;
        }
    }
}
