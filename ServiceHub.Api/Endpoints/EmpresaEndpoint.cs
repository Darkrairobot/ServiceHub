using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace ServiceHub.Api.Endpoints;

using CriarEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.CriarEmpresa.Command;
using AtualizarEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.AtualizarEmpresa.Command;
using RemoverEmpresaCommand = ServiceHub.Api.Application.UseCase.Empresa.RemoverEmpresa.Command;

public static class EmpresaEndpoint
{

    
    public static RouteGroupBuilder AddEmpresaEndpoint(this RouteGroupBuilder group)
    {
        
        group.MapPost("criar", async (CriarEmpresaCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Criar Empresa");

        group.MapPatch("atualizar", async (AtualizarEmpresaCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Atualizar Empresa");
        
        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverEmpresaCommand(id) );
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Remover Empresa");
        
        group.RequireAuthorization();
        
        return group;
    }
    
}