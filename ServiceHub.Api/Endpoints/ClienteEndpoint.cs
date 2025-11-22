using MediatR;
using Microsoft.AspNetCore.Authorization;

using CriarClienteCommand = ServiceHub.Api.Application.UseCase.Cliente.CriarCliente.Command;
using AtualizarClienteCommand = ServiceHub.Api.Application.UseCase.Cliente.AtualizarCliente.Command;
using RemoverClienteCommand = ServiceHub.Api.Application.UseCase.Cliente.RemoverCliente.Command;


namespace ServiceHub.Api.Endpoints;

public static class ClienteEndpoint
{

    public static RouteGroupBuilder AddClienteEndpoint(this RouteGroupBuilder group)
    {

        group.MapPost("criar", async (CriarClienteCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Criar Cliente");
        
        group.MapPatch("atualizar", async (AtualizarClienteCommand command, ISender sender) =>
        {
            
            var result = await sender.Send(command);
            return result.Success ? Results.Ok() : Results.BadRequest(result);
            
        }).WithDescription("Atualizar Cliente");
        
        group.MapDelete("remover/{id}", async (string id, ISender sender) =>
        {
            var result = await sender.Send(new RemoverClienteCommand(id));
            return result.Success ? Results.Ok() : Results.BadRequest(result);
        }).WithDescription("Remover Cliente");

        group.RequireAuthorization();
        
        return group;
    }
}