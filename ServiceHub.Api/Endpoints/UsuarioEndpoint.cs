using MediatR;

namespace ServiceHub.Api.Endpoints;

using CriarUsuarioCommand = ServiceHub.Api.Application.UseCase.Usuario.CriarUsuario.Command;

public static class UsuarioEndpoint
{

    public static RouteGroupBuilder AddUsuarioEndpoint(this RouteGroupBuilder group)
    {

        group.MapPost("criar", async (CriarUsuarioCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);

            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Criar usuario");
        
        return group;
    }
    
}