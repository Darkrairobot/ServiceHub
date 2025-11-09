using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServiceHub.Api.Domain.Repository;
using ServiceHub.Api.Infrestructure;
using ServiceHub.Api.Infrestructure.Entity;
using ServiceHub.Api.Repository;
using ServiceHub.Api.Service;

namespace ServiceHub.Api.Extensions;

public static class BuilderExtension
{

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        
        builder.Services.AddScoped<ICidadeRepository, CidadeRepository>();

        builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();

        builder.Services.AddScoped<TokenService>();

        builder.Services.AddScoped<UsuarioService>();
        
        return builder;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders();
        
        builder.Services.AddOpenApi();
        
        builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return builder;
    }
    
}