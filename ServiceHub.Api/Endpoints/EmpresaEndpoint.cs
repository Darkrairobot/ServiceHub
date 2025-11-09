using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ServiceHub.Api.Endpoints;

using CriarEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.CriarEmpresa.Command;

public static class EmpresaEndpoint
{

    
    public static RouteGroupBuilder AddEmpresaEndpoint(this RouteGroupBuilder group)
    {
        
        group.MapPost("criar", [Authorize] async (CriarEmpresaCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        });

        return group;
    }
    
}