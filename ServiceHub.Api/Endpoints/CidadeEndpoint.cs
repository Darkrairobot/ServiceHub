using MediatR;

namespace ServiceHub.Api.Endpoints;

using CriarCidadeCommand = ServiceHub.Api.Application.UseCase.Cidade.CriarCidade.Command;

public static class CidadeEndpoint
{

    public static RouteGroupBuilder AddCidadeEndpoint(this RouteGroupBuilder group)
    {

        group.MapPost("criar", async (CriarCidadeCommand command, ISender sender) =>
        {
            
            var result = await sender.Send(command);
            
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        });
        
        return group;
    }
    
}