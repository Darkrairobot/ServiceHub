using ServiceHub.Api.Endpoints;
using ServiceHub.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure().AddServices();

var app = builder.Build();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseResources();

app.MapGroup("v1/usuario").AddUsuarioEndpoint().WithTags("Usuario");

app.MapGroup("v1/cidade").AddCidadeEndpoint().WithTags("Cidade");

app.MapGroup("v1/auth").AddAuthEndpoint().WithTags("Auth");

app.MapGroup("v1/empresa").AddEmpresaEndpoint().WithTags("Empresa");

app.MapGroup("v1/cliente").AddClienteEndpoint().WithTags("Cliente");

app.MapGroup("v1/servico").AddServicoEndpoint().WithTags("Servico");

app.MapGroup("v1/venda").AddVendaEndpoint().WithTags("Venda");

app.MapGet("/",() => Results.Redirect("http://localhost:5199/swagger")).ExcludeFromDescription();

app.Run();
