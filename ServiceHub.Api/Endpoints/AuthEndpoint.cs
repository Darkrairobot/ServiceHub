using MediatR;

namespace ServiceHub.Api.Endpoints;

using RealizarLoginCommand = ServiceHub.Api.Application.UseCase.Usuario.RealizarLogin.Command;

public static class AuthEndpoint
{

    public static RouteGroupBuilder AddAuthEndpoint(this RouteGroupBuilder group)
    {

        group.MapPost("logar", async (RealizarLoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok(result) : Results.BadRequest(result);
        });

        return group;
    }
    
    
}