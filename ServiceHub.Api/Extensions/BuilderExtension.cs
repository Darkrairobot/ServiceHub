using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
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
        
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        
        builder.Services.AddScoped<IVendaRepository, VendaRepository>();
        
        builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

        builder.Services.AddScoped<TokenService>();
        
        return builder;
    }

    public static WebApplicationBuilder AddInfrastructure(this WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });
        
        builder.Services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<Context>().AddSignInManager<SignInManager<ApplicationUser>>().AddUserManager<UserManager<ApplicationUser>>()
            .AddDefaultTokenProviders();
        
        builder.Services.AddEndpointsApiExplorer();
        
        builder.Services.AddSwaggerGen(options =>
        {
            
            options.CustomSchemaIds(type => type.FullName); 
            
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,  // Muda para ApiKey
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",  // Nome do header
                Description = "Cole o token JWT aqui. Exemplo: Bearer {seu_token}"
            });
            
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

            
        });
        
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = "ServiceHub.Api",
                    ValidAudience = "ServiceHub.Api",

                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

        builder.Services.AddAuthorization();

        builder.Services.AddCors(c => c.AddDefaultPolicy(c =>
        {
            c.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }));
        
        builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return builder;
    }
    
}