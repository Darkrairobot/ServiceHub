using Microsoft.AspNetCore.Authentication.JwtBearer;
using ServiceHub.Api.Endpoints;
using ServiceHub.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure().AddServices();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddAuthorization();

builder.Services.AddCors(c => c.AddDefaultPolicy(c =>
{
    c.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));


var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseResources();

app.MapGroup("v1/usuario").AddUsuarioEndpoint().WithTags("public");

app.MapGroup("v1/cidade").AddCidadeEndpoint().WithTags("public");

app.MapGroup("v1/auth").AddAuthEndpoint().WithTags("public");

app.MapGroup("v1/empresa").AddEmpresaEndpoint().WithTags("public");

app.Run();
